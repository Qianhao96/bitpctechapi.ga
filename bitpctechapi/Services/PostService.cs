using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using bitpctechapi.Data;
using bitpctechapi.Domain;

namespace bitpctechapi.Services
{
    public class PostService : IPostService
    {
        private readonly DataContext _dataContext;

        public PostService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Post> GetPostByIdAsync(Guid postId)
        {
            return await _dataContext.Posts.SingleOrDefaultAsync(x => x.Id == postId);
        }

        public async Task<List<Post>> GetPostsAsync()
        {
            return await _dataContext.Posts.ToListAsync();
        }

        public async Task<bool> UpdatePostAsync(Post postToUpdate)
        {
            //var exists = await GetPostByIdAsync(postToUpdate.Id) != null;

            var post = _dataContext.Posts.Select(po => new { po.Id, po.Name}).Where(pot => pot.Id == postToUpdate.Id);
            if (post != null)
            {
                _dataContext.Posts.Update(postToUpdate);
                var updated = await _dataContext.SaveChangesAsync();

                return updated > 0;
            }
            return false;
        }

        public async Task<bool> DeletePostAsync(Guid postId)
        {
            var post = await GetPostByIdAsync(postId);
            _dataContext.Posts.Remove(post);

            var deleted = await _dataContext.SaveChangesAsync();
            return deleted > 0;
        }

        public async Task<bool> CreatePostAsync(Post post)
        {
            await _dataContext.Posts.AddAsync(post);

            var created = await _dataContext.SaveChangesAsync();
            return created > 0;
        }
    }
}

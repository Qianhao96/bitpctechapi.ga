using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bitpctechapi.Contracts
{
    public class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "V1";
        public const string Base = Root + "/" + Version;
        public static class Posts
        {
            public const string GetAll = Base + "/posts";
            public const string Get = Base + "/posts/{postId}";
            public const string Update = Base + "/update/{postId}";
            public const string Delete = Base + "/delete/{postId}";
            public const string Create = Base + "/posts";
        }

        public static class Identity
        {
            public const string Login = Base + "/identity/login";
            public const string Register = Base + "/identity/register";
        }

        public static class AdminPcParts
        {
            public const string AddPart = Base + "/admin/pcpart";
            public const string GetPartAll = Base + "/admin/pcpart";
            public const string AddBrand = Base + "/admin/brand";
            public const string AddCategory = Base + "/admin/category";
            public const string AddSpecification = Base + "/admin/specification";
        }
    }
}

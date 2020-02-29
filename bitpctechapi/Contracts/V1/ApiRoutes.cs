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
            public const string GetPartById = Base + "/admin/pcpart/{pcPartId}";
            public const string DeletePartById = Base + "/admin/pcpart/{pcPartId}";
            public const string AddImages = Base + "/admin/images";
            public const string GetImagesAll = Base + "/admin/images";
            public const string GetImageById = Base + "/admin/images/{imageId}";
            public const string DeleteImageById = Base + "/admin/images/{imageId}";
            public const string AddBrand = Base + "/admin/brand";
            public const string GetBrandAll = Base + "/admin/brand";
            public const string GetBrandById = Base + "/admin/brand/{brandId}";
            public const string DeleteBrandById = Base + "/admin/brand/{brandId}";
            public const string AddCategory = Base + "/admin/category";
            public const string GetCategoryAll = Base + "/admin/category";
            public const string GetCategoryById = Base + "/admin/category/{categoryId}";
            public const string DeleteCategoryById = Base + "/admin/category/{categoryId}";
            public const string AddSpecification = Base + "/admin/specification";
            public const string GetSpecificationAll = Base + "/admin/specification";
            public const string GetSpecificationById = Base + "/admin/specification/{specificationId}";
            public const string DeleteSpecificationById = Base + "/admin/specification/{specificationId}";
        }
        public static class Catalog
        {
            public const string GetProductsByCategoryAndBrand = Base + "/catalog/product/{categoryId}/{brandId}";
            public const string GetAllCategory = Base + "/catalog/category";
            public const string GetAllBrand = Base + "/catalog/brand";
            public const string GetImagesByPcpartId = Base + "/catalog/images/{pcpartId}";
        }

    }
}

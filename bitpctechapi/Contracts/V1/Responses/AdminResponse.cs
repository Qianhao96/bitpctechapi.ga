﻿using bitpctechapi.Domain;

namespace bitpctechapi.Contracts.V1.Responses
{
    public class AdminGetAllPcPartResponse
    {
        public PcPart[] PcParts { get; set; }
    }

    public class AdminGetAllBrandResponse
    {
        public Brand[] Brands { get; set; }
    }

    public class AdminGetAllSpecificationResponse
    {
        public Specification[] Specifications { get; set; }
    }

    public class AdminGetAllCategoryResponse
    {
        public Category[] Categories { get; set; }
    }

    public class AdminGetAllImagesResponse
    {
        public Images[] Images { get; set; }
    }

    public class AdminAddOrDeleteResponse
    {
        public string Message { get; set; }
    }
}

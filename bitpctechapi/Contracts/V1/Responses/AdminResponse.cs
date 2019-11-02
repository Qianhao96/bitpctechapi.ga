using bitpctechapi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bitpctechapi.Contracts.V1.Responses
{
    public class AdminGetAllPcPartResponse
    {
        public PcPart[] PcParts { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthResource.API.Initializers
{
    public class AudienceModel {
        public string Secret { get; set; }
        public string Iss { get; set; }
        public string Aud { get; set; }

    }
}

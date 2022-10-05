using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuddlesNextGen.Application.Utility
{
    public class AzureStorage
    { 
        public string BucketName { get; set; }
        public string AzureAccessKey { get; set; }
        public string AzureSecretKey { get; set; }
    }
}

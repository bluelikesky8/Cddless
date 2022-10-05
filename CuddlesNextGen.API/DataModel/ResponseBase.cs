using CuddlesNextGen.Application.Utility;
using PARSNextGen.Application.Utility;
using System.Runtime.Serialization;

namespace CuddlesNextGen.API.DataModel
{
    [DataContract]
    public class ResponseBase<T>
    {
        public ResponseBase()
        {
            IsSuccessful = true;
        }

        [DataMember]
        public T Data { get; set; }

        [DataMember]
        public bool IsSuccessful { get; set; }

        [DataMember]
        public CustomMessage MessageDetail { get; set; }

    }
}

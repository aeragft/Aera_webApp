
using System.Runtime.Serialization;

namespace AeraStore_WebApp.Models
{
    [DataContract]
    public class BaseModel
    {
        [DataMember]
        public int Id { get; protected set; }
    }
}

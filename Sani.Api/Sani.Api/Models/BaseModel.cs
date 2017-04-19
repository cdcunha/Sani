using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System.Runtime.Serialization;

namespace Sani.Api.Models
{
    [DataContract]
    public class BaseModel
    {
        [DataMember]
        [BsonId(IdGenerator = typeof(GuidGenerator))]
        public System.Guid Id { get; set; }

        [DataMember]
        [BsonRepresentation(BsonType.Boolean)]
        public bool Ativo { get; set; }

        [DataMember]
        [BsonDateTimeOptions(Kind = System.DateTimeKind.Local)]
        public System.DateTime DataCriacao { get; set; }

        [DataMember]
        [BsonDateTimeOptions(Kind = System.DateTimeKind.Local)]
        public System.DateTime? DataAlteracao { get; set; }

        public BaseModel()
        {
            Ativo = true;
            DataCriacao = System.DateTime.Now;
        }
    }
}

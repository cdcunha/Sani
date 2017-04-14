using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Sani.Api.Models
{
    [DataContract]
    public class Voluntario
    {
        [DataMember]
        [BsonId(IdGenerator = typeof(GuidGenerator))]
        public System.Guid Id { get; set; }

        [DataMember]
        [BsonElement]
        [BsonRequired]
        public string Nome { get; set; }

        [DataMember]
        [BsonElement]
        [BsonRepresentation(BsonType.Boolean)]
        public bool Ativo { get; set; }

        [DataMember]
        [BsonElement]
        [BsonDateTimeOptions(Kind = System.DateTimeKind.Local)]
        public System.DateTime DataCriacao { get; set; }

        [DataMember]
        [BsonElement]
        [BsonDateTimeOptions(Kind = System.DateTimeKind.Local)]
        public System.DateTime? DataAlteracao { get; set; }

        [BsonConstructor]
        public Voluntario(string nome)
        {
            Nome = nome;
            DataCriacao = System.DateTime.Now;
        }
    }
}

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using Sani.Api.Notifications;
using System.Runtime.Serialization;

namespace Sani.Api.Models
{
    [DataContract]
    public class Voluntario
    {
        [DataMember]
        [BsonId(IdGenerator = typeof(GuidGenerator))]
        public System.Guid Id { get; set; }

        [DataMember]
        //[BsonElement] Usado para atributos somente leitura
        [BsonRequired]
        public string Nome { get; set; }

        [DataMember]
        [BsonRepresentation(BsonType.Boolean)]
        public bool Ativo { get; set; }

        [DataMember]
        [BsonDateTimeOptions(Kind = System.DateTimeKind.Local)]
        public System.DateTime DataCriacao { get; set; }

        [DataMember]
        [BsonDateTimeOptions(Kind = System.DateTimeKind.Local)]
        public System.DateTime? DataAlteracao { get; set; }

        [BsonConstructor]
        public Voluntario(string nome)
        {
            Nome = nome;
            Ativo = true;
            DataCriacao = System.DateTime.Now;
        }
    }
}

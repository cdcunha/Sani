using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using Sani.Api.Notifications;
using System.Runtime.Serialization;

namespace Sani.Api.Models
{
    [DataContract]
    public class Apoiado
    {
        [DataMember]
        [BsonId (IdGenerator = typeof(GuidGenerator))]
        public System.Guid Id { get; set; }

        [DataMember]
        //[BsonElement] Usado para atributos somente leitura
        [BsonRequired]
        public string Nome { get; set; }

        [DataMember]
        public string Logradouro { get; set; }

        [DataMember]
        public string Numero { get; set; }

        [DataMember]
        public string Complemento { get; set; }

        [DataMember]
        public string Bairro { get; set; }

        [DataMember]
        public string Cidade { get; set; }

        [DataMember]
        public string Uf { get; set; }

        [DataMember]
        public string EstadoCivil { get; set; }

        [DataMember]
        [BsonRepresentation(BsonType.Int32)]
        public int QtdeDependentes { get; set; }

        [DataMember]
        [BsonDateTimeOptions(DateOnly = true, Kind = System.DateTimeKind.Local)]
        public System.DateTime? DataNascimento { get; set; }

        [DataMember]
        [BsonRepresentation(BsonType.Boolean)]
        public bool Ativo { get; set; }

        [DataMember]
        [BsonDateTimeOptions(Kind = System.DateTimeKind.Local)]
        public System.DateTime DataCriacao { get; set; }

        [DataMember]
        [BsonDateTimeOptions(Kind = System.DateTimeKind.Local)]
        public System.DateTime? DataAlteracao { get; set; }

        [BsonIgnore]
        public NotificationHandler Notifications { get; set; }

        [BsonConstructor]
        public Apoiado(string nome)
        {
            Nome = nome;
            DataCriacao = System.DateTime.Now;
        }
    }
}

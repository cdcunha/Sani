using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System.Runtime.Serialization;

namespace Sani_api.Models
{
    [DataContract]
    public class Apoiado
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
        public string Logradouro { get; set; }

        [DataMember]
        [BsonElement]
        public string Numero { get; set; }

        [DataMember]
        [BsonElement]
        public string Complemento { get; set; }

        [DataMember]
        [BsonElement]
        public string Bairro { get; set; }

        [DataMember]
        [BsonElement]
        public string Cidade { get; set; }

        [DataMember]
        [BsonElement]
        public string Uf { get; set; }

        [DataMember]
        [BsonElement]
        public string EstadoCivil { get; set; }

        [DataMember]
        [BsonElement]
        [BsonRepresentation(BsonType.Int32)]
        public int QtdeDependentes { get; set; }

        [DataMember]
        [BsonElement]
        [BsonDateTimeOptions(DateOnly = true, Kind = System.DateTimeKind.Local)]
        public System.DateTime? DataNascimento { get; set; }

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
        public Apoiado(string nome)
        {
            Nome = nome;
            DataCriacao = System.DateTime.Now;
        }
    }
}

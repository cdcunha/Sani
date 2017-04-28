using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Sani.Api.Models
{
    [DataContract]
    public class BasePessoa : BaseModel
    {
        [DataMember]
        //[BsonElement] Usado para atributos somente leitura
        [BsonRequired]
        public string Nome { get; set; }

        [DataMember]
        public string Logradouro { get; set; }

        [DataMember]
        public string NumeroLogradouro { get; set; }

        [DataMember]
        public string ComplementoLogradouro { get; set; }

        [DataMember]
        public string Bairro { get; set; }

        [DataMember]
        public string Cidade { get; set; }

        [DataMember]
        public string Uf { get; set; }

        [DataMember]
        public string EstadoCivil { get; set; }

        [DataMember]
        public string Telefone { get; set; }

        [DataMember]
        public string Celular { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        [BsonDateTimeOptions(DateOnly = true, Kind = System.DateTimeKind.Local)]
        public System.DateTime? DataNascimento { get; set; }

        [DataMember]
        public string Observacao { get; set; }

        [BsonConstructor]
        public BasePessoa()
        {
            
        }

        [BsonConstructor]
        public BasePessoa(string nome) : base()
        {
            Nome = nome;
        }
    }
}

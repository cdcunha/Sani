using MongoDB.Bson.Serialization.Attributes;
using System.Runtime.Serialization;

namespace Sani.Api.Models
{
    [DataContract]
    public class Voluntario : BasePessoa
    {
        [DataMember]
        public string Profissao { get; set; }

        [BsonConstructor]
        public Voluntario(string nome) : base(nome)
        {
            
        }
    }
}

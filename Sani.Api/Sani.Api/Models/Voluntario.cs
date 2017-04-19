using MongoDB.Bson.Serialization.Attributes;
using System.Runtime.Serialization;

namespace Sani.Api.Models
{
    [DataContract]
    public class Voluntario : BasePessoa
    {
        

        [BsonConstructor]
        public Voluntario(string nome) : base(nome)
        {
            
        }
    }
}

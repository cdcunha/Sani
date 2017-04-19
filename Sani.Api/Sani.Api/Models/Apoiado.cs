﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Runtime.Serialization;

namespace Sani.Api.Models
{
    [DataContract]
    public class Apoiado : BasePessoa
    {
        [DataMember]
        [BsonRepresentation(BsonType.Int32)]
        public int QtdeDependentes { get; set; }
        
        [DataMember]
        public string RamoAtividade { get; set; }

        [DataMember]
        public bool PossuiVinculoCarteira { get; set; }

        [DataMember]
        public int TempoExperiencia { get; set; }

        [BsonConstructor]
        public Apoiado(string nome) : base(nome)
        {
            
        }
    }
}

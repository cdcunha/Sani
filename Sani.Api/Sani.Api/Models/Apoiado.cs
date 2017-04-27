using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using Newtonsoft.Json.Linq;
using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace Sani.Api.Models
{
    [DataContract]
    public class Apoiado : BasePessoa
    {
        [DataMember]
        public string NomeMae { get; set; }

        [DataMember]
        public string NomePai { get; set; }

        [DataMember]
        [BsonRepresentation(BsonType.Int32)]
        public int QtdeDependentes { get; set; }

        [DataMember]
        public string RamoAtividade { get; set; }

        [DataMember]
        public bool PossuiVinculoCarteira { get; set; }

        [DataMember]
        public int TempoExperiencia { get; set; }

        [DataMember]
        public string Observacao { get; set; }

        [BsonConstructor]
        public Apoiado() { }

        [BsonConstructor]
        public Apoiado(string nome) : base(nome){ }
        
        private string getTokenValue(JObject json, string key)
        {
            return json.ToString().Contains("\"" + key + "\":") && ((JValue)json.SelectToken(key)).Value != null 
                ? ((JValue)json.SelectToken(key)).Value.ToString() 
                : "";
        }

        private DateTime? TokenToDateTime(JObject json, string key, string format)
        {
            string strDate = getTokenValue(json, key);
            if (!string.IsNullOrEmpty(strDate))
            {
                if (format.Length == 10)
                    strDate = strDate.Substring(0, 10);

                if (strDate.Contains("/"))
                    strDate = strDate.Replace('/', '-');

                return DateTime.ParseExact(strDate, format, CultureInfo.InvariantCulture);
            }
            else
            {
                return null;
            }
        }

        public void DeserializeJson(JObject json)
        {
            //Id = ((JValue)json.SelectToken("bairro")).Value.ToBson();
            Nome = getTokenValue(json, "nome");
            NomeMae = getTokenValue(json, "nomeMae");
            NomePai = getTokenValue(json, "nomePai");
            Logradouro = getTokenValue(json, "logradouro");
            NumeroLogradouro = getTokenValue(json, "numeroLogradouro");
            ComplementoLogradouro = getTokenValue(json, "complementoLogradouro");
            Bairro = getTokenValue(json, "bairro");
            Cidade = getTokenValue(json, "cidade");
            Uf = getTokenValue(json, "uf");
            EstadoCivil = getTokenValue(json, "estadoCivil");
            Telefone = getTokenValue(json, "telefone");
            Celular = getTokenValue(json, "celular");
            QtdeDependentes = int.Parse(getTokenValue(json, "qtdeDependentes"));
            DataNascimento = TokenToDateTime(json, "dataNascimento", "dd-MM-yyyy");
            RamoAtividade = getTokenValue(json, "ramoAtividade");
            PossuiVinculoCarteira = Convert.ToBoolean(getTokenValue(json, "possuiVinculoCarteira"));
            TempoExperiencia = int.Parse(getTokenValue(json, "tempoExperiencia"));
            Observacao = getTokenValue(json, "observacao");
            if (!string.IsNullOrEmpty(getTokenValue(json, "ativo")))
                Ativo = Convert.ToBoolean(getTokenValue(json, "ativo"));
            //DataCriacao = ((JValue)json.SelectToken("dataCriacao")).Value.ToString();
            //DataAlteracao = ((JValue)json.SelectToken("nodataAlteracaome")).Value.ToString();
        }
    }
}

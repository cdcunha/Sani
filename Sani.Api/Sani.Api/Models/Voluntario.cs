using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json.Linq;
using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace Sani.Api.Models
{
    [DataContract]
    public class Voluntario : BasePessoa
    {
        [DataMember]
        public string Profissao { get; set; }

        [BsonConstructor]
        public Voluntario() { }

        [BsonConstructor]
        public Voluntario(string nome) : base(nome){ }

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
            Profissao = getTokenValue(json, "profissao");
            Logradouro = getTokenValue(json, "logradouro");
            NumeroLogradouro = getTokenValue(json, "numeroLogradouro");
            ComplementoLogradouro = getTokenValue(json, "complementoLogradouro");
            Bairro = getTokenValue(json, "bairro");
            Cidade = getTokenValue(json, "cidade");
            Uf = getTokenValue(json, "uf");
            EstadoCivil = getTokenValue(json, "estadoCivil");
            Telefone = getTokenValue(json, "telefone");
            Celular = getTokenValue(json, "celular");
            //QtdeDependentes = int.Parse(getTokenValue(json, "qtdeDependentes"));
            DataNascimento = TokenToDateTime(json, "dataNascimento", "dd-MM-yyyy");
            //PossuiVinculoCarteira = Convert.ToBoolean(getTokenValue(json, "possuiVinculoCarteira"));
            //TempoExperiencia = int.Parse(getTokenValue(json, "tempoExperiencia"));
            //Observacao = getTokenValue(json, "observacao");
            if (!string.IsNullOrEmpty(getTokenValue(json, "ativo")))
                Ativo = Convert.ToBoolean(getTokenValue(json, "ativo"));
            //DataCriacao = ((JValue)json.SelectToken("dataCriacao")).Value.ToString();
            //DataAlteracao = ((JValue)json.SelectToken("nodataAlteracaome")).Value.ToString();
        }
    }
}

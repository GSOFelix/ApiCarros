using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Senai.Core.Response
{
    public class Response<TData>
    {
        public int Code;

        //Cosntrutor para ja passa o valor 200 para variavel code
        [JsonConstructor]
        public Response()
            => Code = Configuration.DefautStatusCode;

        /*O segundo construtor permite a criação de uma instância da classe Response com dados específicos e configurações
        personalizadas, enquanto ainda oferece valores padrão para code e message para simplificar a criação de instâncias
        em casos comuns. Isso aumenta a flexibilidade e a usabilidade da classe Response.*/
        public Response(
            TData? data,
            string? message = null!,
            int code= Configuration.DefautStatusCode)
        {
            Data = data;
            Code = code;
            Message = message;
        }

        public TData? Data {  get; set; }
        public string? Message { get; set; }

        [JsonIgnore]
        public bool IsSuccess => Code is >= 200 and <= 299;
    }
}

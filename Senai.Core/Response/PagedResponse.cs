using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Senai.Core.Response
{
    public class PagedResponse<TData> : Response<TData>
    {
        [JsonConstructor]
        public PagedResponse(
            TData? data,
            int totalCount,
            int currentPage = 1,
            int pageSize = Configuration.DefautPageSize)
            //Chama o construtor da classe base Response<TData> passando data
            : base(data)
        {
            Data = data;
            TotalCount = totalCount;
            CurrentPage = currentPage;
            PageSize = pageSize;

        }

        public PagedResponse(
            TData? data,
            int code = Configuration.DefautStatusCode,
            string? message = null)
            : base(data, message, code)
        {

        }


        //Número total de itens disponíveis
        public int TotalCount { get; set; }

        //Total de paginas para acomodar os itens
        public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);

        //Indica a página atual na paginação
        public int CurrentPage { get; set; }

        //Define o número de itens por pagina
        public int PageSize { get; set; } = Configuration.DefautPageSize;
    }
}

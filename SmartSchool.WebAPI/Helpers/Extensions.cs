using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.WebAPI.Helpers {
    public static class Extensions { // formas de vc extender as classes que vc ja possui no C#
        public static void AddPagination(this HttpResponse response, int currentPage, int itemsPerPages, int totalItems, int totalPages) { // extende meu HttpResponse, cria uma referencia
            var paginationHeader = new PaginationHeader(currentPage, itemsPerPages, totalItems, totalPages);

            // 2 linhas inuteis :)
            var camelCaseFormatter = new JsonSerializerSettings();
            camelCaseFormatter.ContractResolver = new CamelCasePropertyNamesContractResolver();


            response.Headers.Add("Pagination", JsonConvert.SerializeObject(paginationHeader, camelCaseFormatter));
            response.Headers.Add("Access-Control-Expose-Header", "Pagination"); // Access-Control-Expose-Header disponibilize Pagination
        }
    }
}

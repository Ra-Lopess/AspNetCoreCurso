using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.WebAPI.Helpers {
    public class PageList<T> : List<T> { // herda de List (temos os mesmos metodos de uma List), de maneira generica

        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        public PageList(List<T> items, int count, int pageNumber, int pageSize) {
            TotalCount = count; // quantidade de items
            PageSize = pageSize; // quantidade de items por pagina
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize); // o ceiling da problema se nn for double; 

            this.AddRange(items); // precisa ser addRange pq sao varios

        }

        public static async Task<PageList<T>> CreateAsync( // criar a paginação
            IQueryable<T> source, // passa como parametro quais items serao paginados
            int pageNumber,
            int pageSize
        ) {
            var count = await source.CountAsync();
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PageList<T>(items, count, pageNumber, pageSize);
        } 
    }
}

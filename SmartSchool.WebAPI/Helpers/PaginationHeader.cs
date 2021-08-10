using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.WebAPI.Helpers {
    public class PaginationHeader {

        // add as mesmas coisas de PageList
        public int CurrentPage { get; set; }
        public int ItemsPerPages { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public PaginationHeader(int currentPage, int itemsPerPages, int totalItems, int totalPages) {
            CurrentPage = currentPage;
            ItemsPerPages = itemsPerPages;
            TotalItems = totalItems;
            TotalPages = totalPages;
        }
    }
}

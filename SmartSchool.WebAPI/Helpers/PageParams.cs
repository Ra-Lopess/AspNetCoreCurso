﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.WebAPI.Helpers {
    public class PageParams { // temos que passar diversos parametros ???
        public int MaxPageSize = 50;

        public int PageNumber { get; set; } = 1;

        private int pageSize = 10;

        public int PageSize {
            get { return pageSize; }
            set { pageSize = (value > MaxPageSize) ? MaxPageSize : value; } // determina que meu pageSize nunca sera maior que meu MaxPageSize
        }

        // parametros de alunos com filtros iniciais
        public int? Matricula { get; set; } = null;
        public string Nome { get; set; } = string.Empty;
        public int? Ativo { get; set; } = null;

    }
}

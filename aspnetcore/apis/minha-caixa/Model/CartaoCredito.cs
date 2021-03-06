﻿using System;

namespace MyWebApp.Model
{
    public class CartaoCredito
    {
        public int CartaoCreditoCodigo { get; set; }
        //public int PK_CartaoCredito { get; set; }
        public int AgenciaCodigo { get; set; }
        public string ContaNumero { get; set; }

        public int ClienteCodigo { get; set; }
        public string CartaoCodigo { get; set; }

        public double CartaoLimite { get; set; }
        public DateTime CartaoExpira { get; set; }

        public int CartaoCodigoSeguranca { get; set; }
    }
}
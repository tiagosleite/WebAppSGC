using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.ApplicationCore.Entity
{
    public class Cliente
    {
        public Cliente()
        {
                
        }
        public int Id { get; protected  set; }
        public string Nome { get; set; }
        public string CPF { get; set; }

    }
}

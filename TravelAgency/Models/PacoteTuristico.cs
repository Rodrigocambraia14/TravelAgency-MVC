using System;

namespace UC4_ATV2.Models
{
    public class PacoteTuristico
    {
        public int Id {get;set;}
        public string Nome {get;set;}
        public string Origem {get;set;}
        public string Destino {get;set;}
        public string Atrativos {get;set;}
        public DateTime Saida {get;set;}
        public DateTime Retorno {get;set;}
        public int Usuario {get;set;}

    }
}
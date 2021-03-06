using CoderByteAPI.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderByteAPI.Models
{
    public class Address
    {
        public int IdAddress { get; set; }
        public int IdUser { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }
        public string Ibge { get; set; }
        public string Gia { get; set; }
        public string Ddd { get; set; }
        public string Siafi { get; set; }
        public CategoryEnum Categoria { get; set; }
    }
}

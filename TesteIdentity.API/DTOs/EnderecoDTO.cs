using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteIdentity.API.DTOs
{
    public class EnderecoDTO
    {
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string CEP { get; set; }
    }
}

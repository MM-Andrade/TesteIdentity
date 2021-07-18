using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteIdentity.API.Models
{
    public class Usuario : IdentityUser<int>
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }

        public int EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }
    }
}

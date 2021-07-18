using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteIdentity.API.DTOs
{
    public class UsuarioDTO
    {
      
        public  DateTimeOffset? LockoutEnd { get; set; }
        public  bool TwoFactorEnabled { get; set; }
        public  bool PhoneNumberConfirmed { get; set; }
        public  string PhoneNumber { get; set; }
        public  string ConcurrencyStamp { get; set; }
        public  string SecurityStamp { get; set; }
        public  string PasswordHash { get; set; }
        public  bool EmailConfirmed { get; set; }
        public  string NormalizedEmail { get; set; }
        public  string Email { get; set; }
        public  string NormalizedUserName { get; set; }
        public  string UserName { get; set; }
        public  bool LockoutEnabled { get; set; }
        public  int AccessFailedCount { get; set; }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public int EnderecoId { get; set; }
        public  EnderecoDTO Endereco { get; set; }
    }
}

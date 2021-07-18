using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteIdentity.API.Data;
using TesteIdentity.API.DTOs;
using TesteIdentity.API.Interfaces;
using TesteIdentity.API.Models;

namespace TesteIdentity.API.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly UserManager<Usuario> _userManager;
        private readonly IMapper _mapper;

        public UsuarioService(ApplicationDbContext applicationDbContext, UserManager<Usuario> userManager, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<UsuarioDTO> Atualizar(UsuarioDTO dto, int id)
        {
            var usuario = await SelecionarPorId(id);

            if (usuario == null)
                return null;

            dto.Id = id;
            dto.EnderecoId = usuario.EnderecoId;
            dto.Endereco.Id = usuario.Endereco.Id;
            dto.SecurityStamp = usuario.SecurityStamp;
            dto.UserName = usuario.UserName;
           _mapper.Map(dto, usuario);

            var result = await _userManager.UpdateAsync(usuario);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return null;
            }
            var usuarioRetorno = await SelecionarPorId(id);

            return _mapper.Map<UsuarioDTO>(usuarioRetorno);
        }

        public async Task<UsuarioDTO> Criar(UsuarioDTO dto)
        {
            var usuario = _mapper.Map<Usuario>(dto);

            usuario.UserName = dto.Sobrenome;
            var result = await _userManager.CreateAsync(usuario, dto.Nome);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return null;
            }

            var usuarioRetorno = await SelecionarPorId(usuario.Id);

            return _mapper.Map<UsuarioDTO>(usuarioRetorno);
        }

        public async Task<Usuario> SelecionarPorId(int id)
        {
            IQueryable<Usuario> query = _applicationDbContext.Usuarios
                 .Include(u => u.Endereco);

            query = query
                .Where(u => u.Id == id);

            return await query.FirstOrDefaultAsync();
        }
    }
}


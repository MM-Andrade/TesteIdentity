using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteIdentity.API.DTOs;
using TesteIdentity.API.Interfaces;
using TesteIdentity.API.Models;

namespace TesteIdentity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {


        private readonly IMapper _mapper;
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IMapper mapper, IUsuarioService usuarioRepository)
        {
            _mapper = mapper;
            _usuarioService = usuarioRepository;
        }

        [HttpGet]
        public Task<IActionResult> Get()
        {
            return null;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UsuarioDTO model) 
        {
            if (model == null || !ModelState.IsValid)
                return BadRequest();

            if (await _usuarioService.Criar(model) != null)
                return Created("/api/usuario/", _mapper.Map<UsuarioDTO>(model));

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] UsuarioDTO model, int id)
        {
            if (await _usuarioService.Atualizar(model, id) != null)
            {
                string uri = $"/api/usuario/{model.Id}";
                return base.Created(uri, model);
            }

            return StatusCode(StatusCodes.Status400BadRequest, "Erro ao atualizar usuário");
        }
    }
}

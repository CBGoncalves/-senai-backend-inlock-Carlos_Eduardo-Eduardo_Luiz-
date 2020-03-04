using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using Senai.InLock.WebApi.Repositories;

namespace Senai.InLock.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiosController : ControllerBase
    {
        private IEstudioRepository _estudioRepository { get; set; }

        public EstudiosController()
        {
            _estudioRepository = new EstudioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_estudioRepository.Listar());
        }

        [HttpPost]
        public IActionResult Post(EstudioDomain novoEstudio)
        {
            _estudioRepository.Cadastrar(novoEstudio);

            return Created("http://localhost:5000/api/Estudios", novoEstudio);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            EstudioDomain estudioBuscado = _estudioRepository.BuscarPorId(id);

            if (estudioBuscado != null)
            {
                _estudioRepository.Deletar(id);

                return Ok($"O estudio {id} foi deletado com sucesso!");
            }

            return NotFound("Nenhum estudio encontrado para o identificador informado");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            EstudioDomain estudioBuscado = _estudioRepository.BuscarPorId(id);

            if (estudioBuscado == null)
            {
                return NotFound("Estudio não encontrado");
            }

            return Ok(estudioBuscado);
        }
    }
}
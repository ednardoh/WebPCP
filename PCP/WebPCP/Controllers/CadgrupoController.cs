using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebPCP.Data;
using WebPCP.Domain;
using WebPCP.Dto;
using WebPCP.Interfaces;

namespace WebPCP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadgrupoController : ControllerBase
    {
        private readonly ICadgrupoRepository _cadgrupoRepository;
        public CadgrupoController(ICadgrupoRepository cadgrupoRepository)
        {
            _cadgrupoRepository = cadgrupoRepository;
        }

        [HttpGet("{codigo}")]
        [SwaggerOperation(Summary = "Busca de grupo por código ")]
        public async Task<IActionResult> GetAsync(int codigo)
        {
            var retorno = await _cadgrupoRepository.GetAsync(codigo);
            return retorno != null ? Ok(retorno) : BadRequest();
        }

        [HttpGet("descricao/{descricao}")]
        [SwaggerOperation(Summary = "Busca de grupo pela descrição ")]
        public async Task<IActionResult> GetByCadgrupodescricaoAsync(string descricao)
        {
            var retorno = await _cadgrupoRepository.GetByCadgrupodescricaoAsync(descricao);
            return retorno != null ? Ok(retorno) : BadRequest();
        }

        [HttpGet("")]
        [SwaggerOperation(Summary = "Busca todos os Grupos ")]
        public async Task<IActionResult> GetAllAsync()
        {
            var retorno = await _cadgrupoRepository.GetAllAsync();
            return retorno?.Count > 0 ? Ok(retorno) : BadRequest();
        }

        [HttpDelete("{codigo}")]
        [SwaggerOperation(Summary = "Exclui Grupos ")]
        public async Task<IActionResult> DeleteAsync(int codigo)
        {
            var retorno = await _cadgrupoRepository.DeleteAsync(codigo);

            if (retorno)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{codigo}")]
        [SwaggerOperation(Summary = "Altera Grupos ")]
        public async Task<IActionResult> UpdateAsync(int codigo, CadgrupoDTO cadgrupoRequest)
        {
            Cadgrupo cadgrupo = new Cadgrupo()
            {
                codigo = codigo,
                descricao = cadgrupoRequest.descricao
            };
            var retorno = await _cadgrupoRepository.UpdateAsync(cadgrupo);

            if (retorno)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPost()]
        [SwaggerOperation(Summary = "Incluir Grupos ")]
        public async Task<IActionResult> PostAsync(CadgrupoDTO cadgrupoRequest)
        {
            Cadgrupo cadgrupo = new Cadgrupo()
            {
                descricao = cadgrupoRequest.descricao                
            };
            var retorno = await _cadgrupoRepository.CreateAsync(cadgrupo);
            if (retorno)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }


    }
}

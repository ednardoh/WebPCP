using Microsoft.AspNetCore.Mvc;
using WebPCP.Domain;
using WebPCP.Dto;
using WebPCP.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace Webpcp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet("{codigo}")]
        [SwaggerOperation(Summary = "Busca de usuário por código ")]
        public async Task<IActionResult> GetAsync(int codigo)
        {
            var retorno = await _usuarioRepository.GetAsync(codigo);
            return retorno != null ? Ok(retorno) : BadRequest();
        }

        [HttpGet("username/{username}")]
        [SwaggerOperation(Summary = "Busca de usuário pelo nome ")]
        public async Task<IActionResult> GetByEmailSenhaAsync(string username) 
        {
            var retorno = await _usuarioRepository.GetByUsernameAsync(username);
            return retorno != null ? Ok(retorno) : BadRequest();
        }

        [HttpGet("")]
        [SwaggerOperation(Summary = "Busca todos os usuários ")]
        public async Task<IActionResult> GetAllAsync()
        {
            var retorno = await _usuarioRepository.GetAllAsync();
            return retorno?.Count > 0 ? Ok(retorno) : BadRequest();
        }

        [HttpDelete("{codigo}")]
        [SwaggerOperation(Summary = "Exclui usuários ")]
        public async Task<IActionResult> DeleteAsync(int codigo)
        {
            var retorno = await _usuarioRepository.DeleteAsync(codigo);

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
        [SwaggerOperation(Summary = "Altera usuários ")]
        public async Task<IActionResult> UpdateAsync(int codigo, UsuarioDTO usuarioRequest)
        {
            Usuario usuario = new Usuario() { codigo = codigo,
                                              username = usuarioRequest.username,
                                              senha = usuarioRequest.senha,
                                              bloquear = usuarioRequest.bloquear,
                                              online = usuarioRequest.online,
                                              permissao_pedidovendaaprovar = usuarioRequest.permissao_pedidovendaaprovar,
                                              permissao_producaoaprovar = usuarioRequest.permissao_producaoaprovar,
                                              permissao_producaofasemovimentar = usuarioRequest.permissao_producaofasemovimentar,
                                              permissao_producaoatualizarestoque = usuarioRequest.permissao_producaoatualizarestoque,
                                              permissao_estoqueinventario = usuarioRequest.permissao_estoqueinventario,
                                              permissao_notafiscalcancelar = usuarioRequest.permissao_notafiscalcancelar,
                                              permissao_pedidovendaverprecos = usuarioRequest.permissao_pedidovendaverprecos,
                                              permissao_pedidovendaalterarpagamento = usuarioRequest.permissao_pedidovendaalterarpagamento,
                                              permissao_produtoverprecos = usuarioRequest.permissao_produtoverprecos,
                                              permissao_pedidovendadesconto = usuarioRequest.permissao_pedidovendadesconto,
            };
            var retorno = await _usuarioRepository.UpdateAsync(usuario);

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
        [SwaggerOperation(Summary = "Incluir usuários ")]
        public async Task<IActionResult> PostAsync(UsuarioDTO usuarioRequest)
        {
            Usuario usuario = new Usuario() { 
                    username = usuarioRequest.username,
                    senha = usuarioRequest.senha,
                    bloquear = usuarioRequest.bloquear,
                    online = usuarioRequest.online,
                    permissao_pedidovendaaprovar = usuarioRequest.permissao_pedidovendaaprovar,
                    permissao_producaoaprovar = usuarioRequest.permissao_producaoaprovar,
                    permissao_producaofasemovimentar = usuarioRequest.permissao_producaofasemovimentar,
                    permissao_producaoatualizarestoque = usuarioRequest.permissao_producaoatualizarestoque,
                    permissao_estoqueinventario = usuarioRequest.permissao_estoqueinventario,
                    permissao_notafiscalcancelar = usuarioRequest.permissao_notafiscalcancelar,
                    permissao_pedidovendaverprecos = usuarioRequest.permissao_pedidovendaverprecos,
                    permissao_pedidovendaalterarpagamento = usuarioRequest.permissao_pedidovendaalterarpagamento,
                    permissao_produtoverprecos = usuarioRequest.permissao_produtoverprecos,
                    permissao_pedidovendadesconto = usuarioRequest.permissao_pedidovendadesconto,
                                              };
            var retorno = await _usuarioRepository.CreateAsync(usuario);
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

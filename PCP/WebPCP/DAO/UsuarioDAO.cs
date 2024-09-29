using Dapper;
using System.Data.SqlClient;
using WebPCP.Domain;
using WebPCP.Interfaces;

namespace WebPCP.Data
{
    public class UsuarioDAO : IUsuarioRepository
    {
       
        private IConfiguration _config;

        public UsuarioDAO(IConfiguration config)
        {
            _config = config;
        }

        public async Task<bool> CreateAsync(Usuario usuario)
        {
            await using (var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {

                var retorno = await connection.ExecuteAsync(@"insert into usuarios 
                                                              (username
                                                               ,senha
                                                               ,bloquear
                                                               ,online
                                                               ,permissao_pedidovendaaprovar
                                                               ,permissao_producaoaprovar
                                                               ,permissao_producaofasemovimentar
                                                               ,permissao_producaoatualizarestoque
                                                               ,permissao_estoqueinventario
                                                               ,permissao_notafiscalcancelar
                                                               ,permissao_pedidovendaverprecos
                                                               ,permissao_pedidovendaalterarpagamento
                                                               ,permissao_produtoverprecos
                                                               ,permissao_pedidovendadesconto
                                                               )
                                                         Output INSERTED.Codigo values
                                                               (@username
                                                               ,@senha
                                                               ,@bloquear
                                                               ,@online
                                                               ,@permissao_pedidovendaaprovar
                                                               ,@permissao_producaoaprovar
                                                               ,@permissao_producaofasemovimentar
                                                               ,@permissao_producaoatualizarestoque
                                                               ,@permissao_estoqueinventario
                                                               ,@permissao_notafiscalcancelar
                                                               ,@permissao_pedidovendaverprecos
                                                               ,@permissao_pedidovendaalterarpagamento
                                                               ,@permissao_produtoverprecos
                                                               ,@permissao_pedidovendadesconto
                                                                )", new {username = usuario.username,
                                                                        senha = usuario.senha,
                                                                        bloquear = usuario.bloquear,
                                                                        online = usuario.online,
                                                                        permissao_pedidovendaaprovar = usuario.permissao_pedidovendaaprovar,
                                                                        permissao_producaoaprovar = usuario.permissao_producaoaprovar,
                                                                        permissao_producaofasemovimentar = usuario.permissao_producaofasemovimentar,
                                                                        permissao_producaoatualizarestoque = usuario.permissao_producaoatualizarestoque,
                                                                        permissao_estoqueinventario = usuario.permissao_estoqueinventario,
                                                                        permissao_notafiscalcancelar = usuario.permissao_notafiscalcancelar,
                                                                        permissao_pedidovendaverprecos = usuario.permissao_pedidovendaverprecos,
                                                                        permissao_pedidovendaalterarpagamento = usuario.permissao_pedidovendaalterarpagamento,
                                                                        permissao_produtoverprecos = usuario.permissao_produtoverprecos,
                                                                        permissao_pedidovendadesconto = usuario.permissao_pedidovendadesconto
                                                                });
               return retorno > 0;                

            }
        }        

        public async Task<bool> DeleteAsync(int codigo)
        {
            await using (var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                var retorno = await connection.ExecuteAsync("delete from usuarios Where codigo = @codigo", new { codigo = codigo });
                return retorno > 0;
                
            }
        }

        public async Task<IList<Usuario>> GetAllAsync()
        {
            await using (var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                return (await connection.QueryAsync<Usuario>(@"select codigo
                                                                     ,username
                                                                     ,senha
                                                                     ,bloquear
                                                                     ,online
                                                                     ,permissao_pedidovendaaprovar
                                                                     ,permissao_producaoaprovar
                                                                     ,permissao_producaofasemovimentar
                                                                     ,permissao_producaoatualizarestoque
                                                                     ,permissao_estoqueinventario
                                                                     ,permissao_notafiscalcancelar
                                                                     ,permissao_pedidovendaverprecos
                                                                     ,permissao_pedidovendaalterarpagamento
                                                                     ,permissao_produtoverprecos
                                                                     ,permissao_pedidovendadesconto
                                                             from usuarios").ConfigureAwait(false)).AsList();
            }
            
        }

        public async Task<Usuario> GetAsync(int codigo)                                  
        {
            await using (var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                return await connection.QueryFirstOrDefaultAsync<Usuario>("Select * from usuarios where codigo = @codigo", new { codigo = codigo });
            }
        }

        public async Task<Usuario> GetByUsernameAsync(string username) 
        {
            await using (var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                return await connection.QueryFirstOrDefaultAsync<Usuario>("select senha from usuarios where username = @username ", new { username = username});
            }
        }


        public async Task<bool> UpdateAsync(Usuario usuario)
        {
            await using (var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                var retorno = await connection.ExecuteAsync(@"update usuarios
                                                               set username = @username
                                                                  ,senha = @senha
                                                                  ,bloquear = @bloquear
                                                                  ,online = @online
                                                                  ,permissao_pedidovendaaprovar = @permissao_pedidovendaaprovar
                                                                  ,permissao_producaoaprovar = @permissao_producaoaprovar
                                                                  ,permissao_producaofasemovimentar = @permissao_producaofasemovimentar
                                                                  ,permissao_producaoatualizarestoque = @permissao_producaoatualizarestoque
                                                                  ,permissao_estoqueinventario = @permissao_estoqueinventario
                                                                  ,permissao_notafiscalcancelar = @permissao_notafiscalcancelar
                                                                  ,permissao_pedidovendaverprecos = @permissao_pedidovendaverprecos
                                                                  ,permissao_pedidovendaalterarpagamento = @permissao_pedidovendaalterarpagamento
                                                                  ,permissao_produtoverprecos = @permissao_produtoverprecos
                                                                  ,permissao_pedidovendadesconto = @permissao_pedidovendadesconto
                                                             where codigo = @codigo",
                                                             new
                                                             {
                                                                codigo = usuario.codigo,
                                                                username = usuario.username,
                                                                senha = usuario.senha,
                                                                bloquear = usuario.bloquear,
                                                                online = usuario.online,
                                                                permissao_pedidovendaaprovar = usuario.permissao_pedidovendaaprovar,
                                                                permissao_producaoaprovar = usuario.permissao_producaoaprovar,
                                                                permissao_producaofasemovimentar = usuario.permissao_producaofasemovimentar,
                                                                permissao_producaoatualizarestoque = usuario.permissao_producaoatualizarestoque,
                                                                permissao_estoqueinventario = usuario.permissao_estoqueinventario,
                                                                permissao_notafiscalcancelar = usuario.permissao_notafiscalcancelar,
                                                                permissao_pedidovendaverprecos = usuario.permissao_pedidovendaverprecos,
                                                                permissao_pedidovendaalterarpagamento = usuario.permissao_pedidovendaalterarpagamento,
                                                                permissao_produtoverprecos = usuario.permissao_produtoverprecos,
                                                                permissao_pedidovendadesconto = usuario.permissao_pedidovendadesconto
                                                             });
                return retorno > 0;   

            }
        }

    }
}

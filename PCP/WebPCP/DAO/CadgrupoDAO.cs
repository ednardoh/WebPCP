using Dapper;
using System.Data.SqlClient;
using WebPCP.Domain;
using WebPCP.Interfaces;

namespace WebPCP.DAO
{
    public class CadgrupoDAO : ICadgrupoRepository
    {

        private IConfiguration _config;

        public CadgrupoDAO(IConfiguration config)
        {
            _config = config;
        }

        public async Task<bool> CreateAsync(Cadgrupo cadgrupo)
        {
            await using (var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {

                var retorno = await connection.ExecuteAsync(@"insert into CAD_GRUPO 
                                                              (descricao)
                                                         Output INSERTED.Codigo values
                                                               (@descricao)", new
                {
                    descricao = cadgrupo.descricao                    
                });
                return retorno > 0;

            }
        }

        public async Task<bool> DeleteAsync(int codigo)
        {
            await using (var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                var retorno = await connection.ExecuteAsync("delete from CAD_GRUPO Where codigo = @codigo", new { codigo = codigo });
                return retorno > 0;

            }
        }

        public async Task<IList<Cadgrupo>> GetAllAsync()
        {
            await using (var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                return (await connection.QueryAsync<Cadgrupo>(@"select codigo, descricao from CAD_GRUPO").ConfigureAwait(false)).AsList();
            }

        }

        public async Task<Cadgrupo> GetAsync(int codigo)
        {
            await using (var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                return await connection.QueryFirstOrDefaultAsync<Cadgrupo>("Select * from CAD_GRUPO where codigo = @codigo", new { codigo = codigo });
            }
        }

        public async Task<Cadgrupo> GetByCadgrupodescricaoAsync(string descricao)
        {
            await using (var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                return await connection.QueryFirstOrDefaultAsync<Cadgrupo>("select descricao from CAD_GRUPO where descricao = @descricao ", new { descricao = descricao });
            }
        }


        public async Task<bool> UpdateAsync(Cadgrupo cadgrupo)
        {
            await using (var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                var retorno = await connection.ExecuteAsync(@"update CAD_GRUPO
                                                               set descricao = @descricao                                                                  
                                                             where codigo = @codigo",
                                                             new
                                                             {
                                                                 codigo = cadgrupo.codigo,
                                                                 descricao = cadgrupo.descricao                                                                 
                                                             });
                return retorno > 0;

            }
        }

    }
}

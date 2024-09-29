namespace WebPCP.Dto
{
    public class UsuarioDTO
    {
        public int     codigo                                 { get; set; }
        public string  username                               { get; set; }
        public string  senha                                  { get; set; }
        public bool    bloquear                               { get; set; }
        public bool    online                                 { get; set; }
        public bool    permissao_pedidovendaaprovar           { get; set; }
        public bool    permissao_producaoaprovar              { get; set; }
        public bool    permissao_producaofasemovimentar       { get; set; }
        public bool    permissao_producaoatualizarestoque     { get; set; }
        public bool    permissao_estoqueinventario            { get; set; }
        public bool    permissao_notafiscalcancelar           { get; set; }
        public bool    permissao_pedidovendaverprecos         { get; set; }
        public bool    permissao_pedidovendaalterarpagamento  { get; set; }
        public bool    permissao_produtoverprecos             { get; set; }
        public bool    permissao_pedidovendadesconto          { get; set; }   
    }
}

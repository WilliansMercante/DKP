namespace DKP.Dominio.DKP.Cadastro
{
    public class TelefoneEntity : EntidadeBase
    {
        public int IdCliente { get; set; }
        public int IdTipoTelefone { get; set; }
        public string DDD { get; set; }
        public string Numero { get; set; }
        public DateTime DtCadastro { get; set; }
        public bool FlAtivo { get; set; }

        public TipoTelefoneEntity TipoTelefone { get; set; }
    }
}

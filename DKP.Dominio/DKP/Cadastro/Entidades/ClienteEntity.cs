namespace DKP.Dominio.DKP.Cadastro.Entidades
{
    public class ClienteEntity : EntidadeBase
    {
        public string Nome { get; set; }
        public DateTime DtNascimento { get; set; }
        public string CPF { get; set; }
        public string Rg { get; set; }
        public DateTime DtCadastro { get; set; }
        public bool FlAtivo { get; set; }

        public ICollection<EnderecoEntity> Enderecos { get; set; }
        public ICollection<TelefoneEntity> Telefones { get; set; }

    }
}

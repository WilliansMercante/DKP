﻿namespace DKP.Dominio.DKP.Cadastro.Entidades
{
    public class EnderecoEntity : EntidadeBase
    {
        public int IdCliente { get; set; }
        public int IdTipoEndereco { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string Municipio { get; set; }
        public string UF { get; set; }
        public DateTime DtCadastro { get; set; }
        public bool FlAtivo { get; set; }

        public TipoEnderecoEntity TipoEndereco { get; set; }


    }
}

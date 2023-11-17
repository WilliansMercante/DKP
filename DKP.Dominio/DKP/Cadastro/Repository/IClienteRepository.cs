﻿using DKP.Dominio.DKP.Cadastro.Entidades;

namespace DKP.Dominio.DKP.Cadastro.Repository
{
    public interface IClienteRepository
    {
        void Incluir(ClienteEntity obj);
        void Atualizar(ClienteEntity obj);
        ClienteEntity ConsultarPorId(int id);
        ClienteEntity ConsultarPorCPF(string cpf);
        void Excluir(int id);
        IEnumerable<ClienteEntity> Listar();
        IEnumerable<ClienteEntity> ListarUltimos20Ativos();
        IEnumerable<ClienteEntity> ListarUltimos20();
        void Inativar(int id);
        IEnumerable<ClienteEntity> Consultar(string nome, string cpf, DateTime? dtNascimento);
    }
}

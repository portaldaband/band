﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EscolaInfra.Repositorios
{
    public interface IRepositorioBase<TEntity> where TEntity : class
    {
        int TotalRegistros(TEntity countEntity);

        IList<TEntity> ObterTodos();

        IList<TEntity> ObterTodosOrdenacaoAscendente(string campo);

        IList<TEntity> ObterTodosOrdenacaoDescendente(string campo);

        TEntity ObterPorId(int id);

        TEntity ObterPorId(string id);

        void ExcluirPorId(int id);

        void Excluir(TEntity entidadeEntity);

        void Dispose();

        void Salvar(TEntity entidadeEntity);

        void SalvarLista(IList<TEntity> entidadeEntity);

        void Atualiza(TEntity entidadeEntity);

        void AtualizaLista(IList<TEntity> entidadesEntity);

        IList<TEntity> PesquisarParametros(Expression<Func<TEntity, bool>> parametros);
    }
}

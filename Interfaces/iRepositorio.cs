using System;
using System.Collections.Generic;
using System.Text;

namespace Dio.Series.Interfaces
{
    public interface iRepositorio<T>
    {
        List<T> Lista();

        T RetornoPorID(int id);

        void Insere(T entidade);

        void Exclui(int id);

        void Atualizar(int id, T entidade);

        int ProximoId();
    }
}

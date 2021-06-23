using System.Collections.Generic;
using EPlayersMVCEx.Models;

namespace EPlayersMVCEx.Interfaces
{
    public interface IJogador
    {
        void Criar(Jogador j);

        List<Jogador> LerTodos();

        void Alterar(Jogador j);

        void Deletar(int id);
    }
}
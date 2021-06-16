using System.Collections.Generic;
using EPlayersMVCEx.Models;

namespace EPlayersMVCEx.Interfaces
{
    public interface IEquipe
    {
         void Criar(Equipe e);

         List<Equipe> LerTodas();

         void Alterar(Equipe e);

         void Deletar(int IdEquipe);
    }
}
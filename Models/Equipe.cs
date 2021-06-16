using System;
using System.Collections.Generic;
using System.IO;
using EPlayersMVCEx.Interfaces;

namespace EPlayersMVCEx.Models
{
    public class Equipe : EPlayersbase, IEquipe
    {
        public int IdEquipe { get; set; }
        
        public string Nome { get; set; }
        
        public string Imagem { get; set; }
        
        private const string CAMINHO = "Database/equipe.csv";

        public Equipe()
        {
            CriarPastaDeArquivo(CAMINHO);
        }

        private string Preparar(Equipe e)
        {
            return $"{e.IdEquipe};{e.Nome};{e.Imagem}";
        }

        public void Alterar(Equipe e)
        {
            List<string> linhas = LerTodasLinhaCSV(CAMINHO);
            //1;Nome;CaminhoImagem
            linhas.RemoveAll(x => x.Split(";")[0] == e.IdEquipe.ToString());
            //linhas.RemoveAll(x => int.Parse(x.Split(";")[0]) == e.IdEquipe); Outro modo de fazer
            linhas.Add(Preparar(e));

            ReescreverCSV(CAMINHO, linhas);
        }

        public void Criar(Equipe e)
        {
            string[] linhas = {Preparar(e)};
            File.AppendAllLines(CAMINHO, linhas);
        }

        public void Deletar(int IdEquipe)
        {
            List<string> linhas = LerTodasLinhaCSV(CAMINHO);
            //1;Nome;CaminhoImagem
            linhas.RemoveAll(x => x.Split(";")[0] == IdEquipe.ToString());
            //linhas.RemoveAll(x => int.Parse(x.Split(";")[0]) == IdEquipe); Outro modo de fazer
            
            ReescreverCSV(CAMINHO, linhas);
        }

        public List<Equipe> LerTodas()
        {
            List<Equipe> equipes = new List<Equipe>();
            
            string[] linhas = File.ReadAllLines(CAMINHO);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                //id equipe
                //nome equipe
                //caminho imagem
                Equipe equipe = new Equipe();
                equipe.IdEquipe = Int32.Parse(linha[0]);
                equipe.Nome = linha[1];
                equipe.Imagem = linha[2];

                equipes.Add(equipe);
            }
            return equipes;
        }
    }
}
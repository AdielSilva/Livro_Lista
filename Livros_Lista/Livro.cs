using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livros_Lista
{

    class Livro
    {
        private int isbn;
        private string titulo;
        private string autor;
        private string editora;
        private List<Exemplar> exemplares;

        public int Isbn { get => isbn; set => isbn = value; }
        public string Autor { get => autor; set => autor = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Editora { get => editora; set => editora = value; }
        public List<Exemplar> Exemplares { get { return this.exemplares; }  }

        public Livro (int isbn, string titulo, string autor, string editora)
        {
            this.isbn = isbn;
            this.titulo = titulo;
            this.editora = editora;
            exemplares = new List<Exemplar>();
        }

        public Livro (int isbn)
        {
            this.isbn = isbn;
        }

        public void adicionarExemplar(Exemplar exemplar)
        {
            exemplares.Add(exemplar);
        }

        public int qtdeExemplares()
        {
            return exemplares.Count();
        }

        public int qtdDisponiveis()
        {
            int exemplaresDisponives = 0;
            foreach (Exemplar x in exemplares)
            {
                if (x.disponivel())
                {
                    exemplaresDisponives++;
                }
            }

            return exemplaresDisponives;
        }

        public int qtdEmprestimos()
        {
            int qtdEmprestado=0;

            foreach (Exemplar x in exemplares)
            {
                qtdEmprestado = x.qtdEmprestimos();
            }

            return qtdEmprestado;
        }

        public double percDisponibilidade()
        {
            double percentual = 0;

            if (qtdeExemplares() != 0 || qtdDisponiveis() != 0)
            {
                percentual = (qtdDisponiveis() * 100) / qtdeExemplares();
            }
            return percentual;
        }

        public override bool Equals(object obj)
        {
            Livro livro = (Livro)obj;
            return livro.isbn.Equals(this.isbn);
        }
    }
}

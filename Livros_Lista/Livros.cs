using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livros_Lista
{
    class Livros
    {
        private List<Livro> acervo;

        public List<Livro> Acervo { get { return this.acervo; } }

        public Livros()
        {
            acervo = new List<Livro>();

        }

        public void adicionar(Livro livro)
        {
            acervo.Add(livro);
        }

        public Livro pesquisar(Livro livro)
        {
             foreach (Livro s in acervo)
             {
                if(s.Equals(livro))
                {
                    return s;
                }
             }

            return null;
        }
    }
}

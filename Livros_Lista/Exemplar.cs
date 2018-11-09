using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livros_Lista
{
    class Exemplar
    {
        private int tombo;
        private List<Emprestimo> emprestimos;

        public int Tombo { get { return tombo; } set { tombo = value; } }
        public List<Emprestimo> Emprestimos { get { return this.emprestimos; } }

        public Exemplar(int tombo)
        {
            this.tombo = tombo;
            this.emprestimos = new List<Emprestimo>();
        }

        public bool emprestar()
        {
            if (disponivel() == true)
            {
                
                emprestimos.Add(new Emprestimo(DateTime.Now));
                return true;
            }

            return false;
        }

        public bool devolver()
        {
            if(!disponivel())
            {
                this.emprestimos[this.emprestimos.Count - 1].DtDevolucao = DateTime.Now;
                
                    return true; //devolve
                
            }
            return false; //não devolve
        }

        public bool disponivel()
        {
            if(this.emprestimos.Count() > 0)
            {
                if (this.emprestimos[this.emprestimos.Count - 1].DtDevolucao == DateTime.MinValue)
                    return false; //disponivel
            }
          
            return true; //indisponivel
        }

        public int qtdEmprestimos ()
        {
            return emprestimos.Count();
        }
    }
}

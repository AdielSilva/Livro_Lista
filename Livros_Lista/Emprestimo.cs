using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livros_Lista
{
    class Emprestimo
    {
        private DateTime dtEmprestimo;
        private DateTime dtDevolucao; 

        public DateTime DtEmprestimo { get { return dtEmprestimo; } set { dtEmprestimo = value; } }
        public DateTime DtDevolucao {  get { return dtDevolucao; } set { dtDevolucao = value; } }

        public Emprestimo (DateTime dataEmprestimo)
        {
            this.dtEmprestimo = dataEmprestimo;
            
        }

        public void setDtDevolucao(DateTime dataDevolucao)
        {
            this.dtDevolucao = dataDevolucao;
        }

        public DateTime getEmprestimo()
        {
            return this.dtEmprestimo;
        }
    }
}

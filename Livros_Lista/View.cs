using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livros_Lista
{
    class View
    {
        Livros acervo = new Livros();

        static void Main(string[] args)
        {
            int opcao;
            bool boolMenu = true;
            View view = new View();
            while (boolMenu)
            {
                try
                {
                    
                    menu();
                    Console.Write("Digite sua opção: ");
                    opcao = int.Parse(Console.ReadLine());

                    switch (opcao)
                    {
                        case 0: System.Environment.Exit(0); break;
                        case 1: view.adicionarLivro(); break;
                        case 2: view.mostrarDadosSintetico(); break;
                        case 3: view.mostrarDadosAnalitico(); break;
                        case 4: view.adicionarExemplar(); break;
                        case 5: view.registrarEmprestimo(); break;

                    }
                }

                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            Console.ReadKey();
        }

        public static void menu()
        {
           
            Console.SetCursorPosition(20, 0);
            Console.WriteLine("Menu");
            Console.WriteLine(" 0. Sair ");
            Console.WriteLine(" 1. Adicionar livro ");
            Console.WriteLine(" 2. Pesquisar livro (sintético)* ");
            Console.WriteLine(" 3. Pesquisar livro (analítico)** ");
            Console.WriteLine(" 4. Adicionar exemplar");
            Console.WriteLine(" 5. Registrar empréstimo ");
            Console.WriteLine(" 6. Registrar devolução ");
        }

        public void adicionarLivro()
        {
            Console.Clear();

            //Dados que serão inseridos
            Console.Write("Digite o ISBN do livro: ");
            int isbn = int.Parse(Console.ReadLine());

            Console.Write("Digite o titulo do livro: ");
            string titulo = Console.ReadLine();

            Console.Write("Digite o nome do autor: ");
            string autor = Console.ReadLine();

            Console.Write("Digite a editora: ");
            string editora = Console.ReadLine();

            Livro livro = new Livro(isbn, titulo, autor, editora);

            acervo.adicionar(livro);

            Console.WriteLine("O livro {0} foi adicionado com sucesso!", livro.Titulo);
            Console.ReadKey();
            Console.Clear();


        }

        public Livro pesquisarLivro()
        {
            Console.Clear();
            Console.Write("Digite o código Isbn:");
            int isbn = int.Parse(Console.ReadLine());

            if (acervo.pesquisar(new Livro(isbn)) != null)
            {
                return acervo.pesquisar(new Livro(isbn));
            }

            else
                return null;
        }

        public void mostrarDadosSintetico()
        {
            Console.Clear();

            Livro teste = pesquisarLivro();
            if (teste == null)
            {
                Console.WriteLine("Livro não foi encontrado.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Código: " + teste.Isbn);
                Console.WriteLine("Titulo: " + teste.Titulo);
                Console.WriteLine("Editora: "+ teste.Editora);
                Console.WriteLine("Quantidade de exemplares: " + teste.qtdeExemplares());
                Console.WriteLine("Quantidades disponiveis: " + teste.qtdDisponiveis());
                Console.WriteLine("Quantidades de emprestimos: " + teste.qtdEmprestimos());
                Console.WriteLine("Percentual disponivel: " + teste.percDisponibilidade());

            }

            Console.ReadKey();
            Console.Clear();
        }

        public void mostrarDadosAnalitico()
        {
            Livro teste = pesquisarLivro();
            if (teste == null)
            {
                Console.WriteLine("Livro não foi encontrado.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Código: {0} " , teste.Isbn);
                Console.WriteLine("Titulo: {0}" , teste.Titulo);
                Console.WriteLine("Editora: {0}" , teste.Editora);
                Console.WriteLine("Quantidade de exemplares: {0}" , teste.qtdeExemplares());
                Console.WriteLine("Quantidades disponiveis: {0}" , teste.qtdDisponiveis());
                Console.WriteLine("Quantidades de emprestimos: {0}" , teste.qtdEmprestimos());
                Console.WriteLine("Percentual disponivel: {0}" , teste.percDisponibilidade());

                foreach (Exemplar exemplar in teste.Exemplares)
                {
                    Console.WriteLine(exemplar.Tombo);
                    foreach(Emprestimo emprestimo in exemplar.Emprestimos)
                    {
                        Console.WriteLine("Data emprstimo: " + emprestimo.DtEmprestimo);
                        Console.WriteLine("Data devolução: " + emprestimo.DtDevolucao);
                    }
                }
                Console.ReadKey();
                Console.Clear();
            }
        }

        public void adicionarExemplar()
        {

            foreach (Livro livro in acervo.Acervo)
            {
                Console.WriteLine(livro.Isbn + " " + livro.Titulo);
                Console.WriteLine(livro.qtdDisponiveis() + "\n\n");
               
            }
            Console.ReadKey();

            Console.WriteLine("Digite o código do livro que deseja adcionar um exemplar.");
            Livro livroEscolhido = pesquisarLivro();
         
            if (livroEscolhido == null)
            {
                Console.WriteLine("Esse livro não existe.");

            }

            else
            {
                Console.WriteLine("Digite o código tombo do exemplar: ");
                int tombo = int.Parse(Console.ReadLine());
                livroEscolhido.adicionarExemplar(new Exemplar(tombo));
                Console.WriteLine("Exemplar adcionado!");
                Console.ReadKey();
                
            }

            Console.ReadKey();
            Console.Clear();
        }
       
        public void registrarEmprestimo()
        {
            Console.Clear();
            Console.SetCursorPosition(20, 0);
            Console.WriteLine("Lista livros");

            foreach (Livro livro in acervo.Acervo)
            {                
                Console.WriteLine(livro.Isbn + " " + livro.Titulo);
                Console.WriteLine(livro.qtdDisponiveis() + "\n\n");
            }
            Console.ReadKey();
            Livro livroEscolhido = pesquisarLivro();

            if(livroEscolhido.qtdDisponiveis() > 0)
            {
                Exemplar exemplar = livroEscolhido.Exemplares.FirstOrDefault(i => i.emprestar());
                if (exemplar != null) Console.WriteLine("Exemplar " + exemplar.Tombo + " emprestado com sucesso!");
                else throw new Exception("Não há exemplares disponíveis.");
            }

            else
            {
                Console.WriteLine("Não foi possivel realizar o emprestimo.");
            }
            Console.ReadKey();
            Console.Clear();
        }
    }
}

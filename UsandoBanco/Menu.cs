using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsandoBanco.interfaces;

namespace UsandoBanco
{
    internal class Menu
    {
        private int _CurrentId = 1;
        private List<Produto> _Produtos = new List<Produto>();
        public void ChamarMenu()
        {
            Console.WriteLine("===============================");
            Console.WriteLine("Este é o menu, seja bem vindo!");
            Console.WriteLine("===============================");
            Console.WriteLine("");
            Console.WriteLine("1 - Listar (Read/Select)");
            Console.WriteLine("2 - Adicionar (Create/Insert)");
            Console.WriteLine("3 - Deletar item (Delete)");
            Console.WriteLine("4 - Alterar item (Update)");

            switch (Console.ReadLine())
            {
                case "1":
                    //var produtos = Produto.GetAll();                    
                    //ListarItens(produtos);
                    List<IMenuItem> produtos = Produto.GetAll();
                    ListarItens(produtos);

                    Console.ReadLine();
                   
                    Console.Clear();
                    ChamarMenu();

                    break;

                case "2":
                    Produto produto = new Produto();
                    produto.Save();

                    Console.WriteLine("Produto Adicionado!");
                    Thread.Sleep(3000); //espera 3 segundos

                    Console.Clear();
                    ChamarMenu();
                   
                    break;

                    case "3":
                    Console.WriteLine("Informe o Id do produto que deseja deletar:");
                    var idDeletar = long.Parse(Console.ReadLine());

                    //long idDeleletar = 0; 
                    //while (!long.TryParse(Console.ReadLine(), out idDeleletar))
                    //{
                    //    Console.WriteLine("Valor inválido!");
                    //    Thread.Sleep(2000);
                    //    break;
                    //}


                    var produtodeletar = new Produto(idDeletar);

                    if (produtodeletar.IsValid())
                    {
                        produtodeletar.Delete();
                        Console.WriteLine("Produto excluido!");
                    }
                    else
                    {
                        Console.WriteLine($"Não existe produto com o Id informado: {idDeletar}!"); 
                    }                                   
                    
                    Thread.Sleep(3000); //espera 3 segundos

                    Console.Clear();
                    ChamarMenu();
                    break;
               
                    case "4":
                    Console.WriteLine("Informe o Id do produto:");
                    var idUpdate = long.Parse(Console.ReadLine());
                    var produtoUpdte = new Produto(idUpdate);

                    if (produtoUpdte.IsValid())
                    {
                        AlterarItem(produtoUpdte);
                    }
                    else
                    {
                        Console.WriteLine($"Não existe produto com o Id informado: {idUpdate}!");
                    }
                  
                 
                    Thread.Sleep(3000); //espera 3 segundos

                    Console.Clear();
                    ChamarMenu();
                    break;

                default: 
                    Console.WriteLine("Opção Inválida");

                    Thread.Sleep(3000); //espera 3 segundos
                   
                    Console.Clear();
                    ChamarMenu();
                    break;
            }
        }
       
      
       
        private void ListarItens(List<IMenuItem> items)
        {
            Console.Clear();
            if (!items.Any())
            {
                Console.WriteLine("Sem itens para exibir");
            }

            foreach (var item in items)
            {
                Console.WriteLine(item.ToString());

            }
        }
        private void DeletarItem(int id)
        {
            _Produtos.RemoveAll(produto => produto.Id == id);

            //caso fosse com o "foreach", demoraria muito mais para processar do que acima (lambda)
            //foreach(var produto in _Produtos)
            //{
            //    if (produto.Id == id)
            //    {
            //        _Produtos.Remove(produto);
            //    }
            //}
        }
        private void AlterarItem(Produto produto)
        {
            Console.Clear();
            Console.WriteLine($"Menu de alteração:");
            Console.WriteLine($"1 - Nome: ");
            Console.WriteLine($"2 - Código: ");
            Console.WriteLine($"3 - Valor: ");
            Console.WriteLine($"4 - Descrição: ");
            Console.WriteLine($"'Salvar' para salvar as alterações.");

            Console.WriteLine("Informe o campo que deseja alterar: ");
            var entrada = Console.ReadLine().ToUpper();

            while (entrada != "SALVAR")
            {
                if (entrada != "1" && entrada != "2" && entrada != "3" && entrada != "4")
                {
                    Console.WriteLine("Campo inválido!");
                }
                else
                {
                    Console.Write("Informe o valor que será aplicado: ");
                    var valor = Console.ReadLine();


                    switch (entrada)
                    {
                        case "1":
                            produto.Nome = valor;
                            break;
                        case "2":
                            produto.Codigo = valor;
                            break;
                        case "3":
                            produto.Valor = decimal.Parse(valor);
                            break;
                        case "4":
                            produto.Descricao = valor;
                            break;
                    }
                }
                Console.Clear();
                Console.WriteLine($"Menu de alteração:");
                Console.WriteLine($"1 - Nome: ");
                Console.WriteLine($"2 - Código: ");
                Console.WriteLine($"3 - Valor: ");
                Console.WriteLine($"4 - Descrição: ");
                Console.WriteLine($"'Salvar' para salvar as alterações.");

                Console.WriteLine("Informe o campo que deseja alterar: ");
                entrada = Console.ReadLine().ToUpper();
            }
            produto.Update();        
                    
        }

    }
}

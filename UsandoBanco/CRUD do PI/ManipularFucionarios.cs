using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace UsandoBanco.CRUD_do_PI
{
    internal class ManipularFucionarios
    {
        private int _IdFuncionario = 1;
        private List<Funcionario> _Funcionarios = new List<Funcionario>();

        public void ChamarMenuFuncionario()
        {
            Console.WriteLine("==============================================================");
            Console.WriteLine("Este é o sistema de cadastro de funcionário, seja bem vindo!");
            Console.WriteLine("==============================================================");
            Console.WriteLine("");
            Console.WriteLine("1 - Adicionar Funcionario");
            Console.WriteLine("2 - Listar Funcionários");
            Console.WriteLine("3 - Deletar Funcionário");
            Console.WriteLine("4 - Alterar dados do funcionário");

            switch (Console.ReadLine())
            {
                case "1":
                    AdicionarFuncionario(GerarFuncionario());
                    Console.WriteLine("Funcionário adicionado!");
                    Thread.Sleep(2000);
                    Console.Clear();
                    ChamarMenuFuncionario();

                    break;

                case "2":
                    ListarFuncionario();
                    Console.ReadLine();
                    Console.Clear();
                    ChamarMenuFuncionario();

                    break;

                case "3":
                    Console.WriteLine("Informe o ID do funcionário: ");
                    DeletarFuncionario(int.Parse(Console.ReadLine()));
                    Console.WriteLine("Funcionário excluído da base!");
                    Thread.Sleep(2000);
                    Console.Clear();
                    ChamarMenuFuncionario();

                    break;

                case "4":
                    Console.WriteLine("Informe o ID do funcionário: ");
                    AlterarFuncionario(int.Parse(Console.ReadLine()));
                   
                  
                    Console.Clear();
                    ChamarMenuFuncionario();
                    break;

                default:
                    Console.WriteLine("Opção Inválida");

                    Thread.Sleep(2000); //espera 2 segundos

                    Console.Clear();
                    ChamarMenuFuncionario();
                    break;
            }
        }
        private void AdicionarFuncionario(Funcionario funcionario)
        {
            _Funcionarios.Add(funcionario);
        }
        private Funcionario GerarFuncionario()
        {
            Funcionario funcionario = new Funcionario();

            funcionario.IdFuncionario = _IdFuncionario;

            Console.WriteLine("Informe o nome do funcionário para cadastro: ");
            funcionario.NomeFuncionario = Console.ReadLine();

            Console.WriteLine("Informe a data de nascimento do funcionário: ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime datanascimento))
            {
                funcionario.NascimentoFuncionario = datanascimento;
            }
            else
            {
                Console.WriteLine("Data inválida");
            }

            Console.WriteLine("Informe o CPF do funcionário: ");
            funcionario.CpfFuncionario = Console.ReadLine();

            Console.WriteLine("Informe o salário do funcionário: ");
            funcionario.SalarioFuncionario = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Informe o cargo do funcionário: ");
            funcionario.CargoFuncionario = Console.ReadLine();

            Console.WriteLine("Informe a data de contratação do funcionário: ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime datacontratacao))
            {
                funcionario.DataContratacao = datacontratacao;   
            }
            else
            {
                Console.WriteLine("Data inválida");
            }

            //DateTime.TryParse("10/03/1994", out DateTime date)
            //var valorHora = date.ToString("HH:mm");
            //var dataAtual = DateTime.Now;

            _IdFuncionario++;
            return funcionario;
        }
        private void ListarFuncionario()
        {
            if (_Funcionarios.Count < 1)
            {
                Console.WriteLine("Sem itens para exibir.");
            }
            else
            {
                foreach (var funcionario in _Funcionarios)
                {
                    Console.WriteLine($"Id: ({funcionario.IdFuncionario}). \nNome: {funcionario.NomeFuncionario}.\nCPF: {funcionario.CpfFuncionario}.\nData de contratação: {funcionario.DataContratacao.ToString("dd/MM/yyyy")}.");
                    Console.WriteLine($"Data de Nascimento: {funcionario.NascimentoFuncionario.ToString("dd/MM/yyyy")}. \nSalário: R$ {funcionario.SalarioFuncionario}.\nCargo: {funcionario.CargoFuncionario}.");
                    Console.WriteLine("");
                    Console.WriteLine("===============================");
                    Console.WriteLine("");

                }
            }
        }
        private void DeletarFuncionario(int id)
        {
            _Funcionarios.RemoveAll(funcionario => funcionario.IdFuncionario == id);
        }
        private void AlterarFuncionario(int id)
        {
            var funcionario1 = _Funcionarios.First(x => x.IdFuncionario == id);
            if (funcionario1 == null)
            {
                Console.WriteLine("O funcionário não existe!");
                Thread.Sleep(2000);
                
            }
            else
            {
                Console.WriteLine($"Informe qual atributo do(a) {funcionario1.NomeFuncionario} você quer alterar: ");
                Console.WriteLine("1 - Nome: ");
                Console.WriteLine("2 - Data de nascimento: ");
                Console.WriteLine("3 - CPF: ");
                Console.WriteLine("4 - Salário: ");
                Console.WriteLine("5 - Cargo: ");
                Console.WriteLine("6 - Data Contratação: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Informe o novo nome do funcionário: ");
                        funcionario1.NomeFuncionario = Console.ReadLine();
                        Console.WriteLine("Nome alterado!");
                        Thread.Sleep(2000);
                        break;

                    case "2":
                        Console.WriteLine("Informe a nova data de nascimento do funcionário: ");
                        if (DateTime.TryParse(Console.ReadLine(), out DateTime datanascimento))
                        {
                            funcionario1.NascimentoFuncionario = datanascimento;
                        }
                        else
                        {
                            Console.WriteLine("Data inválida");
                        }
                        Console.WriteLine("Data alterada!");
                        Thread.Sleep(2000);
                        break;
                     
                    case "3":
                        Console.WriteLine("Informe o novo CPF do funcionário: ");
                        funcionario1.CpfFuncionario = Console.ReadLine();
                        Console.WriteLine("CPF alterado!");
                        Thread.Sleep(2000);
                        break;

                                                
                    case "4":
                        Console.WriteLine("Informe o novo Salário do funcionário: ");
                        funcionario1.SalarioFuncionario = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Salário alterado!");
                        Thread.Sleep(2000);
                        break;
                                                
                    case "5":
                        Console.WriteLine("Informe o novo cargo do funcionário: ");
                        funcionario1.CargoFuncionario = Console.ReadLine();
                        Console.WriteLine("Cargo alterado!");
                        Thread.Sleep(2000);
                        break;
                                               
                    case "6":
                        Console.WriteLine("Informe a nova data de contratação do funcionário: ");
                        if (DateTime.TryParse(Console.ReadLine(), out DateTime datacontratacao))
                        {
                            funcionario1.DataContratacao = datacontratacao;
                        }
                        else
                        {
                            Console.WriteLine("Data inválida");
                        }
                        Console.WriteLine("Data alterada!");
                        Thread.Sleep(2000);
                        break;
                    default:
                        Console.WriteLine("Opção Inválida");

                        Thread.Sleep(2000); 

                        Console.Clear();
                        ChamarMenuFuncionario();
                        break;




                }



            }
        }
    }
}

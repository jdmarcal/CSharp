using Controllers;
using Modelos;
using System;
using System.Collections.Generic;


namespace ConsoleView
{
    class Program
    {
        enum OpcoesMenuPrincipal

        {
            CadastrarCliente = 1,
            PesquisarCliente = 2,
            EditarCliente = 3,
            ExcluirCliente = 4,
            ListarClientes = 5,
            LimparTela = 6,
            Sair = 7
        }

        private static OpcoesMenuPrincipal Menu()
        {
            Console.WriteLine("Escolha sua opcao");
            Console.WriteLine("");            
            Console.WriteLine("-------------------------");
            Console.WriteLine("|      - Clientes -     |");
            Console.WriteLine("-------------------------");
            Console.WriteLine("| 1 - Cadastrar Novo    |"); 
            Console.WriteLine("| 2 - Pesquisar Cliente |");
            Console.WriteLine("| 3 - Editar Cliente    |");
            Console.WriteLine("| 4 - Excluir Cliente   |");
            Console.WriteLine("| 5 - Listar Clientes   |");
            Console.WriteLine("-------------------------");
            Console.WriteLine("| 6 - Limpar Tela       |");
            Console.WriteLine("| 7 - Sair              |");
            Console.WriteLine("-------------------------");


            //return Convert.ToInt32(Console.ReadLine());
            string opcao = Console.ReadLine();
            return (OpcoesMenuPrincipal) int.Parse(opcao);
        }

        static void Main(string[] args)
        {
            OpcoesMenuPrincipal opcaoDigitada = 
                OpcoesMenuPrincipal.Sair;
            do
            {
                opcaoDigitada = Menu();

                switch (opcaoDigitada)
                {
                    case OpcoesMenuPrincipal.CadastrarCliente:
                        Cliente c = CadastrarCliente();

                        ClienteController cc = new ClienteController();
                        cc.SalvarCliente(c);
                        
                        ExibirDadosCliente(c);
                        break;
                    case OpcoesMenuPrincipal.PesquisarCliente:
                        PesquisarCliente();
                        break;
                    case OpcoesMenuPrincipal.EditarCliente:
                        break;
                    case OpcoesMenuPrincipal.ExcluirCliente:
                        ExcluirCliente();
                        break;
                    case OpcoesMenuPrincipal.ListarClientes:
                        ListarClientesCadastrados();
                        break;
                    case OpcoesMenuPrincipal.LimparTela:
                        break;
                    case OpcoesMenuPrincipal.Sair:
                        break;
                    
                    default:
                        break;
                }
               
            } while (opcaoDigitada != OpcoesMenuPrincipal.Sair);
            
        }

        private static void ExcluirCliente()
        {
            Console.Write("Digite o ID do Cliente a ser excluido: ");
            int idCliente = int.Parse(Console.ReadLine());

            ClienteController cc = new ClienteController();
            cc.ExcluirCliente(idCliente);
        }        

        // Metodos Cliente
        private static Cliente CadastrarCliente()
        {
            Cliente cli = new Cliente();
          
            Console.WriteLine();           

            Console.Write("Digite o nome: ");
            cli.Nome = Console.ReadLine();

            Console.WriteLine();

            Console.Write("Digite o cpf: ");
            cli.Cpf = Console.ReadLine();

            Endereco end = CadastrarEndereco();

            cli.EnderecoID = end.EnderecoID;

            Console.WriteLine();
            Console.Write("Cliente cadastrado com sucesso!!!");
            Console.WriteLine();

            return cli;            
        }

        //Metodo geral para cadastro de endereco
        private static Endereco CadastrarEndereco()
        {
            Endereco end = new Endereco();

            Console.WriteLine();

            Console.Write("Digite o nome da rua: ");
            end.Rua = Console.ReadLine();

            Console.WriteLine();

            Console.Write("Digite o numero: ");
            end.Numero = int.Parse(Console.ReadLine());

            Console.WriteLine();

            Console.Write("Digite o complemento: ");
            end.Complemento = Console.ReadLine();

            Console.WriteLine();

            EnderecoController ec = new EnderecoController();
            ec.CadastrarEndereco(end);

            return end;
        }

        private static void ListarClientesCadastrados()
        {
            ClienteController cc = new ClienteController();

            Console.WriteLine();
            Console.WriteLine("---Clientes Cadastrados---");
            Console.WriteLine();

            List<Cliente> lista = cc.ListarClientes();
            
            if(lista.Count == 0)
            {
                Console.WriteLine("***Ainda não tem clientes cadastrados***");
            }
            else
            {
                foreach (Cliente cli in lista)
                {
                    ExibirDadosCliente(cli);
                }
                Console.WriteLine();
            }

           
        }

        private static void PesquisarCliente()
        {
            Console.Write("Digite o nome do Cliente: ");
            String nomeCliente = Console.ReadLine();

            ClienteController cc = new ClienteController();
            Cliente cli = cc.PesquisarClientePorNome(nomeCliente);

            if(cli != null)            
                ExibirDadosCliente(cli);
            else
                Console.Write("Cliente não encontrado");
        }

        private static void AlterarDadosCliente()
        {
            ClienteController cc = new ClienteController();

            int idCliente;

            ListarClientesCadastrados();

            Console.Write("Digite a ID do Cliente a ser alterado: ");

            idCliente = int.Parse(Console.ReadLine());

            Cliente cli = cc.PesquisarPorID(idCliente);

            if(cli != null)
            {
                Console.WriteLine();

                Console.Write("Digite o nome: ");
                cli.Nome = Console.ReadLine();

                Console.WriteLine();

                Console.Write("Digite o cpf: ");
                cli.Cpf = Console.ReadLine();

                

            }
            else
            {
                Console.WriteLine();
                Console.Write("Cliente não encontrado");
                Console.WriteLine();
            }

        }

        private static Endereco AlterarEndereco(int id)
        {
            EnderecoController ec = new EnderecoController();
            Endereco end = ec.pesquisarPorId(id);            
            
                Console.WriteLine();

                Console.Write("Digite o nome da rua: ");
                end.Rua = Console.ReadLine();

                Console.WriteLine();

                Console.Write("Digite o numero: ");
                end.Numero = int.Parse(Console.ReadLine());

                Console.WriteLine();

                Console.Write("Digite o complemento: ");
                end.Complemento = Console.ReadLine();

                Console.WriteLine();

            return end;
        }

        private static void ExibirDadosCliente(Cliente cliente)
        {
            Console.WriteLine();
            Console.WriteLine("---------- DADOS CLIENTE --------- ");
            Console.WriteLine("ID:" + cliente.PessoaID);
            Console.WriteLine("Nome: " + cliente.Nome);
            Console.WriteLine("Cpf: " + cliente.Cpf);
            Console.WriteLine("Endereco Id: " + cliente.EnderecoID);

            ExibirDadosEndereco(cliente.EnderecoID);
        }

        private static void ExibirDadosEndereco(int id)
        {
            EnderecoController ec = new EnderecoController();
            Endereco e = ec.pesquisarPorId(id);

            Console.WriteLine("------------ Endereco ------------");
            Console.WriteLine("Rua: " + e.Rua);
            Console.WriteLine("Num: " + e.Numero);
            Console.WriteLine("Compl.: " + e.Complemento);
            Console.WriteLine("----------------------------------");
            Console.WriteLine();
        }
    }
}
using Modelos;
using System.Linq;
using System.Collections.Generic;

namespace Controllers
{
    public class ClienteController
    {
        static List<Cliente> MeusClientes = new List<Cliente>();
        static int ultimoID = 0;

        public void SalvarCliente(Cliente cliente)
        {
            int id = ultimoID + 1;
            ultimoID = id;

            cliente.PessoaID = id;
            MeusClientes.Add(cliente);            
        }

        public void EditarCliente(Cliente cliente)
        {

        }

        public Cliente PesquisarClientePorNome(string nome)
        {
            var c = from x in MeusClientes
                    where x.Nome.ToLower().Equals(nome.Trim().ToLower()) //Tratamento para consultas eliminando espaços adicionais(TriM()) 
                                                                         //e ignorando case sensitive(ToLower()); 
                    select x;

            if (c != null)
                return c.FirstOrDefault();
            else
                return null;
        }

        public Cliente PesquisarPorID(int idCliente)
        {
            var c = from x in MeusClientes
                    where x.PessoaID.Equals(idCliente)
                    select x;

            if (c != null)
                return c.FirstOrDefault();
            else
                return null;
        }


        public void ExcluirCliente(int idCliente)
        {
            Cliente cli = PesquisarPorID(idCliente);

            if(cli != null)
            {
                MeusClientes.Remove(cli);
            }
        }

        public List<Cliente> ListarClientes()
        {
            return MeusClientes;
        }

    }
}

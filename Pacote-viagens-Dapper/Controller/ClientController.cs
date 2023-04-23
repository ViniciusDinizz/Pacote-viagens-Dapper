using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pacote_viagens_Dapper.Model;
using Pacote_viagens_Dapper.Services;

namespace Pacote_viagens_Dapper.Controller
{
    internal class ClientController
    {
        public int Add(Client client)
        {
            return new ClientService().Add(client);
        }
        public bool Update(Client client)
        {
            return new ClientService().Update(client);
        }
        public bool Delete(int Id)
        {
            return new ClientService().Delete(Id);
        }
        public List<Client> GetAll()
        {
            return new ClientService().GetAll();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pacote_viagens_Dapper.Model;
using Pacote_viagens_Dapper.Repository;

namespace Pacote_viagens_Dapper.Services
{
    internal class ClientService
    {
        private IClientRepository clientRepository;
        public ClientService()
        {
            clientRepository = new ClientRepository();
        }
        public int Add(Client client)
        {
            return clientRepository.Add(client);
        }
        public bool Update(Client client)
        {
            return clientRepository.Update(client);
        }
        public bool Delete(int Id) 
        {
            return clientRepository.Delete(Id);
        }
        public List<Client> GetAll()
        {
            return clientRepository.GetAll();
        }
    }
}

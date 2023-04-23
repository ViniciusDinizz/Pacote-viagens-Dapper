using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pacote_viagens_Dapper.Model;

namespace Pacote_viagens_Dapper.Repository
{
    internal interface IClientRepository
    {
        int Add(Client client);
        bool Update(Client client);
        bool Delete(int Id);
        List<Client> GetAll();
    }
}

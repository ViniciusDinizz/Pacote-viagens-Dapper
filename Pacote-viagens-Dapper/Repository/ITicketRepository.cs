using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pacote_viagens_Dapper.Model;

namespace Pacote_viagens_Dapper.Repository
{
    public interface ITicketRepository
    {
        int Add(Ticket ticket);
        int Update(Ticket ticket);
        bool Delete(int Id);
        List<Ticket> GetAll();
        Adress ReturnAdress(int Id);
        City ReturnCity(int Id);
    }
}

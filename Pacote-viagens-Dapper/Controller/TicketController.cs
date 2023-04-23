using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pacote_viagens_Dapper.Model;
using Pacote_viagens_Dapper.Services;

namespace Pacote_viagens_Dapper.Controller
{
    public class TicketController
    {
        public int Add(Ticket ticket)
        {
            return new TicketService().Add(ticket);
        }
        public int Update(Ticket ticket)
        {
            return new TicketService().Update(ticket);
        }
        public bool Delete(int Id)
        {
            return new TicketService().Delete(Id);
        }
        public List<Ticket> GetAll()
        {
            return new TicketService().GetAll();
        }
    }
}

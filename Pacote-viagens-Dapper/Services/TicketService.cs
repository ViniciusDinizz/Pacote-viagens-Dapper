using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pacote_viagens_Dapper.Model;
using Pacote_viagens_Dapper.Repository;

namespace Pacote_viagens_Dapper.Services
{
    public class TicketService
    {
        private ITicketRepository ticketRepository;
        public TicketService()
        {
            ticketRepository = new TicketRepository();
        }
        public int Add(Ticket ticket)
        {
            return ticketRepository.Add(ticket);
        }
        public int Update(Ticket ticket)
        {
            return ticketRepository.Update(ticket);
        }
        public bool Delete(int Id) 
        {
            return ticketRepository.Delete(Id);
        }
        public List<Ticket> GetAll()
        {
            return ticketRepository.GetAll();
        }
    }
}

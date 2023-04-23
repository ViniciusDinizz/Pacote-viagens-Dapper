using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacote_viagens_Dapper.Model
{
    public class Package
    {
        public readonly static string INSERT = "INSER INTO Package(DtCadastro, IdClient, IdTicket, IdHotel) VALUES(@DtCadastro, @IdClient, @IdTicket, @IdHotel)";
        public readonly static string SELECT = "SELECT Id, DtCadastro, Value, IdClient, IdTicket, IdHotel FROM Packages";
        public readonly static string DELETE = "DELETE FROM Packages WHERE Id = @Id";
        public readonly static string UPDATE = "UPDATE Packages SET Value = @Value, IdHotel = @IdHotel, IdTicket = @IdTicket WHERE Id = @Id";
        public int Id { get; set; }
        public DateTime DtCadastro { get; set; }
        public decimal Value { get; set; }
        public Client Client { get; set; }
        public Ticket Ticket { get; set; }
        public Hotel Hotel { get; set; }

        public override string ToString()
        {
            return $"Id:{Id}\nData:{DtCadastro}\n{Client}\n{Ticket}\n{Hotel}";
        }
    }
}

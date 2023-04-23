using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacote_viagens_Dapper.Model
{
    public class Ticket
    {
        public readonly static string INSERT = "INSERT INTO Ticket(Date, Value, IdOrigin, IdDestin) VALUE(@Data, @Value, @Origin, @Destin); SELECT CAST (SCOPE_IDENTITY() AS INT)";
        public readonly static string DELETE = "DELETE FROM Ticket WHERE Id = @Id";
        public readonly static string SELECT = "SELECT Id, Date, Value, IdOrigin, IdDestin FROM Ticket";
        public readonly static string UPDATE = "UPDATE Ticket SET Value = @Value, IdOrigin = @IdOrigin, IdDestin = @IdDestin WHERE Id = @Id";
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public decimal Value { get; set; }
        public Adress Origin { get; set; }
        public Adress Destin { get; set; }

        public override string ToString()
        {
            return $"Data:{Data}\nValor:{Value}\nOrigem: {Origin}\nDestino:{Destin}";
        }
    }
}

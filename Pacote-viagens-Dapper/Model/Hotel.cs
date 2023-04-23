using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacote_viagens_Dapper.Model
{
    public class Hotel
    {
        public readonly static string INSERT = "INSERT INTO Hotel(Name, DtCadastro, Valor, IdEndereco) VALUES(@Name, @DtCadastro, @Valor, @IdEndereco); SELECT CAST (SCOPE_IDENTITY() AS INT)";
        public readonly static string UPDATE = "UPDATE Hotel SET Name = @Name, DtCadastro = @DtCadastro, Valor = @Value, IdEndereco = @Adress WHERE Id = @Id; SELECT CAST (SCOPE_IDENTITY() AS INT)";
        public readonly static string DELETE = "DELETE FROM Hotel WHERE Hotel.Id = @Id";
        public readonly static string SELECT = "SELECT h.Id, h.Name, h.DtCadastro, h.Valor, a.Street, a.Number, a.Burgh, a.Cep, a.Complement, a.DtCadastro, c.[Id], c.[Description], c.[DtCadastro] FROM Hotel h INNER JOIN Adress a ON h.IdEndereco = a.Id INNER JOIN City c ON a.IdCity = c.Id";
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DtCadastro { get; set; }
        public decimal Value { get; set; }
        public Adress Adress { get; set; }

        public override string ToString()
        {
            return $"Id{Id}\nNome Hotel:{Name}\nData:{DtCadastro}\nValor:{Value}\n{Adress}";
        }
    }
}

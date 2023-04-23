using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacote_viagens_Dapper.Model
{
    public class Client
    {
        public readonly static string INSERT = "INSERT INTO Client(Name, Telephone, DtCadastro, IdEndereco) VALUES(@Name, @Telephone, @DtCadastro, @IdEndereco); SELECT CAST (SCOPE_IDENTITY() AS INT)";
        public readonly static string SELECT = "SELECT c.Id, c.Name, c.Telephone, c.DtCadastro, a.Id, a.Street, a.Number, a.Burgh, a.Cep, a.Complement, a.DtCadastro, ct.[Id], ct.[Description], ct.[DtCadastro] FROM Client c INNER JOIN Adress a ON c.IdEndereco = a.Id INNER JOIN City ct ON a.IdCity = ct.Id";
        public readonly static string DELETE = "DELETE FROM Client WHERE Client.Id = @Id";
        public readonly static string UPDATE = "UPDATE Client SET Name = @Name, Telephone = @Telephone, DtCadastro = @DtCadastro, IdEndereco = @Adress WHERE Id = @Id";

        public int Id { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public DateTime DtCadastro { get; set; }
        public Adress Adress { get; set; }

        public override string ToString()
        {
            return $"Nome:{Name}\nTel:{Telephone}\nData:{DtCadastro}\n{Adress}";
        }
    }
}

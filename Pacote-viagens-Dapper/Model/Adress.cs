using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Pacote_viagens_Dapper.Model
{
    public class Adress
    {
        public readonly static string SELECT = "SELECT a.Id, a.Street, a.Number, a.Burgh, a.Cep, a.Complement, a.DtCadastro, c.Id, c.Description, c.DtCadastro FROM Adress a INNER JOIN City c ON a.IdCity = c.Id";
        public readonly static string DELETE = "DELETE FROM Adress WHERE Adress.Id = @Id";
        public readonly static string INSERT = "INSERT INTO Adress(Street, Number, Burgh, Cep, Complement, DtCadastro, IdCity) VALUES(@Street, @Number, @Burgh, @Cep, @Complement, @DtCadastro, @IdCity); SELECT CAST(SCOPE_IDENTITY() AS INT)";
        public readonly static string UPDATE = "UPDATE Adress SET Street = @Street, Number = @Number, Burgh = @Burgh, Cep = @Cep, Complement = @Complement, DtCadastro = @DtCadastro, IdCity = @IdCity WHERE Id = @Id";
        public int Id { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Burgh { get; set; }
        public string Cep { get; set; }
        public string Complement { get; set; }
        public DateTime DtCadastro { get; set; }
        public City City { get; set; }

        public override string ToString()
        {
            return $"Rua:{Street}\nNum:{Number}\nBairro:{Burgh}\nCep:{Cep}\nComp:{Complement}\nData:{DtCadastro}\n{City}";
        }
    }
}

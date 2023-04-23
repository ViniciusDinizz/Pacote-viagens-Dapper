using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacote_viagens_Dapper.Model
{
    public class City
    {
        public readonly static string INSERT = "INSERT INTO City(Description, DtCadastro) VALUES(@Description, @DtCadastro); SELECT CAST(SCOPE_IDENTITY() AS INT)";
        public readonly static string SELECT = "SELECT Id, Description, DtCadastro FROM City";
        public readonly static string DELETE = "DELETE FROM City WHERE City.Id = @Id";
        public readonly static string UPDATE = "UPDATE City SET [Description] = @description WHERE Id = @Id";
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DtCadastro { get; set; }

        public override string ToString()
        {
            return $"Cidade:{Description}\n\n";
        }
    }
}

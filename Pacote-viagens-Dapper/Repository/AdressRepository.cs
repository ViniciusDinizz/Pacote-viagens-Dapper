using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pacote_viagens_Dapper.Model;
using Dapper;
using static System.Formats.Asn1.AsnWriter;
using Pacote_viagens_Dapper.Services;

namespace Pacote_viagens_Dapper.Repository
{
    public class AdressRepository : IAdressRepository
    {
        private string _conn { get; set; }

        public AdressRepository()
        {
            _conn = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        }
        public int Add(Adress adress)
        {
            bool status = false;
            using(var db = new SqlConnection(_conn))
            {
                db.Open();
                var query = Adress.INSERT.Replace("@IdCity", new CityRepository().Add(adress.City).ToString());
                return (int)db.ExecuteScalar(query, adress);
            }
        }

        public bool Delete(int Id)
        {
            {
                bool status = false;
                using (var db = new SqlConnection(_conn))
                {
                    db.Open();
                    db.Execute(Adress.DELETE, new { Id });
                    status = true;
                }
                return status;
            }
        }

        public List<Adress> GetAll()
        {
            using (var db = new SqlConnection(_conn))
            {
                var address = db.Query<Adress, City, Adress>(Adress.SELECT,
                    (Adress, City) =>
                    {
                        Adress.City = City;
                        return Adress;
                    }
                    );
                return (List<Adress>)address;
            }
        }

        public int Update(Adress adress)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE Adress SET Street = '" + adress.Street + "', Number = " + adress.Number + ", Burgh = '" + adress.Burgh + "', Cep = '" + adress.Cep + "', Complement = '" + adress.Complement + "', IdCity = "+new CityService().Update(adress.City).ToString()+" WHERE Id = " + adress.Id);
            using(var db = new SqlConnection(_conn))
            {
                db.Execute(sb.ToString());
                int id = adress.Id;
                return id;
            }
        }
        
    }
}

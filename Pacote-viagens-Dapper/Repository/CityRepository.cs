using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pacote_viagens_Dapper.Model;
using Dapper;

namespace Pacote_viagens_Dapper.Repository
{
    internal class CityRepository : ICityRepository
    {
        private string _conn;
        public CityRepository()
        {
            _conn = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        }

        public int Add(City city)
        {
            bool status = false;
            using(var db = new SqlConnection(_conn))
            {
                db.Open();
                return (int)db.ExecuteScalar(City.INSERT, city);
            }
        }

        public bool Delete(int Id)
        {
            bool status = false;
            using(var db = new SqlConnection(_conn))
            {
                db.Open();
                db.ExecuteScalar(City.DELETE, new { Id });
                status = true;
            }
            return status;
        }

        public List<City> GetAll()
        {
            using (var db = new SqlConnection(_conn))
            {
                db.Open();
                var city = db.Query<City>(City.SELECT);
                return (List<City>)city;
            }
        }

        public int Update(City city)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE City SET [Description] = '" + city.Description + "' WHERE Id = " +city.Id);
            using(var db = new SqlConnection(_conn))
            {
                db.Execute(sb.ToString());
                int id = city.Id;
                return id;
            }
        }

    }
}

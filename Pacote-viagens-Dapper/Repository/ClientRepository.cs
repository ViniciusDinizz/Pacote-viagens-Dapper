using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Pacote_viagens_Dapper.Model;

namespace Pacote_viagens_Dapper.Repository
{
    internal class ClientRepository : IClientRepository
    {
        private string _conn;
        public ClientRepository()
        {
            _conn = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        }
        public int Add(Client client)
        {
            using(var db = new SqlConnection(_conn))
            {
                db.Open();
                var query = Client.INSERT.Replace("@IdEndereco", new AdressRepository().Add(client.Adress).ToString());
                return (int)db.ExecuteScalar(query, client);
            }
        }

        public bool Delete(int Id)
        {
            using(var db = new SqlConnection(_conn))
            {
                db.ExecuteScalar(Client.DELETE, new { Id });
                return true;
            }
        }

        public List<Client> GetAll()
        {
            using(var db = new SqlConnection(_conn))
            {
                var client = db.Query<Client, Adress, City,Client>(Client.SELECT,
                    (Client, Adress, City) =>
                    {
                        Client.Adress = Adress;
                        Client.Adress.City = City;
                        return Client;
                    }
                    );
                return (List<Client>)client;
            }
        }

        public bool Update(Client client)
        {
            bool status = false;
            using(var db = new SqlConnection(_conn)) 
            {
                var query = Client.UPDATE.Replace("@Adress", new AdressRepository().Add(client.Adress).ToString());
                db.ExecuteScalar(query, client); 
                return status = true;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pacote_viagens_Dapper.Model;
using Pacote_viagens_Dapper.Services;

namespace Pacote_viagens_Dapper.Controller
{
    public class PackageController
    {
        public int Add(Package package)
        {
            return new PackageService().Add(package);
        }
        public int Update(Package package)
        {
            return new PackageService().Update(package);
        }
        public bool Delete(int Id)
        {
            return new PackageService().Delete(Id);
        }
        public List<Package> GetAll()
        {
            return new PackageService().GetAll();
        }
    }
}

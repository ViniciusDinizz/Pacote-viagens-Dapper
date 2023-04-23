using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pacote_viagens_Dapper.Model;
using Pacote_viagens_Dapper.Repository;

namespace Pacote_viagens_Dapper.Services
{
    public class PackageService
    {
        private IPackageRepository packageRepository;
        public PackageService()
        {
            packageRepository = new PackageRepository();
        }
        public int Add(Package package)
        {
            return packageRepository.Add(package);
        }
        public int Update(Package package)
        {
            return packageRepository.Update(package);
        }
        public bool Delete(int Id)
        {
            return packageRepository.Delete(Id);
        }
        public List<Package> GetAll()
        {
            return packageRepository.GetAll();
        }
    }
}

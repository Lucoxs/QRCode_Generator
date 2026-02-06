using QRCode_Generator.Context;
using QRCode_Generator.Interfaces;
using QRCode_Generator.Models;

namespace QRCode_Generator.Services
{
    public class MappingService : IMappingService
    {
        DataContext DataContext;
        public MappingService(DataContext dataContext)
        {
            DataContext = dataContext;
        }

        public Mapping AddMapping(Mapping mapping)
        {
            DataContext.Mapping.Add(mapping);
            DataContext.SaveChanges();
            return mapping;
        }

        public Mapping? GetMappingByRedirectionCode(string redirectionCode)
        {
            return DataContext.Mapping.FirstOrDefault(m => m.DomainUrl == redirectionCode);
        }

        public List<Mapping> GetMappings()
        {
            return DataContext.Mapping.ToList();
        }
    }
}

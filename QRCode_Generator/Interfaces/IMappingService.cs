using QRCode_Generator.Models;

namespace QRCode_Generator.Interfaces
{
    public interface IMappingService
    {
        public Mapping AddMapping(Mapping mapping);
        public List<Mapping> GetMappings();
        public Mapping? GetMappingByRedirectionCode(string redirectionCode);
    }
}

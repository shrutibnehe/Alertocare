using AlertToCareAPI.Models;
using System.Collections.Generic;

namespace AlertToCare.Data
{
    public interface IIcuConfigurationRepository
    {
        void AddNewIcu(Icu icu);
        void RemoveIcu(Icu icu);
        void UpdateIcu(Icu icu);
        Icu GetIcuById(string id);
        IEnumerable<Icu> GetAllIcus();
        bool SaveChanges();
        IEnumerable<Layout> GetAllLayouts();
        bool ConfigureBeds(string IcuId,int BedCount);
        
    }
}

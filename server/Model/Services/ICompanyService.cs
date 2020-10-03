using System.Collections.Generic;
using System.Linq;
using Server.Model.Data;
using Server.Model.DTO;

namespace Server.Model.Services
{
    public interface ICompanyService
    {
        IEnumerable<Company> Search(SearchCondition condition, IQueryable<Company> from);
        void Update(ref Company updatedEntry, Company update);
    }
}
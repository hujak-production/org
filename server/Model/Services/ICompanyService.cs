using System.Collections.Generic;
using System.Linq;
using server.Model.Data;
using server.Model.DTO;

namespace server.Model.Services
{
    public interface ICompanyService
    {
        IEnumerable<Company> Search(SearchCondition condition, IQueryable<Company> from);
        void Update(ref Company updatedEntry, Company update);
    }
}
using System.Collections.Generic;

namespace server.Model.Data
{
    public class Company
    {
        public long CompanyId { get; set; }
        public string Name { get; set; }
        public int EstablishmentYear { get; set; }
        public ICollection<Employer> Employees { get; set; }
    }
}

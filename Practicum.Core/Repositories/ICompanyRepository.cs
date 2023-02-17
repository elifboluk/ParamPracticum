using Practicum.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicum.Core.Repositories
{
    public interface ICompanyRepository : IGenericRepository<Company>
    {
        Task<Company> GetSingleCompanyByIdWithProductsAsync(int companyId);
    }
}

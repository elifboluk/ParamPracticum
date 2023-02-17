using Microsoft.EntityFrameworkCore;
using Practicum.Core.Entities;
using Practicum.Core.Repositories;
using Practicum.Repository.Context;

namespace Practicum.Repository.Repositories
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Company> GetSingleCompanyByIdWithProductsAsync(int companyId)
        {
            return await _context.Companies.Include(x => x.Products).Where(x => x.Id == companyId).SingleOrDefaultAsync();
        }
    }
}

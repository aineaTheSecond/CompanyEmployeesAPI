using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateCompany(Company company) => Create(company);

        public async Task<IEnumerable<Company>> GetAllCompaniesAsync(bool trackChanges) => await FindAll(trackChanges)
            .OrderBy(c => c.Name)
            .ToListAsync();

        public async Task<Company> GetCompany(Guid companyId, bool trackChanges) => await FindByCondition(c => c.Id.Equals(companyId), trackChanges).SingleOrDefaultAsync();

        public async Task <IEnumerable<Company>> GetByIds(IEnumerable<Guid> companyIds, bool trackChanges)
        {
            return await FindByCondition(x => companyIds.Contains(x.Id), trackChanges).ToListAsync();
        }

        void ICompanyRepository.DeleteCompany(Company company) => Delete(company);
    }
}

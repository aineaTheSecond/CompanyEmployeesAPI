using Contracts;
using Entities.Models;

namespace Repository
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateCompany(Company company) => Create(company);

        public IEnumerable<Company> GetAllCompanies(bool trackChanges) => FindAll(trackChanges).OrderBy(c => c.Name).ToList();

        public Company GetCompany(Guid companyId, bool trackChanges) => FindByCondition(c => c.Id.Equals(companyId), trackChanges).SingleOrDefault();

        public IEnumerable<Company> GetByIds(IEnumerable<Guid> companyIds, bool trackChanges)
        {
            return FindByCondition(x => companyIds.Contains(x.Id), trackChanges).ToList();
        }

        void ICompanyRepository.DeleteCompany(Company company) => Delete(company);
    }
}

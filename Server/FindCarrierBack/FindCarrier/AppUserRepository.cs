using FindCarrier.Domain.Entities;
using FindCarrier.Domain;
using FindCarrier.Repositories.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindCarrier.Repositories
{
    public class AppUserRepository
    {
        private readonly IRepository<ApplicationUser> _appUserRepository;
        private readonly CarrierDbContext _dbContext;

        public AppUserRepository(IRepository<ApplicationUser> userRepository,
            CarrierDbContext dbContext)
        {
            _appUserRepository = userRepository;
            _dbContext = dbContext;
        }


        public async Task<IList<ApplicationUser>> GetAll()
        {
            var result = (await _appUserRepository.GetAll()).Where(x => x.IsDeleted == false).ToList();
            return result;
        }


    }
}

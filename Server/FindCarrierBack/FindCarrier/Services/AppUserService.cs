using FindCarrier.Domain;
using FindCarrier.Domain.Entities;
using FindCarrier.Repositories;
using FindCarrier.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindCarrier.Services.Services
{
    public class AppUserService
    {
        private readonly AppUserRepository _userRepository;

        public AppUserService(IRepository<ApplicationUser> userRepository,
            CarrierDbContext context)
        {
            _userRepository = new AppUserRepository(userRepository, context);

        }

        public async Task<IList<ApplicationUser>> GetAll()
        {
            var result = await _userRepository.GetAll();

            return result;
        }
    }
}

using FindCarrier.Domain.Entities;
using FindCarrier.Domain;
using FindCarrier.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindCarrier.Repositories
{
    public class UserRepository
    {
        private readonly IRepository<User> _userRepository;
        private readonly CarrierDbContext _dbContext;

        public UserRepository(IRepository<User> userRepository,
            CarrierDbContext dbContext)
        {
            _userRepository = userRepository;
            _dbContext = dbContext;
        }


        public async Task<bool> Create(User user)
        {
            await _userRepository.Create(user);

            var savedSuccesfully = await _userRepository.SaveChangesAsync();

            return savedSuccesfully;

        }

        public async Task<bool> Update(User user)
        {
            _userRepository.Update(user);

            var updatedSuccesful = await _userRepository.SaveChangesAsync();
            return updatedSuccesful;
        }

        public async Task<User> GetById(int id)
        {
            var result = await _userRepository.GetById(id);
            return result;

        }

        public async Task<bool> DeleteUser(int id)
        {
            var result = await _userRepository.GetById(id);
            result.IsDeleted = true;
            var deletedSuccesful = await _userRepository.SaveChangesAsync();
            return deletedSuccesful;
        }

        public async Task<IList<User>> GetAll()
        {
            var result = (await _userRepository.GetAll()).Where(x => x.IsDeleted == false).ToList();
            return result;
        } 
        
    
    }
}

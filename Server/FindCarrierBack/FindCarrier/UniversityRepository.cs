using FindCarrier.Domain.Entities;
using FindCarrier.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindCarrier.Repositories
{
    public class UniversityRepository
    {
        private readonly IRepository<University> _uniRepository;

        public UniversityRepository(IRepository<University> repository)
        {
            _uniRepository = repository;
        }

        public async Task<bool> Create(University model)
        {
            await _uniRepository.Create(model);

            var savedSuccessful = await _uniRepository.SaveChangesAsync();

            return savedSuccessful;
        }

        public async Task<IList<University>> GetAll()
        {
            var result = (await _uniRepository.GetAll()).Where(x => x.IsDeleted == false).ToList();
            return result;
        }

        public async Task<University> GetById(int id)
        {
            var job = await _uniRepository.GetById(id);
            return job;
        }

        public async Task<bool> Update(University model)
        {
            _uniRepository.Update(model);
            var updatedSuccessful = await _uniRepository.SaveChangesAsync();
            return updatedSuccessful;
        }

        public void Delete(University model)
        {
            _uniRepository.Delete(model);
        }

        public async Task<bool> DeleteUniversity(int id)
        {
            var result = await _uniRepository.GetById(id);
            result.IsDeleted = true;
            var deletedSuccessful = await _uniRepository.SaveChangesAsync();
            return deletedSuccessful;
        }
    }
}


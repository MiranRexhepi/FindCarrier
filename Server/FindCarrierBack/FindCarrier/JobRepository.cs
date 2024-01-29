using FindCarrier.Domain.Entities;
using FindCarrier.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindCarrier.Repositories
{
    public class JobRepository 
    {
        private readonly IRepository<Job> _jobRepository;

        public JobRepository(IRepository<Job> repository)
        {
            _jobRepository = repository;
        }

        public async Task<bool> Create(Job model)
        {
            await _jobRepository.Create(model);

            var savedSuccessful = await _jobRepository.SaveChangesAsync();

            return savedSuccessful;
        }

        public async Task<IList<Job>> GetAll()
        {
            var result = (await _jobRepository.GetAll()).Where(x => x.IsDeleted == false).ToList();
            return result;
        }

        public async Task<Job> GetById(int id)
        {
            var job = await _jobRepository.GetById(id);
            return job;
        }

        public async Task<bool> Update(Job model)
        {
            _jobRepository.Update(model);
            var updatedSuccessful = await _jobRepository.SaveChangesAsync();
            return updatedSuccessful;
        }

        public void Delete(Job model)
        {
            _jobRepository.Delete(model);
        }

        public async Task<bool> DeleteJob(int id)
        {
            var result = await _jobRepository.GetById(id);
            result.IsDeleted = true;
            var deletedSuccessful = await _jobRepository.SaveChangesAsync();
            return deletedSuccessful;
        }
    }
}

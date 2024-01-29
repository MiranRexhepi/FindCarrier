using FindCarrier.Domain.Entities;
using FindCarrier.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindCarrier.Repositories
{
    public class UniversityApplicationRepository
    {
        private readonly IRepository<UniversityApplication> _uniApplyRepository;

        public UniversityApplicationRepository(IRepository<UniversityApplication> repository)
        {
            _uniApplyRepository = repository;
        }

        public async Task<bool> ApplyForUni(UniversityApplication application)
        {
            await _uniApplyRepository.Create(application);

            var savedSuccessful = await _uniApplyRepository.SaveChangesAsync();

            return savedSuccessful;
        }

        public async Task<IList<UniversityApplication>> GetAll()
        {
            var result = (await _uniApplyRepository.GetAll()).Where(x => x.IsDeleted == false).ToList();
            return result;
        }

        public async Task<UniversityApplication> GetById(int id)
        {
            var application = await _uniApplyRepository.GetById(id);
            return application;
        }

        public async Task<bool> DeleteApplication(int id)
        {
            var result = await _uniApplyRepository.GetById(id);
            result.IsDeleted = true;
            var deletedSuccessful = await _uniApplyRepository.SaveChangesAsync();
            return deletedSuccessful;
        }

    }
}


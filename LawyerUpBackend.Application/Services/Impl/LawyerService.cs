using AutoMapper;
using LawyerUpBackend.Application.Models.Lawyer;
using LawyerUpBackend.DataAccess.Repositiories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawyerUpBackend.Application.Services.Impl
{
    public class LawyerService : ILawyerService
    {
        private readonly ILawyerRepostiory _repository;
        private readonly IMapper _mapper;

        public LawyerService(ILawyerRepostiory repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LawyerListResponseModel>> GetAllAsync()
        {
            var lawyerList = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<LawyerListResponseModel>>(lawyerList);
        }

        public async Task<LawyerResponseModel> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var lawyer = await _repository.GetFirstAsync(lawyer => lawyer.Id == id);
            return _mapper.Map<LawyerResponseModel>(lawyer);
        }

        public async Task<IEnumerable<LawyerListResponseModel>> GetListByQuery(string query)
        {
            var lawyerList = await _repository.GetAllAsync(lawyer=> lawyer.Name.Contains(query));
            return _mapper.Map<IEnumerable<LawyerListResponseModel>>(lawyerList);
        }
    }
}

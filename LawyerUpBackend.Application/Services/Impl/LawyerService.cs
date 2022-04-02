using AutoMapper;
using LawyerUpBackend.Application.Dtos;
using LawyerUpBackend.Application.Exceptions;
using LawyerUpBackend.Application.Models.Lawyer;
using LawyerUpBackend.Core.Entities;
using LawyerUpBackend.DataAccess.Repositiories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LawyerUpBackend.Application.Services.Impl
{
    public class LawyerService : ILawyerService
    {
        private readonly ILawyerRepostiory _repository;
        private readonly IMapper _mapper;

        public LawyerService(ILawyerRepostiory repository, IMapper mapper)
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

        public async Task<PagedResultDto<LawyerListResponseModel>> GetListByQuery(LawyerListQueryModel input)
        {
            var query = _repository.GetAll();
            if (string.IsNullOrEmpty(input.Name) == false)
            {
                query = query.Where(x => x.Name.Contains(input.Name));
            }
            if (string.IsNullOrEmpty(input.Sex) == false)
            {
                string sex_zh = input.Sex == "male" ? "男" : "女";
                query = query.Where(i => i.Sex.Contains(input.Sex));
            }
            var count = await query.CountAsync();
            if (count == 0)
            {
                throw new SearchNotFoundException();
            }
            query = query.OrderBy(input.Sort).OrderBy(input.SortDesc + " desc");
            query = query.Skip((input.CurrentPage - 1) * input.MaxResultCount).Take(input.MaxResultCount);
            var result = await query.AsNoTracking().ToListAsync();
            var returnValue = new PagedResultDto<LawyerListResponseModel>()
            {
                CurrentPage = input.CurrentPage,
                TotalCount = count,
                MaxResultCount = input.MaxResultCount,
                Data = _mapper.Map<List<LawyerListResponseModel>>(result),
                FilterText = input.FilterText,
                Sort = input.Sort,
                SortDesc = input.SortDesc,
            };
            return returnValue;
        }
    }

}

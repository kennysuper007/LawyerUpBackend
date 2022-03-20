using LawyerUpBackend.Application.Models.Lawyer;
using LawyerUpBackend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawyerUpBackend.Application.Services
{
    public interface ILawyerService
    {
        Task<IEnumerable<LawyerListResponseModel>> GetAllAsync();
        Task<LawyerResponseModel> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<LawyerListResponseModel>> GetListByQuery(string query);

    }
}

using LawyerUpBackend.Application.Models.Case;
using LawyerUpBackend.DataAccess.Repositiories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawyerUpBackend.Application.Services.Impl
{
    public class CaseService : ICaseService
    {
        private readonly ICaseRepository repository;
        public CaseService(ICaseRepository _repository)
        {
            this.repository = _repository;
        }
        public async Task<CaseListResponseModel> SearchCaseList(string queryString)
        {
            throw new NotImplementedException();

        }
    }
}

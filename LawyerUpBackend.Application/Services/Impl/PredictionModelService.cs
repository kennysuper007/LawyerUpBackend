using LawyerUpBackend.Application.Models.PredictionModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawyerUpBackend.Application.Services.Impl
{
    public class PredictionModelService : IPredictionModelService
    {

        Task<PredictionModelResult> IPredictionModelService.GetPredictionAsync(string querywords)
        {
            throw new NotImplementedException();
        }
    }
}

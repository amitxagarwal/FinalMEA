using Kmd.Momentum.Mea.Caseworker.Model;
using Kmd.Momentum.Mea.Common.Exceptions;
using Kmd.Momentum.Mea.TaskApi.Model;
using System;
using System.Threading.Tasks;

namespace Kmd.Momentum.Mea.Caseworker
{
    public interface ICaseworkerService
    {
        Task<ResultOrHttpError<CaseworkerList, Error>> GetAllCaseworkersAsync(int pagenumber);

        Task<ResultOrHttpError<CaseworkerDataResponseModel, Error>> GetCaseworkerByIdAsync(Guid id);

        Task<ResultOrHttpError<TaskList, Error>> GetAllTasksForCaseworkerIdAsync(Guid caseworkerId, int pagenumber);

    }
}

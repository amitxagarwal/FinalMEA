using Kmd.Momentum.Mea.Common.Exceptions;
using Kmd.Momentum.Mea.Common.MeaHttpClient;
using Kmd.Momentum.Mea.TaskApi.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kmd.Momentum.Mea.MeaHttpClientHelper
{
    public class TaskHttpClientHelper : ITaskHttpClientHelper
    {
        private readonly IMeaClient _meaClient;
        private readonly IFilterData _filterData;

        public TaskHttpClientHelper(IMeaClient meaClient, IFilterData filterData)
        {
            _meaClient = meaClient ?? throw new ArgumentNullException(nameof(meaClient));
            _filterData = filterData;
        }

        public async Task<ResultOrHttpError<string, Error>> UpdateTaskStatusByTaskIdFromMomentumCoreAsync(string path)
        {
            var response = await _meaClient.PutAsync(path).ConfigureAwait(false);

            if (response.IsError)
            {
                return new ResultOrHttpError<string, Error>(response.Error, response.StatusCode.Value);
            }

            var content = response.Result;
            
            var item = JsonConvert.DeserializeObject<TaskData>(content);
            var model = new TaskDataResponseModel(item.Id, item.Title, item.Description, item.Deadline, item.CreatedAt,
                item.StateChangedAt, item.State, (IReadOnlyList<AssignedActors>)item.AssignedActors, item.Reference);
            
            var parseContent = (JsonConvert.DeserializeObject<JToken>(JsonConvert.SerializeObject(model)));
            
            var scrambledData = _filterData.ScrambleData(parseContent, typeof(TaskDataResponseModel));
            
            return new ResultOrHttpError<string, Error>(scrambledData.ToString());
        }
    }

}


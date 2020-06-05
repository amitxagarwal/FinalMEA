﻿using Kmd.Momentum.Mea.Common.Exceptions;
using Kmd.Momentum.Mea.TaskApi.Model;
using System;
using System.Threading.Tasks;

namespace Kmd.Momentum.Mea.TaskApi
{
    public interface ITaskService
    {
        Task<ResultOrHttpError<TaskDataResponseModel, Error>> UpdateTaskStatusByIdAsync(Guid taskId, TaskUpdateStatus taskUpdateStatus);
    }
}

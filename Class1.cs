using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// UiPath specific references
using System.Activities;
using System.ComponentModel;
using UiPath.Studio.Api;
using UiPath.Studio.Activities.Api.Settings;
using UiPath.Robot.Activities.Api;
using System.Diagnostics;

namespace CustomLogDemo
{
    public class MyLogMessageActivity : CodeActivity
    {
        protected override void Execute(CodeActivityContext context)
        {
            var executorRuntime = context.GetExtension<IExecutorRuntime>();
            var jobInfo = executorRuntime.RunningJobInformation;
            executorRuntime.LogMessage(new LogMessage
            {
                EventType = TraceEventType.Warning,
                Message = $"Warning Log - Job {jobInfo.JobId}: My log message from workflow {jobInfo.WorkflowFilePath}"
            });

            // Warning log message
            executorRuntime.LogMessage(new LogMessage
            {
                EventType = TraceEventType.Error,
                Message = $"Error Log - Job {jobInfo.JobId}: My log message from workflow {jobInfo.WorkflowFilePath}"
            });

            // Information log message
            executorRuntime.LogMessage(new LogMessage
            {
                EventType = TraceEventType.Information,
                Message = $"Information Log - Job {jobInfo.JobId}: My log message from workflow {jobInfo.WorkflowFilePath}"
            });
        }
    }
}

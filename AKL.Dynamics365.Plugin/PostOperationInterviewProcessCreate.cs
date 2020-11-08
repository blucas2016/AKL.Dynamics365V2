using System;
using System.Linq;
using Microsoft.Xrm.Sdk;
using AKL.Dynamics365.Entities;
using AKL.Dynamics365.Plugin.Presenter;

namespace AKL.Dynamics365.Plugin
{
    [CrmPluginRegistration(
          message: "Create",
          entityLogicalName: "bru_interview_process",
          stage: StageEnum.PostOperation,
          executionMode: ExecutionModeEnum.Synchronous,
          filteringAttributes: "",
          stepName: "PostOperationInterviewProcessCreate: Create of InterviewProcess",
          executionOrder: 1,
          isolationModel: IsolationModeEnum.Sandbox,
          Image1Type = ImageTypeEnum.PostImage,
          Image1Name = "PostImage",
          Image1Attributes = "bru_name",
          Description = "Reserved for operations that need to be performed only after an InterviewProcess is created",
          Id = "95F6C1FC-AF8D-4FC4-8BF1-2B758A6E61F1"
      )]
    public class PostOperationInterviewProcessCreate : PluginBase
    {

        public PostOperationInterviewProcessCreate() : base(typeof(PostOperationInterviewProcessCreate))
        {

        }

        protected override void ExecuteCrmPlugin(LocalPluginContext localContext)
        {
            if (localContext == null) throw new ArgumentNullException(nameof(localContext));
            IPluginExecutionContext context = localContext.PluginExecutionContext;
            
            const string target = PluginConstants.Target;            
            if (!context.InputParameters.Contains(target) || !(context.InputParameters[target] is Entity)) return;
            
            Entity entity = (Entity)context.InputParameters[target];
           
            bru_interview_process interview_process = entity.ToEntity<bru_interview_process>();
            Entity PostImage = context.PostEntityImages.FirstOrDefault(i => i.Key == PluginConstants.PostImage).Value;

            if (!string.Equals(interview_process.LogicalName, bru_interview_process.EntityLogicalName, StringComparison.CurrentCultureIgnoreCase)) return;
            if (!string.Equals(context.MessageName, PluginConstants.Create, StringComparison.CurrentCultureIgnoreCase)) return;

            try
            {
                using (XrmSvc xrmContext = new XrmSvc(localContext.OrganizationService))
                {
                    var presenter = new InterviewProcessPresenter(xrmContext, localContext.OrganizationService, localContext.TracingService);
                    presenter.AddInterviewToInterviewProcess(interview_process);

                }
            }
            catch (Exception exception)
            {
                string errorMessage = exception.InnerException != null ? $"{exception.Message} | {exception.InnerException.Message}" : exception.Message;
                throw new InvalidPluginExecutionException($"An error has occurred while executing the 'pre-operation contact create' plug-in. The exception thrown was: {errorMessage}");
            }


        }


    }
}

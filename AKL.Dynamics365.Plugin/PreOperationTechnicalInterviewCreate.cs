
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using AKL.Dynamics365.Entities;
using AKL.Dynamics365.Plugin.Presenter;

namespace AKL.Dynamics365.Plugin
{
    [CrmPluginRegistration(
           message: "Create",
           entityLogicalName: "bru_technicalinterview",
           stage: StageEnum.PreOperation,
           executionMode: ExecutionModeEnum.Synchronous,
           filteringAttributes: "",
           stepName: "PreOperationTechnicalInterviewCreate: Creation of bru_technicalinterview",
           executionOrder: 1,
           isolationModel: IsolationModeEnum.Sandbox,
           Description = "PreOperationTechnicalInterviewCreate: Creation of bru_technicalinterview",
           Id = "144E6BFE-675C-42F7-A0BD-B142FCC70D90"
       )]
    public class PreOperationTechnicalInterviewCreate : PluginBase
    {

        public PreOperationTechnicalInterviewCreate() : base(typeof(PreOperationTechnicalInterviewCreate))
        {

        }

        protected override void ExecuteCrmPlugin(LocalPluginContext localContext)
        {
           
            IPluginExecutionContext context = localContext.PluginExecutionContext;
            const string target = PluginConstants.Target;
           
            Entity entity = (Entity)context.InputParameters[target];
            bru_technicalinterview technicalinterview = entity.ToEntity<bru_technicalinterview>();
           


            try
            {
                using (XrmSvc xrmContext = new XrmSvc(localContext.OrganizationService))
                {
                    var presenter = new TechnicalInterviewPresenter(xrmContext, localContext.TracingService);
                    presenter.GenerateName(xrmContext, technicalinterview);
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

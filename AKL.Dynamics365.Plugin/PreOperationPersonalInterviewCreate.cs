
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
           entityLogicalName: "bru_personalinterview",
           stage: StageEnum.PreOperation,
           executionMode: ExecutionModeEnum.Synchronous,
           filteringAttributes: "",
           stepName: "PreOperationPersonalInterviewCreate: Creation of bru_personalinterview",
           executionOrder: 1,
           isolationModel: IsolationModeEnum.Sandbox,          
           Description = "PreOperationPersonalInterviewCreate: Creation of bru_personalinterview",
           Id = "6EE94F36-EB85-41E0-988F-B4185924BE4D"
       )]
    public class PreOperationPersonalInterviewCreate : PluginBase
    {

        public PreOperationPersonalInterviewCreate() : base(typeof(PreOperationApplicationUpdate))
        {

        }

        protected override void ExecuteCrmPlugin(LocalPluginContext localContext)
        {
           
            IPluginExecutionContext context = localContext.PluginExecutionContext;           
            const string target = PluginConstants.Target;            
            Entity entity = (Entity)context.InputParameters[target];
            bru_personalinterview personalinterview = entity.ToEntity<bru_personalinterview>();


           

            try
            {
                using (XrmSvc xrmContext = new XrmSvc(localContext.OrganizationService))
                {
                    var presenter = new PersonalInterviewPresenter(xrmContext, localContext.TracingService);
                    presenter.GenerateName(xrmContext, personalinterview);
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


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using AKL.Dynamics365.Entities;


namespace AKL.Dynamics365.Plugin
{
    [CrmPluginRegistration(
           message: "Update",
           entityLogicalName: "bru_jobapplication",
           stage: StageEnum.PreOperation,
           executionMode: ExecutionModeEnum.Synchronous,
           filteringAttributes: "",
           stepName: "PreOperationApplicationUpdate: Update of Application",
           executionOrder: 1,
           isolationModel: IsolationModeEnum.Sandbox,
           Image1Type = ImageTypeEnum.PreImage,
           Image1Name = "PreImage",
           Image1Attributes = "",
           Description = "PreOperationApplicationUpdate: Update of Application",
           Id = "BBD3443E-F471-448C-A7E0-F6352568E7C9"
       )]
    public class PreOperationApplicationUpdate : PluginBase
    {

        public PreOperationApplicationUpdate() : base(typeof(PreOperationApplicationUpdate))
        {

        }

        protected override void ExecuteCrmPlugin(LocalPluginContext localContext)
        {

            IPluginExecutionContext context = localContext.PluginExecutionContext;
            const string target = PluginConstants.Target;

            Entity entity = (Entity)context.InputParameters[target];
            bru_jobapplication jobapplication = entity.ToEntity<bru_jobapplication>();

            Entity preImage = context.PreEntityImages.FirstOrDefault(i => i.Key == PluginConstants.PreImage).Value;

            try
            {
                using (XrmSvc xrmContext = new XrmSvc(localContext.OrganizationService))
                {

                    
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

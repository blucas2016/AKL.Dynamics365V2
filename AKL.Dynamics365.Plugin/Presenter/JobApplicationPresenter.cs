using System;
using AKL.Dynamics365.Entities;
using Microsoft.Xrm.Sdk;
using System.Linq;

namespace AKL.Dynamics365.Plugin.Presenter
{
    public class JobApplicationPresenter
    {
        private readonly XrmSvc _xrmContext;
        private readonly ITracingService _tracer;

        public JobApplicationPresenter(XrmSvc xrmContext, ITracingService tracer)
        {
            if (xrmContext == null) throw new ArgumentNullException(nameof(xrmContext));
            _xrmContext = xrmContext;
            _tracer = tracer;
        }

        public void BlockDoubleApplication(XrmSvc xrmContext, Entity PreImage)
        {
            _tracer.Trace("Start application update");

            var applicant = ((EntityReference)PreImage.Attributes["bru_applicant"]).Id;

            var jobapplication = (from c in xrmContext.bru_jobapplicationSet
                                                 where c.bru_Applicant.Id == applicant
                                                 select c).ToList();

            //if (jobapplication.Count() > 1)
            //{

            //    throw new InvalidPluginExecutionException("This user has applied already");
            //}
            //else
            //{
            //    throw new InvalidPluginExecutionException("This user has NOT applied already");
            //}

        }

    }
}

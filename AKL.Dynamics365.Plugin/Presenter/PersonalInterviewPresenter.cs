using System;
using AKL.Dynamics365.Entities;
using Microsoft.Xrm.Sdk;
using System.Linq;

namespace AKL.Dynamics365.Plugin.Presenter
{
    public class PersonalInterviewPresenter
    {

        private readonly XrmSvc _xrmContext;
        private readonly ITracingService _tracer;

        public PersonalInterviewPresenter(XrmSvc xrmContext, ITracingService tracer)
        {
            if (xrmContext == null) throw new ArgumentNullException(nameof(xrmContext));
            _xrmContext = xrmContext;
            _tracer = tracer;
        }

        public void GenerateName(XrmSvc xrmContext, bru_personalinterview personalInterview)
        {
            _tracer.Trace("Start application update");


        }

    }
}

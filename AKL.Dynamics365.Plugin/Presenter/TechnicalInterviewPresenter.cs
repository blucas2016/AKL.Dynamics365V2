using System;
using AKL.Dynamics365.Entities;
using Microsoft.Xrm.Sdk;
using System.Linq;

namespace AKL.Dynamics365.Plugin.Presenter
{
    public class TechnicalInterviewPresenter
    {

        private readonly XrmSvc _xrmContext;
        private readonly ITracingService _tracer;

        public TechnicalInterviewPresenter(XrmSvc xrmContext, ITracingService tracer)
        {
            if (xrmContext == null) throw new ArgumentNullException(nameof(xrmContext));
            _xrmContext = xrmContext;
            _tracer = tracer;
        }

        public void GenerateName(XrmSvc xrmContext, bru_technicalinterview technicalinterview)
        {
            _tracer.Trace("Start application update");

            


        }

    }
}

using System;
using AKL.Dynamics365.Entities;
using Microsoft.Xrm.Sdk;
using System.Linq;

namespace AKL.Dynamics365.Plugin.Presenter
{
    public class InterviewProcessPresenter
    {
        private readonly XrmSvc _xrmContext;
        private readonly ITracingService _tracer;
        private readonly IOrganizationService _service;

        public InterviewProcessPresenter(XrmSvc xrmContext,IOrganizationService service, ITracingService tracer)
        {
            if (xrmContext == null) throw new ArgumentNullException(nameof(xrmContext));
            _xrmContext = xrmContext;
            _service = service;
            _tracer = tracer;
        }

        public void AddInterviewToInterviewProcess(bru_interview_process interviewProcess)
        {
            _tracer.Trace("Start AddInterviewToInterviewProcess");

            var candidate = (from c in _xrmContext.ContactSet
                         where c.Id == interviewProcess.bru_candidate.Id
                             select c).FirstOrDefault();

            var candidateName = (candidate != null) ? candidate.FullName : Guid.NewGuid().ToString();


            var roles = (from c in _xrmContext.bru_jobroleSet
                              where c.bru_jobroleId == interviewProcess.bru_JobRole.Id
                              select c).FirstOrDefault();

            if (roles != null)
            {
                //create personal Interview
                if (roles.bru_PersonalInterviewType.Value == bru_personalinterviewtype.Developer) 
                {
                    var personalinterview = new bru_personalinterview();
                    personalinterview.bru_name = candidateName + " - " + "Personal Interview Interview";
                    var x = _service.Create(personalinterview);
                    var relationship = new Relationship("bru_bru_interview_process_bru_personalintervi");                    
                    var accountReferences = new EntityReferenceCollection();                   
                    
                    accountReferences.Add(interviewProcess.ToEntityReference());
                    
                    _service.Associate(bru_personalinterview.EntityLogicalName, x, relationship, accountReferences);
                }

                //bru_bru_interview_process_bru_technicalinterv
                //create personal Interview
                if (roles.bru_TechnicalInterviewtype.Value == bru_technicalinterviewtype.Dynamics365Developer)
                {
                    var technicalinterview = new bru_technicalinterview();
                    technicalinterview.bru_name = candidateName + " - " + "Technical Interview";

                    var technicalInterviewID = _service.Create(technicalinterview);
                    var relationship = new Relationship("bru_bru_interview_process_bru_technicalinterv");
                    var entityReferenceCollection = new EntityReferenceCollection();
                    entityReferenceCollection.Add(interviewProcess.ToEntityReference());
                    _service.Associate(bru_technicalinterview.EntityLogicalName, technicalInterviewID, relationship, entityReferenceCollection);
                }

            }
            else
            {
                throw new InvalidPluginExecutionException("This user has NOT applied already");
            }

        }

    }
}

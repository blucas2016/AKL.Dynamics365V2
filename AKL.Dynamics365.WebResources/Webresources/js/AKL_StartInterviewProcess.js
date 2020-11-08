var AKL;

(function (AKL) {

    var InterviewProcess = (function () {
        function InterviewProcess() {
        }

        InterviewProcess.Create = function (formContext) {


            var confirmStrings = { text: "This action will Start an Interview Process" };
            var confirmOptions = { height: 200, width: 460 };
            Xrm.Navigation.openConfirmDialog(confirmStrings, confirmOptions).then(
                function (success) {
                    if (success.confirmed) {


                        var jobRole = (formContext.getAttribute("bru_jobrole") != null) ? formContext.getAttribute("bru_jobrole").getValue() : null;
                        var applicant = (formContext.getAttribute("bru_applicant") != null) ? formContext.getAttribute("bru_applicant").getValue() : null;

                        var entity = {};
                        entity["bru_JobRole@odata.bind"] = "/bru_jobroles(" + jobRole[0].id.replace("{", "").replace("}", "") + ")";
                        entity["bru_candidate@odata.bind"] = "/contacts(" + applicant[0].id.replace("{", "").replace("}", "") + ")";

                        var req = new XMLHttpRequest();
                        req.open("POST", Xrm.Page.context.getClientUrl() + "/api/data/v9.1/bru_interview_processes", true);
                        req.setRequestHeader("OData-MaxVersion", "4.0");
                        req.setRequestHeader("OData-Version", "4.0");
                        req.setRequestHeader("Accept", "application/json");
                        req.setRequestHeader("Content-Type", "application/json; charset=utf-8");
                        req.onreadystatechange = function () {
                            if (this.readyState === 4) {
                                req.onreadystatechange = null;
                                if (this.status === 204) {
                                    var uri = this.getResponseHeader("OData-EntityId");
                                    var regExp = /\(([^)]+)\)/;
                                    var matches = regExp.exec(uri);
                                    var newEntityId = matches[1];

                                    var entityFormOptions = {};
                                    entityFormOptions["entityName"] = "bru_interview_process";
                                    entityFormOptions["entityId"] = newEntityId;
                                                                       
                                    // Open the form.
                                    Xrm.Navigation.openForm(entityFormOptions).then(
                                        function (success) {
                                            console.log(success);
                                        },
                                        function (error) {
                                            console.log(error);
                                        });


                                } else {
                                    Xrm.Utility.alertDialog(this.response);
                                }
                            }
                        };
                        req.send(JSON.stringify(entity));           

                    }
                    else {
                        //Do something on click of Cancel.
                    }
                });
                             
            
        };

        return InterviewProcess;
    }());

    AKL.InterviewProcess = InterviewProcess;
})(AKL || (AKL = {}));
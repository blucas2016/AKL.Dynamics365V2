var AKL;

(function (AKL) {

    var InterviewProcess = (function () {
        function InterviewProcess() {
        }

        InterviewProcess.ScheduleInterview = function (formContext) {
            debugger;

            var data = {
                text: formContext.data.entity.getPrimaryAttributeValue(),
                date: formContext.getAttribute("createdon").getValue()
            };

            var dialogParameters = {
                pageType: "webresource",
                webresourceName: "bru_/AKL_REACT_SetUpJobInterview.html",
                data: JSON.stringify(data)
            };

            var navigationOptions = {
                target: 2,
                width: 400,
                height: 300,
                position: 1
            };

            Xrm.Navigation.navigateTo(dialogParameters, navigationOptions).then(
                function (returnValue) {
                    console.log(returnValue);
                    
                },
                function (e) {
                    Xrm.Navigation.openErrorDialog(e);
                });

        };        

        return InterviewProcess;
    }());

    AKL.InterviewProcess = InterviewProcess;
})(AKL || (AKL = {}));
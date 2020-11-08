var AKL;

(function (AKL) {

    var Contact = (function () {
        function Contact() {
        }

        Contact.ValidateEmail = function (email) {


            const re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
           
            if (!re.test(String(email).toLowerCase()))
            {            

                var alertStrings = { confirmButtonLabel: "Yes", text: "Please enter a Valid Email", title: "Invalid Email Format!" };
                var alertOptions = { height: 120, width: 260 };

                Xrm.Navigation.openAlertDialog(alertStrings, alertOptions).then(
                    function success(result) {
                        console.log("Alert dialog closed");
                    },
                    function (error) {
                        console.log(error.message);
                    }
                );
                return false;
            }
            return true;
        };

        Contact.OnSave = function (executionContext) {
            
            var formContext = executionContext.getFormContext();
            var eventArgs = executionContext.getEventArgs();
            var email = (formContext.getAttribute("bru_registrationemail") != null) ? formContext.getAttribute("bru_registrationemail").getValue() : null;
            if (email != null) {
                if (!Contact.ValidateEmail(email)) {
                    eventArgs.preventDefault();
                }
            }
        };

        return Contact;
    }());

    AKL.Contact = Contact;
})(AKL || (AKL = {}));
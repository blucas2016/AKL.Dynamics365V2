var Intergen;

(function (Intergen) {

    var PhoneCall = (function () {
        function PhoneCall() {
        }

        PhoneCall.SetToContact = function () {
            /// <summary>Set the "To Contact" attribute.</summary>

            // Get "to" activity party
            var party = Xrm.Page.getAttribute("to").getValue();

            if (party === null) {
                Xrm.Page.getAttribute("int_tocontact").setValue(null);
                return;
            }

            // Get first contact in party
            for (var i = 0; i < party.length; i++) {
                if (party[i].type === "2") {
                    var lookup = new Array();
                    lookup[0] = party[i];
                    Xrm.Page.getAttribute("int_tocontact").setValue(lookup);
                    return;
                }
            }
        };

        return PhoneCall;
    }());

    Intergen.PhoneCall = PhoneCall;
})(Intergen || (Intergen = {}));
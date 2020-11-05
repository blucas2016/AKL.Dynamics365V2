using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKL.Dynamics365.Plugin
{
    public static class PluginConstants
    {
        public const string Target = "Target";

        /// <summary>
        /// The create value.
        /// </summary>
        public const string Create = "Create";

        /// <summary>
        /// The update value.
        /// </summary>
        public const string Update = "Update";

        /// <summary>
        /// The pre image value.
        /// </summary>
        public const string PreImage = "PreImage";

        /// <summary>
        /// The post image value.
        /// </summary>
        public const string PostImage = "PostImage";

        /// <summary>
        /// The Marketo user's first name.
        /// </summary>
        public const string MarketoUserFirstName = "Marketo";

        /// <summary>
        /// The Marketo user's last name.
        /// </summary>
        public const string MarketoUserLastName = "Integration";

        /// <summary>
        /// The open application status code.
        /// </summary>
        public const int ApplicationStatusCodeOpen = 1;

        /// <summary>
        /// The closed application status code.
        /// </summary>
        public const int ApplicationStatusCodeClosed = 121590000;

        /// <summary>
        /// The paid enrolment status code.
        /// </summary>
        public const string EnrolmentStatusCodePaid = "P";

        /// <summary>
        /// The non-enrolled enrolment status code.
        /// </summary>
        public const string EnrolmentStatusCodeNonEnrolled = "N";

        /// <summary>
        /// The approved enrolment status code.
        /// </summary>
        public const string EnrolmentStatusCodeApproved = "A";

        /// <summary>
        /// The invoiced enrolment status code.
        /// </summary>
        public const string EnrolmentStatusCodeInvoiced = "I";

        /// <summary>
        /// The withdrawn enrolment status code.
        /// </summary>
        public const string EnrolmentStatusCodeWithdrawn = "W";
    }
}

using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class FaWeisungWorkflow
    {
        public int FaWeisungWorkflowId { get; set; }
        public int? XtaskTemplateIdRd { get; set; }
        public int? XtaskTemplateIdSar { get; set; }
        public int StatusCode { get; set; }
        public string Aktion { get; set; }
        public int? AktionTid { get; set; }
        public int NeuerStatusCode { get; set; }
        public int ZustaendigCode { get; set; }
        public bool TerminMuss { get; set; }
        public int? NaechsterTerminCode { get; set; }
        public bool NaechsterTerminAnpassen { get; set; }
        public bool PendenzSar { get; set; }
        public bool PendenzRd { get; set; }
        public bool SarpendenzAnpassen { get; set; }
        public bool WeisungErfuellt { get; set; }
        public byte[] FaWeisungWorkflowTs { get; set; }

        public XtaskTemplate XtaskTemplateIdRdNavigation { get; set; }
        public XtaskTemplate XtaskTemplateIdSarNavigation { get; set; }
    }
}

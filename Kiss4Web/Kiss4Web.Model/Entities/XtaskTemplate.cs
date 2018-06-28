using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class XtaskTemplate
    {
        public XtaskTemplate()
        {
            FaWeisungWorkflowXtaskTemplateIdRdNavigation = new HashSet<FaWeisungWorkflow>();
            FaWeisungWorkflowXtaskTemplateIdSarNavigation = new HashSet<FaWeisungWorkflow>();
        }

        public int XtaskTemplateId { get; set; }
        public int TaskTypeCode { get; set; }
        public int TaskStatusCode { get; set; }
        public string TaskSubject { get; set; }
        public int? TaskSubjectTid { get; set; }
        public string TaskDescription { get; set; }
        public int? TaskDescriptionTid { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] XtaskTemplateTs { get; set; }

        public ICollection<FaWeisungWorkflow> FaWeisungWorkflowXtaskTemplateIdRdNavigation { get; set; }
        public ICollection<FaWeisungWorkflow> FaWeisungWorkflowXtaskTemplateIdSarNavigation { get; set; }
    }
}

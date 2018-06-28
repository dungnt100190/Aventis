using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class XtaskTypeAction
    {
        public int XtaskTypeActionId { get; set; }
        public int XtaskTypeActionTypeCode { get; set; }
        public int TaskTypeCode { get; set; }
        public string Bezeichnung { get; set; }
        public int? BezeichnungTid { get; set; }
        public string Betreff { get; set; }
        public int? BetreffTid { get; set; }
        public string Text { get; set; }
        public int? TextTid { get; set; }
        public bool BenachrichtigungAktiv { get; set; }
        public bool ErstellerDarfAusfuehren { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] XtaskTypeActionTs { get; set; }
    }
}

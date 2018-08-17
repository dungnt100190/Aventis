using System;
using System.Collections.Generic;

namespace Kiss.Interfaces.ViewModel
{
    [Flags]
    public enum InitParameterValue
    {
        Title = 1,
        BaPersonID = 2,
        FaFallID = 4,
        FaLeistungID = 8,
        CustomData = 16,
    }

    public struct InitParameters
    {
        public int? BaPersonID { get; set; }

        public Dictionary<string, object> CustomData { get; set; }

        public int? FaFallID { get; set; }

        public int? FaLeistungID { get; set; }

        public string Title { get; set; }
    }
}
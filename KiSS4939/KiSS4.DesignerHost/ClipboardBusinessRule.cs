using System;
using System.Runtime.Serialization;

namespace KiSS4.DesignerHost
{
	/// <summary>
	/// Class to capsle all required fields of a business rule within one element
	/// </summary>
	[Serializable]
	public class ClipboardBusinessRule : ISerializable
	{
		#region Fields

		/// <summary>
		/// Set if a rule is active (XClassRule.Active, not null).
		/// </summary>
		private Boolean _Active = true;

		/// <summary>
		/// Set the sortkey of the rule (XClassRule.SortKey, not null).
		/// </summary>
		private Int32 _SortKey = 100;

		/// <summary>
		/// Set the controlname of the rule (XClassControl.ControlName not null), can be null here. 
		/// </summary>
		private String _ControlName = String.Empty;

		/// <summary>
		/// Set the componentname of the rule (XClassComponent.ComponentName not null), can be null here. 
		/// </summary>
		private String _ComponentName = String.Empty;

		/// <summary>
		/// Set the name of the rule (XRule.RuleName, null).
		/// </summary>
		private String _RuleName = String.Empty;

		/// <summary>
		/// Set the description of the rule (XRule.RuleDescription, null)
		/// </summary>
		private String _RuleDescription = String.Empty;

		/// <summary>
		/// Set the rule type/code of the rule (XRule.RuleCode, not null)
		/// </summary>
		private Int32 _RuleCode = -1;

		/// <summary>
		/// Set the c# code of the rule (XRule.csCode, null)
		/// </summary>
		private String _CsCode = String.Empty;

		/// <summary>
		/// Set if a rule is a public rule (XRule.PublicRule, not null)
		/// </summary>
		private Boolean _PublicRule = false;

		/// <summary>
		/// Set if a rule is a template rule (XRule.TemplateRule, not null)
		/// </summary>
		private Boolean _TemplateRule = false;

		#endregion

		#region Constructor

		/// <summary>
		/// Default constructor
		/// </summary>
		public ClipboardBusinessRule()
		{
			// nothing special here...
		}

		/// <summary>
		/// Constructor to call when creating a new serialized instance
		/// </summary>
		/// <param name="info">The <see cref="SerializationInfo"/> parameter</param>
		/// <param name="context">The <see cref="StreamingContext"/> parameter</param>
		protected ClipboardBusinessRule(SerializationInfo info, StreamingContext context)
        {
			// validate parameter
			if (info == null)
			{
				throw new System.ArgumentNullException("info");
			}
 
			// apply data
			this.Active = info.GetBoolean("Active");
			this.SortKey = info.GetInt32("SortKey");
			this.ControlName = info.GetString("ControlName");
			this.ComponentName = info.GetString("ComponentName");
			this.RuleName = info.GetString("RuleName");
			this.RuleDescription = info.GetString("RuleDescription");
			this.RuleCode = info.GetInt32("RuleCode");
			this.CsCode = info.GetString("CsCode");
			this.PublicRule = info.GetBoolean("PublicRule");
			this.TemplateRule = info.GetBoolean("TemplateRule");        
        }

		#endregion

		#region Properties

		/// <summary>
		/// Set and get if a rule is active (XClassRule.Active, not null).
		/// </summary>
		public Boolean Active
		{
			set { this._Active = value; }
			get { return this._Active; }
		}

		/// <summary>
		/// Set and get the sortkey of the rule (XClassRule.SortKey, not null).
		/// </summary>
		public Int32 SortKey
		{
			set { this._SortKey = value; }
			get { return this._SortKey; }
		}

		/// <summary>
		/// Set the controlname of the rule (XClassControl.ControlName not null), can be null here. 
		/// </summary>
		public String ControlName
		{
			set { this._ControlName = value; }
			get { return this._ControlName; }
		}

		/// <summary>
		/// Set the componentname of the rule (XClassComponent.ComponentName not null), can be null here. 
		/// </summary>
		public String ComponentName
		{
			set { this._ComponentName = value; }
			get { return this._ComponentName; }
		}

		/// <summary>
		/// Set and get the name of the rule (XRule.RuleName, null).
		/// </summary>
		public String RuleName
		{
			set { this._RuleName = value; }
			get { return this._RuleName; }
		}

		/// <summary>
		/// Set and get the description of the rule (XRule.RuleDescription, null)
		/// </summary>
		public String RuleDescription
		{
			set { this._RuleDescription = value; }
			get { return this._RuleDescription; }
		}

		/// <summary>
		/// Set and get the rule type/code of the rule (XRule.RuleCode, not null)
		/// </summary>
		public Int32 RuleCode
		{
			set { this._RuleCode = value; }
			get { return this._RuleCode; }
		}

		/// <summary>
		/// Set and get the c# code of the rule (XRule.csCode, null)
		/// </summary>
		public String CsCode
		{
			set { this._CsCode = value; }
			get { return this._CsCode; }
		}

		/// <summary>
		/// Set and get if a rule is a public rule (XRule.PublicRule, not null)
		/// </summary>
		public Boolean PublicRule
		{
			set { this._PublicRule = value; }
			get { return this._PublicRule; }
		}

		/// <summary>
		/// Set and get if a rule is a template rule (XRule.TemplateRule, not null)
		/// </summary>
		public Boolean TemplateRule
		{
			set { this._TemplateRule = value; }
			get { return this._TemplateRule; }
		}

		#endregion

		#region ISerializable Members

		/// <summary>
		/// Get object data that can be serialized by framework
		/// </summary>
		/// <param name="info">The <see cref="SerializationInfo"/> parameter</param>
		/// <param name="context">The <see cref="StreamingContext"/> parameter</param>
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			// validate parameter
			if (info == null)
			{
				throw new System.ArgumentNullException("info");
			}

			// add type to info
			//info.SetType(typeof(ClipboardBusinessRule));

			// add values to info, these values will be serialized
			info.AddValue("Active", this.Active);
			info.AddValue("SortKey", this.SortKey);
			info.AddValue("ControlName", this.ControlName);
			info.AddValue("ComponentName", this.ComponentName);
			info.AddValue("RuleName", this.RuleName);
			info.AddValue("RuleDescription", this.RuleDescription);
			info.AddValue("RuleCode", this.RuleCode);
			info.AddValue("CsCode", this.CsCode);
			info.AddValue("PublicRule", this.PublicRule);
			info.AddValue("TemplateRule", this.TemplateRule);
		}

		#endregion
	}
}

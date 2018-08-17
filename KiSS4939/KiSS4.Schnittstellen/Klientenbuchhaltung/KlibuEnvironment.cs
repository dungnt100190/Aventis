using System;
using System.Diagnostics;

//using Microsoft.Win32;

using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Messages;

namespace KiSS4.Schnittstellen
{
	public enum KlibuSystem
	{
		None,       //falls gar kein Umsystem und keine Klibu verwendet wird
		Abacus,     //Untersützte Version 2008
        Sesam,      //Untersützte Version 2008.1 
        Klibu       //KiSS intern
	}

	/// <summary>
	/// Base class for a fibu environment
	/// </summary>
	public abstract class KlibuEnvironment
	{
		/// <summary>
		/// The key where all config values are stored.
		/// </summary>
		public const string CnfFibuLink     = @"System\FibuLink";         // root key for all FibuLink entries (Sozialhilfe)
		public const string cnfFibuSys      = @"System\FibuLink\FibuSys"; // config key to get the FibuSys from (Sozialhilfe)
		public const string CnfFibuLinkAsyl = @"System\FibuLinkAsyl";     // root key for all FibuLink entries (Asyl)
		public const string cnfFibuSysAsyl  = @"System\FibuLinkAsyl\FibuSys"; // config key to get the FibuSys from (Asyl)

		protected ModulCode modul;
		private bool isActive;
		private LogonInfo logonInfo;
		private MandantPeriode manPer;
		private CtlLogon ctlLogon;
		private CtlSelManPer ctlSelManPer;

        private KlibuSystem klibuSystem;

        public static KlibuEnvironment GetKlibuEnvironment(ModulCode Modul)
		{
			// get actual FibuSys from XConfig
			string fibuSysConfig = null;

			if (Modul == ModulCode.S)
				fibuSysConfig = (string) DBUtil.GetConfigValue(cnfFibuSys, null);
			else if (Modul == ModulCode.A)
				fibuSysConfig = (string) DBUtil.GetConfigValue(cnfFibuSysAsyl, null);

			KlibuSystem sys;
			if (fibuSysConfig == null)
				sys = KlibuSystem.None;
			else
				try { sys = (KlibuSystem) Enum.Parse(typeof(KlibuSystem), fibuSysConfig, true); }
				catch { throw new ApplicationException("Unbekanntes Fibu-System \"" + fibuSysConfig + "\"."); }

            KlibuEnvironment ret;

			switch (sys)
			{
				case KlibuSystem.None:
					ret = null;
					break;

				case KlibuSystem.Simultan:
					ret = new Simultan.FibuEnvironment(Modul);
					break;
				case KlibuSystem.Abacus:
					ret = new Abacus.FibuEnvironment(Modul);
					break;
				case KlibuSystem.Sesam:
					ret = new Sesam.FibuEnvironment(Modul);
					break;
				default:
					throw new ApplicationException("internal error");
			}

			Debug.Assert(ret == null || ret.Sys == sys);

			return ret;
		}

		/// <summary>
		/// Gets the FibuSys specific root key (e.g. CnfFibuLink + "\Sesam")
		/// </summary>
		protected string CnfFibuSysRoot
		{
			get 
			{
				if (this.modul == ModulCode.S)
					return string.Format(@"{0}\{1}", CnfFibuLink, this.Sys);
				else if (this.modul == ModulCode.A)
					return string.Format(@"{0}\{1}", CnfFibuLinkAsyl, this.Sys);
				else
					return "";
			}
		}

		/// <summary>
		/// Gets a value indicating whether the Fibu-System is activated.
		/// </summary>
		public bool IsActive
		{
			get { return this.isActive; }
		}

		/// <summary>
		/// Gets a value indicating whether the user is logged on.
		/// </summary>
		public bool IsLoggedOn
		{
			get { return this.isActive && this.logonInfo != null; }
		}

		public LogonInfo LogonInfo
		{
			get { return this.IsLoggedOn ? this.logonInfo : null; }
		}

		/// <summary>
		/// Gets the selected Mandant and Period.
		/// </summary>
		public MandantPeriode SelectedManPer
		{
			get
			{
				MandantPeriode ret;
				if (this.IsLoggedOn)
					ret = this.manPer;
				else
					ret = null;

				return ret;
			}
		}

		/// <summary>
		/// Gets the <see cref="CtlLogon"/> in use. (if active)
		/// </summary>
		public CtlLogon LogonControl
		{
			get
			{
				if (!this.isActive) throw new ApplicationException("Not activated.");
				// Debug.Assert(this.ctlLogon != null);
				return this.ctlLogon;
			}
		}

		/// <summary>
		/// Gets the <see cref="CtlSelManPer"/> in use. (if logged on)
		/// </summary>
		public CtlSelManPer SelManPerControl
		{
			get
			{
				if (!this.IsLoggedOn) throw new ApplicationException("not logged on.");
				Debug.Assert(this.ctlSelManPer != null);
				return this.ctlSelManPer;
			}
		}

		/// <summary>
		/// Activate the environment.
		/// </summary>
		/// <exception cref="ActivationException">Activation failed.</exception>
		/// <exception cref="Exception">Something worse happened.</exception>
		public void Activate()
		{
			if (this.isActive) throw new ApplicationException("Cannot activate twice.");
			Debug.Assert(this.ctlLogon == null);

			ActivationException actEx = null;
			try { this.ActivateCore(); this.isActive = true; }
			catch (ActivationException ex) { actEx = ex; }

			if (this.isActive)
			{
				this.ctlLogon = this.GetLogonControl();
				// if (this.ctlLogon == null) throw new ApplicationException("Inheritor returns null.");
			}
			else
			{
				Debug.Assert(actEx != null);
				throw actEx;
			}
		}

		/// <summary>
		/// Try to log on (must be active and not logged on yet)
		/// </summary>
		/// <param name="logonInfo">null for a silent logon, otherwise the logon info</param>
		/// <exception cref="LogonException">Logon failed.</exception>
		/// <exception cref="Exception">Something worse happened.</exception>
		public void Logon(LogonInfo logonInfo)
		{
			if (!this.isActive) throw new ApplicationException("Not activated.");
			//if (this.logonInfo != null) throw new ApplicationException("Cannot log on twice.");
			Debug.Assert(this.ctlSelManPer == null);

			LogonException lEx = null;
			try { this.logonInfo = this.LogonCore(logonInfo); }
			catch (LogonException ex) { lEx = ex; }

			if (this.logonInfo == null && lEx == null) throw new ApplicationException("Inheritor returns null.");

			if (this.logonInfo != null)
			{
				this.ctlSelManPer = this.GetSelManPerControl();
				if (this.ctlSelManPer == null) throw new ApplicationException("Inheritor returns null.");
			}
			else
			{
				Debug.Assert(lEx != null);
				throw lEx;
			}
		}

		public void SelManPer(MandantPeriode mp)
		{
			this.manPer = this.SelManPerCore(mp);
		}

		public Kreditor[] GetKreditorList(CancelProvider cp)
		{
			Debug.Assert (this.SelectedManPer != null);
			return this.GetKreditorListCore(cp);
		}

		public Kostenstelle[] GetKostenstelleList(CancelProvider cp)
		{
			Debug.Assert (this.SelectedManPer != null);
			return this.GetKostenstelleListCore(cp);
		}

		#region abstract

		public abstract KlibuSystem Sys { get; }

		/// <summary>
		/// Gets the name of the fibu system.
		/// </summary>
		public abstract string FibuName { get; }

		/// <summary>
		/// Gets a possibly more detailed description than FibuName (e.g. version information).
		/// </summary>
		public abstract string FibuFullName { get; }

		/// <summary>
		/// Gets a value indicating whether Belegnummer must be generated automatically.
		/// </summary>
		public abstract bool MustUseAutomaticBelegNr { get; }

		/// <summary>
		/// Activate the link to the fibu.
		/// </summary>
		/// <exception cref="ActivationException">If the system cannot be activated.</exception>
		/// <exception cref="Exception">Something worse happened.</exception>
		protected abstract void ActivateCore();

		/// <summary>
		/// Log on to the system.
		/// </summary>
		/// <param name="logonInfo">If null, try a silent logon. Otherwise try to logon with the specified parameters.</param>
		/// <returns>The <see cref="LogonInfo"/> used to logon.</returns>
		/// <exception cref="LogonException">Logon failed.</exception>
		/// <exception cref="Exception">Something worse happened.</exception>
		protected abstract LogonInfo LogonCore(LogonInfo logonInfo);

		/// <summary>
		/// Select mandandt and period.
		/// </summary>
		/// <param name="mp">If null, try a silent select. Otherwise, validate the parameter.</param>
		/// <returns>The <see cref="MandantPeriode"/> validated.</returns>
		/// <exception cref="Exception">Not valid.</exception>
		protected abstract MandantPeriode SelManPerCore(MandantPeriode mp);

		/// <summary>
		/// Gets the "dialog" control to prompt for logon.
		/// </summary>
		protected abstract CtlLogon GetLogonControl();

		/// <summary>
		/// Gets the "dialog" control to select Mandant and Period.
		/// </summary>
		protected abstract CtlSelManPer GetSelManPerControl();

		/// <summary>
		/// A delegate which returns true if the operation should be cancelled.
		/// </summary>
		public delegate bool CancelProvider();

		/// <summary>
		/// Gets a list of the <see cref="Kreditor"/> objects.
		/// </summary>
		/// <param name="cp">If not null, this delegate should be called during the operation. The operation should terminate if cp returns true.</param>
		/// <returns>An array <see cref="Kreditor"/> objects (or null if cancelled).</returns>
		protected abstract Kreditor[] GetKreditorListCore(CancelProvider cp);

		/// <summary>
		/// Gets a list of the <see cref="Kostenstelle"/> objects.
		/// </summary>
		/// <param name="cp">If not null, this delegate should be called during the operation. The operation should terminate if cp returns true.</param>
		/// <returns>An array <see cref="Kostenstelle"/> objects (or null if cancelled).</returns>
		protected abstract Kostenstelle[] GetKostenstelleListCore(CancelProvider cp);

		#region TransBeleg

		public interface IBeleg
		{
			string Belegnummer { get; }
			FlTransfer Transfer { get; }
			int TypSource { get; }
			DateTime Buchungsdatum { get; }
			DateTime Rechnungsdatum { get; }
			DateTime Verfalldatum { get; }
			int IdKreditor { get; }
			int IdZahlungsweg { get; }
			string Buchungstext { get; }
			string Extern { get; }
			string ESR { get; }
			decimal Betrag { get; }
			IBelegKostenart[] Kostenarten { get; }
			bool Provisorisch { get; }
		}

		public interface IBelegKostenart
		{
			string Intern { get; }
			int IdFibuKostenart { get; }
			decimal Betrag { get; }
			IBelegKostenstelle[] Kostenstellen { get; }
		}

		public interface IBelegKostenstelle
		{
			string NameFbKostenstelle { get; }
			decimal Betrag { get; }
			string NrmKonto { get; }
		}

		/// <summary>
		/// The result of transferring a new Beleg.
		/// </summary>
		public class TransferBelegResult
		{
			/// <summary>
			/// Creates an instance for a successful transfer, returning the laufnummer and belegnummer.
			/// </summary>
			public static TransferBelegResult OK(int laufnummer, string belegnummer)
			{
				if (belegnummer == null) throw new ArgumentNullException("belegnummer");
				return new TransferBelegResult(FlBelegStatus.Verbucht, laufnummer, belegnummer, null);
			}

			/// <summary>
			/// Creates an instance for a successful transfer, but with a warning, returning the laufnummer, belegnummer and a message.
			/// </summary>
			public static TransferBelegResult Warning(int laufnummer, string belegnummer, string fibuMsg)
			{
				if (belegnummer == null) throw new ArgumentNullException("belegnummer");
				if (fibuMsg == null) throw new ArgumentNullException("fibuMsg");
				return new TransferBelegResult(FlBelegStatus.Warning, laufnummer, belegnummer, fibuMsg);
			}

			/// <summary>
			/// Creates an instance for an unsuccessful transfer, returning a message.
			/// </summary>
			public static TransferBelegResult Error(string fibuMsg)
			{
				if (fibuMsg == null) throw new ArgumentNullException("fibuMsg");
				return new TransferBelegResult(FlBelegStatus.Error, -1, null, fibuMsg);
			}

			internal readonly FlBelegStatus Status; // Verbucht, Warning, Error
			internal readonly int Laufnummer; // not set if Error
			internal readonly string Belegnummer; // not set if Error
			internal readonly string FibuMsg; // null if Verbucht, non-null otherwise

			private TransferBelegResult(FlBelegStatus status, int laufnummer, string belegnummer, string fibuMsg)
			{
				this.Status = status;
				this.Laufnummer = laufnummer;
				this.Belegnummer = belegnummer;
				this.FibuMsg = fibuMsg;
			}
		}

		/// <summary>
		/// Transfer an <see cref="IBeleg"/> record to the Fibu.
		/// </summary>
		/// <param name="beleg">The <see cref="IBeleg"/> to transfer.</param>
		/// <returns>A non-null <see cref="TransferBelegResult"/>.</returns>
		/// <exception cref="Exception">Something fatal happened. It's uncertain whether the Beleg was transferred or not.</exception>
		public abstract TransferBelegResult TransferBeleg(IBeleg beleg, bool autoBelegnummer);

		#endregion

		#region Kontenabfrage

		public abstract class Buchung
		{
			public abstract DateTime Datum { get; }
			public abstract int Belegnummer { get; }
			public abstract string Kostenart { get; }
			public abstract string KostenartText { get; }
			public abstract string Buchungstext { get; }
			public abstract decimal Auszahlung { get; }
			public abstract decimal Einnahme { get; }
			public abstract decimal Saldovortrag { get; }
		}

		public abstract Buchung[] ReadBuchungen(string kstName, DateTime dateFrom, ref DateTime dateTo);

		#endregion

		#endregion

		#region virtual

		/// <summary>
		/// Called by FibuLink before transferring Belege.
		/// </summary>
		/// <param name="refDate">Transfer Month.</param>
		/// <param name="nameZahlungslauf">e.g. "ZL Sozialhilfe SKOS"</param>
		/// <remarks>
		/// The base implementation does nothing.
		/// Can be overriden by e.g. file based interfaces to open files.
		/// </remarks>
		public virtual void BelegBeginTransfer(DateTime refDate, string nameZahlungslauf) {}

		/// <summary>
		/// Called by FibuLink after transferring Belege.
		/// </summary>
		/// <remarks>
		/// The base implementation does nothing.
		/// Can be overriden by e.g. file based interfaces to close files.
		/// </remarks>
		public virtual void BelegEndTransfer() {}

		#endregion

		/// <summary>
		/// Gets the <see cref="RegistryKey"/> an inheriting class can use to store user specific information.
		/// </summary>
		public static RegistryKey UserRegistry(KlibuSystem sys, ModulCode Modul)
		{
			if (sys == KlibuSystem.None || !Enum.IsDefined(typeof(KlibuSystem), sys)) throw new ArgumentOutOfRangeException("sys");

			RegistryKey ret = Session.UserEnvDataRegistry;

			if (Modul == ModulCode.S)
				ret = ret.CreateSubKey("FibuLink");
			else if (Modul == ModulCode.A)
				ret = ret.CreateSubKey("FibuLinkAsyl");

			ret = ret.CreateSubKey(sys.ToString());
			return ret;
		}

		public static string ConfigBasePath(KlibuSystem sys, ModulCode Modul)
		{
			if (Modul == ModulCode.S)
				return string.Format(@"{0}\{1}", CnfFibuLink, sys);
			else if (Modul == ModulCode.A)
				return string.Format(@"{0}\{1}", CnfFibuLinkAsyl, sys);
			else
				return "";
		}

		/// <summary>
		/// Gets the <see cref="RegistryKey"/> an inheriting class can use to store system specific information.
		/// </summary>
		public static RegistryKey CommonRegistry(KlibuSystem sys, ModulCode Modul)
		{
			if (sys == KlibuSystem.None || !Enum.IsDefined(typeof(KlibuSystem), sys)) throw new ArgumentOutOfRangeException("sys");

			RegistryKey ret = Session.CommonEnvDataRegistry;
			if (Modul == ModulCode.S)
				ret = ret.CreateSubKey("FibuLink");
			else if (Modul == ModulCode.A)
				ret = ret.CreateSubKey("FibuLinkAsyl");

			ret = ret.CreateSubKey(sys.ToString());
			return ret;
		}

		public class ActivationException : Exception
		{
			public ActivationException(Exception innerException) : base("Activation failed.", innerException)
			{
				if (innerException == null) throw new ArgumentNullException("innerException");
			}
		}

		public class LogonException : Exception
		{
			public LogonException(Exception innerException) : base(innerException.Message, innerException)
			{
				if (innerException == null) throw new ArgumentNullException("innerException");
			}
		}
	}
}

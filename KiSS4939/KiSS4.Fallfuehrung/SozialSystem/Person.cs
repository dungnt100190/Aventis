using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using KiSS4.GraphLib;

namespace KiSS4.Fallfuehrung.SozialSystem
{
    /// <summary>
    /// A <see cref="Vertex"/> representing a person.
    /// </summary>
    public class Person : Vertex
    {
        public readonly string Age;

        public readonly Icon Icon;

        public readonly string Name;

        public readonly int PersonId;

        public readonly string Vorname;

        // female icons
        private static Icon f01Icon;

        private static Icon f05Icon;
        private static Icon f10Icon;
        private static Icon f20Icon;
        private static Icon f30Icon;
        private static Icon f40Icon;
        private static Icon f50Icon;
        private static Icon f60Icon;
        private static Icon f70Icon;

        // male icons
        private static Icon m01Icon;

        private static Icon m05Icon;
        private static Icon m10Icon;
        private static Icon m20Icon;
        private static Icon m30Icon;
        private static Icon m40Icon;
        private static Icon m50Icon;
        private static Icon m60Icon;
        private static Icon m70Icon;

        private static Icon modulAarchivedIcon;

        private static Icon modulAclosedIcon;

        private static Icon modulAIcon;

        private static Icon modulFarchivedIcon;

        private static Icon modulFclosedIcon;

        // modul icons
        private static Icon modulFIcon;

        private static Icon modulIarchivedIcon;
        private static Icon modulIclosedIcon;
        private static Icon modulIIcon;
        private static Icon modulMarchivedIcon;
        private static Icon modulMclosedIcon;
        private static Icon modulMIcon;
        private static Icon modulSarchivedIcon;
        private static Icon modulSclosedIcon;
        private static Icon modulSDisabledIcon;
        private static Icon modulSIcon;
        private static Icon modulVarchivedIcon;
        private static Icon modulVclosedIcon;
        private static Icon modulVIcon;
        private Hashtable faelle = new Hashtable();

        private bool isUnterstuetzt;

        private int moduleCount;

        private ModulStatus modulStatusA = ModulStatus.none;
        private ModulStatus modulStatusF = ModulStatus.none;
        private ModulStatus modulStatusI = ModulStatus.none;
        private ModulStatus modulStatusM = ModulStatus.none;
        private ModulStatus modulStatusS = ModulStatus.none;
        private ModulStatus modulStatusV = ModulStatus.none;

        static Person()
        {
            // load icons
            string iconsNs = MethodInfo.GetCurrentMethod().DeclaringType.Namespace + ".Icons.";

            // female icons
            f01Icon = LoadIcon(iconsNs + "f01.ico");
            f05Icon = LoadIcon(iconsNs + "f05.ico");
            f10Icon = LoadIcon(iconsNs + "f10.ico");
            f20Icon = LoadIcon(iconsNs + "f20.ico");
            f30Icon = LoadIcon(iconsNs + "f30.ico");
            f40Icon = LoadIcon(iconsNs + "f40.ico");
            f50Icon = LoadIcon(iconsNs + "f50.ico");
            f60Icon = LoadIcon(iconsNs + "f60.ico");
            f70Icon = LoadIcon(iconsNs + "f70.ico");

            // male icons
            m01Icon = LoadIcon(iconsNs + "m01.ico");
            m05Icon = LoadIcon(iconsNs + "m05.ico");
            m10Icon = LoadIcon(iconsNs + "m10.ico");
            m20Icon = LoadIcon(iconsNs + "m20.ico");
            m30Icon = LoadIcon(iconsNs + "m30.ico");
            m40Icon = LoadIcon(iconsNs + "m40.ico");
            m50Icon = LoadIcon(iconsNs + "m50.ico");
            m60Icon = LoadIcon(iconsNs + "m60.ico");
            m70Icon = LoadIcon(iconsNs + "m70.ico");

            // modul icons
            modulFIcon = LoadIcon(iconsNs + "Modul_F.ico");
            modulSIcon = LoadIcon(iconsNs + "Modul_S.ico");
            modulIIcon = LoadIcon(iconsNs + "Modul_I.ico");
            modulVIcon = LoadIcon(iconsNs + "Modul_V.ico");
            modulMIcon = LoadIcon(iconsNs + "Modul_M.ico");
            modulAIcon = LoadIcon(iconsNs + "Modul_A.ico");

            modulFclosedIcon = LoadIcon(iconsNs + "Modul_F_closed.ico");
            modulSclosedIcon = LoadIcon(iconsNs + "Modul_S_closed.ico");
            modulIclosedIcon = LoadIcon(iconsNs + "Modul_I_closed.ico");
            modulVclosedIcon = LoadIcon(iconsNs + "Modul_V_closed.ico");
            modulMclosedIcon = LoadIcon(iconsNs + "Modul_M_closed.ico");
            modulAclosedIcon = LoadIcon(iconsNs + "Modul_A_closed.ico");

            modulFarchivedIcon = LoadIcon(iconsNs + "Modul_F_archived.ico");
            modulSarchivedIcon = LoadIcon(iconsNs + "Modul_S_archived.ico");
            modulIarchivedIcon = LoadIcon(iconsNs + "Modul_I_archived.ico");
            modulVarchivedIcon = LoadIcon(iconsNs + "Modul_V_archived.ico");
            modulMarchivedIcon = LoadIcon(iconsNs + "Modul_M_archived.ico");
            modulAarchivedIcon = LoadIcon(iconsNs + "Modul_A_archived.ico");

            modulSDisabledIcon = LoadIcon(iconsNs + "Modul_S_disabled.ico");
        }

        public Person(Graph g, int personId, string name, string vorname, bool male, bool female, DateTime birthday)
            : base(g)
        {
            if (name == null) throw new ArgumentNullException("name");
            if (vorname == null) throw new ArgumentNullException("vorname");
            if (male && female) throw new ArgumentException("cannot be male and female.");

            this.PersonId = personId;
            this.Name = name;
            this.Vorname = vorname;

            int age;
            if (birthday == DateTime.MinValue)
            {
                age = 100;
                this.Age = "?";
            }
            else
            {
                age = DateTime.Today.Year - birthday.Year;
                birthday = birthday.AddYears(age);
                if (birthday > DateTime.Today)
                    age--;
                this.Age = age.ToString();
            }

            if (age <= 3)
                this.Icon = male ? m01Icon : female ? f01Icon : null;
            else if (age <= 8)
                this.Icon = male ? m05Icon : female ? f05Icon : null;
            else if (age <= 15)
                this.Icon = male ? m10Icon : female ? f10Icon : null;
            else if (age <= 25)
                this.Icon = male ? m20Icon : female ? f20Icon : null;
            else if (age <= 35)
                this.Icon = male ? m30Icon : female ? f30Icon : null;
            else if (age <= 45)
                this.Icon = male ? m40Icon : female ? f40Icon : null;
            else if (age <= 55)
                this.Icon = male ? m50Icon : female ? f50Icon : null;
            else if (age <= 65)
                this.Icon = male ? m60Icon : female ? f60Icon : null;
            else
                this.Icon = male ? m70Icon : female ? f70Icon : null;
        }

        public event EventHandler DoubleClick;

        public void AddFall(Fall fall, bool isUnterstuetzt)
        {
            if (fall == null) throw new ArgumentNullException("fall");

            PersonFall pf = new PersonFall(fall, isUnterstuetzt);
            this.faelle.Add(fall.FallId, pf);

            switch (fall.ModulCode)
            {
                case 2: UpdateModulStatus(fall.ModulStatus, ref this.modulStatusF); break;
                case 3: UpdateModulStatus(fall.ModulStatus, ref this.modulStatusS); break;
                case 4: UpdateModulStatus(fall.ModulStatus, ref this.modulStatusI); break;
                case 5: UpdateModulStatus(fall.ModulStatus, ref this.modulStatusV); break;
                case 6: UpdateModulStatus(fall.ModulStatus, ref this.modulStatusA); break;
                case 29: UpdateModulStatus(fall.ModulStatus, ref this.modulStatusM); break;
            }

            this.isUnterstuetzt |= isUnterstuetzt;
        }

        // FallId/PersonFall
        public Icon[] GetModuleIcons()
        {
            Icon[] ret = new Icon[this.moduleCount];

            int i = 0;
            switch (this.modulStatusF)
            {
                case ModulStatus.active: ret[i++] = modulFIcon; break;
                case ModulStatus.closed: ret[i++] = modulFclosedIcon; break;
                case ModulStatus.archived: ret[i++] = modulFarchivedIcon; break;
            }

            switch (this.modulStatusS)
            {
                case ModulStatus.active: ret[i++] = this.isUnterstuetzt ? modulSIcon : modulSDisabledIcon; break;
                case ModulStatus.closed: ret[i++] = modulSclosedIcon; break;
                case ModulStatus.archived: ret[i++] = modulSarchivedIcon; break;
            }

            switch (this.modulStatusI)
            {
                case ModulStatus.active: ret[i++] = modulIIcon; break;
                case ModulStatus.closed: ret[i++] = modulIclosedIcon; break;
                case ModulStatus.archived: ret[i++] = modulIarchivedIcon; break;
            }

            switch (this.modulStatusV)
            {
                case ModulStatus.active: ret[i++] = modulVIcon; break;
                case ModulStatus.closed: ret[i++] = modulVclosedIcon; break;
                case ModulStatus.archived: ret[i++] = modulVarchivedIcon; break;
            }

            switch (this.modulStatusM)
            {
                case ModulStatus.active: ret[i++] = modulMIcon; break;
                case ModulStatus.closed: ret[i++] = modulMclosedIcon; break;
                case ModulStatus.archived: ret[i++] = modulMarchivedIcon; break;
            }

            switch (this.modulStatusA)
            {
                case ModulStatus.active: ret[i++] = modulAIcon; break;
                case ModulStatus.closed: ret[i++] = modulAclosedIcon; break;
                case ModulStatus.archived: ret[i++] = modulAarchivedIcon; break;
            }

            Debug.Assert(i == this.moduleCount);

            return ret;
        }

        public PersonFall GetPersonFall(int fallId)
        {
            return (PersonFall)this.faelle[fallId];
        }

        public virtual void OnDoubleClick(EventArgs e)
        {
            if (this.DoubleClick != null) this.DoubleClick(this, e);
        }

        protected override VertexDisplay CreateDisplay(GraphDrawing gd, System.Drawing.Graphics g)
        {
            return new PersonDisplay(gd, this, g);
        }

        private static Icon LoadIcon(string resourceName)
        {
            Assembly a = Assembly.GetExecutingAssembly();
            Stream s = a.GetManifestResourceStream(resourceName);
            Icon ret;
            using (s)
            {
                ret = new Icon(s);
            }
            return ret;
        }

        private void UpdateModulStatus(ModulStatus newModulStatus, ref ModulStatus curModulStatus)
        {
            //set curModulStatus to newModulStatus if it is "higher"
            //increment ModuleCount if curModulStatus = ModulStatus.none
            switch (curModulStatus)
            {
                case ModulStatus.active:
                    break;

                case ModulStatus.closed:
                    if (newModulStatus == ModulStatus.active)
                        curModulStatus = newModulStatus;
                    break;

                case ModulStatus.archived:
                    if (newModulStatus == ModulStatus.active || newModulStatus == ModulStatus.archived)
                        curModulStatus = newModulStatus;
                    break;

                case ModulStatus.none:
                    curModulStatus = newModulStatus;
                    moduleCount++;
                    break;
            }
        }

        public class PersonFall
        {
            public readonly Fall Fall;
            public readonly bool isUnterstuetzt;

            public PersonFall(Fall fall, bool isUnsterstuetzt)
            {
                this.Fall = fall;
                this.isUnterstuetzt = isUnsterstuetzt;
            }
        }
    }
}
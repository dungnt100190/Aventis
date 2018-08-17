using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using KiSS4.GraphLib;

namespace KiSS4.Fallfuehrung.SozialSystem
{
    /// <summary>
    /// Object displaying a person
    /// </summary>
    internal class PersonDisplay : VertexDisplay
    {
        public static readonly Color NotHighlightedColor = SystemColors.Control;

        internal const float MaxFontSize = 18;
        internal const float MinFontSize = 2;
        internal const float OrigFontSize = 8;
        internal static readonly FontFamily FontFamily = FontFamily.GenericSansSerif;

        private const int BorderWidth = 1;

        // selected border width (>= borderWidth)
        private const int BorderWidthSel = 3;

        private const int MaxTextWidth = 80;

        private readonly Hierarchy.Item ageH;
        private readonly Hierarchy.Item ageV;
        private readonly Hierarchy.Item bottomEdge;
        private readonly Hierarchy h;
        private readonly Hierarchy.Item iconH;
        private readonly Hierarchy.Item iconV;
        private readonly Hierarchy.Item leftEdge;
        private readonly Icon[] moduleIcons;
        private readonly Hierarchy.Item[] modulesH;
        private readonly Hierarchy.Item modulesV;
        private readonly Hierarchy.Item namesH;
        private readonly Hierarchy.Item nameV;
        private readonly Hierarchy.Item rightEdge;
        private readonly StringFormat sfAge;
        private readonly StringFormat sfNames;
        private readonly Hierarchy.Item topEdge;
        private readonly string ttt;
        private readonly Hierarchy v;
        private readonly Hierarchy.Item vornameV;
        private int fallId = -1;
        private bool fallTraeger = false;
        private Color hlColor = NotHighlightedColor;

        public PersonDisplay(GraphDrawing gd, Person p, Graphics g)
            : base(gd, p)
        {
            Font f = new Font(FontFamily, OrigFontSize);

            this.sfAge = new StringFormat(StringFormatFlags.NoWrap);
            this.sfAge.Alignment = StringAlignment.Center;
            this.sfAge.LineAlignment = StringAlignment.Center;
            Size sAge = Size.Ceiling(g.MeasureString(p.Age, f));

            this.sfNames = new StringFormat(StringFormatFlags.NoWrap);
            this.sfNames.Trimming = StringTrimming.EllipsisCharacter;
            this.sfNames.Alignment = StringAlignment.Near;
            this.sfNames.LineAlignment = StringAlignment.Center;
            Size sVorname = Size.Ceiling(g.MeasureString(p.Vorname, f, int.MaxValue, this.sfNames));
            Size sName = Size.Ceiling(g.MeasureString(p.Name, f, int.MaxValue, this.sfNames));

            this.ttt = string.Format("{0} {1} ({2})", p.Vorname, p.Name, p.Age);

            this.moduleIcons = p.GetModuleIcons();

            #region horizontal

            {
                this.leftEdge = GetRoundedEdge();
                this.rightEdge = GetRoundedEdge();
                this.iconH = new Hierarchy.Item(32, 0, 32);
                this.ageH = new Hierarchy.Item(sAge.Width + 2);
                int maxOrg = Math.Max(sVorname.Width, sName.Width) + 2;
                int org = this.GD.ForPrinting ? Math.Max(maxOrg, MaxTextWidth) : MaxTextWidth;
                this.namesH = new Hierarchy.Item(org, 0, int.MaxValue, maxOrg);
                this.namesH.DefineDependent(new Hierarchy.Item(0, 0, int.MaxValue, int.MaxValue));
                this.modulesH = new Hierarchy.Item[this.moduleIcons.Length];

                Hierarchy modulesH = null;
                for (int i = 0; i < this.moduleIcons.Length; i++)
                {
                    this.modulesH[i] = new Hierarchy.Item(16, 0, 16);
                    if (modulesH != null)
                    {
                        modulesH.DefineDependent(this.modulesH[i]);
                        modulesH = modulesH.Root;
                    }
                    else
                        modulesH = this.modulesH[i];

                    Hierarchy.Item afterMod;

                    if (i + 1 < this.moduleIcons.Length) // add distance item
                        afterMod = new Hierarchy.Item(1);
                    else
                        afterMod = new Hierarchy.Item(1, 0, int.MaxValue, int.MaxValue);

                    modulesH.DefineDependent(afterMod);
                    modulesH = modulesH.Root;
                }

                Hierarchy iconAgeH = this.iconH | this.ageH;
                Hierarchy namesModulesH = this.namesH;
                if (modulesH != null) namesModulesH |= modulesH;
                Hierarchy interiorH = new Hierarchy.Item(BorderWidthSel + 1, BorderWidthSel);
                interiorH.DefineDependent(iconAgeH); interiorH = interiorH.Root;
                interiorH.DefineDependent(new Hierarchy.Item(1)); interiorH = interiorH.Root;
                interiorH.DefineDependent(namesModulesH); interiorH = interiorH.Root;
                interiorH.DefineDependent(new Hierarchy.Item(BorderWidthSel + 1, BorderWidthSel)); interiorH = interiorH.Root;

                Hierarchy.Item item = new Hierarchy.Item(0, 0, int.MaxValue, int.MaxValue);
                this.leftEdge.DefineDependent(item);
                item.DefineDependent(this.rightEdge);

                this.h = this.leftEdge.Root | interiorH;
                item = new Hierarchy.Item(0, 0, int.MaxValue, int.MaxValue);
                item.DefineDependent(this.h);
                item = new Hierarchy.Item(0, 0, int.MaxValue, int.MaxValue);
                this.h.DefineDependent(item);
                this.h = this.h.Root;
            }

            #endregion

            #region vertical

            {
                this.topEdge = GetRoundedEdge();
                this.bottomEdge = GetRoundedEdge();
                this.iconV = new Hierarchy.Item(32, 0, 32);
                this.ageV = new Hierarchy.Item(sAge.Height + 1);
                this.vornameV = new Hierarchy.Item(sVorname.Height + 1);
                this.nameV = new Hierarchy.Item(sName.Height + 1);
                this.modulesV = new Hierarchy.Item(16, 0, 16);

                Hierarchy iconAgeV = this.iconV;
                iconAgeV.DefineDependent(new Hierarchy.Item(1));
                iconAgeV = iconAgeV.Root;
                iconAgeV.DefineDependent(this.ageV);
                iconAgeV = iconAgeV.Root;

                Hierarchy namesModulesV = this.vornameV;
                namesModulesV.DefineDependent(new Hierarchy.Item(1));
                namesModulesV = namesModulesV.Root;
                namesModulesV.DefineDependent(this.nameV);
                namesModulesV = namesModulesV.Root;
                namesModulesV.DefineDependent(new Hierarchy.Item(2));
                namesModulesV = namesModulesV.Root;
                namesModulesV.DefineDependent(this.modulesV);
                namesModulesV = namesModulesV.Root;

                Hierarchy interiorV = new Hierarchy.Item(BorderWidthSel + 1, BorderWidthSel);
                interiorV.DefineDependent(iconAgeV | namesModulesV);
                interiorV = interiorV.Root;
                interiorV.DefineDependent(new Hierarchy.Item(BorderWidthSel + 1, BorderWidthSel));
                interiorV = interiorV.Root;

                Hierarchy.Item item = new Hierarchy.Item(0, 0, int.MaxValue, int.MaxValue);
                this.topEdge.DefineDependent(item);
                item.DefineDependent(this.bottomEdge);

                this.v = this.topEdge.Root | interiorV;
            }

            #endregion
        }

        public int FallId
        {
            get { return this.fallId; }
            set
            {
                if (value != this.fallId)
                {
                    Person p = this.Person;
                    Person.PersonFall pf = p.GetPersonFall(value);
                    bool fallTraeger = pf != null && pf.Fall.FallTraeger == p;
                    Color hlColor = NotHighlightedColor;
                    if (pf != null)
                        switch (pf.Fall.ModulCode)
                        {
                            case 1: // Basis
                                hlColor = Color.Violet;
                                break;

                            case 2: // Fallführung
                                hlColor = Color.SeaGreen;
                                break;

                            case 3: // Sozialhilfe
                                hlColor = Color.Coral;
                                break;

                            case 4: // Inkasso
                                hlColor = Color.LightGreen;
                                break;

                            case 5: // Vormundschaft
                            case 29: // Kes
                                hlColor = Color.LightBlue;
                                break;

                            case 6: // Asyl
                                hlColor = Color.Orange;
                                break;
                        }

                    if (fallTraeger != this.fallTraeger || hlColor != this.hlColor)
                    {
                        this.fallTraeger = fallTraeger;
                        this.hlColor = hlColor;
                        this.Invalidate();
                    }
                    this.fallId = value;
                }
            }
        }

        public bool IsFallTraeger
        {
            get { return this.fallTraeger; }
        }

        public Person Person
        {
            get { return (Person)this.Vertex; }
        }

        public override Hierarchy SpaceBL
        {
            get { return this.leftEdge; }
        }

        public override Hierarchy SpaceBR
        {
            get { return this.rightEdge; }
        }

        public override Hierarchy SpaceTL
        {
            get { return this.leftEdge; }
        }

        public override Hierarchy SpaceTR
        {
            get { return this.rightEdge; }
        }

        protected override Hierarchy Horizontal
        {
            get { return this.h; }
        }

        protected override Hierarchy Vertical
        {
            get { return this.v; }
        }

        public override void OnDoubleClick(EventArgs e)
        {
            this.Person.OnDoubleClick(e);
        }

        public override string ToolTipText(Point p)
        {
            if (this.HitTest(p))
                return this.ttt;
            else
                return null;
        }

        protected override void Paint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Person p = this.Person;

            #region border and background

            {
                int borderWidth = this.IsSelected ? BorderWidthSel : BorderWidth;
                int bwHalf = borderWidth / 2;
                int bwHalf1 = borderWidth - bwHalf;

                Rectangle lt = new Rectangle(this.leftEdge.Location + bwHalf, this.topEdge.Location + bwHalf, this.leftEdge.Size, this.topEdge.Size);
                Rectangle rt = new Rectangle(this.rightEdge.Location - bwHalf1, this.topEdge.Location + bwHalf, this.rightEdge.Size, this.topEdge.Size);
                Rectangle lb = new Rectangle(this.leftEdge.Location + bwHalf, this.bottomEdge.Location - bwHalf1, this.leftEdge.Size, this.bottomEdge.Size);
                Rectangle rb = new Rectangle(this.rightEdge.Location - bwHalf1, this.bottomEdge.Location - bwHalf1, this.rightEdge.Size, this.bottomEdge.Size);
                Rectangle rBorder = Rectangle.FromLTRB(lt.Left, lt.Top, rb.Right, rb.Bottom);

                GraphicsPath gp = new GraphicsPath(); // border
                if (this.fallTraeger) // rectangle
                {
                    gp.AddRectangle(rBorder);
                }
                else // rounded rectangle
                {
                    gp.AddArc(lt, -180, 90);
                    gp.AddArc(rt, -90, 90);
                    gp.AddArc(rb, 0, 90);
                    gp.AddArc(lb, 90, 90);

                    gp.CloseFigure();
                }

                // background
                Brush brush = new LinearGradientBrush(rBorder, ControlPaint.LightLight(this.hlColor), this.hlColor, LinearGradientMode.Vertical);
                using (brush) { e.Graphics.FillPath(brush, gp); }

                // border
                Pen borderPen = new Pen(Color.Black, this.IsSelected ? BorderWidthSel : BorderWidth);
                using (borderPen) { g.DrawPath(borderPen, gp); }
            }

            #endregion

            #region texts

            if (this.ageV.OrgSize > 0)
            {
                float fontSize = OrigFontSize * ((float)this.ageV.Size / (float)this.ageV.OrgSize);
                if (fontSize > MaxFontSize) fontSize = MaxFontSize;
                if (fontSize >= MinFontSize)
                {
                    Font font = new Font(FontFamily, fontSize);

                    Rectangle rAge = new Rectangle(this.ageH.Location, this.ageV.Location, this.ageH.Size, this.ageV.Size);
                    g.DrawString(p.Age, font, Brushes.Black, rAge, this.sfAge);
                }
            }

            if (this.vornameV.OrgSize > 0)
            {
                float fontSize = OrigFontSize * ((float)this.vornameV.Size / (float)this.vornameV.OrgSize);
                if (fontSize > MaxFontSize) fontSize = MaxFontSize;
                if (fontSize >= MinFontSize)
                {
                    Font font = new Font(FontFamily, fontSize);

                    Rectangle rVorname = new Rectangle(this.namesH.Location, this.vornameV.Location, this.namesH.Size, this.vornameV.Size);
                    g.DrawString(p.Vorname, font, Brushes.Black, rVorname, this.sfNames);
                }
            }

            if (this.nameV.OrgSize > 0)
            {
                float fontSize = OrigFontSize * ((float)this.nameV.Size / (float)this.nameV.OrgSize);
                if (fontSize > MaxFontSize) fontSize = MaxFontSize;
                if (fontSize >= MinFontSize)
                {
                    Font font = new Font(FontFamily, fontSize);

                    Rectangle rName = new Rectangle(this.namesH.Location, this.nameV.Location, this.namesH.Size, this.nameV.Size);
                    g.DrawString(p.Name, font, Brushes.Black, rName, this.sfNames);
                }
            }

            //				g.DrawRectangle(Pens.Red, rAge);
            //				g.DrawRectangle(Pens.Red, rVorname);
            //				g.DrawRectangle(Pens.Red, rName);

            #endregion

            #region icon

            if (p.Icon != null) // that is: gender is determined
            {
                Rectangle r = new Rectangle(this.iconH.Location, this.iconV.Location, this.iconH.Size, this.iconV.Size);
                int size = Math.Min(r.Width, r.Height);
                if (size > 16)
                {
                    if (size < 24) size = 16;
                    else if (size < 32) size = 24;
                    else size = 32;
                }
                if (size > 0)
                {
                    r = new Rectangle(r.Left + (r.Width - size) / 2, r.Top + (r.Height - size) / 2, size, size);
                    Icon i = new Icon(p.Icon, r.Size);
                    Bitmap bmp = i.ToBitmap(); // needed; otherwise uses bad coordinat system when printing (PageUnit)
                    g.DrawImage(bmp, r);
                }
            }

            #endregion

            #region modules

            for (int i = 0; i < this.moduleIcons.Length; i++)
            {
                int size = Math.Min(this.modulesH[i].Size, this.modulesV.Size);
                if (size > 9 && size < 16) size = 9;

                if (size > 0)
                {
                    Rectangle rMod = new Rectangle(
                        this.modulesH[i].Location + (this.modulesH[i].Size - size) / 2,
                        this.modulesV.Location + (this.modulesV.Size - size) / 2,
                        size, size);
                    Icon icon = new Icon(this.moduleIcons[i], rMod.Size);
                    Bitmap bmp = icon.ToBitmap();

                    // clear background
                    g.FillRectangle(SystemBrushes.Control, rMod);

                    // draw icon
                    g.DrawImage(bmp, rMod);
                }
            }

            #endregion
        }

        private static Hierarchy.Item GetRoundedEdge()
        {
            const int minRadius = 2;
            const int maxRadius = int.MaxValue; // 20
            const int origRadius = 10;

            return new Hierarchy.Item(origRadius, minRadius, maxRadius, 0);
        }
    }
}
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace KiSS4.Gui
{
    /// <summary>
    /// KiSS circular progress indicator
    /// </summary>

    [ToolboxBitmap(typeof(KissProgressIndicator), "KissProgressIndicator.bmp")]
    public partial class KissProgressIndicator : Control
    {
        #region Fields

        #region Private Fields

        /// <summary>
        /// Flag to store auto start value
        /// </summary>
        private bool _autoStart;

        /// <summary>
        /// Instance to store color of progress circles
        /// </summary>
        private Color _circleColor = Color.FromArgb(20, 20, 20);

        /// <summary>
        /// Instance to store size of progress circles
        /// </summary>
        private float _circleSize = 1.0F;

        /// <summary>
        /// Instance to store value of interval
        /// </summary>
        private int _interval = 140;

        /// <summary>
        /// Flag to store running state
        /// </summary>
        private bool _stopped = true;

        /// <summary>
        /// Instance to store current progress value
        /// </summary>
        private int _value = 1;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor for the ProgressIndicator.
        /// </summary>
        public KissProgressIndicator()
        {
            // init components
            InitializeComponent();

            // set properties
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.ResizeRedraw = true;

            // check if need to start progress
            if (AutoStart)
            {
                timerAnimation.Start();
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the animation speed.
        /// </summary>
        [DefaultValue(65)]
        [Description("Gets or sets the animation speed.")]
        [Category("Behavior")]
        public int AnimationSpeed
        {
            get
            {
                return (-_interval + 400) / 4;
            }
            set
            {
                // do explicit check for under-/overflow (see: http://msdn.microsoft.com/de-de/library/74b4xzyw(VS.80).aspx)
                checked
                {
                    // calculate interval depending on speed
                    int interval = 400 - (value * 4);

                    // validate for max/min and apply to member var
                    if (interval < 10)
                    {
                        _interval = 10;
                    }
                    else
                    {
                        _interval = interval > 400 ? 400 : interval;
                    }

                    // apply interval to timer
                    timerAnimation.Interval = _interval;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating if the animation should start automatically.
        /// </summary>
        [DefaultValue(false)]
        [Description("Gets or sets a value indicating if the animation should start automatically.")]
        [Category("Behavior")]
        public bool AutoStart
        {
            get
            {
                return _autoStart;
            }
            set
            {
                _autoStart = value;

                if (_autoStart && !DesignMode)
                {
                    // start animation
                    Start();
                }
                else
                {
                    // stop animation
                    Stop();
                }
            }
        }

        /// <summary>
        /// Gets or sets the base color for the circles.
        /// </summary>
        [DefaultValue(typeof(Color), "20, 20, 20")]
        [Description("Gets or sets the base color for the circles.")]
        [Category("Appearance")]
        public Color CircleColor
        {
            get
            {
                return _circleColor;
            }
            set
            {
                // apply
                _circleColor = value;

                // force repaint
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the scale for the circles raging from 0.1 to 1.0. This value is relative and proportional to the control size
        /// </summary>
        [DefaultValue(1.0F)]
        [Description("Gets or sets the scale for the circles raging from 0.1 to 1.0. This value is relative and proportional to the control size")]
        [Category("Appearance")]
        public float CircleSize
        {
            get
            {
                return _circleSize;
            }
            set
            {
                // validate and apply to member
                if (value <= 0.0F)
                {
                    _circleSize = 0.1F;
                }
                else
                {
                    _circleSize = value > 1.0F ? 1.0F : value;
                }

                // force repaint
                Invalidate();
            }
        }

        /// <summary>
        /// Get value if animation is currently running or stopped
        /// </summary>
        public bool IsStopped
        {
            get { return this._stopped; }
        }

        #endregion

        #region EventHandlers

        private void timerAnimation_Tick(object sender, EventArgs e)
        {
            // check if not designing
            if (DesignMode)
            {
                // do nothing
                return;
            }

            // increase current progress value
            IncreaseValue();

            // force repaint
            Invalidate();
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Starts the animation.
        /// </summary>
        public void Start()
        {
            // apply vlaues
            timerAnimation.Interval = _interval;
            _stopped = false;

            // start animation
            timerAnimation.Start();
        }

        /// <summary>
        /// Stops the animation.
        /// </summary>
        public void Stop()
        {
            // sto animation
            timerAnimation.Stop();

            // reset values
            _value = 1;
            _stopped = true;

            // force repaint
            Invalidate();
        }

        #endregion

        #region Protected Methods

        protected override void OnPaint(PaintEventArgs e)
        {
            const float angle = 360.0F / 8;

            GraphicsState oldState = e.Graphics.Save();

            e.Graphics.TranslateTransform(Width / 2.0F, Height / 2.0F);
            e.Graphics.RotateTransform(angle * _value);
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            for (int i = 1; i <= 8; i++)
            {
                int alpha = _stopped ? Convert.ToInt32(255.0F * (1.0F / 8.0F)) : Convert.ToInt32(255.0F * (i / 8.0F));

                Color drawColor = Color.FromArgb(alpha, _circleColor);

                using (SolidBrush brush = new SolidBrush(drawColor))
                {
                    float sizeRate = 4.5F / _circleSize;
                    float size = Width / sizeRate;

                    float diff = (Width / 4.5F) - size;

                    float x = (Width / 9.0F) + diff;
                    float y = (Height / 9.0F) + diff;

                    e.Graphics.FillEllipse(brush, x, y, size, size);
                    e.Graphics.RotateTransform(angle);
                }
            }

            e.Graphics.Restore(oldState);

            // let base do stuff
            base.OnPaint(e);
        }

        protected override void OnResize(EventArgs e)
        {
            // apply new size
            SetNewSize();

            // let base do stuff
            base.OnResize(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            // apply new size
            SetNewSize();

            // let base do stuff
            base.OnSizeChanged(e);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Increase progress value or restart progress
        /// </summary>
        private void IncreaseValue()
        {
            // check if we reached step 8
            if (_value + 1 <= 8)
            {
                // apply step 2..8
                _value++;
            }
            else
            {
                // reset to step 1
                _value = 1;
            }
        }

        /// <summary>
        /// Validate and apply new size
        /// </summary>
        private void SetNewSize()
        {
            // calc new size (we need square size)
            int size = Math.Max(Width, Height);

            // apply
            Size = new Size(size, size);
        }

        #endregion

        #endregion
    }
}
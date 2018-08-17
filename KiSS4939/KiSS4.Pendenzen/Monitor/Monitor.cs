using System;
using System.Threading;

namespace KiSS4.Pendenzen.Monitor
{
    public abstract class Monitor : IMonitor
    {
        #region Fields and Properties

        public enum MonitorState
        {
            Active = 1,
            Waiting = 2,
            Idle = 3
        };

        protected IPendenzProvider provider;

        private Boolean isRunning = false;
        private Thread newThread;
        private MonitorState currentState = MonitorState.Idle;
        private Int32 idletime;
        private Int32 waittime;

        #endregion

        #region setters and getters

        public MonitorState CurrentState
        {
            get
            {
                return currentState;
            }
        }

        public IPendenzProvider Provider
        {
            set
            {
                if (isRunning)
                {
                    throw new InvalidOperationException("Provider cannot be set while task is running");
                }

                provider = value;
            }
        }

        public Int32 IdleTime
        {
            set
            {
                if (isRunning)
                {
                    throw new InvalidOperationException("IdleTime cannot be set while task is running");
                }

                idletime = value;
            }
            get
            {
                return idletime;

            }

        }

        public Int32 WaitTime
        {
            set
            {
                if (isRunning)
                {
                    throw new InvalidOperationException("WaitTime cannot be set while task is running");
                }

                waittime = value;
            }

            get
            {
                return waittime;
            }
        }

        public Int32 Count
        {
            get { return provider.Count; }

        }

        #endregion

        #region IMonitor Members

        public event EventHandler<EventArgs> Detected;

        public void Start()
        {
            this.isRunning = true;
            newThread = new Thread(new ThreadStart(Execute));
            newThread.Start();
        }

        public void Stop()
        {
            this.isRunning = false;
        }

        public void Execute()
        {
            while (this.isRunning)
            {
                switch (this.currentState)
                {
                    case MonitorState.Idle:
                        Thread.Sleep(idletime);
                        this.currentState = MonitorState.Active;
                        break;

                    case MonitorState.Active:
                        LookUp();
                        this.currentState = MonitorState.Waiting;
                        break;

                    case MonitorState.Waiting:
                        Thread.Sleep(waittime);
                        this.currentState = MonitorState.Active;
                        break;

                    default:
                        throw new ArgumentOutOfRangeException("currentState");
                }
            }
        }

        public abstract void LookUp();
     
        #endregion

        protected void OnDetected()
        {
            EventHandler<EventArgs> temp = Detected;

            if (temp != null)
            {
                temp(this, EventArgs.Empty);
            }
        }
    }
}

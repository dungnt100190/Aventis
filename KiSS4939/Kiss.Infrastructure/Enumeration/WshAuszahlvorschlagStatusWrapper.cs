using System;

namespace Kiss.Infrastructure.Enumeration
{
    /// <summary>
    /// This class is a wrapper for the enum <see cref="WshAuszahlvorschlagStatus"/> that allow to have only one property 
    /// witch can be set with an in or a value of the enum.
    /// We need this in Linq to Sql queries because enums can't be used.
    /// 
    /// http://blogs.msdn.com/b/alexj/archive/2009/06/05/tip-23-how-to-fake-enums-in-ef-4.aspx
    /// </summary>
    public class WshAuszahlvorschlagStatusWrapper
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const WshAuszahlvorschlagStatus DEFAULT_VALUE = WshAuszahlvorschlagStatus.Vorschlag;

        #endregion

        #region Private Fields

        private WshAuszahlvorschlagStatus _status;

        #endregion

        #endregion

        #region Properties

        public WshAuszahlvorschlagStatus EnumValue
        {
            get { return _status; }
            set { _status = value; }
        }

        public int Value
        {
            get { return (int)_status; }

            set
            {
                if (Enum.IsDefined(typeof(WshAuszahlvorschlagStatus), value))
                {
                    _status = (WshAuszahlvorschlagStatus)Enum.ToObject(typeof(WshAuszahlvorschlagStatus), value);
                }
                else
                {
                    _status = DEFAULT_VALUE;
                }
            }
        }

        #endregion

        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Convertion from <see cref="WshAuszahlvorschlagStatus"/> to <see cref="WshAuszahlvorschlagStatusWrapper"/>.
        /// Impliclit operator that allow to set an enum value to the wrapper.
        /// </summary>
        /// <param name="status">The status of type <see cref="WshAuszahlvorschlagStatus"/> to set</param>
        /// <returns>A <see cref="WshAuszahlvorschlagStatusWrapper"/> with the geven <paramref name="status"/></returns>
        public static implicit operator WshAuszahlvorschlagStatusWrapper(WshAuszahlvorschlagStatus status)
        {
            return new WshAuszahlvorschlagStatusWrapper { EnumValue = status };
        }

        /// <summary>
        /// Convertion from <see cref="WshAuszahlvorschlagStatusWrapper"/> to <see cref="WshAuszahlvorschlagStatus"/>.
        /// Impliclit operator that allow to set a wrapper (of type <see cref="WshAuszahlvorschlagStatusWrapper"/>) to an enum variable (of type <see cref="WshAuszahlvorschlagStatus"/>)
        /// </summary>
        /// <param name="statusWrapper">The status of type <see cref="WshAuszahlvorschlagStatusWrapper"/> to set</param>
        /// <returns>A <see cref="WshAuszahlvorschlagStatus"/> with the geven <paramref name="statusWrapper"/></returns>
        public static implicit operator WshAuszahlvorschlagStatus(WshAuszahlvorschlagStatusWrapper statusWrapper)
        {
            return statusWrapper == null ? DEFAULT_VALUE : statusWrapper.EnumValue;
        }

        public override string ToString()
        {
            return EnumValue.ToString();
        }

        #endregion

        #endregion
    }
}
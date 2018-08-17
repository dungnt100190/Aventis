using System.Windows.Media;

using Kiss.BL.KissSystem;
using Kiss.Infrastructure.Enumeration;
using Kiss.Model;

namespace Kiss.BL.Wsh
{
    /// <summary>
    /// Service zum erstellen des Icons für den KbuBelegPositionsstatus.
    /// Siehe Dokumentation von Marcel Weber.
    /// </summary>
    public class WshPositionsStatusImageService : XImageService
    {
        #region Constructors

        private WshPositionsStatusImageService()
        {
            SetUpImages();
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Holt das Image für eine bewilligte Position.
        /// </summary>
        /// <returns></returns>
        public ImageSource GetBewilligtImage()
        {
            return GetImage("Bewilligt");
        }

        /// <summary>
        /// Erstellt das Icon für den Positionsstatus.
        /// </summary>
        /// <param name="position">Initialisierte Position. Die Eigenschaften X, und Y müssen geladen worden sein.</param>
        /// <param name="emptyIfZero">Liefert ein leeres Bild zurück, falls der Betrag 0 und die Position verbucht ist.</param>
        /// <returns></returns>
        public ImageSource GetPositionsStatusImage(WshPosition position, bool emptyIfZero = false)
        {
            if (position == null)
            {
                return null;
            }

            if (position.Betrag == 0)
            {
                return GetEmptyImage();
            }

            var status = position.PositionsStatus;

            //Teilweise vreigegeben, Teilweise verbucht.
            if ((status & WshPositionsstatus.TeilweiseFreigegeben) > 0 &&
                (status & WshPositionsstatus.TeilweiseAusgeglichen) > 0 &&
                (status & WshPositionsstatus.TeilweiseVorbereitet) > 0)
            {
                return GetImage("GrauGruenGelb");
            }

            //Freigegeben
            if ((status & WshPositionsstatus.Freigegeben) > 0)
            {
                return GetImage("Freigegeben");
            }

            //Teilweise vorbereitet und teilweise freigegeben.
            if ((status & WshPositionsstatus.TeilweiseFreigegeben) > 0 &&
                (status & WshPositionsstatus.TeilweiseVorbereitet) > 0)
            {
                return GetImage("GrauGruen");
            }

            //Verbucht
            if ((status & WshPositionsstatus.Ausgeglichen) > 0)
            {
                if (emptyIfZero && position.Betrag == 0)
                {
                    return GetEmptyImage();
                }

                return GetImage("Verbucht");
            }

            //Teilweise vorbereitet und Teilweise verbucht.
            if ((status & WshPositionsstatus.TeilweiseAusgeglichen) > 0 &&
                (status & WshPositionsstatus.TeilweiseVorbereitet) > 0)
            {
                return GetImage("GrauGelb");
            }

            //Teilweise vorbereitet und Teilweise verbucht.
            if ((status & WshPositionsstatus.TeilweiseAusgeglichen) > 0 &&
                (status & WshPositionsstatus.TeilweiseFreigegeben) > 0)
            {
                return GetImage("GruenGelb");
            }

            return GetImage("Vorbereitet");
        }

        #endregion

        #region Private Methods

        private void SetUpImages()
        {
            AddImage("Freigegeben", "Kiss_KbuPositionsStatus_Freigegeben.png");
            AddImage("GrauGelb", "Kiss_KbuPositionsStatus_GrauGelb.png");
            AddImage("GrauGruen", "Kiss_KbuPositionsStatus_GrauGruen.png");
            AddImage("GrauGruenGelb", "Kiss_KbuPositionsStatus_GrauGruenGelb.png");
            AddImage("GruenGelb", "Kiss_KbuPositionsStatus_GruenGelb.png");
            AddImage("Verbucht", "Kiss_KbuPositionsStatus_Verbucht.png");
            AddImage("Vorbereitet", "Kiss_KbuPositionsStatus_Vorbereitet.png");
            AddImage("Bewilligt", "Kiss_KbuPositionsStatus_Bewilligt.png");
        }

        #endregion

        #endregion
    }
}
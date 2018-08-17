using System;
using System.ComponentModel;

using Kiss.Infrastructure;
using Kiss.Infrastructure.Utils;

namespace Kiss.Model
{
    public partial class VmPosition
    {
        public bool BetragModifiedFlag { get; private set; }

        #region Constructors

        public VmPosition()
        {
            PropertyChanged += VmPosition_PropertyChanged;
        }

        #endregion

        #region EventHandlers

        private void VmPosition_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (BetragModifiedFlag)
                return;

            try
            {
                BetragModifiedFlag = true;
                if (e.PropertyName == PropertyName.GetPropertyName(() => BetragJaehrlich))
                {
                    if (!BetragJaehrlich.HasValue)
                    {
                        BetragMonatlich = null;
                    }
                    else
                    {
                        BetragMonatlich = Utils.RoundMoney_CH(BetragJaehrlich.Value / 12);
                    }
                }

                if (e.PropertyName == PropertyName.GetPropertyName(() => BetragMonatlich))
                {
                    BetragJaehrlich = BetragMonatlich*12;
                }
            }
            finally
            {
                BetragModifiedFlag = false;
            }
        }

        #endregion
    }
}
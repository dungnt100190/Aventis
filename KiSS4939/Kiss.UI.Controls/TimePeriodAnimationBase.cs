using System;
using System.Windows.Media.Animation;

using Kiss.Infrastructure;

namespace Kiss.UI.Controls
{
    public abstract class TimePeriodAnimationBase : AnimationTimeline
    {
        public override object GetCurrentValue(object defaultOriginValue, object defaultDestinationValue, AnimationClock animationClock)
        {
            if (!(defaultOriginValue is TimePeriod))
            {
                throw new ArgumentException("defaultOriginValue has to be of Type TimePeriod", "defaultOriginValue");
            }
            if (!(defaultOriginValue is TimePeriod))
            {
                throw new ArgumentException("defaultDestinationValue has to be of Type TimePeriod", "defaultDestinationValue");
            }
            return GetCurrentValueCore((TimePeriod)defaultOriginValue, (TimePeriod)defaultDestinationValue, animationClock);
        }
        public override Type TargetPropertyType
        {
            get { return typeof(TimePeriod); }
        }

        protected abstract TimePeriod GetCurrentValueCore(TimePeriod defaultOriginValue, TimePeriod defaultDestinationValue, AnimationClock animationClock);
    }
}

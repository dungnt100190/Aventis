using System;
using System.Windows;
using System.Windows.Media.Animation;

using Kiss.Infrastructure;

namespace Kiss.UI.Controls
{
    public class TimePeriodAnimation : TimePeriodAnimationBase
    {
        protected override Freezable CreateInstanceCore()
        {
            return new TimePeriodAnimation
            {
                From = From,
                To = To,
                AccelerationRatio = AccelerationRatio,
                DecelerationRatio = DecelerationRatio,
                Duration = Duration,
                AutoReverse = AutoReverse,
                BeginTime = BeginTime,
                FillBehavior = FillBehavior,
                Name = Name,
                RepeatBehavior = RepeatBehavior,
                SpeedRatio = SpeedRatio
            };
        }

        public TimePeriod? From { get; set; }
        public TimePeriod? To { get; set; }

        public override bool IsDestinationDefault
        {
            get { return false; }
        }

        protected override TimePeriod GetCurrentValueCore(TimePeriod defaultOriginValue, TimePeriod defaultDestinationValue, AnimationClock animationClock)
        {
            var from = From ?? defaultOriginValue;
            var to = To ?? defaultDestinationValue;
            var progress = animationClock.CurrentProgress ?? 1.0;
            var result = new TimePeriod(new DateTime(from.From.Ticks + (long)(progress * (to.From.Ticks - from.From.Ticks))),
                                  new DateTime(from.To.Ticks + (long)(progress * (to.To.Ticks - from.To.Ticks))));
            return result;
        }
    }
}

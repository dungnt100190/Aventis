﻿using System;
using System.Windows.Markup;

namespace Kiss.UI.Controls.Converter
{
    public abstract class BaseConverter : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
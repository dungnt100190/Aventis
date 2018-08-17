using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

using Kiss.DbContext;
using Kiss.Infrastructure;
using Kiss.Infrastructure.Converter;
using Kiss.UI.Controls.Converter;
using Kiss.UI.Controls.LocalResources;

namespace Kiss.UI.Controls
{
    /// <summary>
    /// Interaction logic for SearchParamsText.xaml
    /// </summary>
    public partial class SearchParamsText
    {
        // Using a DependencyProperty as the backing store for SearchParamsDto.
        public static readonly DependencyProperty SearchParamsDtoProperty =
            DependencyProperty.Register("SearchParamsDto", typeof(object), typeof(SearchParamsText), new UIPropertyMetadata(SearchParamsDtoChanged));

        public SearchParamsText()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The DTO which holds the search parameters.
        /// </summary>
        public object SearchParamsDto
        {
            get { return GetValue(SearchParamsDtoProperty); }
            set { SetValue(SearchParamsDtoProperty, value); }
        }

        /// <summary>
        /// Creates a OneWay binding on the Name of the property passed on.
        /// Includes a converter for certain property types for better display.
        /// </summary>
        /// <param name="bindingSource"></param>
        /// <param name="propertyInfo"></param>
        /// <returns></returns>
        private static Binding GetBinding(object bindingSource, PropertyInfo propertyInfo)
        {
            var binding = new Binding(propertyInfo.Name)
                              {
                                  Source = bindingSource,
                                  Mode = BindingMode.OneWay
                              };
            if (propertyInfo.PropertyType == typeof(DateTime) || propertyInfo.PropertyType == typeof(DateTime?))
            {
                binding.Converter = new Date2StringConverter();
            }
            else if (propertyInfo.PropertyType == typeof(bool))
            {
                binding.Converter = new Boolean2ValueConverter<string> { FalseValue = "Nein", TrueValue = "Ja" }; // TODO: Mehrsprachigkeit
            }
            else
            {
                var isEnumList = propertyInfo.PropertyType
                    .GetInterfaces()
                    .Any(
                        ifc => ifc.GetInterfaces()
                                   .Contains(typeof(IEnumerable)) &&
                               ifc.IsGenericType && (ifc.GetGenericArguments()[0].IsEnum ||
                                                     ifc.GetGenericArguments()[0] == typeof(XLOVCode)));
                if (isEnumList)
                {
                    binding.Converter = new EnumLocalizationConverter();
                }
            }

            return binding;
        }

        /// <summary>
        /// Generates a TextBlock with static text
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private static TextBlock GetNewTextBlock(string text)
        {
            var textBlock = new TextBlock
                                {
                                    Text = text,
                                    Margin = new Thickness(0, 0, 5, 0)
                                };

            return textBlock;
        }

        /// <summary>
        /// Generates a TextBlock with a binding
        /// </summary>
        /// <param name="binding"></param>
        /// <returns></returns>
        private static TextBlock GetNewTextBlock(BindingBase binding)
        {
            var textBlock = GetNewTextBlock(string.Empty);
            textBlock.SetBinding(TextBlock.TextProperty, binding);

            return textBlock;
        }

        private static void SearchParamsDtoChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var thisInstance = (SearchParamsText)d;
            thisInstance.layoutRoot.Children.Clear();

            foreach (var propertyInfo in e.NewValue.GetType().GetProperties())
            {
                var attribute = propertyInfo.GetCustomAttributes(typeof(SearchFieldAttribute), false).FirstOrDefault() as SearchFieldAttribute;

                if (attribute != null && attribute.Name != null)
                {
                    var labelValueText = new StackPanel
                                             {
                                                 Orientation = Orientation.Horizontal,
                                                 Margin = new Thickness(0, 0, 10, 0)
                                             };

                    var text = attribute.Name;

                    if (!string.IsNullOrEmpty(attribute.ResourceName))
                    {
                        text = SearchParamsTextRes.ResourceManager.GetString(attribute.ResourceName);
                    }

                    labelValueText.Children.Add(GetNewTextBlock(text + ":"));

                    var binding = GetBinding(e.NewValue, propertyInfo);
                    labelValueText.Children.Add(GetNewTextBlock(binding));

                    if (attribute.FollowedBy != null)
                    {
                        var followedByProperty = e.NewValue.GetType().GetProperty(attribute.FollowedBy);

                        labelValueText.Children.Add(GetNewTextBlock("-"));

                        var bindingFollowedBy = GetBinding(e.NewValue, followedByProperty);

                        labelValueText.Children.Add(GetNewTextBlock(bindingFollowedBy));
                    }

                    thisInstance.layoutRoot.Children.Add(labelValueText);
                }
            }
        }
    }
}
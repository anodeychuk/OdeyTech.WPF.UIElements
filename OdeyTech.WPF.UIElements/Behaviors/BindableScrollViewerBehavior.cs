// --------------------------------------------------------------------------
// <copyright file="BindableScrollViewerBehavior.cs" author="Andrii Odeychuk">
//
// Copyright (c) Andrii Odeychuk. ALL RIGHTS RESERVED
// The entire contents of this file is protected by International Copyright Laws.
// </copyright>
// --------------------------------------------------------------------------

using System.Windows;
using System.Windows.Controls;
using Microsoft.Xaml.Behaviors;

namespace OdeyTech.WPF.UIElements.Behaviors
{
    public class BindableScrollViewerBehavior : Behavior<ScrollViewer>
    {
        public static readonly DependencyProperty VerticalOffsetProperty =
            DependencyProperty.Register(nameof(VerticalOffset), typeof(double), typeof(BindableScrollViewerBehavior), new UIPropertyMetadata(0.0, OnVerticalOffsetChanged));

        public double VerticalOffset
        {
            get => (double)GetValue(VerticalOffsetProperty);
            set => SetValue(VerticalOffsetProperty, value);
        }

        private static void OnVerticalOffsetChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is BindableScrollViewerBehavior behavior && behavior.AssociatedObject != null)
            {
                behavior.AssociatedObject.ScrollToVerticalOffset((double)e.NewValue);
            }
        }

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.ScrollChanged += OnScrollChanged;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            if (AssociatedObject != null)
            {
                AssociatedObject.ScrollChanged -= OnScrollChanged;
            }
        }

        private void OnScrollChanged(object sender, ScrollChangedEventArgs e) => VerticalOffset = e.VerticalOffset;
    }
}

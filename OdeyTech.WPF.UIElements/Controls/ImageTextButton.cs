// --------------------------------------------------------------------------
// <copyright file="ImageTextButton.cs" author="Andrii Odeychuk">
//
// Copyright (c) Andrii Odeychuk. ALL RIGHTS RESERVED
// The entire contents of this file is protected by International Copyright Laws.
// </copyright>
// --------------------------------------------------------------------------

using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace OdeyTech.WPF.UIElements.Controls
{
    /// <summary>
    /// Represents an ImageTextButton class that is a special type of button that can display both image and text.
    /// </summary>
    public partial class ImageTextButton : Button
    {
        /// <summary>
        /// Identifies the <see cref="ImageSource"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register(nameof(ImageSource), typeof(ImageSource), typeof(ImageTextButton), new PropertyMetadata(null));

        /// <summary>
        /// Identifies the <see cref="BitmapSource"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty BitmapSourceProperty =
            DependencyProperty.Register(nameof(BitmapSource), typeof(Bitmap), typeof(ImageTextButton), new PropertyMetadata(null, OnBitmapSourceChanged));

        /// <summary>
        /// Identifies the <see cref="Text"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(nameof(Text), typeof(string), typeof(ImageTextButton), new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets the image source of the button.
        /// </summary>
        public ImageSource ImageSource
        {
            get => (ImageSource)GetValue(ImageSourceProperty);
            set => SetValue(ImageSourceProperty, value);
        }

        /// <summary>
        /// Gets or sets the bitmap source of the button.
        /// </summary>
        public Bitmap BitmapSource
        {
            get => (Bitmap)GetValue(BitmapSourceProperty);
            set => SetValue(BitmapSourceProperty, value);
        }

        /// <summary>
        /// Gets or sets the text of the button.
        /// </summary>
        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        /// <summary>
        /// Called when the <see cref="BitmapSource"/> property is changed.
        /// </summary>
        private static void OnBitmapSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ImageTextButton control && e.NewValue is Bitmap bitmap && control.ImageSource == null)
            {
                control.ImageSource = ImageSourceFromBitmap(bitmap);
            }
        }

        /// <summary>
        /// Creates an <see cref="ImageSource"/> from a <see cref="Bitmap"/>.
        /// </summary>
        private static ImageSource ImageSourceFromBitmap(Bitmap bitmap)
        {
            IntPtr handle = bitmap.GetHbitmap();
            try
            {
                return Imaging.CreateBitmapSourceFromHBitmap(
                    handle,
                    IntPtr.Zero,
                    Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions()
                );
            }
            finally
            {
                DeleteObject(handle);
            }
        }

        /// <summary>
        /// Deletes a logical pen, brush, font, bitmap, region, or palette, freeing all system resources associated with the object.
        /// </summary>
        [DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteObject([In] IntPtr hObject);
    }
}

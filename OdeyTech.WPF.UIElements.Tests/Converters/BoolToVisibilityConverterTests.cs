// --------------------------------------------------------------------------
// <copyright file="BoolToVisibilityConverterTests.cs" author="Andrii Odeychuk">
//
// Copyright (c) Andrii Odeychuk. ALL RIGHTS RESERVED
// The entire contents of this file is protected by International Copyright Laws.
// </copyright>
// --------------------------------------------------------------------------

using System.Windows;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OdeyTech.WPF.UIElements.Converters;

namespace OdeyTech.WPF.UIElements.Tests.Converters
{
    [TestClass]
    public class BoolToVisibilityConverterTests
    {
        private BoolToVisibilityConverter converter;

        [TestInitialize]
        public void TestInitialize() => this.converter = new BoolToVisibilityConverter();

        [TestMethod]
        public void Convert_WhenValueIsTrue_ReturnsVisible()
        {
            // Act
            var result = this.converter.Convert(true, typeof(Visibility), null, null);

            // Assert
            Assert.AreEqual(Visibility.Visible, result);
        }

        [TestMethod]
        public void Convert_WhenValueIsFalse_ReturnsCollapsed()
        {
            // Act
            var result = this.converter.Convert(false, typeof(Visibility), null, null);

            // Assert
            Assert.AreEqual(Visibility.Collapsed, result);
        }

        [TestMethod]
        public void ConvertBack_WhenValueIsVisible_ReturnsTrue()
        {
            // Act
            var result = this.converter.ConvertBack(Visibility.Visible, typeof(bool), null, null);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ConvertBack_WhenValueIsCollapsed_ReturnsFalse()
        {
            // Act
            var result = this.converter.ConvertBack(Visibility.Collapsed, typeof(bool), null, null);

            // Assert
            Assert.AreEqual(false, result);
        }
    }
}

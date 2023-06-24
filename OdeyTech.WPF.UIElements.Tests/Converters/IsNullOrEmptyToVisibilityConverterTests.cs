// --------------------------------------------------------------------------
// <copyright file="IsNullOrEmptyToVisibilityConverterTests.cs" author="Andrii Odeychuk">
//
// Copyright (c) Andrii Odeychuk. ALL RIGHTS RESERVED
// The entire contents of this file is protected by International Copyright Laws.
// </copyright>
// --------------------------------------------------------------------------

using System;
using System.Windows;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OdeyTech.WPF.UIElements.Converters;

namespace OdeyTech.WPF.UIElements.Tests.Converters
{
    [TestClass]
    public class IsNullOrEmptyToVisibilityConverterTests
    {
        private IsNullOrEmptyToVisibilityConverter converter;

        [TestInitialize]
        public void TestInitialize() => this.converter = new IsNullOrEmptyToVisibilityConverter();

        [TestMethod]
        public void Convert_WhenValueIsNull_ReturnsVisible()
        {
            // Act
            var result = this.converter.Convert(null, typeof(Visibility), null, null);

            // Assert
            Assert.AreEqual(Visibility.Visible, result);
        }

        [TestMethod]
        public void Convert_WhenValueIsEmpty_ReturnsVisible()
        {
            // Act
            var result = this.converter.Convert(string.Empty, typeof(Visibility), null, null);

            // Assert
            Assert.AreEqual(Visibility.Visible, result);
        }

        [TestMethod]
        public void Convert_WhenValueIsNotEmpty_ReturnsCollapsed()
        {
            // Act
            var result = this.converter.Convert("test", typeof(Visibility), null, null);

            // Assert
            Assert.AreEqual(Visibility.Collapsed, result);
        }

        [TestMethod]
        public void ConvertBack_ThrowsNotImplementedException()
            => Assert.ThrowsException<NotSupportedException>(() => this.converter.ConvertBack(Visibility.Visible, typeof(string), null, null));
    }
}

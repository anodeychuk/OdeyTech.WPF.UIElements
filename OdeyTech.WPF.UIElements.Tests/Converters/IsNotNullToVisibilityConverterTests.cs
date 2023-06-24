// --------------------------------------------------------------------------
// <copyright file="IsNotNullToVisibilityConverterTests.cs" author="Andrii Odeychuk">
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
    public class IsNotNullToVisibilityConverterTests
    {
        private IsNotNullToVisibilityConverter converter;

        [TestInitialize]
        public void TestInitialize() => this.converter = new IsNotNullToVisibilityConverter();

        [TestMethod]
        public void Convert_WhenValueIsNull_ReturnsCollapsed()
        {
            // Act
            var result = this.converter.Convert(null, typeof(Visibility), null, null);

            // Assert
            Assert.AreEqual(Visibility.Collapsed, result);
        }

        [TestMethod]
        public void Convert_WhenValueIsNotNull_ReturnsVisible()
        {
            // Act
            var result = this.converter.Convert(new object(), typeof(Visibility), null, null);

            // Assert
            Assert.AreEqual(Visibility.Visible, result);
        }

        [TestMethod]
        public void ConvertBack_ThrowsNotImplementedException()
            => Assert.ThrowsException<NotSupportedException>(() => this.converter.ConvertBack(Visibility.Visible, typeof(object), null, null));
    }
}

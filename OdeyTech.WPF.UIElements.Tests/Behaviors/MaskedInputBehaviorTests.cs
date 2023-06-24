// --------------------------------------------------------------------------
// <copyright file="MaskedInputBehaviorTests.cs" author="Andrii Odeychuk">
//
// Copyright (c) Andrii Odeychuk. ALL RIGHTS RESERVED
// The entire contents of this file is protected by International Copyright Laws.
// </copyright>
// --------------------------------------------------------------------------

using System.Windows;
using System.Windows.Controls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xaml.Behaviors;
using OdeyTech.WPF.UIElements.Behaviors;

namespace OdeyTech.WPF.UIElements.Tests.Behaviors
{
    [TestClass]
    public class MaskedInputBehaviorTests
    {
        private MaskedInputBehavior behavior;
        private TextBox textBox;

        [TestInitialize]
        public void TestInitialize()
        {
            this.behavior = new MaskedInputBehavior();
            this.textBox = new TextBox();
            BehaviorCollection behaviors = Interaction.GetBehaviors(this.textBox);
            behaviors.Add(this.behavior);
        }

        [TestMethod]
        public void TextBox_WhenTextIsValid_AllowsInput()
        {
            // Arrange
            this.behavior.Mask = "000-000";

            // Act
            this.textBox.Text = "123-456";
            this.textBox.RaiseEvent(new RoutedEventArgs(TextBox.TextChangedEvent));

            // Assert
            Assert.AreEqual("123-456", this.textBox.Text);
        }

        [TestMethod]
        public void TextBox_WhenTextIsInvalid_BlocksInput()
        {
            // Arrange
            this.behavior.Mask = "000-000";

            // Act
            this.textBox.Text = "123/456";
            this.textBox.RaiseEvent(new RoutedEventArgs(TextBox.TextChangedEvent));

            // Assert
            Assert.AreNotEqual("123-456", this.textBox.Text);
        }
    }
}

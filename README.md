
# OdeyTech.WPF.UIElements

**OdeyTech.WPF.UIElements** is a comprehensive collection of custom WPF controls and converters that facilitate the development of user interfaces in WPF applications. This repository provides an array of components and utilities to enhance the visual appeal and functionality of your WPF projects.

## Features

- **Controls**: Unlock the potential of your UI with custom controls designed to streamline and simplify user interactions.
- **Converters**: Simplify data transformations in your XAML bindings using a variety of value converters that handle common scenarios.

## Sample Usage

### TextEntryLabel Control

The `TextEntryLabel` control combines a label and a TextBox, providing a consistent and user-friendly way to capture user input. It offers several customizable properties for flexibility.

~~~xml
<Window x:Class="YourNamespace.YourWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:local="clr-namespace:OdeyTech.WPF.UIElements.Controls;assembly=OdeyTech.WPF.UIElements"
        xmlns:conv="clr-namespace:OdeyTech.WPF.UIElements.Converters;assembly=OdeyTech.WPF.UIElements">
    <StackPanel>
        <local:TextEntryLabel LabelText="Name:"
                              Text="{Binding UserName}"
                              LabelWidth="100"
                              TextBoxWidth="200"
                              TextHint="Enter your name" />
    </StackPanel>
</Window>
~~~

-   `LabelText`: Sets the label text displayed next to the TextBox.
-   `TextHint`: Specifies the hint text to display when the TextBox is empty.
-   `Text`: Binds the TextBox text to a property in your view model.
-   `LabelWidth`: Defines the width of the label column.
-   `TextBoxWidth`: Defines the width of the TextBox column.

### MaskedTextBoxLabel Control
The `MaskedTextBoxLabel` control is designed for masked input scenarios, allowing you to enforce specific input patterns while providing a visually appealing user interface. It inherits from `TextEntryLabel` and includes additional properties for customization.

~~~xml
<Window x:Class="YourNamespace.YourWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:local="clr-namespace:OdeyTech.WPF.UIElements.Controls;assembly=OdeyTech.WPF.UIElements"
        xmlns:conv="clr-namespace:OdeyTech.WPF.UIElements.Converters;assembly=OdeyTech.WPF.UIElements">
    <StackPanel>
        <local:MaskedTextBoxLabel LabelText="Phone Number:"
                                  Text="{Binding PhoneNumber}"
                                  Mask="(000) 000-0000"
                                  TextHint="Enter phone number" />
    </StackPanel>
</Window>
~~~

- `LabelText`: Sets the label text displayed next to the TextBox.
- `TextHint`: Specifies the hint text to display when the TextBox is empty.
- `Text`: Binds the TextBox text to a property in your view model.
- `Mask`: Defines the input mask pattern for the TextBox.

### Controlling Visibility with BoolToVisibilityConverter
You can easily show or hide UI elements based on a boolean condition using the `BoolToVisibilityConverter`. Here's an example:
~~~xml
<StackPanel Visibility="{Binding IsVisible, Converter={conv:BoolToVisibilityConverter}}">
    <!-- Your UI elements here -->
</StackPanel>
~~~

## Getting Started
To leverage the power of `OdeyTech.WPF.UIElements` in your projects, follow these simple steps:

1. Install the NuGet package `OdeyTech.WPF.UIElements` into your WPF project.
2. To apply the provided themes and styles to your entire application, add the following code snippet to your `App.xaml` file:
~~~xml
<Application x:Class="YourNamespace.App"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
    <Application.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary Source="pack://application:,,,/OdeyTech.WPF.UIElements;component/Themes/Generic.xaml" />
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Application.Resources>
</Application>
~~~
3. Add the necessary XAML namespace references to the files where you want to use the custom controls, behaviors, or converters.

## Contributing
We welcome contributions to `OdeyTech.WPF.UIElements`! Feel free to submit pull requests or raise issues to help us improve the library.

## License
`OdeyTech.WPF.UIElements` is released under the [MIT License][LICENSE]. See the LICENSE file for more information.

## Stay in Touch
For more information, updates, and future releases, follow me on [LinkedIn][LIn] I'd be happy to connect and discuss any questions or ideas you might have.

[//]: #
   [LIn]: <https://www.linkedin.com/in/anodeychuk/>
   [LICENSE]: <https://github.com/anodeychuk/OdeyTech.WPF.UIElements/blob/main/LICENSE>
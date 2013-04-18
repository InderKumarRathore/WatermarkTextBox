This project demostrate the Watermark TextBox.
For andriod users it's just like "Hint"
For iphone users it's "placeholder" property

Steps for including this in your project.
1. Copy WatermarkTextBox.cs and Theme folder in your project.
2. Include xmlns:watermark="using:WaterMarkProject" in your xaml file where you want to use this control.
Here is the example

<Page
    x:Class="App2.MainPage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="using:App2"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    mc:Ignorable="d"
    xmlns:watermark="using:WaterMarkProject">

    <Grid Background="{StaticResource ApplicationPageBackgroundThemeBrush}">
        <watermark:WatermarkTextBox WatermarkForeground="Red" Watermark="nope" Width="300" Height="60" FontFamily="Segoe UI" FontSize="30"/>
    </Grid>
</Page>

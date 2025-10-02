using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using ComputerService.ViewModels;

namespace ComputerService.Views;

public partial class MainWindow : Window
{

    private MainWindowViewModel? ViewModel => DataContext as MainWindowViewModel;

    public MainWindow()
    {
        InitializeComponent();
    }

    private void OnRadioButtonClick(object? sender, RoutedEventArgs e)
    {
        if (ViewModel == null) return;
        if (sender is not RadioButton radioButton) return;
        ViewModel!.ChangePage(Convert.ToInt32(radioButton.Tag));
    }
    
    
    
    
}
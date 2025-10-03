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


    private void OnAddSparePartClick(object? sender, RoutedEventArgs e)
    {
        if (ViewModel == null) return;
        ViewModel.AddSparePart();
    }

    private void OnRemoveSparePartClick(object? sender, RoutedEventArgs e)
    {
        if (ViewModel == null) return;
        ViewModel.RemoveSparePart();
    }

    private void OnAddRepairModelClick(object? sender, RoutedEventArgs e)
    {
        if (ViewModel == null) return;
        ViewModel.AddRepairModel();
    }

    private void OnDeleteRepairModelClick(object? sender, RoutedEventArgs e)
    {
        if (ViewModel == null) return;
        ViewModel.RemoveRepairModel();
    }

    private void OnAddFaultTypeClick(object? sender, RoutedEventArgs e)
    {
        if (ViewModel == null) return;
        ViewModel.AddFaultType();
    }

    private void OnDeleteFaultTypeClick(object? sender, RoutedEventArgs e)
    {
        if (ViewModel == null) return;
        ViewModel.RemoveFaultType();
    }
}
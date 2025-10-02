using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using ComputerService.Models;
using ComputerService.Services;

namespace ComputerService.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private SparePartService _sparePartService = SparePartService.Shared;
    
    [ObservableProperty] private bool _isSelectedFirstPage = true;
    [ObservableProperty] private bool _isSelectedSecondPage = false;
    [ObservableProperty] private bool _isSelectedThirdPage = false;
    [ObservableProperty] private bool _isSelectedFourthPage = false;

    [ObservableProperty] private ObservableCollection<SparePartModel> _isSelectedFifthPage = new();
    [ObservableProperty] private string _sparePartId = "";
    [ObservableProperty] private string _sparePartName = "";
    [ObservableProperty] private string _sparePartFunctions = "";
    [ObservableProperty] private string _sparePartPrice = "";
    
    

    public void ChangePage(int page)
    {
        IsSelectedFirstPage = page == 1;
        IsSelectedSecondPage = page == 2;
        IsSelectedThirdPage = page == 3;
        IsSelectedFourthPage = page == 4;
    }
    
    
    

}
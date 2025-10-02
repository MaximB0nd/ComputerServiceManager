using System;
using System.Collections.ObjectModel;
using System.Data;
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

    [ObservableProperty] private ObservableCollection<SparePartModel> _sparePartModels = new();
    [ObservableProperty] private SparePartModel? _selectedSparePartModel = null;
    [ObservableProperty] private string _sparePartError = "";
    [ObservableProperty] private string _sparePartId = "";
    [ObservableProperty] private string _sparePartName = "";
    [ObservableProperty] private string _sparePartFunctions = "";
    [ObservableProperty] private string _sparePartPrice = "";

    public MainWindowViewModel()
    {
        Update();
    }
    public void ChangePage(int page)
    {
        IsSelectedFirstPage = page == 1;
        IsSelectedSecondPage = page == 2;
        IsSelectedThirdPage = page == 3;
        IsSelectedFourthPage = page == 4;
    }

    public void AddSparePart()
    {
        try
        {
            _sparePartService.AddSparePart(
                new SparePartModel(
                    SparePartId, 
                    SparePartName, 
                    SparePartFunctions, 
                    SparePartPrice
                    )
                );
            SparePartId = "";
            SparePartPrice = "";
            SparePartFunctions = "";
            SparePartName = "";
            Update();
        }
        catch (Exception e)
        {
            SparePartError = e.Message;
        }
        
        
    }

    public void RemoveSparePart()
    {
        try
        {
            if (SelectedSparePartModel == null) return;
            _sparePartService.DeleteSparePart(SelectedSparePartModel);
            Update();
        }
        catch (Exception e)
        {
            SparePartError = e.Message;
        }
    }

    private void Update()
    {
        SparePartModels = _sparePartService.ReadSpaceParts();
    }
    
    
    

}
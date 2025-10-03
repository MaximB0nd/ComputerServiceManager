using System;
using System.Collections.ObjectModel;
using System.Data;
using CommunityToolkit.Mvvm.ComponentModel;
using ComputerService.Models;
using ComputerService.Services;

namespace ComputerService.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel()
    {
        UpdateAll();
    }
    
    // --- Pages
    
    [ObservableProperty] private bool _isSelectedFirstPage = true;
    [ObservableProperty] private bool _isSelectedSecondPage = false;
    [ObservableProperty] private bool _isSelectedThirdPage = false;
    [ObservableProperty] private bool _isSelectedFourthPage = false;
    
    // --- for all 
    public void ChangePage(int page)
    {
        IsSelectedFirstPage = page == 1;
        IsSelectedSecondPage = page == 2;
        IsSelectedThirdPage = page == 3;
        IsSelectedFourthPage = page == 4;
        ClearAll();
        UpdateAll();
    }
    
    private void ClearAll()
    {
        // -- Spare model
        SelectedSparePartModel = null;
        SparePartError = "";
        SparePartId = "";
        SparePartName = "";
        SparePartFunctions = "";
        SparePartPrice = "";

        // -- Repair model
        SelectedRepairModel = null;
        RepairModelId = "";
        RepairModelName = "";
        RepairModelType = "";
        RepairModelProducer = ""; 
        RepairModelProperties = ""; 
        RepairModelFeatures = "";
        RepairModelError = "";
        
        // -- Fault type
        
        SelectedFaultTypeModel = null;
        FaultTypeError = "";
        FaultTypeId = "";
        FaultTypeModelId = "";
        FaultTypeDescription = "";
        FaultTypeSymptoms = "";
        FaultTypeRepairMethods = "";
    }
    
    private void UpdateAll()
    {
        SparePartModels = _sparePartService.ReadSpaceParts();
        RepairModels = _repairModelService.ReadRepairModels();
        FaultTypeModels = _faultTypeService.ReadFaultTypes();
    }

    // --- SparePart 
    private SparePartService _sparePartService = SparePartService.Shared;
    [ObservableProperty] private ObservableCollection<SparePartModel> _sparePartModels = new();
    [ObservableProperty] private SparePartModel? _selectedSparePartModel = null;
    [ObservableProperty] private string _sparePartError = "";
    [ObservableProperty] private string _sparePartId = "";
    [ObservableProperty] private string _sparePartName = "";
    [ObservableProperty] private string _sparePartFunctions = "";
    [ObservableProperty] private string _sparePartPrice = "";
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
            ClearAll();
            UpdateAll();
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
            ClearAll();
            UpdateAll();
        }
        catch (Exception e)
        {
            SparePartError = e.Message;
        }
    }

    // --- Repair Model
    
    private RepairModelService _repairModelService = RepairModelService.Shared;
    [ObservableProperty] private RepairModel? _selectedRepairModel = null;
    [ObservableProperty] private ObservableCollection<RepairModel> _repairModels = new();
    [ObservableProperty] private string _repairModelId = "";
    [ObservableProperty] private string _repairModelName = "";
    [ObservableProperty] private string _repairModelType = "";
    [ObservableProperty] private string _repairModelProducer = "";
    [ObservableProperty] private string _repairModelProperties = "";
    [ObservableProperty] private string _repairModelFeatures = "";
    [ObservableProperty] private string _repairModelError = "";
    
    public void AddRepairModel()
    {
        try
        {
            _repairModelService.AddRepairModel(new(
                RepairModelId,
                RepairModelName,
                RepairModelType,
                RepairModelProducer,
                RepairModelProperties,
                RepairModelFeatures
                ));
            ClearAll();
            UpdateAll();
        }
        catch (Exception e)
        {
            RepairModelError = e.Message;
        }
    }
    
    public void RemoveRepairModel()
    {
        try
        {
            if (SelectedRepairModel == null) return;
            _repairModelService.DeleteRepairModel(SelectedRepairModel);
            ClearAll();
            UpdateAll();
        }
        catch (Exception e)
        {
            RepairModelError = e.Message;
        }
    }
    
    // --- Fault types
    
    private FaultTypeService _faultTypeService = FaultTypeService.Shared;
    [ObservableProperty] private ObservableCollection<FaultTypeModel> _faultTypeModels = new();
    [ObservableProperty] private FaultTypeModel? _selectedFaultTypeModel = null;
    [ObservableProperty] private string _faultTypeError = "";
    [ObservableProperty] private string _faultTypeId = "";
    [ObservableProperty] private string _faultTypeModelId = "";
    [ObservableProperty] private string _faultTypeDescription = "";
    [ObservableProperty] private string _faultTypeSymptoms = "";
    [ObservableProperty] private string _faultTypeRepairMethods = "";

    public void AddFaultType()
    {
        try
        {
            _faultTypeService.AddFaultType(new FaultTypeModel(
                FaultTypeId,
                FaultTypeModelId,
                FaultTypeDescription,
                FaultTypeSymptoms,
                FaultTypeRepairMethods
            ));
            ClearAll();
            UpdateAll();
        }
        catch (Exception e)
        {
            FaultTypeError = e.Message;
        }
    }

    public void RemoveFaultType()
    {
        try
        {
            if (SelectedFaultTypeModel == null) return;
            _faultTypeService.DeleteFaultType(SelectedFaultTypeModel);
            ClearAll();
            UpdateAll();
        }
        catch (Exception e)
        {
            FaultTypeError = e.Message;
        }
    }
    
    
    
    


}
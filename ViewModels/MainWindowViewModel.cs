using CommunityToolkit.Mvvm.ComponentModel;

namespace ComputerService.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty] private bool _isSelectedFirstPage = true;
    [ObservableProperty] private bool _isSelectedSecondPage = false;
    [ObservableProperty] private bool _isSelectedThirdPage = false;
    [ObservableProperty] private bool _isSelectedFourthPage = false;

    public void ChangePage(int page)
    {
        IsSelectedFirstPage = page == 1;
        IsSelectedSecondPage = page == 2;
        IsSelectedThirdPage = page == 3;
        IsSelectedFourthPage = page == 4;
    }
    
    

}
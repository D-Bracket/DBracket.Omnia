using CommunityToolkit.Mvvm.ComponentModel;
using DBracket.Omnia.Api;

namespace DBracket.Omnia.App.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    #region "----------------------------- Private Fields ------------------------------"
    private OmniaCore _omniaCore;
    #endregion



    #region "------------------------------ Constructor --------------------------------"
    public MainViewModel()
    {
        _omniaCore = OmniaCore.GetInstance();
    }
    #endregion



    #region "--------------------------------- Methods ---------------------------------"
    #region "----------------------------- Public Methods ------------------------------"

    #endregion

    #region "----------------------------- Private Methods -----------------------------"

    #endregion

    #region "------------------------------ Event Handling -----------------------------"

    #endregion

    #region "----------------------------- Command Handling ----------------------------"

    #endregion
    #endregion



    #region "--------------------------- Public Propterties ----------------------------"
    #region "------------------------------- Properties --------------------------------"
    [ObservableProperty]
    private string _greeting = "Welcome to Avalonia!";
    #endregion

    #region "--------------------------------- Events ----------------------------------"

    #endregion

    #region "-------------------------------- Commands ---------------------------------"

    #endregion
    #endregion
}
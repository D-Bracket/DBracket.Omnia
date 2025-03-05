using CommunityToolkit.Mvvm.ComponentModel;
using DBracket.Common.UI.AvaloniaUI.Commands;
using DBracket.Omnia.Api;
using DBracket.Omnia.App.UserControls.Plugins.KeyboardOptimizer;
using System.Windows.Input;

namespace DBracket.Omnia.App.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    #region "----------------------------- Private Fields ------------------------------"
    private OmniaCore _omniaCore;
    private KeymizerCore _keymizerCore;
    #endregion



    #region "------------------------------ Constructor --------------------------------"
    public MainViewModel()
    {
        _omniaCore = OmniaCore.GetInstance();
        _keymizerCore = new();
        Commands = new GenericCommand<string>(HandleTest);
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
    private void HandleTest(string? command)
    {
        switch (command)
        {
            case "OpenKeymizer":
                _keymizerCore.Open();
                break;

            default:
                break;
        }
    }
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
    //public ReactiveCommand<Unit, Unit> DoTheThing { get; }+
    public ICommand Commands { get; } 
    #endregion
    #endregion
}
using Avalonia.Controls;
using System;

namespace DBracket.Omnia.App;

public partial class KeyboardOptimizerWindow : Window
{

    #region "----------------------------- Private Fields ------------------------------"

    #endregion



    #region "------------------------------ Constructor --------------------------------"
    public KeyboardOptimizerWindow(KeyboardOptimizerView _view)
    {
        InitializeComponent();
        PluginContent.Content = _view;
    }
    #endregion



    #region "--------------------------------- Methods ---------------------------------"
    #region "----------------------------- Public Methods ------------------------------"
    protected override void OnClosed(EventArgs e)
    {
        base.OnClosed(e);
        IsClosed = true;
    }
    #endregion

    #region "----------------------------- Private Methods -----------------------------"

    #endregion

    #region "------------------------------ Event Handling -----------------------------"

    #endregion
    #endregion



    #region "--------------------------- Public Propterties ----------------------------"
    #region "------------------------------- Properties --------------------------------"
    public bool IsClosed { get; private set; }
    #endregion

    #region "--------------------------------- Events ----------------------------------"

    #endregion
    #endregion

}
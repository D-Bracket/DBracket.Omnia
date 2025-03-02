namespace DBracket.Omnia.App.UserControls.Plugins.KeyboardOptimizer
{
    public class KeymizerCore
    {
        #region "----------------------------- Private Fields ------------------------------"
        private KeyboardOptimizerWindow? _window;
        private KeyboardOptimizerView _view;
        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public KeymizerCore()
        {
            _view = new KeyboardOptimizerView()
            {
                DataContext = new KeyboardOptimizerViewModel()
            };
        }
        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"
        public void Open()
        {
            if (_window == null || _window.IsClosed)
            {
                _window = new KeyboardOptimizerWindow(_view);
                _window.Show();
                return;
            }

            _window.Activate();
        }
        #endregion

        #region "----------------------------- Private Methods -----------------------------"

        #endregion

        #region "------------------------------ Event Handling -----------------------------"

        #endregion
        #endregion



        #region "--------------------------- Public Propterties ----------------------------"
        #region "------------------------------- Properties --------------------------------"

        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }
}
using System.Windows.Input;

namespace DBracket.Common.UI.AvaloniaUI.Commands
{
    public class GenericCommand<T> : ICommand
    {
        #region "----------------------------- Private Fields ------------------------------"
        private readonly Action<T?> _excute;
        private readonly Predicate<object?>? _predicate;
        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public GenericCommand(Action<T?> execute) : this(execute, null)
        {

        }

        public GenericCommand(Action<T?> execute, Predicate<object?>? canExecute)
        {
            _excute = execute;
            _predicate = canExecute;
        }
        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"
        public bool CanExecute(object? parameter)
        {
            return _predicate == null || _predicate(parameter);
        }

        public void Execute(object? parameter)
        {
            if (parameter is not T genericParameter)
                throw new Exception("Invalid CommandParameter");

            _excute(genericParameter);
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
        public event EventHandler? CanExecuteChanged;
        #endregion
        #endregion
    }
}
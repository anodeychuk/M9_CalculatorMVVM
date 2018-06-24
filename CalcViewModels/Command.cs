using System;
using System.Windows.Input;

namespace CalcViewModels
{
    /// <summary>
    /// General command with parameter
    /// </summary>
    public class Command : ICommand
    {
        private bool _canExecute;

        public event EventHandler CanExecuteChanged;
        private Action<object> Action { get; set; }

        /// <summary>
        /// Basic CanExecute
        /// </summary>
        private bool BasicCanExecute {
            get => _canExecute;
            set
            {
                this._canExecute = value;
                CanExecuteChanged?.Invoke(this, new EventArgs());
            }
        }

        #region Constructor
        public Command(Action<object> action, bool canExecute = true)
        {
            //  Set the action.
            this.Action = action;
            this.BasicCanExecute = canExecute;
            CanExecuteChanged += CanExecuteChangedMeth;
        }
        #endregion

        /// <summary>
        /// Actions are executed when the CanExecuteChanged event is called
        /// </summary>
        /// <param name="sender">Sender which invoked CanExecuteChanged</param>
        /// <param name="e">Parameters that are passed when the event is called</param>
        private void CanExecuteChangedMeth(object sender, EventArgs e) { }

        /// <summary>
        /// Whether it is possible to enforce the action
        /// </summary>
        /// <param name="parameter">Parameters of arithmetic operation (CalcModels.CalcOperationParam)</param>
        /// <returns>if it can execute returns true else false</returns>
        public bool CanExecute(object parameter)
        {
            return BasicCanExecute;
        }

        /// <summary>
        /// Executed of command action
        /// </summary>
        /// <param name="parameter">Parameters of arithmetic operation (CalcModels.CalcOperationParam)</param>
        public void Execute(object parameter)
        {
            if (CanExecute(parameter))
            {
                BasicCanExecute = false;
                Action?.Invoke(parameter);
                BasicCanExecute = true;
            }
        }
    }
}

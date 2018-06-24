using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CalcModels;

namespace CalcViewModels
{
    /// <summary>
    /// View Model for Main user interface of calculator
    /// </summary>
    public class CalcVM : INotifyPropertyChanged
    {
        #region Variables
        CalcOperationParam cop = new CalcOperationParam();
        string result = "0";
        string history = "";
        #endregion

        #region Properties
        /// <summary>
        /// result of the arithmetical operation
        /// </summary>
        public string Result
        {
            get => result;
            set
            {
                if (this.result != value)
                {
                    this.result = value;
                    this.OnPropertyChanged("Result");
                }
            }
        }
        
        /// <summary>
        /// history of the action
        /// </summary>
        public string History
        {
            get => history;
            set
            {
                if (this.history != value)
                {
                    this.history = value;
                    this.OnPropertyChanged("History");
                }
            }
        }
        #endregion

        #region Commands
        /// <summary>
        /// Command which invoke when calculator button click
        /// </summary>
        public ICommand BtnCommand { get; }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constructor
        public CalcVM()
        {
            BtnCommand = new Command((arg) => BtnMethod(arg));
            Arithmometer.Clear(ref cop);
        }
        #endregion

        /// <summary>
        /// Method which executes when BtnCommand invoke
        /// </summary>
        /// <param name="arg"></param>
        private void BtnMethod(object arg)
        {
            cop.arg = arg.ToString();
            Arithmometer.Calc(ref cop);
            Result = cop.result;
            History = cop.history;
        }

        /// <summary>
        /// Executes when properties changed.
        /// Needed for updating values in the use interface fields
        /// </summary>
        /// <param name="prop"></param>
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
  
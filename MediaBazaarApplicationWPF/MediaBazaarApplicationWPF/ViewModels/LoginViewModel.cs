using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MediaBazaarApplicationWPF.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        //Instance variable(s)
        private string _username;
        private string _password;
        //private readonly DelegateCommand _changeNameCommand;
        //public ICommand ChangeNameCommand => _changeNameCommand;

        private readonly DelegateCommand _loginCommand;
        public ICommand LoginCommand => _loginCommand;

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged();
                _loginCommand.InvokeCanExecuteChanged();
                //Alternative to the 2 lines above: SetProperty(ref _username, value);
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
                _loginCommand.InvokeCanExecuteChanged();
                //Alternative to the 2 lines above: SetProperty(ref _password, value);
            }
        }

        public LoginViewModel()
        {
            //_changeNameCommand = new DelegateCommand(OnChangeName, CanChangeName);
            _loginCommand = new DelegateCommand(OnLogin, CanClickLogin);
        }

        private void OnLogin(object commandParameter)
        {
            Console.WriteLine($"Tried to login with credentials: {this.Username}, {this.Password}");
        }

        private bool CanClickLogin(object commandParameter)
        {
            return !String.IsNullOrWhiteSpace(this.Username) && !String.IsNullOrWhiteSpace(this.Password);
        }

        //private void OnChangeName(object commandParameter)
        //{
        //    //FirstName = "Test";
        //    //_changeNameCommand.InvokeCanExecuteChanged(); Ability to toggle whether a command is enabled or disabled
        //}

        //private bool CanChangeName(object commandParameter)
        //{
        //    //return FirstName != "Test";
        //    return true;
        //}
    }
}

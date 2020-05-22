using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MediaBazaarApplicationWPF.ViewModels;
using MediaBazaarApplicationWPF.Views;
using MySql.Data.MySqlClient;

namespace MediaBazaarApplicationWPF.Commands
{
    public class OnLoginCommand : ICommand
    {
        private LoginViewModel viewModel;
        public event EventHandler CanExecuteChanged;

        public OnLoginCommand(LoginViewModel viewModel) { this.viewModel = viewModel; }

        public void Execute(object parameter)
        {
            if (!string.IsNullOrEmpty(viewModel.Username) && !string.IsNullOrEmpty(viewModel.Password))
            {
                using (MySqlConnection conn = SqlConnectionHandler.GetSqlConnection())
                {
                    try
                    {
                        using (MySqlCommand cmd = new MySqlCommand($"SELECT userID, username, password, role FROM users WHERE username=@username AND password=@password", conn))
                        {
                            cmd.Parameters.AddWithValue("@username", viewModel.Username);
                            cmd.Parameters.AddWithValue("@password", HashManager.GetSha256(viewModel.Password));
                            MySqlDataReader dataReader = cmd.ExecuteReader();

                            if (dataReader.Read())
                            {
                                LoggedInUser.userID = dataReader.GetString(0);
                                LoggedInUser.role = (EmployeeRole)dataReader.GetInt16(3);
                                //Opening dashboard on successful login
                                //Most likely bad practice. Might be changed in future version of the app
                                var newWindow = new DashboardView();
                                newWindow.Show();
                                (parameter as LoginView).Close();
                            }
                            else MessageBox.Show("Failed login attempt. Please try again.");
                        }
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show(ex.ToString(), $"Login failed");
                    }
                    conn.Close();
                }
            }
            else MessageBox.Show("Please fill all required fields before attempting to log in!");

            //Console.WriteLine($"Tried to login with credentials: {viewModel.Username}, {viewModel.Password}");
            ////Most likely bad practice. Ask Georgiana
            //var newWindow = new DashboardView();
            //newWindow.Show();
            //(parameter as LoginView).Close();
        }

        public bool CanExecute(object parameter)
        {
            return !String.IsNullOrWhiteSpace(viewModel.Username) && !String.IsNullOrWhiteSpace(viewModel.Password);
        }

        public void InvokeCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MediaBazaarApplicationWPF
{
    public class Employee
    {
        #region #Instance variable(s)

        private string userID;
        private string username;
        private string password;
        private decimal salaryHourlyRate;
        private EmployeeRole role;
        private string departmentID;
        private string departmentName;
        private string firstName;
        private string lastName;
        private string nationality;
        private string address;
        private string email;
        private string phoneNumber;
        private DateTime? dateofBirth;
        private bool? sex;
        private DateTime? startDate;
        private DateTime? endDate;
        private int workHours;
        private double attendance;
        #endregion

        #region #Properties

        public string UserID
        {
            get { return this.userID; }
            private set { this.userID = value; }
        }

        public string Username
        {
            get { return this.username; }
            set
            {
                Regex usernameValidation = new Regex(@"^\w+$");

                if (value != null && usernameValidation.IsMatch(value)) this.username = value;
                else throw new ArgumentException("Invalid username has been parsed to employee. Given value contains special characters.");              
            }
        }

        public string Password
        {
            get { return this.password; }
            set
            {
                Regex passwordValidation = new Regex(@"^\w+$");

                if (value != null && passwordValidation.IsMatch(value)) this.password = HashManager.GetSha256(value);
                else throw new ArgumentException("Invalid password has been parsed to employee. Given value contains special characters.");
            }
        }

        public decimal SalaryHourlyRate
        {
            get { return this.salaryHourlyRate; }
            set
            {
                if (value >= 0) this.salaryHourlyRate = value;
                else throw new ArgumentException("Invalid salary rate has been parsed to employee. Given value cannot be lower than 0.");
            }
        }

        public EmployeeRole Role
        {
            get { return this.role; }
            private set { this.role = value; }
        }

        public string DepartmentID
        {
            get { return this.departmentID; }
            set { this.departmentID = value; }
        }

        public string DepartmentName
        {
            get { return this.departmentName; }
            set { this.departmentName = value; }
        }

        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                Regex nameValidation = new Regex(@"\d+");

                if(value != null)
                {
                    if(!nameValidation.IsMatch(value)) this.firstName = value;
                    else throw new ArgumentException("Invalid first name has been parsed to employee. Given value cannot contain digits.");
                }
              
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            set
            {
                Regex nameValidation = new Regex(@"\d+");

                if (value != null)
                {
                    if(!nameValidation.IsMatch(value)) this.lastName = value;
                    else throw new ArgumentException("Invalid last name has been parsed to employee. Given value cannot contain digits.");
                }
                
            }
        }

        public string Name
        {
            get
            {
                if (!string.IsNullOrEmpty(this.firstName) && !string.IsNullOrEmpty(this.lastName)) return $"{this.firstName} {this.lastName} ({this.departmentName})";
                else return $"{this.Username} ({this.departmentName})";
            }
        }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(this.firstName) && !string.IsNullOrEmpty(this.lastName)) return $"{this.firstName} {this.lastName} ({this.departmentName})";
            else return $"{this.Username} ({this.departmentName})";
        }

        public string Nationality
        {
            get { return this.nationality; }
            set
            {
                Regex nationalityValidation = new Regex(@"\d+");

                if(value != null)
                {
                    if(!nationalityValidation.IsMatch(value)) this.nationality = value;
                    else throw new ArgumentException("Invalid nationality has been parsed to employee. Given value cannot contain digits.");
                }
                
            }
        }

        public string Address
        {
            get { return this.address; }
            set {
                if(value!=null )
                this.address = value; 
                else throw new ArgumentException("Address cant be null");
            }
        }

        public string Email
        {
            get { return this.email; }
            set
            {
                Regex emailValidation = new Regex(@"^(([^<>()[\]\\.,;:\s@\""]+(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$");

                if(value != null)
                {
                    if(emailValidation.IsMatch(value)) this.email = value;
                    else throw new ArgumentException("Invalid e-mail address has been parsed to employee.");
                }
                
            }
        }

        public string PhoneNumber
        {
            get { return this.phoneNumber; }
            set
            {
                Regex phoneValidation = new Regex(@"^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$");

                if(value != null)
                {
                    if(phoneValidation.IsMatch(value)) this.phoneNumber = value;
                    else throw new ArgumentException("Invalid phone number has been parsed to employee.");
                }
            }
        }

        public DateTime? DateOfBirth
        {
            get { return this.dateofBirth; }
            set
            {
                if(value != null)
                {
                    if (value < DateTime.Now) this.dateofBirth = value;
                    else throw new ArgumentException("Invalid birth date has been parsed to employee. Given value is a future point in time.");
                }
            }
        }

        public string FullName
        { 
            get { if (string.IsNullOrWhiteSpace(this.FirstName) && string.IsNullOrWhiteSpace(this.LastName)) return this.Username;
                else return $"{this.FirstName} {this.LastName} ({this.Username})";
            } 
        }

        public bool? Sex
        {
            //Binary: 0 = Male, 1 = Female
            get { return this.sex; }
            set { this.sex = value; }
        }

        public DateTime? StartDate
        {
            get { return this.startDate; }
            set { this.startDate = value; }
        }

        public DateTime? EndDate
        {
            get { return this.endDate; }
            set { this.endDate = value; }
        }

        public int WorkHours
        {
            get { return workHours; }
            set
            {
                if (value % 4 == 0 && value >= 0) this.workHours = value;
                else throw new ArgumentException("Invalid work hours has been parsed to employee.");
            }
        }

        public double Attendance
        {
            get { return attendance; }
            set
            {
                if(value >= 0) this.attendance = value;
                else throw new ArgumentException("Invalid attendance has been parsed to employee. Given value cannot be a negative number.");
            }
        }
        #endregion

        #region #Constructor(s)

        public Employee(string userID, string username, string password, decimal salaryRate, EmployeeRole role, string depID, int workHours, bool hashPassword)
        {
            this.UserID = userID;
            this.Username = username;
            if (hashPassword) this.password = HashManager.GetSha256(password);
            else this.password = password;
            this.SalaryHourlyRate = salaryRate;
            this.Role = role;
            this.DepartmentID = depID;
            this.WorkHours = workHours;
            this.StartDate = DateTime.Today;
        }
        #endregion

        #region #Method(s)

        public void SetPersonalInfo(string fName, string lName, DateTime? dateOfBirth, bool? sex)
        {
            this.FirstName = fName;
            this.LastName = lName;
            this.DateOfBirth = dateOfBirth;
            this.Sex = sex;
        }

        public void SetPersonalInfo(string fName, string lName, string nationality, string address, string email, string phoneNum, DateTime? dateOfBirth, bool? sex)
        {
            this.FirstName = fName;
            this.LastName = lName;
            this.Nationality = nationality;
            this.Address = address;
            this.Email = email;
            this.PhoneNumber = phoneNum;
            this.DateOfBirth = dateOfBirth;
            this.Sex = sex;
        }
        #endregion
    }
}

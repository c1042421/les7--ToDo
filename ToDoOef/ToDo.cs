using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ToDoOef
{
    class ToDo : INotifyPropertyChanged, IDataErrorInfo
    {
        private string _wanneer;
        private string _wat;
        private string _wie;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool isValid() => string.IsNullOrEmpty(Error);

        public ToDo(string wie, string wat, string wanneer)
        {
            Wanneer = wanneer;
            Wat = wat;
            Wie = wie;
        }

        public ToDo() : this("", "", "") { }

        public string Wanneer { get => _wanneer; set {
                _wanneer = value;
                RaisePropertyChanged("Wanneer");
                RaisePropertyChanged("Gegevens");
            }
        }
        public string Wat { get => _wat; set {
                _wat = value;
                RaisePropertyChanged("Wat");
                RaisePropertyChanged("Gegevens");
            }
        }
        public string Wie { get => _wie; set {
                _wie = value;
                RaisePropertyChanged("Wie");
                RaisePropertyChanged("Gegevens");
            }
        }
        public string Gegevens { get => string.Format("{0} {1}: {2}", Wanneer, Wie, Wat); }

        private void RaisePropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

        public string Error
        {
            get
            {
                string result = "";
                string error = "";

                foreach (PropertyInfo prop in this.GetType().GetProperties())
                {
                    error = this[prop.Name];
                    if (!string.IsNullOrEmpty(error))
                    {
                        result = error + Environment.NewLine;
                    }
                }
                return result;
            }
        }

        public string this[string columnName]
        {
            get
            {
                string result = null;
                bool wieIsEmpty = String.IsNullOrEmpty(Wie) && columnName == "Wie";
                bool wanneerIsEmty = String.IsNullOrEmpty(Wanneer) && columnName == "Wanneer";
                bool watIsEmpty = String.IsNullOrEmpty(Wat) && columnName == "Wat";

                if (wieIsEmpty)
                {
                    result = "Geef een taak in!";
                }
                if (wanneerIsEmty)
                {
                    result = "Geef een datum in!";
                }
                if (watIsEmpty)
                {
                    result = "Geef een naam in!";
                }
                return result;
            }
        }

        public override string ToString() => Wie + Environment.NewLine + Wat + Environment.NewLine + Wanneer;
    }
}


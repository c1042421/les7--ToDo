using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ToDoOef
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ToDo[] todos;

        public MainWindow()
        {
            InitializeComponent();
            MakeTodos();
            //cmdToDo.DisplayMemberPath = "Gegevens";
            cmdToDo.ItemsSource = todos;
        }

        private void MakeTodos()
        {
            todos = new ToDo[4];
            todos[0] = new ToDo("Jefke", "huiswerk maken", "2017-11-08");
            todos[1] = new ToDo("Jefke", "sporten", "2017-11-09");
            todos[2] = new ToDo("Jantje", "afwas doen", "2017-11-10");
            todos[3] = new ToDo("Jefke", "gras afdoen", "2017-11-10");
        }

        private void btnVerzenden_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

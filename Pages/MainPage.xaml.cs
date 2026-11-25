using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
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

namespace Pract10.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public ObservableCollection<Computer> list { get; set; } = new();

        public Computer? cur { get; set; } = null;

        public MainPage()
        {
            InitializeComponent();

            this.Loaded += PreviousPage_Loaded;

            DataContext = this;


        }


        void GetList()
        {
            list.Clear();

            int i = 0;

            while (File.Exists($"comp{i}.json"))
            {
                string fileName = $"comp{i}.json";
                string jsonString = File.ReadAllText(fileName);
                var item = JsonSerializer.Deserialize<Computer>(jsonString);
                item.id = i;
                list.Add(item);
                i++;
            }


        }

        private void PreviousPage_Loaded(object sender, RoutedEventArgs e)
        {
            GetList();
        }

        private void Create(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreateComp(cur));
        }

        private void ProcSelect(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Copy(object sender, RoutedEventArgs e)
        {
            if (cur != null)
            {
                Computer.Clone(cur);
                GetList();
            }
            else
                MessageBox.Show("Выберите запись");
        }

        private void CopyCreate(object sender, RoutedEventArgs e)
        {
            if (cur != null)
            {
                cur.id = -1;
                NavigationService.Navigate(new CreateComp(cur));
                cur = null;
            }
        }
    }
}

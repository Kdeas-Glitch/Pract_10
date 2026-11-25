using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pract10
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Computer> list { get; set; } = new();

        public string curProc { get; set; } ="";
        public string curVram { get; set; } = "";
        public string curAcum { get; set; } = "";
        public string curVideo { get; set; } = "";

        public MainWindow()
        {
            InitializeComponent();

            Computer t = new();

            

            GetList();
        }

        void GetList()
        {
            list.Clear();

            int i = 0;

            while (File.Exists($"comp{i}.json"))
            {
                string fileName = $"comp{i}.json";
                string jsonString = File.ReadAllText(fileName);
                list.Add(JsonSerializer.Deserialize<Computer>(jsonString));
                i++;
            }


        }

        private void Create(object sender, RoutedEventArgs e)
        {
            Computer cp = new();

            cp.addRam("");
        }
    }
}
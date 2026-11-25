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

namespace Pract10.Pages
{
    /// <summary>
    /// Логика взаимодействия для CreateComp.xaml
    /// </summary>
    public partial class CreateComp : Page
    {
        public int curProc { get; set; } = -1;
        public int curVram { get; set; } = -1;
        public int curAcum { get; set; } = -1;
        public int curVideo { get; set; } = -1;

        public Computer t = new();

        public CreateComp(Computer r)
        {

            InitializeComponent();


            if (r != null)
            {
                Stack1.Visibility = Visibility.Visible;
                Stack2.Visibility = Visibility.Visible;
                Stack3.Visibility = Visibility.Visible;
                Buttton.Visibility = Visibility.Visible;

                Buttton.Content = "Сохранить";

                t = r;

                if (t.Proc == "intel")
                    curProc = 0;
                else
                    curProc = 1;

                if (t.Vram == "8 битов")
                    curVram = 0;
                else
                    curVram = 1;

                if (t.Accumulator == "SSD")
                    curAcum = 0;
                else
                    curAcum = 1;
                if (t.Video == "GeForce")
                    curVideo = 0;
                else
                    curVideo = 1;
            }

            DataContext = this;
        }

        private void Create(object sender, RoutedEventArgs e)
        {
            if (t.Build(t))
            {
                MessageBox.Show("Успешно");
                NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show("Неверные данные");
            }
        }

        private void ProcSelect(object sender, SelectionChangedEventArgs e)
        {
            Stack1.Visibility= Visibility.Visible;
            if (curProc == 0)
                t.addProc("intel");
            else
                t.addProc("amd");
        }

        private void VramSelect(object sender, SelectionChangedEventArgs e)
        {
            Stack2.Visibility = Visibility.Visible;
            if (curVram == 0)
                t.addRam("8 битов");
            else
                t.addRam("1 КилоБайт");
        }

        private void AcumSelect(object sender, SelectionChangedEventArgs e)
        {
            Stack3.Visibility = Visibility.Visible;
            if (curAcum == 0)
                t.addAcum("SSD");
            else
                t.addAcum("HDD");
        }

        private void VideoSelect(object sender, SelectionChangedEventArgs e)
        {
            Buttton.Visibility = Visibility.Visible;
            if (curVideo == 0)
                t.addVideo("GeForce");
            else
                t.addVideo("Radeon");
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}

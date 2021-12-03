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
using System.IO;

namespace test2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        //tab1 add save work
        private void tab1ButtonAdd_Click(object sender, RoutedEventArgs e)
        {

        }


        //tab2 run save work
        private void tab2ButtonStartSequentialRun_Click(object sender, RoutedEventArgs e)
        {

        }

        private void tab2ButtonStartSingleRun_Click(object sender, RoutedEventArgs e)
        {

        }

        private void tab2ButtonPause_Click(object sender, RoutedEventArgs e)
        {

        }

        private void tab2ButtonStop_Click(object sender, RoutedEventArgs e)
        {

        }

        //tab3 Settings 
        private void tab3ButtonUserGuide_Click(object sender, RoutedEventArgs e)
        {
            OpenProcess.OpenProcessFunction("notepad.exe", @"..\..\..\Files\UserGuide.txt");
        }

        private void tab3ButtonOpenConfig_Click(object sender, RoutedEventArgs e)
        {
            OpenProcess.OpenProcessFunction("notepad.exe", @"..\..\..\Files\work.json");

        }

        private void tab3ButtonOpenLogs_Click(object sender, RoutedEventArgs e)
        {
            OpenProcess.OpenProcessFunction("notepad.exe", @"..\..\..\Files\log.json");

        }

        //button close
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

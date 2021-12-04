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

        private void tab3ButtonFrench_Click(object sender, RoutedEventArgs e)
        {
            
            Button clickedButton = (Button)sender;
            //clickedButton.Content = "...button clicked...";
            clickedButton.IsEnabled = false;
            tab3ButtonEnglish.IsEnabled = true;

            tab1SaveWork.Header = "Ajouter un travail de sauvegarde";
            tab2RunWork.Header = "Executer un travail de sauvegarde";
            tab3Settings.Header = "Paramètres";
            tab1TextBlockDescription.Text = "Le meilleur logiciel de gestion de sauvegarde que vous puissiez avoir !";
            tab2TextBlockDescription.Text = "Le meilleur logiciel de gestion de sauvegarde que vous puissiez avoir !";
            tab3TextBlockDescription.Text = "Le meilleur logiciel de gestion de sauvegarde que vous puissiez avoir !";
            tab1LabelName.Content = "Nom du TS :";
            tab1LabelSourcePath.Content = "Chemin source :";
            tab1LabelTargetPath.Content = "Chemin cible :";
            tab1LabelType.Content = "Type de TS :";
            tab1SelectTypeFull.Content = "Complet";
            tab1SelectTypeDifferential.Content = "Différentiel";
            tab1LabelCrypted.Content = "Fichiers chiffrés :";
            tab1CheckCrypted.Content = "Chiffrés";
            tab1ButtonAdd.Content = "Ajouter";
            tab2ButtonStartSequentialRun.Content = "Lancement séquentiel";
            tab2TextBoxNumber.Text = "Nombre";
            tab2ButtonStartSingleRun.Content = "Lancement unique";
            tab2LabelProgessBar.Content = "Progression";
            tab2ButtonPause.Content = "Pause";
            tab2ButtonStop.Content = "Stop";
            tab3ButtonFrench.Content = "Français";
            tab3ButtonEnglish.Content = "Anglais";
            tab3ButtonUserGuide.Content = "Ouvrir le guide utilisateur";
            tab3ButtonOpenConfig.Content = "Ouvrir la configuration";
            tab3ButtonOpenLogs.Content = "Ouvrir les logs";

        }
        private void tab3ButtonEnglish_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            //clickedButton.Content = "...button clicked...";
            clickedButton.IsEnabled = false;
            tab3ButtonFrench.IsEnabled = true;
            /*
            tab1SaveWork.Header = "Add Save Work";
            tab2RunWork.Header = "Run Save Work";
            tab3Settings.Header = "Settings";
            tab1TextBlockDescription.Text = "The best backup management software you can have !";
            tab2TextBlockDescription.Text = "The best backup management software you can have !";
            tab3TextBlockDescription.Text = "The best backup management software you can have !";
            tab1LabelName.Content = "Save work name :";
            tab1LabelSourcePath.Content = "Source path :";
            tab1LabelTargetPath.Content = "Target path :";
            tab1LabelType.Content = "Save work type :";
            tab1SelectTypeFull.Content = "Full";
            tab1SelectTypeDifferential.Content = "Differential";
            tab1LabelCrypted.Content = "Files encrypted :";
            tab1CheckCrypted.Content = "Crypted";
            tab1ButtonAdd.Content = "Add";
            tab2ButtonStartSequentialRun.Content = "Start Sequential Run";
            tab2TextBoxNumber.Text = "Number";
            tab2ButtonStartSingleRun.Content = "Start Single Run";
            tab2LabelProgessBar.Content = "Progress";
            tab2ButtonPause.Content = "Pause";
            tab2ButtonStop.Content = "Stop";
            tab3ButtonFrench.Content = "French";
            tab3ButtonEnglish.Content = "English";
            tab3ButtonUserGuide.Content = "Open User Guide";
            tab3ButtonOpenConfig.Content = "Open Config";
            tab3ButtonOpenLogs.Content = "Open Logs";
            */

            Object[] contentToTranslate = {
                tab1SaveWork.Header,
                tab2RunWork.Header,
                tab3Settings.Header,
                tab1TextBlockDescription.Text,
                tab2TextBlockDescription.Text,
                tab3TextBlockDescription.Text,
                tab1LabelName.Content,
                tab1LabelSourcePath.Content,
                tab1LabelTargetPath.Content,
                tab1LabelType.Content,
                tab1SelectTypeFull.Content,
                tab1SelectTypeDifferential.Content,
                tab1LabelCrypted.Content,
                tab1CheckCrypted.Content,
                tab1ButtonAdd.Content,
                tab2ButtonStartSequentialRun.Content,
                tab2TextBoxNumber.Text,
                tab2ButtonStartSingleRun.Content,
                tab2LabelProgessBar.Content,
                tab2ButtonPause.Content,
                tab2ButtonStop.Content,
                tab3ButtonFrench.Content,
                tab3ButtonEnglish.Content,
                tab3ButtonUserGuide.Content,
                tab3ButtonOpenConfig.Content,
                tab3ButtonOpenLogs.Content
            };

            ChangeLang test = new ChangeLang();
            test.changeLangFunction(contentToTranslate, test.englishTranslation);
        }
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

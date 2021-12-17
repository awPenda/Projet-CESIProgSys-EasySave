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
using System.Threading;

namespace test2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window


    {

        EasySave execWork = EasySave.Getinstance();
        public ManualResetEvent _resetevnt = new ManualResetEvent(true);
        public static List<(string Nom, Thread t)> ls_thread = new List<(string Nom, Thread t)>();


        Work list;

        ChangeLang lang = new ChangeLang();

        public MainWindow()
        {
            //InitializeComponent();
            Server server = Server.GetInstance(); //SINGELTON
            server.StartServer();
        }


        //tab1 add save work
        private void tab1ButtonAdd_Click(object sender, RoutedEventArgs e)
        {

            if (tab1TextBoxName.Text != "" && tab1TextBoxSourcePath.Text != "" && tab1TextBoxTargetPath.Text != "" && tab1SelectType.Text != "")
            {
                test2.EasySave addWork = new test2.EasySave();

                int fCount = Directory.GetFiles(tab1TextBoxSourcePath.Text, "*", SearchOption.AllDirectories).Length;
                long size = addWork.GetFileSizeSumFromDirectory(tab1TextBoxSourcePath.Text);

                try
                {
                    addWork.addWork(size, fCount, tab1TextBoxName.Text, tab1TextBoxSourcePath.Text, tab1TextBoxTargetPath.Text, tab1SelectType.Text);
                    tab1TextBoxName.Text = "";
                    tab1TextBoxSourcePath.Text = "";
                    tab1TextBoxTargetPath.Text = "";
                    tab1SelectType.Text = "";
                    tab1SaveWork_Loaded(sender, e);

                }
                catch
                {


                    MessageBox.Show(lang.printError);


                    tab1TextBoxName.Text = "";
                    tab1TextBoxSourcePath.Text = "";
                    tab1TextBoxTargetPath.Text = "";
                    tab1SelectType.Text = "";
                }
            }
            else
            {



                MessageBox.Show(lang.printFillOut);

            }

        }


        //tab2 run save work
        private void tab2ButtonStartSequentialRun_Click(object sender, RoutedEventArgs e)
        { /*
            test2.EasySave exeseqWork = new test2.EasySave();
            try
            {
                exeseqWork.ExecuteAllWork();

                MessageBox.Show(lang.printExecutedworks);
                tab2DataGrid_Loaded(sender, e);
                tab1SaveWork_Loaded(sender, e);

            }
            catch
            {
                MessageBox.Show(lang.printError);
            } */
        }

        private void tab2ButtonStartSingleRun_Click(object sender, RoutedEventArgs e)
        {
            if (tab2TextBoxNumber.Text != "")
            {
                test2.EasySave exeWork = new test2.EasySave();
                string input = tab2TextBoxNumber.Text;


                Thread th_Exe_Work = new Thread(() => exeWork.ExecuteWork(input));
                    
                    MessageBox.Show(tab2TextBoxNumber.Text + lang.printHasBeenExecuted);
                    th_Exe_Work.Name = list.name;
                    th_Exe_Work.Start();
                    ls_thread.Add((list.name, th_Exe_Work));

                tab2TextBoxNumber.Text = "";

                tab1SaveWork_Loaded(sender, e);
            }
            else
            {



                MessageBox.Show(lang.printFillOut);

            }
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
            tab3ButtonConfigureBuisnessSoftware.Content = "Configurer le Logiciel Métier";
            tab3ButtonConfigureTypeFilesToEncrypt.Content = "Configurer le type de fichier à chiffrer";

            MessageBox.Show(lang.changeMessageBoxLang("french"));
        }
        private void tab3ButtonEnglish_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            //clickedButton.Content = "...button clicked...";
            clickedButton.IsEnabled = false;
            tab3ButtonFrench.IsEnabled = true;

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
            tab3ButtonConfigureBuisnessSoftware.Content = "Configure Buisness Software";
            tab3ButtonConfigureTypeFilesToEncrypt.Content = "Configure Type of Files to Encrypt";

            MessageBox.Show(lang.changeMessageBoxLang("english"));
            /*
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
                tab3ButtonOpenLogs.Content,
                tab3ButtonConfigureBuisnessSoftware.Content,
                tab3ButtonConfigureTypeFilesToEncrypt.Content,
                lang.printError,
                lang.printFillOut,
                lang.printExecutedworks,
                lang.printHasBeenExecuted,
                lang.printEmptyTargetDir,
                lang.printEmptySourceDir
            };
            */

            
            
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

        private void TargetPATH_Clicked(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog
            Ookii.Dialogs.Wpf.VistaFolderBrowserDialog openDlg = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();

            // Launch OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = openDlg.ShowDialog();
            // Get the selected file name and display in a TextBox.
            // Load content of file in a TextBlock
            if (result == true)
            {
                tab1TextBoxTargetPath.Text = openDlg.SelectedPath;
                // TextBlock1.Text = System.IO.File.ReadAllText(openFileDlg.FileName);
            }
            else
            {
                MessageBox.Show(lang.printEmptyTargetDir);
            }

        }
        private void SourcePath_Clicked(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog
            Ookii.Dialogs.Wpf.VistaFolderBrowserDialog openDlg = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();

            // Launch OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = openDlg.ShowDialog();
            // Get the selected file name and display in a TextBox.
            // Load content of file in a TextBlock
            if (result == true)
            {
                tab1TextBoxSourcePath.Text = openDlg.SelectedPath;
                // TextBlock1.Text = System.IO.File.ReadAllText(openFileDlg.FileName);
            }
            else
            {

                MessageBox.Show(lang.printEmptySourceDir);
            }

        }

        private void tab1SaveWork_Loaded(object sender, RoutedEventArgs e)
        {
            test2.EasySave DisplayWorks = new test2.EasySave();
            tab1DataGrid.ItemsSource = DisplayWorks.displayWorks();
        }



        private void tab1DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void tab2DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            test2.EasySave DisplayWorks = new test2.EasySave();
            tab2DataGrid.ItemsSource = DisplayWorks.displayWorks();
        }

        private void tab2DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void tab3ButtonConfigureBuisnessSoftware_Click(object sender, RoutedEventArgs e)
        {
            //here you just have to change log.json with the file you want tu put buisness software
           // OpenProcess.OpenProcessFunction("notepad.exe", @"..\..\..\Files\log.json");
            // Create OpenFileDialog
            Ookii.Dialogs.Wpf.VistaFolderBrowserDialog openDlg = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();

            // Launch OpenFileDialog by calling ShowDialog method

            Nullable<bool> result = openDlg.ShowDialog();

            // Get the selected file name and display in a TextBox.
            // Load content of file in a TextBlock
            // Load content of file in a TextBlock
            if (result == true)
            {
                //tab1TextBoxSourcePath.Text = openDlg.SelectedPath;
                tab3logicielmetier.Text = openDlg.SelectedPath;
                // TextBlock1.Text = System.IO.File.ReadAllText(openFileDlg.FileName);
            }

        }

        private void tab3ButtonConfigureTypeFilesToEncrypt_Click(object sender, RoutedEventArgs e)
        {
            OpenProcess.OpenProcessFunction("notepad.exe", @"..\..\..\Files\extensions.json");

            //here you just have to change log.json with the file you want tu put the extensions for the files to encrypt

            /* Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
             dialog.Multiselect = true;
             dialog.InitialDirectory = tab1TextBoxSourcePath.Text;
             if (tab1TextBoxSourcePath.Text != "")
             {
                 dialog.ShowDialog();

                 foreach (var file in dialog.FileNames)
                 {
                     var fileToCrypt = file.Replace(tab1TextBoxSourcePath.Text, tab1TextBoxTargetPath.Text);
                     test2.CryptoSoft dr = new test2.CryptoSoft();
                     dr.Cryptage(tab1TextBoxSourcePath.Text, tab1TextBoxTargetPath.Text);
                 }
             }
             else
             { MessageBox.Show("veuillez entrer un chemin valide"); }
             }
         }
            */
        }

        private void tab2DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                list = (Work)tab2DataGrid.SelectedItems[0];
                var o = tab2DataGrid.SelectedIndex + 1;
                tab2TextBoxNumber.Text = o.ToString();
                //MessageBox.Show(o.ToString());
                var indexx = tab2DataGrid.SelectedIndex;
                //supp.Text = indexx.ToString();

            }
            catch
            {

            }
        }
    }
}

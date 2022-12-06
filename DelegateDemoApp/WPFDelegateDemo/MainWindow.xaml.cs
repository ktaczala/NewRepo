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
using System.ComponentModel;

namespace WPFDelegateDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static BackgroundWorker? BGW;
        public MainWindow()
        {
            InitializeComponent();
            //create a BackGroundWorker
            BGW = new BackgroundWorker
            {
                WorkerSupportsCancellation = true,
                WorkerReportsProgress = true
            };
            // create the BackGroundWorker events
            BGW.DoWork += BGW_DoWork;
            BGW.RunWorkerCompleted += BGW_RunWorkerCompleted;
            BGW.ProgressChanged += BGW_ProgressChanged;
        }
        private void ManualButton_Click(object sender, RoutedEventArgs e)
        {
            // check if already running
            if (WPFManualButton.Content.ToString() == "Stop Manual")
            {
                // if so then rename button 
                WPFManualButton.Content = "Start Manual";
                // set flag to stop requested
                WPFVariables.stopManual = true;
                return;
            }
            // set button the show stop
            WPFManualButton.Content = "Stop Manual";
            // reset values
            WPFManualPBar.Value = 0;
            WPFManualCountLabel.Content = "0%";
            // call method to increment progressbar
            WPFUpdateProgressBar.IncrementProgressBar(Callback, 100);
            // do cleanup
            WPFManualButton.Content = "Start Manual";
        }
        //callback for the manual process
        private void Callback(int i)
        {
            // set label text to current count
            WPFManualCountLabel.Content = $"{i}%";
            // set progressbar to current count
            WPFManualPBar.Value = i;
            // added try .. catch because if closing form while jobs are running 
            // caused exception of control was disposed before Form Update triggered
            // this is needed to update form if the manual job is also running
            // the form update affects all jobs in conjuction with the delay of the manual job
            // i.e. NEVER mix a sync job with an async job
            try
            {
                // update the form
                Application.Current.Dispatcher.Invoke(
        System.Windows.Threading.DispatcherPriority.Background,
        new System.Threading.ThreadStart(() => { }));
            }
            //set abort flag because form was closed while job running
            catch { WPFVariables.stopManual = true; }
        }
        private void WPFBGWButton_Click(object sender, RoutedEventArgs e)
        {
            // test if back ground worker is alreay busy
            if (BGW!.IsBusy)
            {
                // cancel if it is
                BGW.CancelAsync();
                //rename button 
                WPFBGWButton.Content = "Start BackGroundWorker";
                // exit method
                return;
            }
            // reset values
            WPFBGWPBar.Value = 0;
            WPFBGWCountLabel.Content = "0%";
            //rename button 
            WPFBGWButton.Content = "Stop BackGroundWorker";
            // start the job
            BGW.RunWorkerAsync();
        }
        // callback for the background worker process
        private void Callback1(int i, DoWorkEventArgs e)
        {
            // call report progress
            BGW!.ReportProgress(i);
        }
        // invoke the back ground job
    private void BGW_DoWork(object? sender, DoWorkEventArgs e)
        {
            // do the work using callback to update form
#pragma warning disable CS8604 // Possible null reference argument.
            WPFUpdateProgressBar.IncrementProgressBarBW(Callback1, 100, e, sender);
#pragma warning restore CS8604 // Possible null reference argument.
        }
        private void BGW_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {
            // do cleanup
            WPFBGWButton.Content = "Start BackGroundWorker";
        }
        private void BGW_ProgressChanged(object? sender, ProgressChangedEventArgs e)
        {
            //update the label to the current count
            WPFBGWCountLabel.Content = $"{e.ProgressPercentage}%";
            // set the progress bar to the current value
            WPFBGWPBar.Value = e.ProgressPercentage;
        }
    }
}


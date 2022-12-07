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
using System.Threading;

namespace WPFDelegateDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static BackgroundWorker? BGW;
        CancellationTokenSource? _cancelSource = null;
        CancellationTokenSource? _iCancelSource = null;

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
        private void ManualButton_Click(object sender, RoutedEventArgs? e)
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
        private void WPFBGWButton_Click(object sender, RoutedEventArgs? e)
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

        private async void WPFAsyncButton_Click(object sender, RoutedEventArgs? e)
        {
            // check if Async is already running
            if (WPFAsyncButton.Content.ToString() == "Stop Async")
            {
                // if so cancel it rename button text
                _cancelSource!.Cancel();
                WPFAsyncButton.Content = "Start Async";
                return;
            }
            // button clicked to start job
            //initialize cancel token source
            _cancelSource = new CancellationTokenSource();
            // create a token variable
            var token = _cancelSource.Token;
            // set button to stop value
            WPFAsyncButton.Content = "Stop Async";
            //reset values
            WPFAsyncPBar.Value = 0;
            WPFAsyncCountLabel.Content = "0%";
            // do the work using a delegate
            try
            {
                // run job async using callback to update form
                await Task.Run(() => WPFUpdateProgressBar.IncrementProgressBarAsync(Callback2, 100, token));
            }
            // come here if canceled
            catch (OperationCanceledException)
            {
                // mention canceled if desired
            }
            finally
            {
                // do cleanup
                _cancelSource.Dispose();
                WPFAsyncButton.Content = "Start Async";
            }
        }
        private async void Callback2(int i)
        {
            // Update the counter and the progressbar using invoke if needed
            await Task.Run(() =>
                {
                    Application.Current.Dispatcher.Invoke(
                        () =>
                        {
                            try
                            {
                                WPFAsyncCountLabel.Content = $"{i}%";
                                WPFAsyncPBar.Value = i;
                            }
                            catch(Exception ex) { MessageBox.Show(ex.ToString()); }
                        });
                });
        }
        private async void WPFAsyncWIProgressButton_Click(object sender, RoutedEventArgs? e)
        {
            if (WPFAsyncWIProgressButton.Content.ToString() == "Stop Async w/IProgress")
            {
                // if so cancel it rename button text
                _iCancelSource!.Cancel();
                WPFAsyncWIProgressButton.Content = "Start Async w/IProgress";
                return;
            }
            // button clicked to start job
            //initialize cancel token source
            _iCancelSource = new CancellationTokenSource();
            // create token variable
            var itoken = _iCancelSource.Token;
            // create the progress function
            var progress = new Progress<int>(value =>
            {
                WPFAsyncWIPBar.Value = value;
                WPFAsyncICountLabel.Content = $"{value}%";
            });
            // set button to stop text
            WPFAsyncWIProgressButton.Content = "Stop Async w/IProgress";
            //reset values
            WPFAsyncWIPBar.Value = 0;
            WPFAsyncICountLabel.Content = "0%";

            // do the work using IProgress to update the form
            try
            {
                await Task.Run(() => WPFUpdateProgressBar.IncrementIProgressBarAsync(100, progress, itoken));
            }
            // come here if canceled
            catch (OperationCanceledException)
            {
                // mention canceled if desired
            }
            finally
            {
                // do cleanup
                _iCancelSource.Dispose();
                WPFAsyncWIProgressButton.Content = "Start Async w/IProgress";
            }
        }
        private void WPFStartAllButton_Click(object sender, RoutedEventArgs e)
        {
            // if text = Start then start the jobs
            if (WPFStartAllButton.Content.ToString() == "Start All")
            {
                // rename button text for stopping the jobs
                WPFStartAllButton.Content = "Stop All";
            }
            else
            {
                //Jobs already running cancel them all by calling all the button clicked events
                WPFStartAllButton.Content = "Start All";
                //for the manual (sync) job must set the flag to stop that job
                WPFVariables.stopManual = true;
            }
            // click all the buttons
            WPFBGWButton_Click(this, null);
            WPFAsyncButton_Click(this,null);
            WPFAsyncWIProgressButton_Click(this, null);
            ManualButton_Click(this, null);
            // once all jobs are done (which waits here for the manual one to finish)
            // rename button to start again
            WPFStartAllButton.Content = "Start All";
        }
    }
}


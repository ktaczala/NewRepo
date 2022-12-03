using System;
using System.ComponentModel;

namespace DelegateDemoProject;

public partial class DelegateForm : Form
{
    public DelegateForm()
    {
        InitializeComponent();
        // set default values for progressbars
        TestProgressBar.Maximum = 100;
        TestProgressBar.Step = 1;
        BGWProgressBar.Maximum = 100;
        BGWProgressBar.Step = 1;
        AsyncProgressBar.Maximum = 100;
        AsyncProgressBar.Step = 1;
        AsyncWithIProgressBar.Maximum = 100;
        AsyncWithIProgressBar.Step = 1;
    }

    // Uses a delegate to loosely couple the code from the form
    // to start the manual process
    private void ManualButton_Click(object sender, EventArgs e)
    {
        // check if already running
        if(ManualButton.Text == "Stop Manual")
        {
            // if so then rename button 
            ManualButton.Text = "Start Manual";
            // set flag to stop requested
            MyVariables.stopmanual = true;
            return;
        }
        // set button the show stop
        ManualButton.Text = "Stop Manual";
        // reset values
        TestProgressBar.Value = 0;
        ManualCountLabel.Text = "0%";
        // call method to increment progressbar
        UpdateProgressBar.IncrementProgressBar(Callback);
        // do cleanup
        ManualButton.Text = "Start Manual";
    }
    //callback for the manual process
    private void Callback(int i)
    {
        // set label text to current count
        ManualCountLabel.Text = $"{i}%";
        // force form to update **needed when not doing async or background worker
        Application.DoEvents();
        // set progressbar to current count
        TestProgressBar.Value = i;
    }
    // Uses a delegate to looslely couple the code from the form
    // to start the background worker job
    private void BGWButton_Click(object sender, EventArgs e)
    {
        // test if back ground worker is alreay busy
        if (BGWTest.IsBusy)
        {
            // cancel if it is
            BGWTest.CancelAsync();
            // exit method
            //rename button 
            BackGroundWorkerButton.Text = "Start BackGroundWorker";
            return;
        }
        // reset values
        BGWProgressBar.Value = 0;
        BGWCountLabel.Text = "0%";
        //rename button 
        BackGroundWorkerButton.Text = "Stop BackGroundWorker";
        // start the job
        BGWTest.RunWorkerAsync();
    }
    // callback for the background worker process
    private void Callback1(int i, DoWorkEventArgs e)
    {
        // call report progress
        BGWTest.ReportProgress(i);
    }
    // invoke the back ground job
    private void BGWTest_DoWork(object sender, DoWorkEventArgs e)
    {
        // do the work using callback to update form
        UpdateProgressBar.IncrementProgressBarBW(Callback1, e, sender);
    }
    // progress changed event
    private void BGWTest_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        //update the label to the current count
        BGWCountLabel.Text = $"{e.ProgressPercentage}%";
        // set the progress bar to the current value
        BGWProgressBar.Value = e.ProgressPercentage;
    }
    // do cleanup
    private void BGWTest_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        BackGroundWorkerButton.Text = "Start BackGroundWorker";
    }
    // Uses a delegate to loosely couple the code from the form
    // to the start the async job
    private async void Asyncbutton_Click(object sender, EventArgs e)
    {
        // check if Async is already running
        if (Asyncbutton.Text == "Stop Async")
        {
            // if so cancel it rename button text
            MyVariables._cancelSource!.Cancel();
            Asyncbutton.Text = "Start Async";
            return;
        }
        // button clicked to start job
        //initialize cancel token source
        MyVariables._cancelSource = new CancellationTokenSource();
        // create a token variable
        var token = MyVariables._cancelSource.Token;
        // set button to stop value
        Asyncbutton.Text = "Stop Async";
        //reset values
        AsyncProgressBar.Value = 0;
        AsyncCountlabel.Text = "0%";
        // do the work using a delegate
        try
        {
            // run job async using callback to update form
            await Task.Run(() => UpdateProgressBar.IncrementProgressBarAsync(Callback2, 100, token));
        }
        // come here if canceled
        catch (OperationCanceledException)
        {
            // mention canceled if desired
        }
        finally
        { 
            // do cleanup
            MyVariables._cancelSource.Dispose();
            Asyncbutton.Text = "Start Async";
        }
    }
    //Callback for Async Method
    private void Callback2(int i)
    {
        // Update the counter and the progressbar using invoke if needed
        AsyncCountlabel.Invoke(new Action(() => { AsyncCountlabel.Text = $"{i}%"; }));
        AsyncProgressBar.Invoke(new Action(() => { AsyncProgressBar.Value = i; }));
    }
    private async void AsyncWithIProgressbutton_Click(object sender, EventArgs e)
    {
        if (AsyncIProgressButton.Text == "Stop Async w/IProgress")
        {
            // if so cancel it rename button text
            MyVariables._iCancelSource!.Cancel();
            AsyncIProgressButton.Text = "Start Async w/IProgress";
            return;
        }
        // button clicked to start job
        //initialize cancel token source
        MyVariables._iCancelSource = new CancellationTokenSource();
        // create token variable
        var itoken = MyVariables._iCancelSource.Token;
        // create the progress function
        var progress = new Progress<int>(value =>
        {
            AsyncWithIProgressBar.Value = value;
            AsyncWIProgressCountLabel.Text = $"{value}%";
        });
        // set button to stop text
        AsyncIProgressButton.Text = "Stop Async w/IProgress";
        //reset values
        AsyncWithIProgressBar.Value = 0;
        AsyncWIProgressCountLabel.Text = "0%";

        // do the work using IProgress to update the form
        try
        {
            await Task.Run(() => UpdateProgressBar.IncrementIProgressBarAsync( 100, progress, itoken));
        }
        // come here if canceled
        catch (OperationCanceledException)
        {
            // mention canceled if desired
        }
        finally 
        {
            // do cleanup
            MyVariables._iCancelSource.Dispose();
            AsyncIProgressButton.Text = "Start Async w/IProgress";
        }
    }


}
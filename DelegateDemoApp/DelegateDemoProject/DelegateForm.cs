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
    }
    // Uses a delegate to loosley couple the code from the form
    // button to start the manual process
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
        CountLabel.Text = "0";
        // call method to increment progressbar
        UpdateProgressBar.IncrementProgressBar(Callback);
    }
    //callback for the manual process
    private void Callback(int i)
    {
        // set label text to current count
        CountLabel.Text = i.ToString();
        // force form to update **needed when not doing async or background worker
        Application.DoEvents();
        // set progressbar to current count
        TestProgressBar.Value = i;
    }
    // Uses a delegate to loosley couple the code from the form
    // button to start the background worker job
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
        CountLabel2.Text = "0";
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
        // do the work
        UpdateProgressBar.IncrementProgressBarBW(Callback1, e, sender);
    }
    // progress changed event
    private void BGWTest_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
    {
        //update the label to the current count
        CountLabel2.Text = e.ProgressPercentage.ToString();
        // set the progress bar to the current value
        BGWProgressBar.Value = e.ProgressPercentage;
    }

    // Uses a delegate to loosley couple the code from the form
    // button to the start the async job
    private async void Asyncbutton_Click(object sender, EventArgs e)
    {
        // check if Async is already running
        if (Asyncbutton.Text == "Stop Async")
        {
            // if so cancel it rename button text
            MyVariables._cancelSource.Cancel();
            Asyncbutton.Text = "Start Async";
            return;
        }
        // button clicked to start job
        Asyncbutton.Text = "Stop Async";
        //reset values
        AsyncProgressBar.Value= 0;
        AsyncCountlabel.Text = "0";

        // do the work
        await Task.Run(() => UpdateProgressBar.IncrementProgressBarAsync(Callback2));
    }
    //Callback for Async Method
    private void Callback2(int i)
    {
        // Update the counter and the progressbar
        AsyncCountlabel.Invoke(new Action(() => { AsyncCountlabel.Text = i.ToString(); }));
        AsyncProgressBar.Invoke(new Action(() => { AsyncProgressBar.Value = i; }));
    }

}
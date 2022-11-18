using System.ComponentModel;

namespace DelegateDemoProject;

// create delagates
// manual delagate
public delegate void Callback(int i);
// background worker delagate
public delegate void Callback1(int i, DoWorkEventArgs e);

public class UpdateProgressBar
{
    // this increments the progress bar manually
    public static void IncrementProgressBar(Callback obj)
    {
        // simulate looping thru some data
        for (int i = 1; i <= 100; i++)
        {
            // check of manual button clicked 2nd time
            if (MyVariables.stopmanual) 
            {
                // reset flag to false
                MyVariables.stopmanual = false;
                return; 
            }
                // call the delagate to update the progressbar and the count
                obj(i);
            // delay
            Thread.Sleep(100);
        }
    }
    // this updates the progress bar via background worker
    public static void IncrementProgressBarBW(Callback1 obj, DoWorkEventArgs e, object sender)
    {
        //create an instance of the background worker (not a new worker)
        BackgroundWorker bw = (BackgroundWorker)sender;
        // simulate looping thru some data
        for (int i = 1; i <= 100; i++)
        {
            // check if cancel requested (Click button 2nd time causes cancel)
            if(bw.CancellationPending)
            {
                // set cancel flag
                e.Cancel = true;
                return;
            }
            // call delagate to update progress bar, count
            obj(i, e);
            Thread.Sleep(100);
        }
    }
}

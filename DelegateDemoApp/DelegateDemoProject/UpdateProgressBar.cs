using System.ComponentModel;

namespace DelegateDemoProject;

// create delegates
// manual delegate
public delegate void Callback(int i);
// background worker delegate
public delegate void Callback1(int i, DoWorkEventArgs e);
// Async delegate
public delegate void Callback2(int i);

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
                // call the delegate to update the progressbar and the count
                obj(i);
            // delay for effect
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
            // call delegate to update progress bar, count
            obj(i, e);
            // delay for effect
            Thread.Sleep(100);
        }
    }
    //update the progressbar via Async method
    public static void IncrementProgressBarAsync(Callback2 obj, int count, CancellationToken token)

    {
        // simulate looping thru some data
        for (int i = 1; i <= count; i++)
        {
            // check for cancel button clicked
                token.ThrowIfCancellationRequested();
            // call delegate to update progress bar, count
            obj(i * 100 / count);
            // delay for effect
            Thread.Sleep(100);
        }
    }
    public static void IncrementIProgressBarAsync(int count, IProgress<int> progress, CancellationToken itoken)
    {
        // simulate looping thru some data
        for (int i = 1; i <= count; i++)
        {
            // check for cancel button clicked
            itoken.ThrowIfCancellationRequested();
            // update progress bar
            var percentComplete = (i * 100) / count;
            progress.Report(percentComplete);
            // delay for effect
            Thread.Sleep(100);
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WPFDelegateDemo
{
    public class WPFUpdateProgressBar
    {
    //mixing Thread.Sleep values in different methods
    //results in some interesting results.
    //the manual job really affects the progress of the Async job
    //but has no affect on the BackGroundWorker Job nor the Async with IProgress Job

    // create delegates
    // manual delegate
    public delegate void Callback(int i);
    // background worker delegate
    public delegate void Callback1(int i, DoWorkEventArgs e);
    // Async delegate
    public delegate void Callback2(int i);

        // this increments the progress bar manually
        public static bool IncrementProgressBar(Callback obj, int count)
        {
            // simulate looping thru some data
            for (int i = 1; i <= count; i++)
            {
                // check of manual button clicked 2nd time
                if (WPFVariables.stopManual)
                {
                    // reset flag to false
                    WPFVariables.stopManual = false;
                    return false;
                }
                // call the delegate to update the progressbar and the count
                obj(i * 100 / count);
                // delay for effect
                Thread.Sleep(100);
            }
            return true;
        }
        // this updates the progress bar via background worker
        public static void IncrementProgressBarBW(Callback1 obj, int count, DoWorkEventArgs e, object sender)
        {
            //create an instance of the background worker (not a new worker)
            BackgroundWorker bw = (BackgroundWorker)sender;
            // simulate looping thru some data
            for (int i = 1; i <= count; i++)
            {
                // check if cancel requested (Click button 2nd time causes cancel)
                if (bw.CancellationPending)
                {
                    // set cancel flag
                    e.Cancel = true;
                    return;
                }
                // call delegate to update progress bar, count
                obj(i * 100 / count, e);
                // delay for effect
                Thread.Sleep(10);
            }
        }
        //update the progressbar via Async method
        public static bool IncrementProgressBarAsync(Callback2 obj, int count, CancellationToken token)

        {
            // simulate looping thru some data
            for (int i = 1; i <= count; i++)
            {
                // check for cancel button clicked
                token.ThrowIfCancellationRequested();
                // call delegate to update progress bar, count
                obj(i * 100 / count);
                // delay for effect
                Thread.Sleep(10);
            }
            return true;
        }
        public static bool IncrementIProgressBarAsync(int count, IProgress<int> progress, CancellationToken itoken)
        {
            // simulate looping thru some data
            for (int i = 1; i <= count; i++)
            {
                // check for cancel button clicked
                itoken.ThrowIfCancellationRequested();
                // update progress bar
                var percentComplete = i * 100 / count;
                progress.Report(percentComplete);
                // delay for effect
                Thread.Sleep(10);
            }
            return true;
        }
    }

}

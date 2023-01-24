using System.ComponentModel;

namespace EventDemoProject
{
    public class MyClass
    {
        public event ProgressChangedEventHandler? ProgressChanged;
        readonly BackgroundWorker backgroundworker = new();
        public MyClass()
        {
            backgroundworker.WorkerReportsProgress = true;
            backgroundworker.DoWork += BGW_DoWork!;
            backgroundworker.ProgressChanged += MyBGWClass_ProgressChanged;
        }
        public void DoJoB()
        {
            backgroundworker.RunWorkerAsync();
        }
        private void BGW_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i <= 100; i++)
            {
                // Do some work...
                backgroundworker.ReportProgress(i);
                Thread.Sleep (200);
            }
        }
        private void MyBGWClass_ProgressChanged(object? sender,  ProgressChangedEventArgs e)
        {
            ProgressChanged?.Invoke(this, e);
        }
    }
}

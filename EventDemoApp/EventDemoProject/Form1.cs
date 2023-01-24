using System.ComponentModel;

namespace EventDemoProject
{
    public partial class FormUI : Form
    {
        private readonly ProgressBar progressBar1;
        private readonly ProgressBar progressBar2;
        private readonly MyClass myClass = new();
        public FormUI()
        {
            InitializeComponent();
            progressBar1 = ProgressBar1;
            progressBar2 = ProgressBar2;
            myClass.ProgressChanged += MyClass_ProgressChanged;
        }
        private void MyClass_ProgressChanged(object? sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            progressBar2.Value = 100 - e.ProgressPercentage;
            UpdatePercentLabels(e.ProgressPercentage);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            myClass.DoJoB();
        }
        private void UpdatePercentLabels(int e)
        {
            label1.Invoke (new Action(() => label1.Text = $"{e.ToString()}%"));
            label2.Invoke (new Action(() => label2.Text = $"{(100 - e).ToString()}%"));
        }
    }
}
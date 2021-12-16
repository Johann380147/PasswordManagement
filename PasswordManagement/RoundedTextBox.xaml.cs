using System.Windows.Controls;

namespace PasswordManagement
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class RoundedTextBox : UserControl
    {
        public RoundedTextBox()
        {
            InitializeComponent();
        }

        private void textBlock_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            txtSearch.Focus();
            txtSearch.Select(0, 0);
        }
        
    }
}

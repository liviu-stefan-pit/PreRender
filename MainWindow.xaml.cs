using System.Collections.Generic;
using System.Windows;

namespace BeforeRendering
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NewWindow window;

        #region Fields
        private double _height;
        private double _width;
        private string _title;
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            window = new NewWindow();
        }

        private void openNewWindow_Click(object sender, RoutedEventArgs e)
        {
            List<string> windowData = new List<string>();

            window.Visibility = Visibility.Hidden;

            if(window.ShowDialog() != window.DialogResult.HasValue)
            {
                this._height = window.Height;
                this._width = window.Width;
                this._title = window.Title;

                windowData.Add(_title);
                windowData.Add(_height.ToString());
                windowData.Add(_width.ToString());

                this.newWindowData.ItemsSource = windowData;

                MessageBox.Show("The list was updated!");
            }
            else
            {
                window.Close();
                return;
            }

            window.Visibility = Visibility.Visible;
            window.Show();
        }
    }
}

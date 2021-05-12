using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace QuanLySV
{
    /// <summary>
    /// Interaction logic for TrangChu.xaml
    /// </summary>
    public partial class TrangChu : Window
    {
        public TrangChu()
        {
            InitializeComponent();
        }

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Process.Start(e.Uri.ToString());
        }

        private void btnDangNhap_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow dn = new MainWindow();
            dn.Show();
        }

        private void TrangChu1_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer tm = new DispatcherTimer();
            tm.Interval = TimeSpan.FromSeconds(1.5);
            tm.Tick += Tm_Tick;
            tm.Start();
        }

        private void Tm_Tick(object sender, EventArgs e)
        {
            if (pic1.Visibility != pic2.Visibility)
            {
                tg.Visibility = pic1.Visibility;
                pic1.Visibility = pic2.Visibility;
                pic2.Visibility = tg.Visibility;
            }
        }
    }
}

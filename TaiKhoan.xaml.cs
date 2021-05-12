using System;
using System.Collections.Generic;
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

namespace QuanLySV
{
    /// <summary>
    /// Interaction logic for TaiKhoan.xaml
    /// </summary>
    public partial class TaiKhoan : Window
    {
        public TaiKhoan()
        {
            InitializeComponent();
        }
        QLSVDataContext dc = new QLSVDataContext();
        public void Load_tk()
        {
            var query = from tk in dc.TAIKHOANs
                        select tk;
            dataTK.ItemsSource = query;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Load_tk();
        }

        private void btnQuayLai_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            QuanLySinhVien ql = new QuanLySinhVien();
            ql.Show();
        }

        private void btnTim_Click(object sender, RoutedEventArgs e)
        {
            var query = from tk1 in dc.TAIKHOANs
                        where tk1.TENDANGNHAP.EndsWith(txbTim.Text)
                        select tk1;
            dataTK.ItemsSource = query;
        }

        private void btnLamMoi_Click(object sender, RoutedEventArgs e)
        {
            Load_tk();
        }
    }
}

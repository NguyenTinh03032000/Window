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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QuanLySV
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void btnDangNgap_Click(object sender, RoutedEventArgs e)
        {
            QLSVDataContext cc = new QLSVDataContext();
            var query = from p in cc.TAIKHOANs
                        where p.TENDANGNHAP == txbTenDangNhap.Text && p.MATKHAU == txbMatKhau.Password
                        select p;
            if(query.Count()==0)
            {
                MessageBox.Show("Sai mật khẩu hoặc tài khoản!", "Thông báo", MessageBoxButton.OK);
            }
            else
            {
                QuanLySinhVien Chinh = new QuanLySinhVien();
                QuanLySinhVien.taikhoantruyen = txbTenDangNhap.Text;
                Đổi_mật_khẩu.taikhoantruyen = txbTenDangNhap.Text;
                Đổi_mật_khẩu.matkhautruyen = txbMatKhau.Password;
                this.Hide();
                Chinh.Show();
            }
        }

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void lbDK_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DangKy dk = new DangKy();
            dk.Show();
            this.Hide();
        }
        
    }
}

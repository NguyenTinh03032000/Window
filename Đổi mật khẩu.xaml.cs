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
    /// Interaction logic for Đổi_mật_khẩu.xaml
    /// </summary>
    public partial class Đổi_mật_khẩu : Window
    {
        public static string taikhoantruyen = string.Empty;
        public static string matkhautruyen = string.Empty;
        public Đổi_mật_khẩu()
        {
            InitializeComponent();
        }
        QLSVDataContext dc = new QLSVDataContext();

        private void Đổi_mật_khẩu1_Loaded(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(taikhoantruyen))//chuỗi có giá trị
            {
                this.lbTen.Text = taikhoantruyen;
            }
            if (!string.IsNullOrEmpty(matkhautruyen))//chuỗi có giá trị
            {
                this.lbmk.Text = matkhautruyen;
            }
        }

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            QuanLySinhVien ql = new QuanLySinhVien();
            ql.Show();
        }

        private void btnCapNhat_Click(object sender, RoutedEventArgs e)
        {
            if (txbmkm.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu mới!", "Chú ý");
                txbmkm.Focus();
            }
            else if (txbNhapLaimk.Text == "")
            {
                MessageBox.Show("Bạn chưa đánh lại mật khẩu!", "Chú ý");
                txbNhapLaimk.Focus();
            }
            else if (txbmkm.Text != txbNhapLaimk.Text)
            {
                MessageBox.Show("Bạn đánh lại mật khẩu không trùng khớp!", "Chú ý",MessageBoxButton.OK,MessageBoxImage.Information);
                txbNhapLaimk.Focus();
            }

            else
            {
                var query = from tk in dc.TAIKHOANs
                            where tk.TENDANGNHAP == lbTen.Text
                            select tk;
                foreach(var tk in query)
                {
                    tk.TENDANGNHAP = lbTen.Text;
                    tk.MATKHAU = txbmkm.Text;

                    dc.SubmitChanges();
                }
                MessageBox.Show("Cập nhật thành công!", "Thông báo");
                this.Hide();
                MainWindow dn = new MainWindow();
                dn.Show();        
            }

        }
    }
}

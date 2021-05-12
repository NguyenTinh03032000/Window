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
    /// Interaction logic for DangKy.xaml
    /// </summary>
    public partial class DangKy : Window
    {
        QLSVDataContext db = new QLSVDataContext();
        public DangKy()
        {
            InitializeComponent();
        }

        private void btnXacNhan_Click(object sender, RoutedEventArgs e)
        {
            if(txbTenDangNhap.Text=="")
            {
                MessageBox.Show("Chưa nhập tài khoản!", "Thông Báo", MessageBoxButton.OK);
            }
            else
            {
                if (txbmatkhau.Text== "")
                {
                    MessageBox.Show("Chưa nhập mật khẩu!", "Thông Báo", MessageBoxButton.OK);
                }
                else
                {
                    if (txbXacNhanMK.Text.Equals(txbmatkhau.Text) == false)
                    {
                        MessageBox.Show("Xác nhận mật khẩu không đúng!", "Thông Báo", MessageBoxButton.OK);
                    }
                    else
                    {
                        try
                        {
                            var tk = new TAIKHOAN
                            {
                                TENDANGNHAP = txbTenDangNhap.Text,
                                MATKHAU = txbmatkhau.Text
                            };
                            db.TAIKHOANs.InsertOnSubmit(tk);
                            db.SubmitChanges();

                            MessageBox.Show("Đăng ký thành công!", "Chúc Mừng");
                            txbTenDangNhap.Clear();
                            txbmatkhau.Clear();
                            txbXacNhanMK.Clear();
                        }
                        catch
                        {
                            MessageBox.Show("Trùng tài khoản!", "Thông báo", MessageBoxButton.OK);
                        }
                    }
                }
            }
        }

        private void btnQuayLai_Click(object sender, RoutedEventArgs e)
        {
            MainWindow DangNhap = new MainWindow();
            DangNhap.Show();
            this.Hide();
        }
    }
}

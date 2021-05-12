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
using System.Windows.Threading;

namespace QuanLySV
{
    /// <summary>
    /// Interaction logic for QuanLySinhVien.xaml
    /// </summary>
    public partial class QuanLySinhVien : Window
    {
        public static string taikhoantruyen = string.Empty;

        public QuanLySinhVien()
        {
            InitializeComponent();
        }

        private void btnQLSV1_Click(object sender, RoutedEventArgs e)
        {
            SinhVien sv = new SinhVien();
            sv.Show();
            this.Hide();
        }

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnDangXuat_Click(object sender, RoutedEventArgs e)
        {
            MainWindow dn = new MainWindow();
            dn.Show();
            this.Hide();
        }

        private void QuanLySinhVien1_Loaded(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(taikhoantruyen))//chuỗi có giá trị
            {
                this.txbChaoTen.Text = taikhoantruyen;
            }

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

        private void btnDoiMK_Click(object sender, RoutedEventArgs e)
        {
            Đổi_mật_khẩu mk = new Đổi_mật_khẩu();
            mk.Show();
            this.Hide();
        }

        private void ItemDoiMK_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Đổi_mật_khẩu doi = new Đổi_mật_khẩu();
            doi.Show();
        }

        private void btnQLSV_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            SinhVien ql = new SinhVien();
            ql.Show();
        }

        private void btnQLL_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Lop lp = new Lop();
            lp.Show();
        }

        private void btnHK_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            HocKy hk = new HocKy();
            hk.Show();
        }

        private void btnMonHoc_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Mon mon = new Mon();
            mon.Show();
        }

        private void btnNhapDiem_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            NhapDiem diem = new NhapDiem();
            diem.Show();
        }

        private void btnThongTin_Click(object sender, RoutedEventArgs e)
        {
            ThongTin tt = new ThongTin();
            tt.Show();
        }

        private void btnTrangChu_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            TrangChu tc = new TrangChu();
            tc.Show();
        }

        private void btTrangChu_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            TrangChu tc = new TrangChu();
            tc.Show();
        }

        private void btnTroGiup_Click(object sender, RoutedEventArgs e)
        {
            Trogiup tg = new Trogiup();
            tg.Show();
        }

        private void btnTK_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            TaiKhoan tk = new TaiKhoan();
            tk.Show();
        }

        private void btnQLC_Click(object sender, RoutedEventArgs e)
        {
            QuanLyChung ql = new QuanLyChung();
            ql.Show();
        }
    }
}

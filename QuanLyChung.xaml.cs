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
    /// Interaction logic for QuanLyChung.xaml
    /// </summary>
    public partial class QuanLyChung : Window
    {
        public QuanLyChung()
        {
            InitializeComponent();
        }
        QLSVDataContext dc = new QLSVDataContext();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            load_Lop();
        }
        public void load_Lop()
        {
            var query = from lp in dc.LOPs select lp;
            cbLop.ItemsSource = query;
            cbLop.DisplayMemberPath = "TENLOP";
            cbLop.SelectedValuePath = "MALOP";
        }

        private void cbLop_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var query = from sv in dc.SINHVIENs
                        where sv.MALOP.Equals(cbLop.SelectedValue)
                        select sv;
            listBoxSV.ItemsSource = query;
            listBoxSV.DisplayMemberPath = "HOTEN";
            listBoxSV.SelectedValuePath = "MASV";
        }

        private void listBoxSV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var query = from diem in dc.DIEMHPs
                        where diem.MASV.Equals(listBoxSV.SelectedValue)
                        select diem;
            dataDiem.ItemsSource = query;
            var query1 = from sv1 in dc.SINHVIENs
                         where sv1.MASV.Equals(listBoxSV.SelectedValue)
                         select sv1;
            foreach (var sv in query1)
            {
                txtMASV.Text = sv.MASV;
                txtTen.Text = sv.HOTEN;
                txtNgaySinh.Text = Convert.ToString(sv.NGAYSINH);
                txtNoiSinh.Text = sv.NOISINH;
                txtGioiTinh.Text = Convert.ToString(sv.GIOITINH);
                txtDanToc.Text = sv.DANTOC;
            }
        }
    }
}

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
    /// Interaction logic for SinhVien.xaml
    /// </summary>
    public partial class SinhVien : Window
    {
        public SinhVien()
        {
            InitializeComponent();
        }
        QLSVDataContext dc = new QLSVDataContext();

        public void Load_Data()
        {
            var query = from sv in dc.SINHVIENs
                        select sv;
            dataSV.ItemsSource = query;
        }

        public void Load_Lop()
        {
            var query = from lp in dc.LOPs select lp;
            cbMaLop.ItemsSource = query;
            cbMaLop.DisplayMemberPath = "TENLOP";
            cbMaLop.SelectedValuePath = "MALOP";
        }
        private void formSinhVien_Loaded(object sender, RoutedEventArgs e)
        {
            Load_Data();
            Load_Lop();
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            if (txbMaSV.Text == "")
                MessageBox.Show("Bạn chưa nhập mã sinh viên!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                var query = from sv in dc.SINHVIENs
                            where sv.MASV == txbMaSV.Text
                            select sv;
                int i = 0;
                foreach (var sv in query)
                {
                    i++;
                }
                if (i == 0)
                {
                    SINHVIEN sv = new SINHVIEN();
                    sv.MASV = txbMaSV.Text;
                    sv.HOTEN = txbHoTen.Text;
                    sv.SDT = txbSDT.Text;
                    sv.NGAYSINH = Convert.ToDateTime(dtpNgaySinh.Text);
                    sv.GIOITINH = rdNam.IsChecked == true ? true : false;
                    sv.NOISINH = txbNoiSinh.Text;
                    sv.DANTOC = txbDanToc.Text;
                    sv.MALOP = cbMaLop.SelectedValue.ToString();

                    dc.SINHVIENs.InsertOnSubmit(sv);
                    dc.SubmitChanges();
                    Load_Data();
                }
                else
                {
                    MessageBox.Show("Trùng mã nhân viên", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            int i = dataSV.SelectedIndex;
            if(i>=0)
            {
                SINHVIEN sv = (SINHVIEN)dataSV.Items.GetItemAt(i);
                txbTG.Text = sv.MASV;
            }
            var query = from sv1 in dc.SINHVIENs
                        where sv1.MASV.Equals(txbTG.Text)
                        select sv1;
                foreach (var sv1 in query)
                {
                    dc.SINHVIENs.DeleteOnSubmit(sv1);
                }
                dc.SubmitChanges();
                Load_Data();   
        }

        private void btnThongKe_Click(object sender, RoutedEventArgs e)
        {
            
            var query = from lp in dc.LOPs
                        join sv in dc.SINHVIENs on lp.MALOP equals sv.MALOP
                        group lp by new { lp.TENLOP } into qh
                        select new { qh.Key.TENLOP, Số_Lượng_SV = qh.Count() };
            dataTK.ItemsSource = query;
        }

        private void btnQuayLai_Click(object sender, RoutedEventArgs e)
        {
            QuanLySinhVien ql = new QuanLySinhVien();
            ql.Show();
            this.Hide();
        }

        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dc.SubmitChanges();
            }
            catch
            {
                MessageBox.Show("Trùng mã nhân viên", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnTim_Click(object sender, RoutedEventArgs e)
        {
            var query = from sv in dc.SINHVIENs
                        where sv.HOTEN.EndsWith(txbTim.Text)
                        select sv;
            dataSV.ItemsSource = query;
        }

        private void btnLamMoi_Click(object sender, RoutedEventArgs e)
        {
            txbMaSV.Clear();
            txbHoTen.Clear();
            txbSDT.Clear();
            txbNoiSinh.Clear();
            txbDanToc.Clear();
            dtpNgaySinh.Text = DateTime.Now.ToString();
            cbMaLop.SelectedIndex = 0;
            rdNam.IsChecked = true;
            dataSV.ItemsSource = null;
            Load_Data();
        }

        
    }
}


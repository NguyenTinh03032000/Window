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
    /// Interaction logic for Mon.xaml
    /// </summary>
    public partial class Mon : Window
    {
        public Mon()
        {
            InitializeComponent();
        }
        QLSVDataContext dc = new QLSVDataContext();

        public void Load_Data()
        {
            var query = from mon in dc.MONHPs
                        select mon;
            dataMon.ItemsSource = query;
        }

        public void Load_HK()
        {
            var query = from hk in dc.HOCKies
                        select hk;
            cbMaHK.ItemsSource = query;
            cbMaHK.DisplayMemberPath = "TENHK";
            cbMaHK.SelectedValuePath = "MAHK";
        }

        private void MonHoc_Loaded(object sender, RoutedEventArgs e)
        {
            Load_Data();
            Load_HK();
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            if (txbMaMon.Text == "")
                MessageBox.Show("Bạn chưa nhập mã môn học!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                var query = from mon in dc.MONHPs
                            where txbMaMon.Text==mon.MAMON
                            select mon;
                int i = 0;
                foreach (var mon in query)
                {
                    i++;
                }
                if (i == 0)
                {
                    MONHP mon = new MONHP();
                    mon.MAMON = txbMaMon.Text;
                    mon.TENMON = txbTenMon.Text;
                    mon.SOTINCHI = Convert.ToInt32(txbSTC.Text);
                    mon.MAHK = cbMaHK.SelectedValue.ToString();

                    dc.MONHPs.InsertOnSubmit(mon);
                    dc.SubmitChanges();
                    Load_Data();
                }
                else
                {
                    MessageBox.Show("Trùng mã môn", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            if(txbMaMon.Text!=null)
            {
                var query = from mon in dc.MONHPs
                            where mon.MAMON == txbMaMon.Text
                            select mon;
                foreach(var mon in query)
                {
                    dc.MONHPs.DeleteOnSubmit(mon);
                }
                dc.SubmitChanges();
                Load_Data();
            }
        }

      
        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            QuanLySinhVien ql = new QuanLySinhVien();
            ql.Show();
        }

        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dc.SubmitChanges();
                Load_Data();
            }
            catch
            {
                MessageBox.Show("Trùng mã môn học!", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void butlammoi_Click(object sender, RoutedEventArgs e)
        {
            txbMaMon.Clear();
            txbTenMon.Clear();
            txbSTC.Clear();
            cbMaHK.SelectedIndex = 0;
            dataMon.ItemsSource = null;
            Load_Data();
        }
    }
}

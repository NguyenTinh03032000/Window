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
    /// Interaction logic for HocKy.xaml
    /// </summary>
    public partial class HocKy : Window
    {
        QLSVDataContext dc = new QLSVDataContext();
        public HocKy()
        {
            InitializeComponent();
        }

        public void Load_data()
        {
            var query = from hk in dc.HOCKies
                        select hk;
            datahk.ItemsSource = query;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Load_data();
        }
        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            if (txbMaHK.Text == "")
                MessageBox.Show("Bạn chưa nhập mã học kỳ!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                var query = from hk in dc.HOCKies
                            where txbMaHK.Text == hk.MAHK
                            select hk;
                int i = 0;
                foreach(var hk in query)
                {
                    i++;
                }
                if(i==0)
                {
                    HOCKY hk = new HOCKY();
                    hk.MAHK = txbMaHK.Text;
                    hk.TENHK = txbTenHK.Text;

                    dc.HOCKies.InsertOnSubmit(hk);
                    dc.SubmitChanges();
                    Load_data();
                }
                else
                {
                        MessageBox.Show("Trùng mã học kỳ!", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);

                }
            }
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            if (txbMaHK.Text != null)
            {
                var query = from hk1 in dc.HOCKies
                            where hk1.MAHK == txbMaHK.Text
                            select hk1;
                foreach (var hk1 in query)
                {
                    dc.HOCKies.DeleteOnSubmit(hk1);
                }
                dc.SubmitChanges();
                Load_data();
            }
        }

        private void btnQuayLai_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            QuanLySinhVien ql = new QuanLySinhVien();
            ql.Show();
        }

        

        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                txbMaHK.Clear();
                txbTenHK.Clear();
                datahk.ItemsSource = null;
                dc.SubmitChanges();
                Load_data();
            }
            catch
            {
                MessageBox.Show("Trùng mã học kỳ!", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}

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
    /// Interaction logic for Lop.xaml
    /// </summary>
    public partial class Lop : Window
    {
        public Lop()
        {
            InitializeComponent();
        }
        QLSVDataContext dc = new QLSVDataContext();

        public void Load_data()
        {
            var query = from lp in dc.LOPs
                        select lp;
            datalop.ItemsSource = query;
        }
        private void QLL_Loaded(object sender, RoutedEventArgs e)
        {
            Load_data();
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            if (txbMaLop.Text == "")
                MessageBox.Show("Chưa nhập mã lớp!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                var query = from lp in dc.LOPs
                            where txbMaLop.Text == lp.MALOP
                            select lp;
                int i = 0;
                foreach (var lp in query)
                {
                    i++;
                }
                if (i == 0)
                {
                    LOP lpp = new LOP();
                    lpp.MALOP = txbMaLop.Text;
                    lpp.TENLOP = txbTenLop.Text;

                    dc.LOPs.InsertOnSubmit(lpp);
                    dc.SubmitChanges();
                    Load_data();
                }
                else
                {
                    MessageBox.Show("Trùng mã sinh viên!", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            if(txbMaLop.Text!=null)
            {
                var query = from lp1 in dc.LOPs
                            where lp1.MALOP == txbMaLop.Text
                            select lp1;
                foreach(var lp1 in query)
                {
                    dc.LOPs.DeleteOnSubmit(lp1);
                }
                dc.SubmitChanges();
                Load_data();
            }
        }

        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                txbMaLop.Clear();
                txbTenLop.Clear();
                dc.SubmitChanges();
                Load_data();
            }
            catch
            {
                MessageBox.Show("Trùng mã lớp!", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnQuayLai_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            QuanLySinhVien ql = new QuanLySinhVien();
            ql.Show();
        }

        
    }
}

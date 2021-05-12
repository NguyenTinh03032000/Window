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
    /// Interaction logic for NhapDiem.xaml
    /// </summary>
    public partial class NhapDiem : Window
    {
        public NhapDiem()
        {
            InitializeComponent();
        }
        QLSVDataContext dc = new QLSVDataContext();

        public void Load_Masv()
        {
            var query = from sv in dc.SINHVIENs
                        select sv;
            cbMaSV.ItemsSource = query;
            cbMaSV.DisplayMemberPath = "MASV";
            cbMaSV.SelectedValuePath = "MASV";

        }
        public void Load_data()
        {
            var query = from diem in dc.DIEMHPs
                        select diem;
            dataDiem.ItemsSource = query;
        }
        public void Load_Mon()
        {
            var query = from mon in dc.MONHPs
                        select mon;
            cbMaMON.ItemsSource = query;
            cbMaMON.DisplayMemberPath = "MAMON";
            cbMaMON.SelectedValuePath = "MAMON";
        }

        private void NhapDiem1_Loaded(object sender, RoutedEventArgs e)
        {
            Load_Masv();
            Load_Mon();
            Load_data(); 
        }

        

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            if (cbMaSV.Text == "")
                MessageBox.Show("Bạn chưa chọn sinh viên!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                if (cbMaMON.Text == "")
                    MessageBox.Show("Bạn chưa chọn môn!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                {
                    if (txbDiemLan1.Text == "")
                        MessageBox.Show("Bạn chưa nhập điểm lần 1!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    else
                    {
                        if (txbDiemLan2.Text == "")
                            MessageBox.Show("Bạn chưa nhập điểm lần 2!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                        else
                        {
                            var query = from diem2 in dc.DIEMHPs
                                        where (diem2.MASV==cbMaSV.Text && diem2.MAMON==cbMaMON.Text)
                                        select diem2;
                            int i = 0;
                            foreach (var diem2 in query)
                            {
                                i++;
                            }
                            if (i == 0)
                            {
                                try
                                {
                                DIEMHP diemhp = new DIEMHP();
                                diemhp.MAMON = cbMaMON.SelectedValue.ToString();
                                diemhp.MASV = cbMaSV.SelectedValue.ToString();
                                diemhp.DIEMLAN1 = Convert.ToDouble(txbDiemLan1.Text);
                                diemhp.DIEMLAN2 = Convert.ToDouble(txbDiemLan2.Text);

                                dc.DIEMHPs.InsertOnSubmit(diemhp);
                                dc.SubmitChanges();
                                Load_data();
                                }
                                catch
                                {
                                    MessageBox.Show("Trùng tên sinh viên và môn111!", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Trùng tên sinh viên và môn!", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                            }
                        }
                    }

                }
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
                Load_data();
                Load_Masv();
                Load_Mon();
            }
            catch
            {
                MessageBox.Show("Trùng mã môn học hoặc môn!", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnLamMoi_Click(object sender, RoutedEventArgs e)
        {
            cbMaSV.SelectedIndex = 0;
            cbMaMON.SelectedIndex = 0;
            txbDiemLan1.Clear();
            txbDiemLan2.Clear();
            dataDiem.ItemsSource = null;
            Load_data();
        }

        private void btnXoa_Click_1(object sender, RoutedEventArgs e)
        {
            if (cbMaSV.Text != "" && cbMaMON.Text != "")
            {
                int i = dataDiem.SelectedIndex;
                if(i>=0)
                {
                    DIEMHP diem = (DIEMHP)dataDiem.Items.GetItemAt(i);
                    tgsv.Text = diem.MASV;
                    tgmon.Text = diem.MAMON;
                }
                var query = from diem2 in dc.DIEMHPs
                            where (diem2.MAMON.Equals(tgmon.Text) && diem2.MASV.Equals(tgsv.Text))
                            select diem2;
                foreach (var diem2 in query)
                {
                    dc.DIEMHPs.DeleteOnSubmit(diem2);
                }
                dc.SubmitChanges();
                Load_data();
             }
        }   
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using DTO;

namespace WindowsFormsApp15
{
    public partial class QuanLyLop : Form
    {
        public QuanLyLop()
        {
            InitializeComponent();
        }

        private void QuanLyLop_Load(object sender, EventArgs e)
        {
            QuanLyLopBUL cls = new QuanLyLopBUL() ;
            dgvLop.DataSource = cls.HienThi();
            DataTable dt = new DataTable();
            dt.Columns.Add("magvcn", typeof(string));
            dt.Columns.Add("tengvcn", typeof(string));

            dt.Rows.Add("GV0001", "Nguyen Van An");
            dt.Rows.Add("GV0002", "Nguyen Duc Anh");
            dt.Rows.Add("GV0003", "Nguyen Van Canh");

            cboGVCN.DataSource = dt;
            cboGVCN.DisplayMember = "tengvcn";
            cboGVCN.ValueMember = "magvcn";
            dgvLop.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            QuanLyLopBUL cls = new QuanLyLopBUL();
            Lop x = new Lop();
            x.MaLop = txtMaLop.Text;
            x.TenLop = txtTenLop.Text;
            x.NienKhoa = txtNienKhoa.Text;
            x.SiSo = int.Parse(txtSiSo.Text);
            x.GiaoVienChuNhiem = cboGVCN.SelectedValue.ToString();
            DialogResult dlr = MessageBox.Show("Bạn có muốn Thêm không?", "Thêm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dlr == DialogResult.OK)
            {
                cls.Them(x);
            }   
            QuanLyLop_Load(sender, e);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            QuanLyLopBUL cls = new QuanLyLopBUL();
            Lop x = new Lop();
            x.MaLop = txtMaLop.Text;
            x.TenLop = txtTenLop.Text;
            x.NienKhoa = txtNienKhoa.Text;
            x.SiSo = int.Parse(txtSiSo.Text);
            x.GiaoVienChuNhiem = cboGVCN.SelectedValue.ToString();
            DialogResult dlr = MessageBox.Show("Bạn có muốn Sửa không?", "Sửa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dlr == DialogResult.OK)
            {
                cls.Sua(x);
            } 
            QuanLyLop_Load(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            QuanLyLopBUL cls = new QuanLyLopBUL();
            Lop x = new Lop();
            x.MaLop = txtMaLop.Text;
            DialogResult dlr = MessageBox.Show("Bạn có muốn Xóa không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                cls.Xoa(x);
            }
            QuanLyLop_Load(sender, e);
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            QuanLyLopBUL cls = new QuanLyLopBUL();
            Lop x = new Lop();
            x.MaLop = txtMaLop.Text;
            dgvLop.DataSource = cls.Xem(x);
            if (txtMaLop.Text == "")
            {
                QuanLyLop_Load(sender, e);
            }
        }
    }
}

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
    public partial class QuanLyMonHoc : Form
    {
        public QuanLyMonHoc()
        {
            InitializeComponent();
        }

        private void QuanLyMonHoc_Load(object sender, EventArgs e)
        {
            QuanLyMonBUL cls = new QuanLyMonBUL();
            dgvMonHoc.DataSource = cls.HienThi();
            dgvMonHoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            QuanLyMonBUL cls = new QuanLyMonBUL();
            MonHoc x = new MonHoc();
            x.MaMon = txtMaMon.Text;
            x.TenMon = txtTenMon.Text;
            x.SoTiet = int.Parse(txtSoTiet.Text);
            DialogResult dlr = MessageBox.Show("Bạn có muốn Thêm không?", "Thêm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dlr == DialogResult.OK)
            {
                cls.Them(x); 
            }            
            QuanLyMonHoc_Load(sender, e);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            QuanLyMonBUL cls = new QuanLyMonBUL();
            MonHoc x = new MonHoc();
            x.MaMon = txtMaMon.Text;
            x.TenMon = txtTenMon.Text;
            x.SoTiet = int.Parse(txtSoTiet.Text);
            DialogResult dlr = MessageBox.Show("Bạn có muốn Sửa không?", "Sửa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dlr == DialogResult.OK)
            {
                cls.Sua(x);
            } 
            QuanLyMonHoc_Load(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            QuanLyMonBUL cls = new QuanLyMonBUL();
            MonHoc x = new MonHoc();
            x.MaMon = txtMaMon.Text;
            DialogResult dlr = MessageBox.Show("Bạn có muốn Xóa không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                cls.Xoa(x);
            } 
            QuanLyMonHoc_Load(sender, e);
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            QuanLyMonBUL cls = new QuanLyMonBUL();
            MonHoc x = new MonHoc();
            x.MaMon = txtMaMon.Text;
            dgvMonHoc.DataSource = cls.Xem(x);
            if (txtMaMon.Text == "")
            {
                QuanLyMonHoc_Load(sender, e);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DTO;
using BLL;
using System.IO;

namespace WindowsFormsApp15
{
    public partial class DanhSachHocSinh : Form
    {
        public DanhSachHocSinh()
        {
            InitializeComponent();
        }

        private void DanhSachHocSinh_Load(object sender, EventArgs e)
        {
            DanhSachHocSinhBUL cls = new DanhSachHocSinhBUL();
            cboTenLop.DataSource = cls.LayMaLop();
            cboTenLop.DisplayMember = "TenLop";
            cboTenLop.ValueMember = "MaLop";
            txtTenTruong.Text = "Trường ĐHCNHN";
            dgvDSHS.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            DanhSachHocSinhBUL cls = new DanhSachHocSinhBUL();
            HoSoHocSinh x = new HoSoHocSinh();
            x.MaLop = cboTenLop.SelectedValue.ToString();
            dgvDSHS.DataSource = cls.HienThi(x);
            dgvDSHS.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}

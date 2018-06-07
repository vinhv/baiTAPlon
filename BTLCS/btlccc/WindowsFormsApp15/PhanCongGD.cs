using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;

namespace WindowsFormsApp15
{
    public partial class PhanCongGD : Form
    {
        public PhanCongGD()
        {
            InitializeComponent();
        }

        private void PhanCongGD_Load(object sender, EventArgs e)
        {
            GiangDayPCDABLL cls = new GiangDayPCDABLL();
            dgvGiangday.DataSource = cls.HienThiDS();
            DataTable dt = new DataTable();

            cboMon.DataSource = cls.getMamon();
            cboLop.DataSource = cls.getMalop();
            cboGiaovien.DataSource = cls.getGiaovien();
            cboMon.DisplayMember = "TenMon";
            cboMon.ValueMember = "MaMon";
            cboLop.DisplayMember = "TenLop";
            cboLop.ValueMember = "MaLop";
            cboGiaovien.DisplayMember = "HoTen";
            cboGiaovien.ValueMember = "MaCanBoGiaoVien";
            dgvGiangday.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnPhancong_Click(object sender, EventArgs e)
        {
            GiangDayPCDABLL pcc = new GiangDayPCDABLL();
            PhanCongGiangDay x = new PhanCongGiangDay();
            x.MaLop = cboLop.SelectedValue.ToString();
            x.MaMon = cboMon.SelectedValue.ToString();
            x.MaCanBoGV = cboGiaovien.SelectedValue.ToString();
            x.NgayPhanCong = dateTimePicker1.Value;
            pcc.Phancong(x);
            PhanCongGD_Load(sender, e);
        }
    }
}

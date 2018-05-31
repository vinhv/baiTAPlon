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
    public partial class frmQLDMGiaoVien : Form
    {
        public frmQLDMGiaoVien()
        {
            InitializeComponent();
        }
        
        private void frmQLDMGiaoVien_Load(object sender, EventArgs e)
        {
            QuanLyCBGVBUL cls = new QuanLyCBGVBUL();
            dgvCBGV.DataSource = cls.HienThiDS();
        }
    }
}

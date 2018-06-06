using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;
namespace WindowsFormsApp15
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
           DialogResult r= MessageBox.Show("Bạn thực sự muốn thoát ??", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (r == DialogResult.Yes)

            {
                for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
                {
                    //if (Application.OpenForms[i].Name != "Menu")
                    Application.OpenForms[i].Close();
                }
            }
            else
                return;
        }
        private string LoaiTaiKhoan = "";
        private bool chk()
        {
          
            CanBoGiaoVienBLL cb = new CanBoGiaoVienBLL();
            foreach (CanBoGiaoVien item in cb.dscb())
            {
               
                if (item.Taikhoan == txtuser.Text && item.MatKHau == txtpass.Text)
                {
                    LoaiTaiKhoan = item.LoaiTaiKhoan;
                    return true;
                }
            }
          
            return false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Close();
            if (chk())
            {
                FormMain frm = new FormMain();

                if (LoaiTaiKhoan =="admin")
                {
                    frm.ad = true;
                }

                else
                {
                    frm.gv = true;
                   
                }
                frm.TenUsers = txtuser.Text;
                frm.Show();
                this.Hide();
            }
            else
                MessageBox.Show("sai tai khoan or mat khau ", "");
        }
    }
}

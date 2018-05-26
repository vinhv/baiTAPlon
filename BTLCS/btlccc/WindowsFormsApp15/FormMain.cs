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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
        //btn
        public bool gv = false
            ;
        public bool ad = false;
        public string TenUsers { get; set; }
        public string MaGV { get; set; }
        
        
        
        QuanLyDiem qlDiem = new QuanLyDiem()

                                                 ;
     
        QuanLyGiaovien qlGiaoVien
            = new QuanLyGiaovien();
        QuanLyHocSinh qlHocSinh = new QuanLyHocSinh();
        QuanLyLop qlLOp = new QuanLyLop();
        ThongKeGV tkGV = new ThongKeGV();
        ThongKeHS tkHS = new ThongKeHS();
        QuanLyMonHoc qlMOnHoc = new QuanLyMonHoc();
        PhanCongGiangDay Phan = new PhanCongGiangDay();
        private bool chkqlDiem = false;
        private Button disQuanLyDiem = null, clsQuanLyDiem = null,
                                disPhanCong = null, clsPhanCong = null,
                                 disLopHoc = null, clsLopHoc = null,
                                     disGiaoVien = null, clsGiaovien = null,
             disMonHoc = null, clsMonHoc = null,
             disTkgiaovien = null, clsTkgiaovien = null,
             disTkHocSinh = null, clsTkHocSinh = null,
             disHocsinh = null, clsHocSinh = null;

        private void btnThongKeHs_Click(object sender, EventArgs e)
        {
            Them(tkHS);
            if (Application.OpenForms["ThongKeHS"] as ThongKeHS == null)
            {
                tkHS.Show();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnQuanLyGiaoVien_Click(object sender, EventArgs e)
        {
            Them(qlGiaoVien);
            if (Application.OpenForms["QuanLyGiaovien"] as QuanLyGiaovien == null)
            {
                qlGiaoVien.Show();
            }
        }

        //panel
        private Panel pnDiem = null, pnLop = null, pnHOCsinh = null, pnTKHocsinh = null, pnTKGIaovien = null,
            pnPhancong = null,
        pnMonHoc = null, pnGiaoVien = null;

        private void mini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void max_Click(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Normal;
            max.Visible = false;
            moo.Visible = true;
            
        }

        private void moo_Click(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            max.Visible = true;
            moo.Visible = false;
        }

        private void BaoForm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void thoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                //if (Application.OpenForms[i].Name != "Menu")
                Application.OpenForms[i].Close();
            }
        }

        private void doDucVinhToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void A_FormClosed(object sender, FormClosedEventArgs e)
        {
          

        }

        private void dangXuatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            login a = new login();
            a.Show();
            Close();
        }

        private void btnThongKEGiaoVien_Click(object sender, EventArgs e)
        {
            Them(tkGV);
            if (Application.OpenForms["ThongKeGV"] as ThongKeGV == null)
            {
                tkGV.Show();
            }
        }
        

        // disQuanLyDiem = null, clsQuanLyDiem = null,;
        //btnLen
        private void button6_Click(object sender, EventArgs e)
        {
            btnLen.Visible = false;
            btnXuong.Visible = true;
            pnDanhMuc.Visible = true;
            if (pnThongKe.Visible == false)
            {
                pnXuong.Location = new System.Drawing.Point(3, 240);
                pictureBox1.Location = new System.Drawing.Point(3, 381);
                // pnDanhMuc.Location = new System.Drawing.Point(3,66);
            }
            else {
                pnXuong.Location = new System.Drawing.Point(3, 240);
                pictureBox1.Location = new System.Drawing.Point(3, 471);
                pnThongKe.Location = new System.Drawing.Point(3, 371);

            }


        }
        //btnXUong
        private void button7_Click(object sender, EventArgs e)
        {
            btnLen.Visible = true;
            btnXuong.Visible = false;
            pnDanhMuc.Visible = false;
            if (pnThongKe.Visible == false)
            {
                pnXuong.Location = new System.Drawing.Point(3, 66);
                pictureBox1.Location = new System.Drawing.Point(3, 201);
            }
            else {

                pnXuong.Location = new System.Drawing.Point(3, 66);
                pictureBox1.Location = new System.Drawing.Point(3, 291);
                pnThongKe.Location = new System.Drawing.Point(3, 201);
            }
        }
        //Len
        private void button3_Click(object sender, EventArgs e)
        {
            btnThongkeLen.Visible = false;
            btnThonglkeXuong.Visible = true;
            pnThongKe.Visible = true;

            if (pnDanhMuc.Visible == false)
            {
                pictureBox1.Location = new System.Drawing.Point(3, 291);
                pnThongKe.Location = new System.Drawing.Point(3, 201);
            }
            else {
                pictureBox1.Location = new System.Drawing.Point(3, 471);
                pnThongKe.Location = new System.Drawing.Point(3, 371);
            }
        }
        //xuong
        private void button4_Click(object sender, EventArgs e)
        {
            pnThongKe.Visible = false;
            btnThongkeLen.Visible = true;
            btnThonglkeXuong.Visible = false;
            if (pnDanhMuc.Visible == false)
            {
                pictureBox1.Location = new System.Drawing.Point(3, 201);
                pnThongKe.Location = new System.Drawing.Point(3, 201);
            }
            else
            {
                pictureBox1.Location = new System.Drawing.Point(3, 381);
                pnThongKe.Location = new System.Drawing.Point(3, 371);
            }
        }
        //show form

        //Mo form quan ly diem
        private void btnQuanLyDiem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["QuanLyDiem"] as QuanLyDiem == null)
            {
                //QuanLyDiem f = new QuanLyDiem();
                //foreach (Control item in BaoForm.Controls.OfType<Form>())
                //{
                //    BaoForm.Controls.Remove(item);
                //}
                //QuanLyDiem frm = new QuanLyDiem();
                //;
                Them(qlDiem);
                //qlDiem.TopLevel = false;
                //qlDiem.AutoScroll = true;
                //qlDiem.MdiParent = this;
                //BaoForm.Controls.Add(qlDiem);
                // qlDiem.Dock = DockStyle.Fill;
                qlDiem.MAGV = MAGV;
                qlDiem.Show();
                ////HTform(qlDiem);
                //// btnQuanLyDiem.BackColor = Color.Red;


                ////them 1 tab

                ////pnDiem = new Panel();
                ////pnDiem.Width = 100;
                ////pnDiem.Height = 30;
                ////pnDiem.BackColor = Color.White;
                ////pnDiem.BorderStyle = BorderStyle.FixedSingle;
                //Taopn(out pnDiem);

                ////them btn

                ////disQuanLyDiem = new Button();
                ////disQuanLyDiem.Width = 70;
                ////disQuanLyDiem.Text = "QLdiem";
                ////disQuanLyDiem.FlatStyle = FlatStyle.Flat;
                ////disQuanLyDiem.FlatAppearance.BorderSize = 0;
                //Taodis(out disQuanLyDiem);
                //pnDiem.Controls.Add(disQuanLyDiem);
                //disQuanLyDiem.Dock = DockStyle.Right;


                ////clsQuanLyDiem = new Button();
                ////clsQuanLyDiem.Width = 30;
                ////clsQuanLyDiem.Text = "X";
                ////clsQuanLyDiem.ForeColor = Color.Red;
                ////clsQuanLyDiem.FlatStyle = FlatStyle.Flat;
                ////clsQuanLyDiem.FlatAppearance.BorderSize = 0;
                //Taocls(out clsQuanLyDiem);
                //clsQuanLyDiem.Click += ClsQuanLyDiem_Click;
                //pnDiem.Controls.Add(clsQuanLyDiem);
                //clsQuanLyDiem.Dock = DockStyle.Right;


                //TabGG.Controls.Add(pnDiem);
                //pnDiem.Dock = DockStyle.Left;






            }
            else
            {
                Them(qlDiem);

            }

        }
        //tao
        
        //su kien dong
        private void Them(Form a)
        {
            foreach (Control item in BaoForm.Controls.OfType<Form>())
            {


                item.Dock = DockStyle.None;
                BaoForm.Controls.Remove(item);
                   
                
            }
            a.TopLevel = false;
            a.AutoScroll = true;
            a.FormBorderStyle = FormBorderStyle.None;
            
            a.MdiParent = this;
            BaoForm.Controls.Add(a);
            a.Dock = DockStyle.Fill;
        }
        private void ClsQuanLyDiem_Click(object sender, EventArgs e)
        {
            if (pnDiem != null)
            {
                foreach (Control i in TabGG.Controls.OfType<Panel>())
                    if (i == pnDiem)
                    {
                        
                        TabGG.Controls.Remove(i);
                        pnDiem = null;
                        disQuanLyDiem = null;
                        clsQuanLyDiem = null;

                        break;
                    }
            }



            foreach (Form item in this.MdiChildren)
            {
                
            }
               // frm.Close();
            //frm.Visible = false;
           // Application.Exit(QuanLyDiem);




            foreach (Control item in BaoForm.Controls.OfType<Form>())
                {
                    BaoForm.Controls.Remove(item);
                }
            
        }

        private void btnQuanLyMonHoc_Click(object sender, EventArgs e)
        {
            Them(qlMOnHoc);
            if (Application.OpenForms["QuanLyMonHoc"] as QuanLyMonHoc == null)
            {
                qlMOnHoc.Show();
            }
        }

        private void btnQuanLyLopHoc_Click(object sender, EventArgs e)
        {
            Them(qlLOp);
            if (Application.OpenForms["QuanLyLop"] as QuanLyLop == null)
            {
                qlLOp.Show();
            }
        }

        private void btnQuanLyHocSinh_Click(object sender, EventArgs e)
        {
            Them(qlHocSinh);
            if (Application.OpenForms["QuanLyHocSinh"] as QuanLyHocSinh == null)
            {
                qlHocSinh.Show();
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
          //  CanBoGiaoVienBLL c = new CanBoGiaoVienBLL();
           
            dos();
            btnThongkeLen.FlatStyle = FlatStyle.Flat;
            btnThongkeLen.FlatAppearance.BorderSize = 0;
            btnThongkeLen.BackColor = Color.White;

            btnThonglkeXuong.FlatStyle = FlatStyle.Flat;
            btnThonglkeXuong.FlatAppearance.BorderSize = 0;
            btnThonglkeXuong.BackColor = Color.White;

            btnLen.FlatStyle = FlatStyle.Flat;
            btnLen.FlatAppearance.BorderSize = 0;
            btnLen.BackColor = Color.White;

            btnXuong.FlatStyle = FlatStyle.Flat;
            btnXuong.FlatAppearance.BorderSize = 0;
            btnXuong.BackColor = Color.White;
            if (gv)
            {
                btnXuong.Enabled = false;
                btnLen.Enabled = false;
                btnThongkeLen.Enabled = false;
                btnThonglkeXuong.Enabled = false;
                btnQuanLyDanhMuc.Enabled = false;
                btnThongKeBaoCao.Enabled = false;
                btnPhanCongGiangDay.Enabled = false;
            }
            if (ad)
                btnQuanLyDiem.Enabled = false;
        }

        private void TabGG_Paint(object sender, PaintEventArgs e)
        {
           
        }

        
        private bool checkE(string name)
        {
            bool check = false;
            foreach (Form item in this.MdiChildren)
            {
                if (item.Name == name)
                {
                    check = true;
                    break;
                }
            }
            return check;
        }
        //Mo form Phan Cong giang day
        //tao
        private void Taodis(out Button na)
        {
            na = new Button();
            na.Width = 70;
            na.Height = 30;
            na.FlatStyle = FlatStyle.Flat;
            na.FlatAppearance.BorderSize = 0;
            if (na == disGiaoVien)
            {
                na.Text = "GiaoVien";
            }
            if (na == disLopHoc)
            {
                na.Text = "LopHoc";
            }
            if (na == disMonHoc)
            {
                na.Text = "MonHoc";
            }
            if (na == disPhanCong)
            {
                na.Text = "PhanCong";
            }
            if (na == disQuanLyDiem)
            {
                na.Text = "Diem";
            }
            if (na == disHocsinh)
            {
                na.Text = "HOcSinh";
            }
            if (na == disTkgiaovien)
            {
                na.Text = "TKGiaoVien";
            }
            if (na == disTkHocSinh)
            {
                na.Text = "tkHS";
            }
        }
        //cls
        private void Taocls(out Button  na)
        {
            na = new Button();
            na.Width = 30;
            na.Height = 30;
            na.FlatStyle = FlatStyle.Flat;
            na.FlatAppearance.BorderSize = 0;
            na.ForeColor = Color.Red;
            na.Text = "X";
        }
        private void Taopn(out Panel pn)
        {
            pn = new Panel();
            pn.BorderStyle = BorderStyle.None;
            pn.BackColor = Color.White;
            pn.Width = 100;
            pn.Height = 30;
        }

        string MAGV;
        private void dos (){
            CanBoGiaoVienBLL cb = new CanBoGiaoVienBLL();
            foreach (CanBoGiaoVien item in cb.dscb())
            {
                if (item.Taikhoan == TenUsers)
                {
                    doDucVinhToolStripMenuItem.Text = item.HoTen;
                    //QuanLyDiem f = new QuanLyDiem();
                    MAGV = item.MaCanBo;
                    break;
                }
            }
                  
                
            
        }
        //phancong
        private void btnPhanCongGiangDay_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["PhanCongGiangDay"] as PhanCongGiangDay == null)
            {
                //PhanCongGiangDay frm = new PhanCongGiangDay();
                //frm.FormBorderStyle = FormBorderStyle.None;
                //frm.TopLevel = false;
                //frm.AutoScroll = true;
                //frm.MdiParent = this;

                //foreach (Control item in BaoForm.Controls.OfType<Form>())
                //{
                //    BaoForm.Controls.Remove(item);
                //}
                // HTform(Phan);
                //BaoForm.Controls.Remove(f);
                //BaoForm.Controls.Add(frm);

                //frm.Dock = DockStyle.Fill;
                Them(Phan);
                Phan.Show();
                ////btnQuanLyDiem.BackColor = Color.Red;


                ////them 1 tab

                ////pnPhancong = new Panel();
                ////pnPhancong.Width = 100;
                ////pnPhancong.Height = 30;
                ////pnPhancong.BackColor = Color.White;
                ////pnPhancong.BorderStyle = BorderStyle.FixedSingle;
                //Taopn(out pnPhancong);

                ////them btn

                ////disPhanCong = new Button();
                ////disPhanCong.Width = 70;
                ////disPhanCong.Text = "PhanCong";
                ////disPhanCong.FlatStyle = FlatStyle.Flat;
                ////disPhanCong.FlatAppearance.BorderSize = 0;
                //Taodis(out disPhanCong);
                //pnPhancong.Controls.Add(disPhanCong);
                //disPhanCong.Dock = DockStyle.Right;


                //// clsPhanCong = new Button();
                ////clsPhanCong.Width = 30;
                ////clsPhanCong.Text = "X";
                ////clsPhanCong.ForeColor = Color.Red;
                ////clsPhanCong.FlatStyle = FlatStyle.Flat;
                ////clsPhanCong.FlatAppearance.BorderSize = 0;
                //Taocls(out clsPhanCong);
                //pnPhancong.Controls.Add(clsPhanCong);
                //clsPhanCong.Dock = DockStyle.Right;


                //TabGG.Controls.Add(pnPhancong);
                //pnPhancong.Dock = DockStyle.Left;


            }
            else
            {
                //PhanCongGiangDay frm = new PhanCongGiangDay();
                ////foreach (Control item in BaoForm.Controls.OfType<Form>())
                ////{
                ////    BaoForm.Controls.Remove(item);

                ////}
                ////BaoForm.Controls.Add(frm);
                //QuanLyDiem f = new QuanLyDiem();
                //f.Dock = DockStyle.None;

                //frm.Dock = DockStyle.Fill;
                Them(Phan);
                
            }

        }
    }
}

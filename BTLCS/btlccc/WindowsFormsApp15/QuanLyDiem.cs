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
using System.Threading;
namespace WindowsFormsApp15
{
    public partial class QuanLyDiem : Form
    {
        public QuanLyDiem()
        {
            InitializeComponent();
        }
        #region CAC BIEN LOP
        private QuanLyDiemBLL ql = new QuanLyDiemBLL();
        private int STT = 0;
        List<string> MaLop = new List<string>();
        List<string> tenLop = new List<string>();
        List<string> maMon = new List<string>();
        List<string> tenMon = new List<string>();
        List<string> MaHoc = new List<string>();
        List<string> HoTenHS = new List<string>();
        //du lieu tu form main
        public string MAGV;
        List<string> MALOP = new List<string>();
        List<string> MAMON = new List<string>();
        //Them
        List<string> MaHocSinhsuadiem1 = new List<string>();
        List<string> MaHocSinhsuadiem2 = new List<string>();
        List<string> diem1SUa = new List<string>();
        List<string> diem2Sua = new List<string>();
        List<int> dongSua1 = new List<int>();
        List<int> dongSua2 = new List<int>();
        private bool LuubtnThem = false, LuutoolThem = false, LuubtnSua = false, LuutoolSua = false, LuubtnMoi = false, LuutoolMoi = false;

        #endregion
        private void TIMGV()
        {
            foreach (var item in ql.dsPhanCong())
            {
                if (item.MaCanBoGV == MAGV)
                {
                    string lop = item.MaLop;
                    string mon = item.MaMon;
                    MALOP.Add(lop);
                    MAMON.Add(mon);
                }
            }
        }
        private void TIMTRUNGLAP()
        {
            for (int i = 0; i < MALOP.Count; i++)
                for (int j = i + 1; j < MALOP.Count; j++)
                {
                    if (MALOP[i] == MALOP[j])
                        MALOP.RemoveAt(j);
                }

            //xoa trUng lap MaMon

            for (int i = 0; i < MAMON.Count; i++)
                for (int j = i + 1; j < MAMON.Count; j++)
                {
                    if (MAMON[i] == MAMON[j])
                        MAMON.RemoveAt(j);
                }
        }
        private void LAYDANHSACHCOMBO()
        {
            foreach (Lop item in ql.dsLop())
            {
                foreach (string i in MALOP)
                    if (item.MaLop == i)
                    {
                        string ma = item.MaLop;
                        string ten = item.TenLop;
                        MaLop.Add(ma);
                        tenLop.Add(ten);
                    }
            }
            cbTenLop.DataSource = tenLop
                                         ;
            //LAY RA DANH SACH MON GIONG VOI NHUNG MON MA GIAO VIEN DAY
            foreach (MonHoc item in ql.dsMon())
            {
                foreach (string i in MAMON)
                {


                    if (item.MaMon == i)
                    {
                        string ma = item.MaMon;
                        string ten = item.TenMon;
                        maMon.Add(ma);
                        tenMon.Add(ten);
                    }
                }
            }
            cbTenMon.DataSource = tenMon;

        }
        //thay doi font tim 

        private void ThayFont()
        {
            txtTim.Text = "Mã môn + Tên môn trong combobox :)) or Mã Hoc Sinh";
            txtTim.ForeColor = Color.Gray;
        }
        private void QuanLyDiem_Load(object sender, EventArgs e)
        {
            //thayfont
            ThayFont();
            
            btnLuu.Enabled = false;
            toolSave.Enabled = false;
            //tim CAC LOP CAC MON MA GIAO VIEN DANG DANG NHAP DAY
            TIMGV();
            //xoa trung lap
            TIMTRUNGLAP();
            //LAY RA DANH saCH MA LOP VA TEN LOP 
            LAYDANHSACHCOMBO();

        }
        private bool btnTHemACTIVE = false;
        private bool btnSUAACTIVE = false;
        //Lay ra ma lop dang duoc chon
        
        private void HienThiListView()
        {
            #region Lay Ma LOp , Mamon duoc chon
            int l;
            string maLop="";
            if (cbTenLop.SelectedIndex != -1)
            {
                l = cbTenLop.SelectedIndex;
                maLop = MaLop[l];
            }
            //Lay nhung HOc Sinh Hoc Ma LOP Duoc chon va co day
            List<HoSoHocSinh> t = ql.dsHs();
            for (int i = 0; i < t.Count; i++)
            {

                if (t[i].MaLop == maLop)
                {
                    string maHs = t[i].MaHocSinh;
                    string tenHs = t[i].HoTen;
                    HoTenHS.Add(tenHs);
                    MaHoc.Add(maHs);
                }
            }
            //Lay MAMOn duoc chon va co day
            int bb;
            string mam="";
            if (cbTenMon.SelectedIndex != -1)
            {
                 bb = cbTenMon.SelectedIndex;
                 mam = maMon[bb];
            }

            #endregion

            foreach (Diem item in ql.dsDiem())
            {
                int c = 0;
                foreach (string hs in MaHoc)
                {

                    
                    if (item.MaHocSinh == hs && item.MaMonHoc == mam)
                    {
                        double tb=0;
                        DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[STT].Clone();
                        row.Cells[0].Value = STT.ToString();
                        row.Cells[1].Value = item.MaHocSinh;
                        row.Cells[2].Value = HoTenHS[c];

                        if (item.DiemKy1 == -1)
                            row.Cells[3].Value = "";
                        else
                            row.Cells[3].Value = item.DiemKy1.ToString();
                        if (item.DiemKy2 == -1)
                            row.Cells[4].Value = "";
                        else
                            row.Cells[4].Value = item.DiemKy2.ToString(); ;

                        if (item.DiemKy1 != -1 && item.DiemKy2 != -1)
                            tb = (item.DiemKy2 + item.DiemKy1) / 2;
                        if (item.DiemKy1 == -1 && item.DiemKy2 != -1)
                            tb = item.DiemKy2;
                        if (item.DiemKy1 != -1 && item.DiemKy2 == -1)
                            tb = item.DiemKy1;
                        if (item.DiemKy1 == -1 && item.DiemKy2 == -1)
                            tb =-1;
                        if(tb==-1)
                            row.Cells[5].Value ="";
                        else
                        row.Cells[5].Value = tb.ToString();
                        dataGridView1.Rows.Add(row);
                        STT++;
                    }
                    //}
                    c++;
                }

            }
            MaHoc.Clear();
            HoTenHS.Clear();

        }
        
        //them moi

        private void ThemMoiHT()
        {
            STT = 0;
            List<string> dsHSHOC = new List<string>();
            int k = -1;
            string mal = "";
            if (cbTenLop.SelectedIndex != -1)
            {
                k = cbTenLop.SelectedIndex;
                mal = MaLop[k];
            }
            foreach (var item in ql.dsHs())
            {
                if (item.MaLop == mal)
                {
                    string mahs = item.MaHocSinh;
                    dsHSHOC.Add(mahs);
                }
            }
            string mam = "";
            if (cbTenMon.SelectedIndex != -1)
            {
                k = cbTenMon.SelectedIndex;
                mam = maMon[k];
            }
            foreach (var item in dsHSHOC)
            {
                bool gg = true;
                foreach (var i in ql.dsDiem())
                {
                    if (item == i.MaHocSinh && mam == i.MaMonHoc)
                    {
                        gg = false;
                        break;
                    }
                }
                if (gg)
                {

                    DataGridViewRow row = (DataGridViewRow)dataGridView3.Rows[STT].Clone();
                    row.Cells[0].Value = STT.ToString();
                    row.Cells[1].Value = item;
                    row.Cells[2].Value = mam;
                    row.Cells[3].Value = "";
                    row.Cells[4].Value = "";
                    dataGridView3.Rows.Add(row);
                    STT++;
                }
            }
            STT = 0;

        }



        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        //private void cbTenMon_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (cbTenMon.SelectedIndex != -1)
        //    {
        //        lblMon.Text = cbTenMon.SelectedItem.ToString();
        //        int k = cbTenMon.SelectedIndex;
        //        labelmamon.Text = maMon[k];
        //    }
        //}

        //private void cbTenLop_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (cbTenLop.SelectedIndex != -1)
        //    {
        //        lblLOp.Text = cbTenLop.SelectedItem.ToString();
        //        int k = cbTenLop.SelectedIndex;
        //        lblMa.Text = MaLop[k];
        //    }
           
        //}

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //hien thi
        private string MamonLay = "";
        //hoi btn sua
        private void HOiBTNsua()
        { }
        //hoi btn them
        private void HoiBtnTHem()
        { }
        private void unEDA1()
        {
            dataGridView1.Columns[3].ReadOnly = true;
            dataGridView1.Columns[4].ReadOnly = true;
            dataGridView2.Columns[5].ReadOnly = true;
            dataGridView2.Columns[6].ReadOnly = true;
            dataGridView3.Columns[3].ReadOnly = true;
            dataGridView3.Columns[4].ReadOnly = true;
            
        }

        private bool tCK()
        {
            if (txtTim.Text == "Mã môn + Tên môn trong combobox :)) or Mã Hoc Sinh" || txtTim.ForeColor == Color.Gray)
                return true;
            else
                return false;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (tCK())
            {
                //kiem tra btn
                LuubtnMoi = false;
                LuubtnSua = false;
                LuubtnThem = false;

                unEDA1();

                if (btnSUAACTIVE)
                {
                    HOiBTNsua();
                }
                if (btnTHemACTIVE)
                {
                    HoiBtnTHem();
                }

                btnSUAACTIVE = false;
                btnTHemACTIVE = false;

                if (dataGridView1.Visible == false)
                    CH("dataGridView1");
                int k = 0;
                if (cbTenMon.SelectedIndex != -1)
                {
                    k = cbTenMon.SelectedIndex;
                    MamonLay = maMon[k];
                }

                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                STT = 0;
                // if(tCK())
                HienThiListView();

            }
            else

            {
                //kiem tra btn
                LuubtnMoi = false;
                LuubtnSua = false;
                LuubtnThem = false;

               // unEDA1();

                if (btnSUAACTIVE)
                {
                    HOiBTNsua();
                }
                if (btnTHemACTIVE)
                {
                    HoiBtnTHem();
                }

                btnSUAACTIVE = false;
                btnTHemACTIVE = false;

                if (dataGridView4.Visible == false)
                    CH("dataGridView4");
                int k = 0;
                if (cbTenMon.SelectedIndex != -1)
                {
                    k = cbTenMon.SelectedIndex;
                    MamonLay = maMon[k];
                }

                dataGridView4.Rows.Clear();
                dataGridView4.Refresh();
                STT = 0;
                // if(tCK())
                Hths();
            }
            btnLuu.Enabled = false;
            toolSave.Enabled = false;
           

        }

        //
        private List<string> mhs = new List<string>();
        private void lay()
        {
            //List<string> mhs = new List<string>();
            foreach (var item in ql.dsHs())

            {
                foreach (var ml in MaLop)
                {
                    if (item.MaLop == ml)
                    {
                        mhs.Add(item.MaHocSinh);
                        break;
                    }
                }
            }

            
        }
        private void Hths()
        {
            lay();
            bool g = false;
            foreach (var hs in ql.dsHs())
            {


                foreach (var item in mhs)
                {
                    if (hs.MaHocSinh == item)
                    {
                        if (item == txtTim.Text)
                        {
                            DataGridViewRow row = (DataGridViewRow)dataGridView4.Rows[STT].Clone();
                            row.Cells[0].Value = hs.MaHocSinh.ToString();
                            row.Cells[1].Value = hs.HoTen;
                            row.Cells[2].Value = hs.NgaySinh;
                            row.Cells[3].Value = hs.GioiTinh;
                            row.Cells[4].Value = hs.DiaChi;
                            row.Cells[5].Value = hs.DiemVAotruong.ToString();
                            row.Cells[6].Value = hs.HoTenBoMe;
                            row.Cells[7].Value = hs.sdt;
                            row.Cells[8].Value = hs.MaLop;

                            dataGridView4.Rows.Add(row);
                            g = true;
                            break;


                        }
                    }
                }

            }
            if (!g)
                MessageBox.Show("Khong thay hoc sinh co ma: " + txtTim, "null", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        //CHeck btn sua
        private void CheckBTNSUA()
        {

            
        }
        //enable cell input data
        private void ENA()
        {
            if (dataGridView1.Rows.Count == 1)
            {
                MessageBox.Show("Chưa có HỌC SINH làm sao mà nhập điểm  !!!", "");
            }
            else
            {
                bool xx = false;

                //enable
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    if (dataGridView1.Rows[i].Cells[3].Value.ToString() == "")
                    {
                        xx = true;
                        dataGridView1.Rows[i].Cells[3].ReadOnly = false;
                        // dataGridView1.Rows[i].Cells[3].Selected = true;

                        dataGridView1.CurrentCell = dataGridView1[3, i];
                        dataGridView1.Rows[0].Cells[0].Selected = false;

                        MaHocSinhsuadiem1.Add(dataGridView1.Rows[i].Cells[1].Value.ToString());
                        diem1SUa.Add(dataGridView1.Rows[i].Cells[1].Value.ToString());
                        dongSua1.Add(i);
                    }
                    if (dataGridView1.Rows[i].Cells[4].Value.ToString() == "")
                    {
                        xx = true;
                        dataGridView1.Rows[i].Cells[4].ReadOnly = false;
                        // dataGridView1.Rows[i].Cells[4].Selected = true;
                        dataGridView1.CurrentCell = dataGridView1[4, i];
                        dataGridView1.Rows[0].Cells[0].Selected = false;
                        MaHocSinhsuadiem2.Add(dataGridView1.Rows[i].Cells[1].Value.ToString());
                        diem2Sua.Add(dataGridView1.Rows[i].Cells[1].Value.ToString());
                        dongSua2.Add(i);
                    }

                }
                if (xx)
                {
                    btnLuu.Enabled = true;
                    toolSave.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Điểm đã thêm hết rồi \nchỉ có sửa or xem được thôi thím ơi !!!", "");
                }
            }
        }
        //Them
        private void button2_Click(object sender, EventArgs e)
        {
            //ht

         
            unEDA1();
       
            LuubtnMoi = false;
            LuubtnSua = false;
            LuubtnThem = true;
         
            if (dataGridView1.Visible == false)
                CH("dataGridView1");
            int k = 0;
            if (cbTenMon.SelectedIndex != -1)
            {
                k = cbTenMon.SelectedIndex;
                MamonLay = maMon[k];
            }

            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            STT = 0;
            HienThiListView();
            btnTHemACTIVE = true;
            if(btnSUAACTIVE)
                CheckBTNSUA();
            ENA();
            
        }
        //btn LUU
        private void button4_Click(object sender, EventArgs e)
        {
            if (LuubtnThem)
            {
                int i = 0; bool t = true;
                foreach (int item in dongSua1)
                {
                    bool ck = ql.ThemDiem1(MaHocSinhsuadiem1[i], MamonLay, dataGridView1.Rows[item].Cells[3].Value.ToString());
                    i++;
                    if (!ck)
                    {
                        MessageBox.Show("Thêm thất bại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        t = false;
                        /// dataGridView1.Rows[item].Selected = true;
                        
                        break;

                    }

                }
                if (!t)
                {
                    dataGridView1.Refresh();
                    dataGridView1.CurrentCell = dataGridView1[3, i];
                    return;
                }
                int j = 0;
                if (t)
                {
                    foreach (int item in dongSua2)
                    {
                        bool ck = ql.ThemDiem2(MaHocSinhsuadiem2[j], MamonLay, dataGridView1.Rows[item].Cells[4].Value.ToString());

                        j++;
                        if (!ck)
                        {
                            MessageBox.Show("Thêm thất bại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            t = false;

                            break;

                        }

                    }
                }
                if (!t)
                {
                    dataGridView1.Refresh();
                    dataGridView1.CurrentCell = dataGridView1[4, j];
                }
                if (t)
                {
                    dataGridView1.Refresh();
                    MessageBox.Show("Thêm thành công", "success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    toolStripProgressBar1.Visible = true;
                    backgroundWorker1.RunWorkerAsync();
                    button2_Click(null, null);
                    //  btnLuu.Enabled = false;

                }
               
            }
            //xoa
            if (LuubtnSua)
            {
                int m = 0,c=0;
                bool t = true;
                for(int i=0;i<dataGridView2.Rows.Count-1;i++)
                {
                    if (dataGridView2.Rows[i].Cells[1].Value != null)
                    {
                        bool ck = true, ck1 = true;

                        if (dataGridView2.Rows[i].Cells[5].Value == null || dataGridView2.Rows[i].Cells[5].Value.ToString()=="")
                            ck = ql.Suadiem1(
                                                     dataGridView2.Rows[i].Cells[1].Value.ToString(),
                                                     MamonLay,
                                                     "v"
                                                );
                        else
                            ck = ql.Suadiem1(
                                                     dataGridView2.Rows[i].Cells[1].Value.ToString(),
                                                     MamonLay,
                                                     dataGridView2.Rows[i].Cells[5].Value.ToString()
                                                );
                        if (!ck)
                        {
                            MessageBox.Show("Sửa thất bại Diem ky1", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            t = false;
                            c = 5;
                            // dataGridView1.Rows[item].Selected = true;

                            break;

                        }

                       // System.Threading.Thread.Sleep(500);
                        //diem 2

                        if (dataGridView2.Rows[i].Cells[6].Value == null || dataGridView2.Rows[i].Cells[6].Value.ToString()=="")
                            ck1 = ql.Suadiem2(
                                                     dataGridView2.Rows[i].Cells[1].Value.ToString(),
                                                     MamonLay,
                                                     "v"
                                                );
                        else
                            ck1 = ql.Suadiem2(
                                                     dataGridView2.Rows[i].Cells[1].Value.ToString(),
                                                     MamonLay,
                                                     dataGridView2.Rows[i].Cells[6].Value.ToString()
                                                );




                        //diem 2

                        if (!ck1)
                        {
                            MessageBox.Show("Sửa thất bại diem ky2", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            t = false;
                            c = 6;
                            /// dataGridView1.Rows[item].Selected = true;

                            break;

                        }
                        m++;
                    }

                }
                if (!t)
                {
                    dataGridView2.Refresh();
                    dataGridView2.CurrentCell = dataGridView2[c, m ];
                    
                }
               
                
                if (t)
                {
                    dataGridView2.Refresh();
                    MessageBox.Show("Sua thành công", "success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    toolStripProgressBar1.Visible = true;
                    backgroundWorker1.RunWorkerAsync();
                    button3_Click(null, null);
                    // btnLuu.Enabled = false;

                }
                
            }
            //btnLuu.Enabled = false;

            if (LuubtnMoi)
            {
                if (dataGridView3.SelectedRows.Count > 0)
                {
                    DialogResult d = MessageBox.Show("Ban co muon thuc su them cac hoc sinh nay vao bang diem ???", "questn", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    if (d == DialogResult.Yes)
                    {

                        for (int i = 0; i < dataGridView3.Rows.Count - 1; i++)
                        {
                            if (dataGridView3.Rows[i].Selected == true)
                                ql.THemDiemMOI(dataGridView3.Rows[i].Cells[1].Value.ToString(), MamonLay, "", "");
                        }
                        toolStripProgressBar1.Visible = true;
                        backgroundWorker1.RunWorkerAsync();
                        MessageBox.Show("Them moi thanh cong ", "!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                    else
                    {
                        return;
                    }
                    btnMoi_Click(null, null);
                }
                else
                {
                    MessageBox.Show("can chon de them vao bao diem ","",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                }
            }
            //btnLuu.Enabled = false;


        }
        //hien thi data2
        private void CH(string Name)
        {
            if (Name == "dataGridView2")
            {
                dataGridView4.Dock = DockStyle.None;
                dataGridView4.Visible = false;
                dataGridView1.Dock = DockStyle.None;
                dataGridView1.Visible = false;
                dataGridView3.Dock = DockStyle.None;
                dataGridView3.Visible = false;

                dataGridView2.Visible = true;
                dataGridView2.Dock = DockStyle.Fill;
            }
            if (Name == "dataGridView1")
            {
                dataGridView4.Dock = DockStyle.None;
                dataGridView4.Visible = false;
                dataGridView3.Dock = DockStyle.None;
                dataGridView3.Visible = false;
                dataGridView2.Dock = DockStyle.None;
                dataGridView2.Visible = false;
                dataGridView1.Visible = true;
                dataGridView1.Dock = DockStyle.Fill;
            }
            if (Name == "dataGridView3")
            {
                dataGridView4.Dock = DockStyle.None;
                dataGridView4.Visible = false;
                dataGridView1.Dock = DockStyle.None;
                dataGridView1.Visible = false;
                dataGridView2.Dock = DockStyle.None;
                dataGridView2.Visible = false;

                dataGridView3.Visible = true;
                dataGridView3.Dock = DockStyle.Fill;
            }
            if (Name == "dataGridView4")
            {
                dataGridView1.Dock = DockStyle.None;
                dataGridView1.Visible = false;
                dataGridView2.Dock = DockStyle.None;
                dataGridView2.Visible = false;

                dataGridView3.Visible = false;
                dataGridView3.Dock = DockStyle.None;

                dataGridView4.Visible = true;
                dataGridView4.Dock = DockStyle.Fill;
            }
        }
        //khong ht data2
       
        private void Hienthidata2()
        {
            STT = 0;

            #region Lay Ma LOp , Mamon duoc chon
            int l;
            string maLop = "";
            if (cbTenLop.SelectedIndex != -1)
            {
                l = cbTenLop.SelectedIndex;
                maLop = MaLop[l];
            }
            //Lay nhung HOc Sinh Hoc Ma LOP Duoc chon va co day
            List<HoSoHocSinh> t = ql.dsHs();
            for (int i = 0; i < t.Count; i++)
            {

                if (t[i].MaLop == maLop)
                {
                    string maHs = t[i].MaHocSinh;
                    string tenHs = t[i].HoTen;
                    HoTenHS.Add(tenHs);
                    MaHoc.Add(maHs);
                }
            }
            //Lay MAMOn duoc chon va co day
            int bb;
            string mam = "";
            if (cbTenMon.SelectedIndex != -1)
            {
                bb = cbTenMon.SelectedIndex;
                mam = maMon[bb];
            }

            #endregion

            foreach (Diem item in ql.dsDiem())
            {
                int c = 0;
                foreach (string hs in MaHoc)
                {


                    if (item.MaHocSinh == hs && item.MaMonHoc == mam)
                    {
                        //double tb = 0;
                        DataGridViewRow row = (DataGridViewRow)dataGridView2.Rows[STT].Clone();
                        row.Cells[0].Value = STT.ToString();
                        row.Cells[1].Value = item.MaHocSinh;
                        row.Cells[2].Value = HoTenHS[c];

                        if (item.DiemKy1 == -1)
                            row.Cells[3].Value = null;
                        else
                            row.Cells[3].Value = item.DiemKy1.ToString();
                        if (item.DiemKy2 == -1)
                            row.Cells[4].Value = null;
                        else
                            row.Cells[4].Value = item.DiemKy2.ToString(); ;




                        if (item.DiemKy1 == -1)
                            row.Cells[5].Value = null;
                        else
                            row.Cells[5].Value = item.DiemKy1.ToString();
                        if (item.DiemKy2 == -1)
                            row.Cells[6].Value = null;
                        else
                            row.Cells[6].Value = item.DiemKy2.ToString(); ;

                        dataGridView2.Rows.Add(row);
                        STT++;
                    }
                    //}
                    c++;
                }

            }
            //dataGridView2.ClearSelection();
            //for (int r = 0; r < dataGridView2.RowCount; r++)
            //{
            //    dataGridView2[5, r].Selected = true;
            //    dataGridView2[6, r].Selected = true;
            //}
          
            MaHoc.Clear();
            HoTenHS.Clear();
        }
        //chk btn them
        private void CheckbtnTHEM()
        { }
        //enable sua
        private void ENASUA()
        {
           // for(int i=0)
            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {
                dataGridView2.Rows[i].Cells[5].ReadOnly = false;
                dataGridView2.Rows[i].Cells[6].ReadOnly = false;
               
            }
        }
        //btn SUA
        
        private void button3_Click(object sender, EventArgs e)
        {
         
            unEDA1();
       
            LuubtnMoi = false; 
            LuubtnSua = true;
            LuubtnThem = false;
            //lay mamon
          
            int k = 0;
            if (cbTenMon.SelectedIndex != -1)
            {
                k = cbTenMon.SelectedIndex;
                MamonLay = maMon[k];
            }

            btnSUAACTIVE = true;
            if (btnTHemACTIVE)
                 CheckbtnTHEM();
            if (dataGridView2.Visible == false)
                 CH("dataGridView2");
            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();
            Hienthidata2();
            dataGridView2.Columns[5].DefaultCellStyle.BackColor = Color.Gray;
            dataGridView2.Columns[6].DefaultCellStyle.BackColor = Color.Gray;
            if (dataGridView2.Rows.Count == 1)
            {
                MessageBox.Show("Đã có Học Sinh nào đâu mà Sửa điểm :)))");
            }
            else
                ENASUA();
            btnLuu.Enabled = true;
            toolSave.Enabled = true;
            

        }

       
     
     
        //tim
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            toolStripProgressBar1.Visible = true;
            backgroundWorker1.RunWorkerAsync();
            System.Threading.Thread.Sleep(10);
            button1_Click_1(null, null);
           
        }
        //goi su kien button luu click
        private void saveToolStripButton_Click_1(object sender, EventArgs e)
        {
            button4_Click(null, null);
        }
        //tro ve font cu
        private void TroveFont()
        {
            txtTim.Text = "";
            txtTim.ForeColor = Color.Black;
        }
       

        private void txtTim_Enter(object sender, EventArgs e)
        {
            TroveFont();
        }

        private void txtTim_Leave(object sender, EventArgs e)
        {
            ThayFont();
        }

        private void cbTenLop_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cbTenLop.SelectedIndex != -1)
            {
                lblLOp.Text = cbTenLop.SelectedItem.ToString();
                int k = cbTenLop.SelectedIndex;
                lblMa.Text = MaLop[k];
            }
        }

        private void cbTenMon_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cbTenMon.SelectedIndex != -1)
            {
                lblMon.Text = cbTenMon.SelectedItem.ToString();
                int k = cbTenMon.SelectedIndex;
                labelmamon.Text = maMon[k];
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i <= 100;i= i+2)
            {
                int per = i * 100 / 100;
                backgroundWorker1.ReportProgress(per,i);
                System.Threading.Thread.Sleep(1);
                // System.Threading.Thread.Sleep(100);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            toolStripProgressBar1.Value = 0;
            toolStripProgressBar1.Visible = false;
        }

        private void toolMoi_Click(object sender, EventArgs e)
        {
            btnMoi_Click(null, null);
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i <= 100; i = i + 1)
            {
                int per = i * 100 / 100;
                backgroundWorker2.ReportProgress(per, i);
                System.Threading.Thread.Sleep(1);
                // System.Threading.Thread.Sleep(100);
            }
        }

        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            toolStripProgressBar1.Value = 0;
            toolStripProgressBar1.Visible = false;
        }

        private void txtTim_Click(object sender, EventArgs e)
        {

        }

        //goi sukien button them click
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            button2_Click(null, null);
        }
        //goi su kien button sua click
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            button3_Click(null, null);
        }

        private void helpToolStripButton_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start
                ("https://www.google.com.vn/search?q=%3F&rlz=1C1PRFI_enVN" +
                "767VN767&source=lnms&tbm=isch&sa=X&ved=0ahUKEwiAqYDX" +
                "jaPbAhWKWLwKHUM2DTEQ_AUICigB&biw=1517&bih=664");
        }
        //lay ra toan bo hoc sinh :ma hoc sinh , ten hoc sinh hoc mon nay va co nay day , sau do them 2 cot la cot diem ky1 va diem ky2 cho 
        //user them moi . tao datafridview moi
        //en
        private void ENAMOI()
        {
            // for(int i=0)
            for (int i = 0; i < dataGridView3.Rows.Count - 1; i++)
            {
                dataGridView3.Rows[i].Cells[3].ReadOnly = false;
                dataGridView3.Rows[i].Cells[4].ReadOnly = false;

            }
        }
        private void btnMoi_Click(object sender, EventArgs e)
        {
            toolStripProgressBar1.Visible = true;
            backgroundWorker2.RunWorkerAsync();
           // System.Threading.Thread.Sleep(5000);
            
            unEDA1();

            LuubtnMoi = true;
            LuubtnSua = false;
            LuubtnThem = false;
            //lay mamon

            int k = 0;
            if (cbTenMon.SelectedIndex != -1)
            {
                k = cbTenMon.SelectedIndex;
                MamonLay = maMon[k];
            }

            if (dataGridView3.Visible == false)
                CH("dataGridView3");
            dataGridView3.Rows.Clear();
            dataGridView3.Refresh();
            STT = 0;
            ThemMoiHT();
            dataGridView3.Columns[3].DefaultCellStyle.BackColor = Color.Tomato;
            dataGridView3.Columns[4].DefaultCellStyle.BackColor = Color.Tomato;
            dataGridView3.ClearSelection();
            if (dataGridView3.Rows.Count == 1)
            {
                MessageBox.Show("Tất cả học sinh trong lớp đều đã được thêm vào bảng điểm :)))");
            }
            else
            {
               // ENAMOI();
                btnLuu.Enabled = true;
                toolSave.Enabled = true;
            }

        }
    }
}

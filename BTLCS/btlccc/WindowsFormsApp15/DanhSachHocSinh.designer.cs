namespace WindowsFormsApp15
{
    partial class DanhSachHocSinh
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNguoiLap = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtTenTruong = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnIn = new System.Windows.Forms.Button();
            this.dgvDSHS = new System.Windows.Forms.DataGridView();
            this.btnTim = new System.Windows.Forms.Button();
            this.cboTenLop = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSHS)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(263, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(342, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "DANH SÁCH HỌC SINH";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(123, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên Lớp:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.txtNguoiLap);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.txtTenTruong);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(57, 138);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(759, 149);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin chung";
            // 
            // txtNguoiLap
            // 
            this.txtNguoiLap.Location = new System.Drawing.Point(221, 93);
            this.txtNguoiLap.Name = "txtNguoiLap";
            this.txtNguoiLap.Size = new System.Drawing.Size(189, 22);
            this.txtNguoiLap.TabIndex = 7;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(528, 49);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(182, 22);
            this.dateTimePicker1.TabIndex = 6;
            // 
            // txtTenTruong
            // 
            this.txtTenTruong.Location = new System.Drawing.Point(221, 46);
            this.txtTenTruong.Name = "txtTenTruong";
            this.txtTenTruong.Size = new System.Drawing.Size(189, 22);
            this.txtTenTruong.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(102, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 17);
            this.label6.TabIndex = 3;
            this.label6.Text = "Người lập:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(440, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "Ngày lập:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(102, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tên Trường:";
            // 
            // btnIn
            // 
            this.btnIn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnIn.Location = new System.Drawing.Point(699, 84);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(90, 33);
            this.btnIn.TabIndex = 4;
            this.btnIn.Text = "In";
            this.btnIn.UseVisualStyleBackColor = true;
            // 
            // dgvDSHS
            // 
            this.dgvDSHS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dgvDSHS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSHS.Location = new System.Drawing.Point(57, 333);
            this.dgvDSHS.Name = "dgvDSHS";
            this.dgvDSHS.RowTemplate.Height = 24;
            this.dgvDSHS.Size = new System.Drawing.Size(759, 262);
            this.dgvDSHS.TabIndex = 5;
            // 
            // btnTim
            // 
            this.btnTim.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnTim.Location = new System.Drawing.Point(547, 84);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(88, 32);
            this.btnTim.TabIndex = 6;
            this.btnTim.Text = "Hiển Thị";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // cboTenLop
            // 
            this.cboTenLop.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboTenLop.FormattingEnabled = true;
            this.cboTenLop.Location = new System.Drawing.Point(209, 86);
            this.cboTenLop.Name = "cboTenLop";
            this.cboTenLop.Size = new System.Drawing.Size(281, 24);
            this.cboTenLop.TabIndex = 7;
            // 
            // DanhSachHocSinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 619);
            this.Controls.Add(this.cboTenLop);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.dgvDSHS);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "DanhSachHocSinh";
            this.Text = "Danh sách học sinh";
            this.Load += new System.EventHandler(this.DanhSachHocSinh_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSHS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNguoiLap;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox txtTenTruong;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.DataGridView dgvDSHS;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.ComboBox cboTenLop;
    }
}


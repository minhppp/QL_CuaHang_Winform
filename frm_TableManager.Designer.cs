namespace DOAN
{
    partial class frm_TableManager
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinTàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinCáNhânToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.nmFoodCount = new System.Windows.Forms.NumericUpDown();
            this.btn_Add = new System.Windows.Forms.Button();
            this.cb_Food = new System.Windows.Forms.ComboBox();
            this.cb_FoodCategory = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lsv_Bill = new System.Windows.Forms.ListView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.nm_Discount = new System.Windows.Forms.NumericUpDown();
            this.lb_TotalPrice = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_Combine = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Combine = new System.Windows.Forms.Button();
            this.btn_Check = new System.Windows.Forms.Button();
            this.flow_Table = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmFoodCount)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nm_Discount)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminToolStripMenuItem,
            this.thôngTinTàiKhoảnToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(975, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(81, 29);
            this.adminToolStripMenuItem.Text = "Admin";
            this.adminToolStripMenuItem.Click += new System.EventHandler(this.adminToolStripMenuItem_Click);
            // 
            // thôngTinTàiKhoảnToolStripMenuItem
            // 
            this.thôngTinTàiKhoảnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thôngTinCáNhânToolStripMenuItem,
            this.đăngXuấtToolStripMenuItem});
            this.thôngTinTàiKhoảnToolStripMenuItem.Name = "thôngTinTàiKhoảnToolStripMenuItem";
            this.thôngTinTàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(182, 29);
            this.thôngTinTàiKhoảnToolStripMenuItem.Text = "Thông tin tài khoản";
            // 
            // thôngTinCáNhânToolStripMenuItem
            // 
            this.thôngTinCáNhânToolStripMenuItem.Name = "thôngTinCáNhânToolStripMenuItem";
            this.thôngTinCáNhânToolStripMenuItem.Size = new System.Drawing.Size(256, 34);
            this.thôngTinCáNhânToolStripMenuItem.Text = "Thông tin cá nhân";
            this.thôngTinCáNhânToolStripMenuItem.Click += new System.EventHandler(this.thôngTinCáNhânToolStripMenuItem_Click);
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(256, 34);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng Xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.nmFoodCount);
            this.panel1.Controls.Add(this.btn_Add);
            this.panel1.Controls.Add(this.cb_Food);
            this.panel1.Controls.Add(this.cb_FoodCategory);
            this.panel1.Location = new System.Drawing.Point(507, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(427, 110);
            this.panel1.TabIndex = 2;
            // 
            // nmFoodCount
            // 
            this.nmFoodCount.Location = new System.Drawing.Point(354, 37);
            this.nmFoodCount.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nmFoodCount.Name = "nmFoodCount";
            this.nmFoodCount.Size = new System.Drawing.Size(52, 26);
            this.nmFoodCount.TabIndex = 3;
            this.nmFoodCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btn_Add
            // 
            this.btn_Add.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btn_Add.Location = new System.Drawing.Point(263, 18);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(85, 62);
            this.btn_Add.TabIndex = 2;
            this.btn_Add.Text = "Thêm";
            this.btn_Add.UseVisualStyleBackColor = false;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // cb_Food
            // 
            this.cb_Food.FormattingEnabled = true;
            this.cb_Food.Location = new System.Drawing.Point(4, 52);
            this.cb_Food.Name = "cb_Food";
            this.cb_Food.Size = new System.Drawing.Size(244, 28);
            this.cb_Food.TabIndex = 1;
            // 
            // cb_FoodCategory
            // 
            this.cb_FoodCategory.FormattingEnabled = true;
            this.cb_FoodCategory.Location = new System.Drawing.Point(4, 18);
            this.cb_FoodCategory.Name = "cb_FoodCategory";
            this.cb_FoodCategory.Size = new System.Drawing.Size(244, 28);
            this.cb_FoodCategory.TabIndex = 0;
            this.cb_FoodCategory.SelectedIndexChanged += new System.EventHandler(this.cb_Category_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lsv_Bill);
            this.panel2.Location = new System.Drawing.Point(507, 156);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(430, 288);
            this.panel2.TabIndex = 3;
            // 
            // lsv_Bill
            // 
            this.lsv_Bill.HideSelection = false;
            this.lsv_Bill.Location = new System.Drawing.Point(0, 3);
            this.lsv_Bill.Name = "lsv_Bill";
            this.lsv_Bill.Size = new System.Drawing.Size(427, 281);
            this.lsv_Bill.TabIndex = 0;
            this.lsv_Bill.UseCompatibleStateImageBehavior = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.nm_Discount);
            this.panel3.Controls.Add(this.lb_TotalPrice);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.cb_Combine);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.btn_Combine);
            this.panel3.Controls.Add(this.btn_Check);
            this.panel3.Location = new System.Drawing.Point(507, 450);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(427, 151);
            this.panel3.TabIndex = 4;
            // 
            // nm_Discount
            // 
            this.nm_Discount.Location = new System.Drawing.Point(127, 54);
            this.nm_Discount.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nm_Discount.Name = "nm_Discount";
            this.nm_Discount.Size = new System.Drawing.Size(59, 26);
            this.nm_Discount.TabIndex = 4;
            // 
            // lb_TotalPrice
            // 
            this.lb_TotalPrice.AutoSize = true;
            this.lb_TotalPrice.Location = new System.Drawing.Point(123, 13);
            this.lb_TotalPrice.Name = "lb_TotalPrice";
            this.lb_TotalPrice.Size = new System.Drawing.Size(0, 20);
            this.lb_TotalPrice.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Tổng Giá:";
            // 
            // cb_Combine
            // 
            this.cb_Combine.FormattingEnabled = true;
            this.cb_Combine.Location = new System.Drawing.Point(123, 106);
            this.cb_Combine.Name = "cb_Combine";
            this.cb_Combine.Size = new System.Drawing.Size(134, 28);
            this.cb_Combine.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Giảm Giá";
            // 
            // btn_Combine
            // 
            this.btn_Combine.Location = new System.Drawing.Point(4, 99);
            this.btn_Combine.Name = "btn_Combine";
            this.btn_Combine.Size = new System.Drawing.Size(113, 40);
            this.btn_Combine.TabIndex = 1;
            this.btn_Combine.Text = "Gộp Bàn";
            this.btn_Combine.UseVisualStyleBackColor = true;
            this.btn_Combine.Click += new System.EventHandler(this.btn_Combine_Click);
            // 
            // btn_Check
            // 
            this.btn_Check.Location = new System.Drawing.Point(293, 96);
            this.btn_Check.Name = "btn_Check";
            this.btn_Check.Size = new System.Drawing.Size(113, 40);
            this.btn_Check.TabIndex = 0;
            this.btn_Check.Text = "Thanh Toán";
            this.btn_Check.UseVisualStyleBackColor = true;
            this.btn_Check.Click += new System.EventHandler(this.btn_Check_Click);
            // 
            // flow_Table
            // 
            this.flow_Table.Location = new System.Drawing.Point(13, 40);
            this.flow_Table.Name = "flow_Table";
            this.flow_Table.Size = new System.Drawing.Size(488, 561);
            this.flow_Table.TabIndex = 5;
            // 
            // frm_TableManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 613);
            this.Controls.Add(this.flow_Table);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frm_TableManager";
            this.Text = "frm_TableManager";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nmFoodCount)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nm_Discount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinTàiKhoảnToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cb_Food;
        private System.Windows.Forms.ComboBox cb_FoodCategory;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView lsv_Bill;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.NumericUpDown nmFoodCount;
        private System.Windows.Forms.Button btn_Combine;
        private System.Windows.Forms.Button btn_Check;
        private System.Windows.Forms.FlowLayoutPanel flow_Table;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem thôngTinCáNhânToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.ComboBox cb_Combine;
        private System.Windows.Forms.Label lb_TotalPrice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nm_Discount;
    }
}
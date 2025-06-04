namespace factory_inventory
{
    partial class factory_inventory_system
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnShowSuppliers = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnShowProducts = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.comb = new System.Windows.Forms.CheckBox();
            this.shaver = new System.Windows.Forms.CheckBox();
            this.shampoo = new System.Windows.Forms.CheckBox();
            this.toothpaste = new System.Windows.Forms.CheckBox();
            this.toothbrush = new System.Windows.Forms.CheckBox();
            this.supplierE = new System.Windows.Forms.CheckBox();
            this.supplierD = new System.Windows.Forms.CheckBox();
            this.supplierC = new System.Windows.Forms.CheckBox();
            this.supplierB = new System.Windows.Forms.CheckBox();
            this.supplierA = new System.Windows.Forms.CheckBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.SearchButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxTransactionType = new System.Windows.Forms.ComboBox();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.comboBoxProduct_tab3 = new System.Windows.Forms.ComboBox();
            this.comboBoxSupplier_tab3 = new System.Windows.Forms.ComboBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelAfterStock = new System.Windows.Forms.Label();
            this.labelCurrentStock = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.submitButton = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.dateTimePicker_trans = new System.Windows.Forms.DateTimePicker();
            this.textBoxQuantity = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxType_tab4 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxProduct_tab4 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxSupplier_tab4 = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(1, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(802, 450);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tabPage1.Controls.Add(this.btnShowSuppliers);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.btnShowProducts);
            this.tabPage1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(794, 420);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "基本資料";
            // 
            // btnShowSuppliers
            // 
            this.btnShowSuppliers.Location = new System.Drawing.Point(250, 26);
            this.btnShowSuppliers.Name = "btnShowSuppliers";
            this.btnShowSuppliers.Size = new System.Drawing.Size(130, 35);
            this.btnShowSuppliers.TabIndex = 2;
            this.btnShowSuppliers.Text = "btnShowSuppliers";
            this.btnShowSuppliers.UseVisualStyleBackColor = true;
            this.btnShowSuppliers.Click += new System.EventHandler(this.btnShowSuppliers_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(51, 76);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(688, 313);
            this.dataGridView1.TabIndex = 1;
            // 
            // btnShowProducts
            // 
            this.btnShowProducts.Location = new System.Drawing.Point(386, 26);
            this.btnShowProducts.Name = "btnShowProducts";
            this.btnShowProducts.Size = new System.Drawing.Size(130, 35);
            this.btnShowProducts.TabIndex = 0;
            this.btnShowProducts.Text = "btnShowProducts";
            this.btnShowProducts.UseVisualStyleBackColor = true;
            this.btnShowProducts.Click += new System.EventHandler(this.btnShowProducts_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.LavenderBlush;
            this.tabPage2.Controls.Add(this.comb);
            this.tabPage2.Controls.Add(this.shaver);
            this.tabPage2.Controls.Add(this.shampoo);
            this.tabPage2.Controls.Add(this.toothpaste);
            this.tabPage2.Controls.Add(this.toothbrush);
            this.tabPage2.Controls.Add(this.supplierE);
            this.tabPage2.Controls.Add(this.supplierD);
            this.tabPage2.Controls.Add(this.supplierC);
            this.tabPage2.Controls.Add(this.supplierB);
            this.tabPage2.Controls.Add(this.supplierA);
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(794, 420);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "庫存";
            // 
            // comb
            // 
            this.comb.AutoSize = true;
            this.comb.Location = new System.Drawing.Point(530, 42);
            this.comb.Name = "comb";
            this.comb.Size = new System.Drawing.Size(62, 21);
            this.comb.TabIndex = 10;
            this.comb.Text = "comb";
            this.comb.UseVisualStyleBackColor = true;
            this.comb.CheckedChanged += new System.EventHandler(this.comb_CheckedChanged);
            // 
            // shaver
            // 
            this.shaver.AutoSize = true;
            this.shaver.Location = new System.Drawing.Point(457, 42);
            this.shaver.Name = "shaver";
            this.shaver.Size = new System.Drawing.Size(67, 21);
            this.shaver.TabIndex = 9;
            this.shaver.Text = "shaver";
            this.shaver.UseVisualStyleBackColor = true;
            this.shaver.CheckedChanged += new System.EventHandler(this.shaver_CheckedChanged);
            // 
            // shampoo
            // 
            this.shampoo.AutoSize = true;
            this.shampoo.Location = new System.Drawing.Point(367, 42);
            this.shampoo.Name = "shampoo";
            this.shampoo.Size = new System.Drawing.Size(84, 21);
            this.shampoo.TabIndex = 8;
            this.shampoo.Text = "shampoo";
            this.shampoo.UseVisualStyleBackColor = true;
            this.shampoo.CheckedChanged += new System.EventHandler(this.shampoo_CheckedChanged);
            // 
            // toothpaste
            // 
            this.toothpaste.AutoSize = true;
            this.toothpaste.Location = new System.Drawing.Point(267, 42);
            this.toothpaste.Name = "toothpaste";
            this.toothpaste.Size = new System.Drawing.Size(94, 21);
            this.toothpaste.TabIndex = 7;
            this.toothpaste.Text = "toothpaste";
            this.toothpaste.UseVisualStyleBackColor = true;
            this.toothpaste.CheckedChanged += new System.EventHandler(this.toothpaste_CheckedChanged);
            // 
            // toothbrush
            // 
            this.toothbrush.AutoSize = true;
            this.toothbrush.Location = new System.Drawing.Point(165, 42);
            this.toothbrush.Name = "toothbrush";
            this.toothbrush.Size = new System.Drawing.Size(96, 21);
            this.toothbrush.TabIndex = 6;
            this.toothbrush.Text = "toothbrush";
            this.toothbrush.UseVisualStyleBackColor = true;
            this.toothbrush.CheckedChanged += new System.EventHandler(this.toothbrush_CheckedChanged);
            // 
            // supplierE
            // 
            this.supplierE.AutoSize = true;
            this.supplierE.Location = new System.Drawing.Point(504, 15);
            this.supplierE.Name = "supplierE";
            this.supplierE.Size = new System.Drawing.Size(73, 21);
            this.supplierE.TabIndex = 5;
            this.supplierE.Text = "供應商E";
            this.supplierE.UseVisualStyleBackColor = true;
            this.supplierE.CheckedChanged += new System.EventHandler(this.supplierE_CheckedChanged);
            // 
            // supplierD
            // 
            this.supplierD.AutoSize = true;
            this.supplierD.Location = new System.Drawing.Point(429, 15);
            this.supplierD.Name = "supplierD";
            this.supplierD.Size = new System.Drawing.Size(76, 21);
            this.supplierD.TabIndex = 4;
            this.supplierD.Text = "供應商D";
            this.supplierD.UseVisualStyleBackColor = true;
            this.supplierD.CheckedChanged += new System.EventHandler(this.supplierD_CheckedChanged);
            // 
            // supplierC
            // 
            this.supplierC.AutoSize = true;
            this.supplierC.Location = new System.Drawing.Point(348, 15);
            this.supplierC.Name = "supplierC";
            this.supplierC.Size = new System.Drawing.Size(75, 21);
            this.supplierC.TabIndex = 3;
            this.supplierC.Text = "供應商C";
            this.supplierC.UseVisualStyleBackColor = true;
            this.supplierC.CheckedChanged += new System.EventHandler(this.supplierC_CheckedChanged);
            // 
            // supplierB
            // 
            this.supplierB.AutoSize = true;
            this.supplierB.Location = new System.Drawing.Point(267, 15);
            this.supplierB.Name = "supplierB";
            this.supplierB.Size = new System.Drawing.Size(74, 21);
            this.supplierB.TabIndex = 2;
            this.supplierB.Text = "供應商B";
            this.supplierB.UseVisualStyleBackColor = true;
            this.supplierB.CheckedChanged += new System.EventHandler(this.supplierB_CheckedChanged);
            // 
            // supplierA
            // 
            this.supplierA.AutoSize = true;
            this.supplierA.Location = new System.Drawing.Point(186, 15);
            this.supplierA.Name = "supplierA";
            this.supplierA.Size = new System.Drawing.Size(75, 21);
            this.supplierA.TabIndex = 1;
            this.supplierA.Text = "供應商A";
            this.supplierA.UseVisualStyleBackColor = true;
            this.supplierA.CheckedChanged += new System.EventHandler(this.supplierA_CheckedChanged);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(7, 69);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(776, 350);
            this.dataGridView2.TabIndex = 0;
            this.dataGridView2.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView_DataBindingComplete);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.Ivory;
            this.tabPage3.Controls.Add(this.dataGridView3);
            this.tabPage3.Controls.Add(this.SearchButton);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.comboBoxTransactionType);
            this.tabPage3.Controls.Add(this.dateTimePickerEnd);
            this.tabPage3.Controls.Add(this.dateTimePickerStart);
            this.tabPage3.Controls.Add(this.comboBoxProduct_tab3);
            this.tabPage3.Controls.Add(this.comboBoxSupplier_tab3);
            this.tabPage3.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(794, 420);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "交易紀錄";
            // 
            // dataGridView3
            // 
            this.dataGridView3.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(7, 111);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowTemplate.Height = 24;
            this.dataGridView3.Size = new System.Drawing.Size(776, 301);
            this.dataGridView3.TabIndex = 11;
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(548, 75);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(73, 25);
            this.SearchButton.TabIndex = 10;
            this.SearchButton.Text = "查詢";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(551, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "交易類型: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(332, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "選擇產品: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(95, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "選擇供應商: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(353, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "~";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(154, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "日期區間:";
            // 
            // comboBoxTransactionType
            // 
            this.comboBoxTransactionType.FormattingEnabled = true;
            this.comboBoxTransactionType.Items.AddRange(new object[] {
            "全部",
            "IN",
            "OUT"});
            this.comboBoxTransactionType.Location = new System.Drawing.Point(623, 35);
            this.comboBoxTransactionType.Name = "comboBoxTransactionType";
            this.comboBoxTransactionType.Size = new System.Drawing.Size(54, 25);
            this.comboBoxTransactionType.TabIndex = 4;
            this.comboBoxTransactionType.Text = "全部";
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Location = new System.Drawing.Point(376, 75);
            this.dateTimePickerEnd.MaxDate = new System.DateTime(2025, 5, 31, 0, 0, 0, 0);
            this.dateTimePickerEnd.MinDate = new System.DateTime(2024, 12, 1, 0, 0, 0, 0);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(124, 25);
            this.dateTimePickerEnd.TabIndex = 3;
            this.dateTimePickerEnd.Value = new System.DateTime(2025, 5, 29, 0, 0, 0, 0);
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Location = new System.Drawing.Point(223, 75);
            this.dateTimePickerStart.MaxDate = new System.DateTime(2025, 5, 29, 0, 0, 0, 0);
            this.dateTimePickerStart.MinDate = new System.DateTime(2024, 12, 1, 0, 0, 0, 0);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(124, 25);
            this.dateTimePickerStart.TabIndex = 2;
            this.dateTimePickerStart.Value = new System.DateTime(2025, 5, 29, 0, 0, 0, 0);
            // 
            // comboBoxProduct_tab3
            // 
            this.comboBoxProduct_tab3.FormattingEnabled = true;
            this.comboBoxProduct_tab3.Location = new System.Drawing.Point(404, 35);
            this.comboBoxProduct_tab3.Name = "comboBoxProduct_tab3";
            this.comboBoxProduct_tab3.Size = new System.Drawing.Size(124, 25);
            this.comboBoxProduct_tab3.TabIndex = 1;
            this.comboBoxProduct_tab3.Text = "全部";
            this.comboBoxProduct_tab3.SelectedIndexChanged += new System.EventHandler(this.comboBoxProduct_SelectedIndexChanged);
            // 
            // comboBoxSupplier_tab3
            // 
            this.comboBoxSupplier_tab3.FormattingEnabled = true;
            this.comboBoxSupplier_tab3.Location = new System.Drawing.Point(180, 35);
            this.comboBoxSupplier_tab3.Name = "comboBoxSupplier_tab3";
            this.comboBoxSupplier_tab3.Size = new System.Drawing.Size(124, 25);
            this.comboBoxSupplier_tab3.TabIndex = 0;
            this.comboBoxSupplier_tab3.Text = "全部";
            this.comboBoxSupplier_tab3.SelectedIndexChanged += new System.EventHandler(this.comboBoxSupplier_SelectedIndexChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.AliceBlue;
            this.tabPage4.Controls.Add(this.panel1);
            this.tabPage4.Controls.Add(this.submitButton);
            this.tabPage4.Controls.Add(this.label10);
            this.tabPage4.Controls.Add(this.dateTimePicker_trans);
            this.tabPage4.Controls.Add(this.textBoxQuantity);
            this.tabPage4.Controls.Add(this.label9);
            this.tabPage4.Controls.Add(this.label8);
            this.tabPage4.Controls.Add(this.comboBoxType_tab4);
            this.tabPage4.Controls.Add(this.label7);
            this.tabPage4.Controls.Add(this.comboBoxProduct_tab4);
            this.tabPage4.Controls.Add(this.label6);
            this.tabPage4.Controls.Add(this.comboBoxSupplier_tab4);
            this.tabPage4.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage4.Location = new System.Drawing.Point(4, 26);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(794, 420);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "新增交易";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelAfterStock);
            this.panel1.Controls.Add(this.labelCurrentStock);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Location = new System.Drawing.Point(276, 215);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(274, 38);
            this.panel1.TabIndex = 11;
            // 
            // labelAfterStock
            // 
            this.labelAfterStock.AutoSize = true;
            this.labelAfterStock.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelAfterStock.Location = new System.Drawing.Point(131, 9);
            this.labelAfterStock.Name = "labelAfterStock";
            this.labelAfterStock.Size = new System.Drawing.Size(18, 21);
            this.labelAfterStock.TabIndex = 12;
            this.labelAfterStock.Text = "  ";
            // 
            // labelCurrentStock
            // 
            this.labelCurrentStock.AutoSize = true;
            this.labelCurrentStock.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelCurrentStock.Location = new System.Drawing.Point(3, 9);
            this.labelCurrentStock.Name = "labelCurrentStock";
            this.labelCurrentStock.Size = new System.Drawing.Size(18, 21);
            this.labelCurrentStock.TabIndex = 3;
            this.labelCurrentStock.Text = "  ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(86, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(0, 17);
            this.label12.TabIndex = 1;
            // 
            // submitButton
            // 
            this.submitButton.BackColor = System.Drawing.Color.MidnightBlue;
            this.submitButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.submitButton.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.submitButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.submitButton.Location = new System.Drawing.Point(261, 325);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(289, 31);
            this.submitButton.TabIndex = 10;
            this.submitButton.Text = "送出";
            this.submitButton.UseVisualStyleBackColor = false;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label10.Location = new System.Drawing.Point(287, 274);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 19);
            this.label10.TabIndex = 9;
            this.label10.Text = "日期: ";
            // 
            // dateTimePicker_trans
            // 
            this.dateTimePicker_trans.Location = new System.Drawing.Point(340, 270);
            this.dateTimePicker_trans.Name = "dateTimePicker_trans";
            this.dateTimePicker_trans.Size = new System.Drawing.Size(210, 25);
            this.dateTimePicker_trans.TabIndex = 8;
            // 
            // textBoxQuantity
            // 
            this.textBoxQuantity.Location = new System.Drawing.Point(340, 175);
            this.textBoxQuantity.Name = "textBoxQuantity";
            this.textBoxQuantity.Size = new System.Drawing.Size(210, 25);
            this.textBoxQuantity.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label9.Location = new System.Drawing.Point(287, 176);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 19);
            this.label9.TabIndex = 6;
            this.label9.Text = "數量: ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(257, 135);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 19);
            this.label8.TabIndex = 5;
            this.label8.Text = "交易類型: ";
            // 
            // comboBoxType_tab4
            // 
            this.comboBoxType_tab4.FormattingEnabled = true;
            this.comboBoxType_tab4.Items.AddRange(new object[] {
            "全部",
            "IN",
            "OUT"});
            this.comboBoxType_tab4.Location = new System.Drawing.Point(340, 134);
            this.comboBoxType_tab4.Name = "comboBoxType_tab4";
            this.comboBoxType_tab4.Size = new System.Drawing.Size(210, 25);
            this.comboBoxType_tab4.TabIndex = 4;
            this.comboBoxType_tab4.Text = "全部";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(287, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 19);
            this.label7.TabIndex = 3;
            this.label7.Text = "產品: ";
            // 
            // comboBoxProduct_tab4
            // 
            this.comboBoxProduct_tab4.FormattingEnabled = true;
            this.comboBoxProduct_tab4.Location = new System.Drawing.Point(340, 93);
            this.comboBoxProduct_tab4.Name = "comboBoxProduct_tab4";
            this.comboBoxProduct_tab4.Size = new System.Drawing.Size(210, 25);
            this.comboBoxProduct_tab4.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(272, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 19);
            this.label6.TabIndex = 1;
            this.label6.Text = "供應商: ";
            // 
            // comboBoxSupplier_tab4
            // 
            this.comboBoxSupplier_tab4.FormattingEnabled = true;
            this.comboBoxSupplier_tab4.Location = new System.Drawing.Point(340, 52);
            this.comboBoxSupplier_tab4.Name = "comboBoxSupplier_tab4";
            this.comboBoxSupplier_tab4.Size = new System.Drawing.Size(210, 25);
            this.comboBoxSupplier_tab4.TabIndex = 0;
            // 
            // factory_inventory_system
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "factory_inventory_system";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button btnShowSuppliers;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnShowProducts;
        private System.Windows.Forms.CheckBox supplierA;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.CheckBox toothbrush;
        private System.Windows.Forms.CheckBox supplierE;
        private System.Windows.Forms.CheckBox supplierD;
        private System.Windows.Forms.CheckBox supplierC;
        private System.Windows.Forms.CheckBox supplierB;
        private System.Windows.Forms.CheckBox shampoo;
        private System.Windows.Forms.CheckBox toothpaste;
        private System.Windows.Forms.CheckBox comb;
        private System.Windows.Forms.CheckBox shaver;
        private System.Windows.Forms.ComboBox comboBoxSupplier_tab3;
        private System.Windows.Forms.ComboBox comboBoxProduct_tab3;
        private System.Windows.Forms.ComboBox comboBoxTransactionType;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.TextBox textBoxQuantity;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxType_tab4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxProduct_tab4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxSupplier_tab4;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dateTimePicker_trans;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label labelAfterStock;
        private System.Windows.Forms.Label labelCurrentStock;
    }
}


namespace Практика_Нечеухин
{
    partial class UserForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.textBoxFilter = new System.Windows.Forms.TextBox();
            this.panelExit = new System.Windows.Forms.Panel();
            this.btnCreateRequest = new System.Windows.Forms.Button();
            this.btnAppRequest = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Bear = new System.Windows.Forms.Panel();
            this.panelMainMenu = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panelAppRequest = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnSaveData = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.panelCreateRequest = new System.Windows.Forms.Panel();
            this.comboBoxTechType = new System.Windows.Forms.ComboBox();
            this.textBoxDescriptionProblems = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.textBoxHomeTechModel = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.btn_review = new System.Windows.Forms.Button();
            this.panelReview = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelMainMenu.SuspendLayout();
            this.panelAppRequest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelCreateRequest.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.textBoxFilter);
            this.panel1.Controls.Add(this.panelExit);
            this.panel1.Controls.Add(this.btnCreateRequest);
            this.panel1.Controls.Add(this.btnAppRequest);
            this.panel1.Location = new System.Drawing.Point(1, -3);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2208, 176);
            this.panel1.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSearch.Location = new System.Drawing.Point(1258, 36);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(296, 79);
            this.btnSearch.TabIndex = 14;
            this.btnSearch.Text = "Поиск";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // textBoxFilter
            // 
            this.textBoxFilter.Location = new System.Drawing.Point(1570, 54);
            this.textBoxFilter.Multiline = true;
            this.textBoxFilter.Name = "textBoxFilter";
            this.textBoxFilter.Size = new System.Drawing.Size(424, 61);
            this.textBoxFilter.TabIndex = 13;
            // 
            // panelExit
            // 
            this.panelExit.AutoSize = true;
            this.panelExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelExit.BackgroundImage")));
            this.panelExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelExit.Location = new System.Drawing.Point(2013, 36);
            this.panelExit.Margin = new System.Windows.Forms.Padding(4);
            this.panelExit.Name = "panelExit";
            this.panelExit.Size = new System.Drawing.Size(159, 108);
            this.panelExit.TabIndex = 10;
            this.panelExit.Click += new System.EventHandler(this.panelExit_Click);
            // 
            // btnCreateRequest
            // 
            this.btnCreateRequest.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnCreateRequest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreateRequest.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCreateRequest.Location = new System.Drawing.Point(805, 36);
            this.btnCreateRequest.Margin = new System.Windows.Forms.Padding(4);
            this.btnCreateRequest.Name = "btnCreateRequest";
            this.btnCreateRequest.Size = new System.Drawing.Size(445, 79);
            this.btnCreateRequest.TabIndex = 5;
            this.btnCreateRequest.Text = "Создать заявку";
            this.btnCreateRequest.UseVisualStyleBackColor = false;
            this.btnCreateRequest.Click += new System.EventHandler(this.btnCreateRequest_Click);
            // 
            // btnAppRequest
            // 
            this.btnAppRequest.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnAppRequest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAppRequest.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAppRequest.Location = new System.Drawing.Point(352, 36);
            this.btnAppRequest.Margin = new System.Windows.Forms.Padding(4);
            this.btnAppRequest.Name = "btnAppRequest";
            this.btnAppRequest.Size = new System.Drawing.Size(445, 79);
            this.btnAppRequest.TabIndex = 4;
            this.btnAppRequest.Text = "Списки заявки";
            this.btnAppRequest.UseVisualStyleBackColor = false;
            this.btnAppRequest.Click += new System.EventHandler(this.btnAppRequest_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(53, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(327, 51);
            this.label1.TabIndex = 4;
            this.label1.Text = "Наши мастера:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panelReview);
            this.panel2.Controls.Add(this.btn_review);
            this.panel2.Controls.Add(this.Bear);
            this.panel2.Location = new System.Drawing.Point(1, -3);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(340, 1109);
            this.panel2.TabIndex = 6;
            // 
            // Bear
            // 
            this.Bear.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Bear.BackgroundImage")));
            this.Bear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Bear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Bear.Location = new System.Drawing.Point(60, 15);
            this.Bear.Margin = new System.Windows.Forms.Padding(4);
            this.Bear.Name = "Bear";
            this.Bear.Size = new System.Drawing.Size(210, 181);
            this.Bear.TabIndex = 8;
            this.Bear.Click += new System.EventHandler(this.Bear_Click);
            // 
            // panelMainMenu
            // 
            this.panelMainMenu.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panelMainMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMainMenu.Controls.Add(this.panel6);
            this.panelMainMenu.Controls.Add(this.panel5);
            this.panelMainMenu.Controls.Add(this.panel4);
            this.panelMainMenu.Controls.Add(this.label8);
            this.panelMainMenu.Controls.Add(this.label7);
            this.panelMainMenu.Controls.Add(this.label6);
            this.panelMainMenu.Controls.Add(this.label5);
            this.panelMainMenu.Controls.Add(this.label2);
            this.panelMainMenu.Controls.Add(this.label1);
            this.panelMainMenu.Location = new System.Drawing.Point(341, 173);
            this.panelMainMenu.Margin = new System.Windows.Forms.Padding(4);
            this.panelMainMenu.Name = "panelMainMenu";
            this.panelMainMenu.Size = new System.Drawing.Size(1868, 933);
            this.panelMainMenu.TabIndex = 7;
            // 
            // panel6
            // 
            this.panel6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel6.BackgroundImage")));
            this.panel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel6.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.panel6.Location = new System.Drawing.Point(1292, 97);
            this.panel6.Margin = new System.Windows.Forms.Padding(4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(540, 324);
            this.panel6.TabIndex = 9;
            // 
            // panel5
            // 
            this.panel5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel5.BackgroundImage")));
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel5.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.panel5.Location = new System.Drawing.Point(704, 93);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(544, 328);
            this.panel5.TabIndex = 9;
            // 
            // panel4
            // 
            this.panel4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel4.BackgroundImage")));
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel4.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.panel4.Location = new System.Drawing.Point(62, 93);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(567, 328);
            this.panel4.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(24, 832);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(836, 51);
            this.label8.TabIndex = 9;
            this.label8.Text = "- Беремся за ремонты любой сложности";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(24, 746);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(585, 51);
            this.label7.TabIndex = 8;
            this.label7.Text = "- Быстро выполняем заявки";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(24, 670);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(209, 51);
            this.label6.TabIndex = 7;
            this.label6.Text = "- Дешево";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(24, 593);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(754, 51);
            this.label5.TabIndex = 6;
            this.label5.Text = "- Мы сделаем качественный ремонт";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(24, 520);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(444, 51);
            this.label2.TabIndex = 5;
            this.label2.Text = "Почему именно нас?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(33, 1128);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(353, 42);
            this.label3.TabIndex = 8;
            this.label3.Text = "ПН-ПТ: 6:00 - 24:00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(1767, 1146);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(229, 42);
            this.label4.TabIndex = 9;
            this.label4.Text = "+796564334";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(1767, 1209);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(407, 42);
            this.label9.TabIndex = 10;
            this.label9.Text = "Все права защищены ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(33, 1209);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(289, 42);
            this.label10.TabIndex = 11;
            this.label10.Text = "ВС: 7:00 - 23:00";
            // 
            // panelAppRequest
            // 
            this.panelAppRequest.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panelAppRequest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAppRequest.Controls.Add(this.dataGridView1);
            this.panelAppRequest.Controls.Add(this.btnSaveData);
            this.panelAppRequest.Controls.Add(this.label12);
            this.panelAppRequest.Location = new System.Drawing.Point(339, 174);
            this.panelAppRequest.Margin = new System.Windows.Forms.Padding(4);
            this.panelAppRequest.Name = "panelAppRequest";
            this.panelAppRequest.Size = new System.Drawing.Size(1870, 933);
            this.panelAppRequest.TabIndex = 12;
            this.panelAppRequest.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(102, 184);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(1633, 512);
            this.dataGridView1.TabIndex = 6;
            // 
            // btnSaveData
            // 
            this.btnSaveData.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnSaveData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveData.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSaveData.Location = new System.Drawing.Point(1364, 714);
            this.btnSaveData.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveData.Name = "btnSaveData";
            this.btnSaveData.Size = new System.Drawing.Size(448, 173);
            this.btnSaveData.TabIndex = 5;
            this.btnSaveData.Text = "Сохранить заявку";
            this.btnSaveData.UseVisualStyleBackColor = false;
            this.btnSaveData.Click += new System.EventHandler(this.btnSaveData_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(53, 17);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(330, 51);
            this.label12.TabIndex = 4;
            this.label12.Text = "Список заявок:";
            // 
            // panelCreateRequest
            // 
            this.panelCreateRequest.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panelCreateRequest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCreateRequest.Controls.Add(this.comboBoxTechType);
            this.panelCreateRequest.Controls.Add(this.textBoxDescriptionProblems);
            this.panelCreateRequest.Controls.Add(this.label13);
            this.panelCreateRequest.Controls.Add(this.label14);
            this.panelCreateRequest.Controls.Add(this.label15);
            this.panelCreateRequest.Controls.Add(this.textBoxHomeTechModel);
            this.panelCreateRequest.Controls.Add(this.btnSave);
            this.panelCreateRequest.Controls.Add(this.label16);
            this.panelCreateRequest.Location = new System.Drawing.Point(340, 173);
            this.panelCreateRequest.Margin = new System.Windows.Forms.Padding(4);
            this.panelCreateRequest.Name = "panelCreateRequest";
            this.panelCreateRequest.Size = new System.Drawing.Size(1868, 933);
            this.panelCreateRequest.TabIndex = 13;
            this.panelCreateRequest.Visible = false;
            // 
            // comboBoxTechType
            // 
            this.comboBoxTechType.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxTechType.FormattingEnabled = true;
            this.comboBoxTechType.Items.AddRange(new object[] {
            "Фен",
            "Тостер",
            "Холодельник",
            "Стиральная машина",
            "Мультиварка"});
            this.comboBoxTechType.Location = new System.Drawing.Point(554, 134);
            this.comboBoxTechType.Name = "comboBoxTechType";
            this.comboBoxTechType.Size = new System.Drawing.Size(1071, 50);
            this.comboBoxTechType.TabIndex = 12;
            // 
            // textBoxDescriptionProblems
            // 
            this.textBoxDescriptionProblems.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxDescriptionProblems.Location = new System.Drawing.Point(554, 383);
            this.textBoxDescriptionProblems.Multiline = true;
            this.textBoxDescriptionProblems.Name = "textBoxDescriptionProblems";
            this.textBoxDescriptionProblems.Size = new System.Drawing.Size(1071, 301);
            this.textBoxDescriptionProblems.TabIndex = 11;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(4, 633);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(452, 51);
            this.label13.TabIndex = 10;
            this.label13.Text = "Описание проблемы:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.Location = new System.Drawing.Point(4, 246);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(543, 51);
            this.label14.TabIndex = 9;
            this.label14.Text = "Модель бытовой техники:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.Location = new System.Drawing.Point(4, 125);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(465, 51);
            this.label15.TabIndex = 8;
            this.label15.Text = "Вид бытовой техники:";
            // 
            // textBoxHomeTechModel
            // 
            this.textBoxHomeTechModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxHomeTechModel.Location = new System.Drawing.Point(554, 246);
            this.textBoxHomeTechModel.Multiline = true;
            this.textBoxHomeTechModel.Name = "textBoxHomeTechModel";
            this.textBoxHomeTechModel.Size = new System.Drawing.Size(1071, 60);
            this.textBoxHomeTechModel.TabIndex = 6;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSave.Location = new System.Drawing.Point(1364, 714);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(448, 173);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Сохранить заявку";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.Location = new System.Drawing.Point(53, 17);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(349, 51);
            this.label16.TabIndex = 4;
            this.label16.Text = "Создать заявку:";
            // 
            // btn_review
            // 
            this.btn_review.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btn_review.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_review.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_review.Location = new System.Drawing.Point(50, 230);
            this.btn_review.Margin = new System.Windows.Forms.Padding(4);
            this.btn_review.Name = "btn_review";
            this.btn_review.Size = new System.Drawing.Size(220, 74);
            this.btn_review.TabIndex = 9;
            this.btn_review.Text = "Отзыв";
            this.btn_review.UseVisualStyleBackColor = false;
            this.btn_review.Click += new System.EventHandler(this.btn_review_Click);
            // 
            // panelReview
            // 
            this.panelReview.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelReview.BackgroundImage")));
            this.panelReview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelReview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelReview.Location = new System.Drawing.Point(38, 329);
            this.panelReview.Margin = new System.Windows.Forms.Padding(4);
            this.panelReview.Name = "panelReview";
            this.panelReview.Size = new System.Drawing.Size(260, 277);
            this.panelReview.TabIndex = 9;
            this.panelReview.Visible = false;
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(230)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(2204, 1309);
            this.Controls.Add(this.panelCreateRequest);
            this.Controls.Add(this.panelAppRequest);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panelMainMenu);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "UserForm";
            this.Text = "Пользователь";
            this.Load += new System.EventHandler(this.UserForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panelMainMenu.ResumeLayout(false);
            this.panelMainMenu.PerformLayout();
            this.panelAppRequest.ResumeLayout(false);
            this.panelAppRequest.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelCreateRequest.ResumeLayout(false);
            this.panelCreateRequest.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCreateRequest;
        private System.Windows.Forms.Button btnAppRequest;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelMainMenu;
        private System.Windows.Forms.Panel Bear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panelExit;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox textBoxFilter;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panelAppRequest;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnSaveData;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panelCreateRequest;
        private System.Windows.Forms.TextBox textBoxDescriptionProblems;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBoxHomeTechModel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox comboBoxTechType;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel panelReview;
        private System.Windows.Forms.Button btn_review;
    }
}
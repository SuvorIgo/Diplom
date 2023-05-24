namespace Diplom.Manager
{
    partial class ManagerMainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManagerMainForm));
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.orderIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tonnageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameCompanyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberPhoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pointDepartureDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pointReceptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usersDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ordersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(421, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 42);
            this.label4.TabIndex = 11;
            this.label4.Text = "Заявки";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Brown;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(1189, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(168, 64);
            this.button1.TabIndex = 10;
            this.button1.Text = "Выйти";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(272, 193);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.orderIdDataGridViewTextBoxColumn,
            this.tonnageDataGridViewTextBoxColumn,
            this.nameCompanyDataGridViewTextBoxColumn,
            this.numberPhoneDataGridViewTextBoxColumn,
            this.pointDepartureDataGridViewTextBoxColumn,
            this.pointReceptionDataGridViewTextBoxColumn,
            this.usersDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.ordersBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 210);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(690, 252);
            this.dataGridView1.TabIndex = 12;
            // 
            // orderIdDataGridViewTextBoxColumn
            // 
            this.orderIdDataGridViewTextBoxColumn.DataPropertyName = "OrderId";
            this.orderIdDataGridViewTextBoxColumn.HeaderText = "OrderId";
            this.orderIdDataGridViewTextBoxColumn.Name = "orderIdDataGridViewTextBoxColumn";
            // 
            // tonnageDataGridViewTextBoxColumn
            // 
            this.tonnageDataGridViewTextBoxColumn.DataPropertyName = "Tonnage";
            this.tonnageDataGridViewTextBoxColumn.HeaderText = "Tonnage";
            this.tonnageDataGridViewTextBoxColumn.Name = "tonnageDataGridViewTextBoxColumn";
            // 
            // nameCompanyDataGridViewTextBoxColumn
            // 
            this.nameCompanyDataGridViewTextBoxColumn.DataPropertyName = "NameCompany";
            this.nameCompanyDataGridViewTextBoxColumn.HeaderText = "NameCompany";
            this.nameCompanyDataGridViewTextBoxColumn.Name = "nameCompanyDataGridViewTextBoxColumn";
            // 
            // numberPhoneDataGridViewTextBoxColumn
            // 
            this.numberPhoneDataGridViewTextBoxColumn.DataPropertyName = "NumberPhone";
            this.numberPhoneDataGridViewTextBoxColumn.HeaderText = "NumberPhone";
            this.numberPhoneDataGridViewTextBoxColumn.Name = "numberPhoneDataGridViewTextBoxColumn";
            // 
            // pointDepartureDataGridViewTextBoxColumn
            // 
            this.pointDepartureDataGridViewTextBoxColumn.DataPropertyName = "PointDeparture";
            this.pointDepartureDataGridViewTextBoxColumn.HeaderText = "PointDeparture";
            this.pointDepartureDataGridViewTextBoxColumn.Name = "pointDepartureDataGridViewTextBoxColumn";
            // 
            // pointReceptionDataGridViewTextBoxColumn
            // 
            this.pointReceptionDataGridViewTextBoxColumn.DataPropertyName = "PointReception";
            this.pointReceptionDataGridViewTextBoxColumn.HeaderText = "PointReception";
            this.pointReceptionDataGridViewTextBoxColumn.Name = "pointReceptionDataGridViewTextBoxColumn";
            // 
            // usersDataGridViewTextBoxColumn
            // 
            this.usersDataGridViewTextBoxColumn.DataPropertyName = "Users";
            this.usersDataGridViewTextBoxColumn.HeaderText = "Users";
            this.usersDataGridViewTextBoxColumn.Name = "usersDataGridViewTextBoxColumn";
            // 
            // ordersBindingSource
            // 
            this.ordersBindingSource.DataSource = typeof(Diplom.libs.db.entities.Orders);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Brown;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(708, 440);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(650, 64);
            this.button2.TabIndex = 13;
            this.button2.Text = "Обработать заявки";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1074, 268);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textBox1.Size = new System.Drawing.Size(244, 152);
            this.textBox1.TabIndex = 14;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(798, 95);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 25;
            this.dataGridView2.Size = new System.Drawing.Size(520, 152);
            this.dataGridView2.TabIndex = 15;
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(798, 268);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowTemplate.Height = 25;
            this.dataGridView3.Size = new System.Drawing.Size(260, 152);
            this.dataGridView3.TabIndex = 16;
            // 
            // ManagerMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 607);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ManagerMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ManagerMainForm";
            this.Load += new System.EventHandler(this.ManagerMainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label4;
        private Button button1;
        private PictureBox pictureBox1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn orderIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn tonnageDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameCompanyDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn numberPhoneDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn pointDepartureDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn pointReceptionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn usersDataGridViewTextBoxColumn;
        private Button button2;
        private TextBox textBox1;
        private DataGridView dataGridView2;
        private BindingSource ordersBindingSource;
        private DataGridView dataGridView3;
    }
}
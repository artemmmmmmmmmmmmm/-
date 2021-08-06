namespace Інформаційна_система_з_технічного_обліку
{
    partial class Form2
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button3 = new System.Windows.Forms.Button();
            this.віфівToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.переглядТехнікиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.технікаЯкаСтоїтьНаОбілкуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.постановаНаОбілкToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.зняттяЗОблікуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.проПрограмуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.проАвтораToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(0, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1517, 591);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Журнал Техніки";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.Location = new System.Drawing.Point(3, 25);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1511, 563);
            this.dataGridView1.TabIndex = 17;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "№Запису";
            this.Column1.Name = "Column1";
            this.Column1.Width = 110;
            // 
            // Column2
            // 
            this.Column2.Frozen = true;
            this.Column2.HeaderText = "Дата оренди";
            this.Column2.Name = "Column2";
            this.Column2.Width = 147;
            // 
            // Column3
            // 
            this.Column3.Frozen = true;
            this.Column3.HeaderText = "Ідентифікаційний номер техніки";
            this.Column3.Name = "Column3";
            this.Column3.Width = 200;
            // 
            // Column4
            // 
            this.Column4.Frozen = true;
            this.Column4.HeaderText = "Назва";
            this.Column4.Name = "Column4";
            this.Column4.Width = 148;
            // 
            // Column5
            // 
            this.Column5.Frozen = true;
            this.Column5.HeaderText = "Модель";
            this.Column5.Name = "Column5";
            this.Column5.Width = 97;
            // 
            // Column6
            // 
            this.Column6.Frozen = true;
            this.Column6.HeaderText = "Кафедра";
            this.Column6.Name = "Column6";
            this.Column6.Width = 240;
            // 
            // Column7
            // 
            this.Column7.Frozen = true;
            this.Column7.HeaderText = "Факультет";
            this.Column7.Name = "Column7";
            this.Column7.Width = 240;
            // 
            // Column8
            // 
            this.Column8.Frozen = true;
            this.Column8.HeaderText = "Джерело";
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.FillWeight = 120F;
            this.Column9.Frozen = true;
            this.Column9.HeaderText = "Відповідальний";
            this.Column9.Name = "Column9";
            this.Column9.Width = 150;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(1317, 627);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(188, 44);
            this.button3.TabIndex = 16;
            this.button3.Text = "Назад";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // віфівToolStripMenuItem
            // 
            this.віфівToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.переглядТехнікиToolStripMenuItem,
            this.постановаНаОбілкToolStripMenuItem,
            this.зняттяЗОблікуToolStripMenuItem});
            this.віфівToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.віфівToolStripMenuItem.Name = "віфівToolStripMenuItem";
            this.віфівToolStripMenuItem.Size = new System.Drawing.Size(71, 26);
            this.віфівToolStripMenuItem.Text = "Облік";
            this.віфівToolStripMenuItem.Click += new System.EventHandler(this.ОблікToolStripMenuItem_Click);
            // 
            // переглядТехнікиToolStripMenuItem
            // 
            this.переглядТехнікиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.технікаЯкаСтоїтьНаОбілкуToolStripMenuItem});
            this.переглядТехнікиToolStripMenuItem.Name = "переглядТехнікиToolStripMenuItem";
            this.переглядТехнікиToolStripMenuItem.Size = new System.Drawing.Size(284, 26);
            this.переглядТехнікиToolStripMenuItem.Text = "Перегляд Техніки";
            // 
            // технікаЯкаСтоїтьНаОбілкуToolStripMenuItem
            // 
            this.технікаЯкаСтоїтьНаОбілкуToolStripMenuItem.Name = "технікаЯкаСтоїтьНаОбілкуToolStripMenuItem";
            this.технікаЯкаСтоїтьНаОбілкуToolStripMenuItem.Size = new System.Drawing.Size(250, 26);
            this.технікаЯкаСтоїтьНаОбілкуToolStripMenuItem.Text = "Журнал обладнання";
            this.технікаЯкаСтоїтьНаОбілкуToolStripMenuItem.Click += new System.EventHandler(this.технікаЯкаСтоїтьНаОбілкуToolStripMenuItem_Click);
            // 
            // постановаНаОбілкToolStripMenuItem
            // 
            this.постановаНаОбілкToolStripMenuItem.Name = "постановаНаОбілкToolStripMenuItem";
            this.постановаНаОбілкToolStripMenuItem.Size = new System.Drawing.Size(284, 26);
            this.постановаНаОбілкToolStripMenuItem.Text = "Внесення нової техніки";
            this.постановаНаОбілкToolStripMenuItem.Click += new System.EventHandler(this.постановаНаОбілкToolStripMenuItem_Click);
            // 
            // зняттяЗОблікуToolStripMenuItem
            // 
            this.зняттяЗОблікуToolStripMenuItem.Name = "зняттяЗОблікуToolStripMenuItem";
            this.зняттяЗОблікуToolStripMenuItem.Size = new System.Drawing.Size(284, 26);
            this.зняттяЗОблікуToolStripMenuItem.Text = "Зняття з обліку";
            this.зняттяЗОблікуToolStripMenuItem.Click += new System.EventHandler(this.зняттяЗОблікуToolStripMenuItem_Click);
            // 
            // проПрограмуToolStripMenuItem
            // 
            this.проПрограмуToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.проАвтораToolStripMenuItem});
            this.проПрограмуToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.проПрограмуToolStripMenuItem.Name = "проПрограмуToolStripMenuItem";
            this.проПрограмуToolStripMenuItem.Size = new System.Drawing.Size(139, 26);
            this.проПрограмуToolStripMenuItem.Text = "Про програму";
            // 
            // проАвтораToolStripMenuItem
            // 
            this.проАвтораToolStripMenuItem.Name = "проАвтораToolStripMenuItem";
            this.проАвтораToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.проАвтораToolStripMenuItem.Text = "Про автора";
            this.проАвтораToolStripMenuItem.Click += new System.EventHandler(this.проАвтораToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.віфівToolStripMenuItem,
            this.проПрограмуToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(1517, 30);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(12, 627);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(188, 44);
            this.button1.TabIndex = 17;
            this.button1.Text = "Друк";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1517, 683);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Інформаційна система з матеріально - технічного обліку в учбовому закладі";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.Form2_Layout);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem віфівToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem переглядТехнікиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem технікаЯкаСтоїтьНаОбілкуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem постановаНаОбілкToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem зняттяЗОблікуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem проПрограмуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem проАвтораToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
    }
}
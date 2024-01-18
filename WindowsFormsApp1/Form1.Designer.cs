namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.GridC = new System.Windows.Forms.DataGridView();
            this.GridB = new System.Windows.Forms.DataGridView();
            this.GridA = new System.Windows.Forms.DataGridView();
            this.GreedA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonOpenFile = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBoxResultTwoPage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.GridHelp = new System.Windows.Forms.DataGridView();
            this.buttonNW = new System.Windows.Forms.Button();
            this.buttonMinEl = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.textBoxResult = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.GridResult = new System.Windows.Forms.DataGridView();
            this.buttonResult = new System.Windows.Forms.Button();
            this.GridBMain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridA)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridHelp)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridResult)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(877, 322);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Lavender;
            this.tabPage1.Controls.Add(this.GridC);
            this.tabPage1.Controls.Add(this.GridB);
            this.tabPage1.Controls.Add(this.GridA);
            this.tabPage1.Controls.Add(this.buttonOpenFile);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(869, 293);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Task conditions";
            // 
            // GridC
            // 
            this.GridC.BackgroundColor = System.Drawing.Color.Lavender;
            this.GridC.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GridC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridC.Location = new System.Drawing.Point(436, 7);
            this.GridC.Name = "GridC";
            this.GridC.RowHeadersWidth = 51;
            this.GridC.RowTemplate.Height = 24;
            this.GridC.Size = new System.Drawing.Size(427, 280);
            this.GridC.TabIndex = 3;
            this.GridC.Visible = false;
            // 
            // GridB
            // 
            this.GridB.BackgroundColor = System.Drawing.Color.Lavender;
            this.GridB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GridB.ColumnHeadersHeight = 29;
            this.GridB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.GridB.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GridBMain});
            this.GridB.Location = new System.Drawing.Point(254, 6);
            this.GridB.Name = "GridB";
            this.GridB.RowHeadersWidth = 30;
            this.GridB.RowTemplate.Height = 24;
            this.GridB.Size = new System.Drawing.Size(176, 280);
            this.GridB.TabIndex = 2;
            this.GridB.Visible = false;
            // 
            // GridA
            // 
            this.GridA.BackgroundColor = System.Drawing.Color.Lavender;
            this.GridA.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GridA.ColumnHeadersHeight = 29;
            this.GridA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.GridA.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GreedA});
            this.GridA.Location = new System.Drawing.Point(82, 7);
            this.GridA.Name = "GridA";
            this.GridA.RowHeadersWidth = 30;
            this.GridA.RowTemplate.Height = 24;
            this.GridA.Size = new System.Drawing.Size(166, 280);
            this.GridA.TabIndex = 1;
            this.GridA.Visible = false;
            this.GridA.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridA_CellContentClick);
            // 
            // GreedA
            // 
            this.GreedA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.GreedA.FillWeight = 90F;
            this.GreedA.HeaderText = "Сonsumers";
            this.GreedA.MinimumWidth = 6;
            this.GreedA.Name = "GreedA";
            this.GreedA.Width = 90;
            // 
            // buttonOpenFile
            // 
            this.buttonOpenFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.buttonOpenFile.Location = new System.Drawing.Point(6, 7);
            this.buttonOpenFile.Name = "buttonOpenFile";
            this.buttonOpenFile.Size = new System.Drawing.Size(70, 280);
            this.buttonOpenFile.TabIndex = 0;
            this.buttonOpenFile.Text = "Open File";
            this.buttonOpenFile.UseVisualStyleBackColor = false;
            this.buttonOpenFile.Click += new System.EventHandler(this.buttonOpenFile_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Lavender;
            this.tabPage2.Controls.Add(this.textBoxResultTwoPage);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.GridHelp);
            this.tabPage2.Controls.Add(this.buttonNW);
            this.tabPage2.Controls.Add(this.buttonMinEl);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(869, 293);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Reference plan";
            // 
            // textBoxResultTwoPage
            // 
            this.textBoxResultTwoPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxResultTwoPage.Location = new System.Drawing.Point(168, 252);
            this.textBoxResultTwoPage.Name = "textBoxResultTwoPage";
            this.textBoxResultTwoPage.Size = new System.Drawing.Size(100, 38);
            this.textBoxResultTwoPage.TabIndex = 5;
            this.textBoxResultTwoPage.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(82, 255);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 32);
            this.label1.TabIndex = 4;
            this.label1.Text = "Cost:";
            this.label1.Visible = false;
            // 
            // GridHelp
            // 
            this.GridHelp.BackgroundColor = System.Drawing.Color.Lavender;
            this.GridHelp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GridHelp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridHelp.Location = new System.Drawing.Point(82, 6);
            this.GridHelp.Name = "GridHelp";
            this.GridHelp.RowHeadersWidth = 51;
            this.GridHelp.RowTemplate.Height = 24;
            this.GridHelp.Size = new System.Drawing.Size(781, 230);
            this.GridHelp.TabIndex = 3;
            this.GridHelp.Visible = false;
            // 
            // buttonNW
            // 
            this.buttonNW.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.buttonNW.Location = new System.Drawing.Point(6, 147);
            this.buttonNW.Name = "buttonNW";
            this.buttonNW.Size = new System.Drawing.Size(70, 140);
            this.buttonNW.TabIndex = 2;
            this.buttonNW.Text = "Nord West";
            this.buttonNW.UseVisualStyleBackColor = false;
            this.buttonNW.Click += new System.EventHandler(this.buttonNW_Click);
            // 
            // buttonMinEl
            // 
            this.buttonMinEl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.buttonMinEl.Location = new System.Drawing.Point(6, 6);
            this.buttonMinEl.Name = "buttonMinEl";
            this.buttonMinEl.Size = new System.Drawing.Size(70, 140);
            this.buttonMinEl.TabIndex = 1;
            this.buttonMinEl.Text = "Minimal element";
            this.buttonMinEl.UseVisualStyleBackColor = false;
            this.buttonMinEl.Click += new System.EventHandler(this.buttonMinEl_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.Lavender;
            this.tabPage3.Controls.Add(this.textBoxResult);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.GridResult);
            this.tabPage3.Controls.Add(this.buttonResult);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(869, 293);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Optimal solution";
            // 
            // textBoxResult
            // 
            this.textBoxResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxResult.Location = new System.Drawing.Point(165, 248);
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.Size = new System.Drawing.Size(100, 38);
            this.textBoxResult.TabIndex = 7;
            this.textBoxResult.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(79, 251);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 32);
            this.label2.TabIndex = 6;
            this.label2.Text = "Cost:";
            this.label2.Visible = false;
            // 
            // GridResult
            // 
            this.GridResult.BackgroundColor = System.Drawing.Color.Lavender;
            this.GridResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GridResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridResult.GridColor = System.Drawing.Color.Lavender;
            this.GridResult.Location = new System.Drawing.Point(79, 3);
            this.GridResult.Name = "GridResult";
            this.GridResult.RowHeadersWidth = 51;
            this.GridResult.RowTemplate.Height = 24;
            this.GridResult.Size = new System.Drawing.Size(781, 230);
            this.GridResult.TabIndex = 4;
            this.GridResult.Visible = false;
            // 
            // buttonResult
            // 
            this.buttonResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.buttonResult.Location = new System.Drawing.Point(3, 3);
            this.buttonResult.Name = "buttonResult";
            this.buttonResult.Size = new System.Drawing.Size(70, 280);
            this.buttonResult.TabIndex = 1;
            this.buttonResult.Text = "Result";
            this.buttonResult.UseVisualStyleBackColor = false;
            this.buttonResult.Click += new System.EventHandler(this.buttonResult_Click);
            // 
            // GridBMain
            // 
            this.GridBMain.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.GridBMain.HeaderText = "Manufacturers";
            this.GridBMain.MinimumWidth = 6;
            this.GridBMain.Name = "GridBMain";
            this.GridBMain.Width = 120;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(901, 356);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.HelpButton = true;
            this.Name = "Form1";
            this.Text = "Transport Problem Solver";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridA)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridHelp)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView GridC;
        private System.Windows.Forms.DataGridView GridB;
        private System.Windows.Forms.DataGridView GridA;
        private System.Windows.Forms.Button buttonOpenFile;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridViewTextBoxColumn GreedA;
        private System.Windows.Forms.TextBox textBoxResultTwoPage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView GridHelp;
        private System.Windows.Forms.Button buttonNW;
        private System.Windows.Forms.Button buttonMinEl;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox textBoxResult;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView GridResult;
        private System.Windows.Forms.Button buttonResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridBMain;
    }
}


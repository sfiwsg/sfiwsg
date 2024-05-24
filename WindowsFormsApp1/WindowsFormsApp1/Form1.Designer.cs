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
            this.comboBoxYears = new System.Windows.Forms.ComboBox();
            this.btnLoadData = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.comboBoxColumns = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCountEnlistees = new System.Windows.Forms.Button();
            this.btnLastFiveDischarged = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnCreateXmlFile = new System.Windows.Forms.Button();
            this.txtNewFileName = new System.Windows.Forms.TextBox();
            this.DeleteByNameButton = new System.Windows.Forms.Button();
            this.txtNameDelete = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxYears
            // 
            this.comboBoxYears.FormattingEnabled = true;
            this.comboBoxYears.Location = new System.Drawing.Point(860, 313);
            this.comboBoxYears.Name = "comboBoxYears";
            this.comboBoxYears.Size = new System.Drawing.Size(83, 21);
            this.comboBoxYears.TabIndex = 0;
            this.comboBoxYears.Tag = "";
            this.comboBoxYears.Text = "Рік призову";
            this.comboBoxYears.SelectedIndexChanged += new System.EventHandler(this.comboBoxYears_SelectedIndexChanged);
            // 
            // btnLoadData
            // 
            this.btnLoadData.BackColor = System.Drawing.Color.Silver;
            this.btnLoadData.Location = new System.Drawing.Point(860, 340);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(83, 46);
            this.btnLoadData.TabIndex = 1;
            this.btnLoadData.Tag = "";
            this.btnLoadData.Text = "Загрузити";
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(650, 466);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.Tag = "";
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Location = new System.Drawing.Point(668, 314);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(186, 20);
            this.dateTimePickerStart.TabIndex = 3;
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Location = new System.Drawing.Point(668, 353);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(186, 20);
            this.dateTimePickerEnd.TabIndex = 4;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(668, 399);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 79);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Бінарний пошук";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(774, 418);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(169, 20);
            this.textBoxSearch.TabIndex = 6;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // comboBoxColumns
            // 
            this.comboBoxColumns.FormattingEnabled = true;
            this.comboBoxColumns.Location = new System.Drawing.Point(774, 457);
            this.comboBoxColumns.Name = "comboBoxColumns";
            this.comboBoxColumns.Size = new System.Drawing.Size(169, 21);
            this.comboBoxColumns.TabIndex = 7;
            this.comboBoxColumns.SelectedIndexChanged += new System.EventHandler(this.comboBoxColumns_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(668, 298);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Початкова дата";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(665, 337);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Кінцева дата";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(771, 441);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Вибір стовпця для пошуку";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(771, 402);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Вікно пошуку";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // btnCountEnlistees
            // 
            this.btnCountEnlistees.Location = new System.Drawing.Point(806, 220);
            this.btnCountEnlistees.Name = "btnCountEnlistees";
            this.btnCountEnlistees.Size = new System.Drawing.Size(137, 61);
            this.btnCountEnlistees.TabIndex = 12;
            this.btnCountEnlistees.Text = "Кількість призваних на службу в період введеного інтервалу дат";
            this.btnCountEnlistees.UseVisualStyleBackColor = true;
            this.btnCountEnlistees.Click += new System.EventHandler(this.btnCountEnlistees_Click);
            // 
            // btnLastFiveDischarged
            // 
            this.btnLastFiveDischarged.Location = new System.Drawing.Point(668, 220);
            this.btnLastFiveDischarged.Name = "btnLastFiveDischarged";
            this.btnLastFiveDischarged.Size = new System.Drawing.Size(132, 61);
            this.btnLastFiveDischarged.TabIndex = 13;
            this.btnLastFiveDischarged.Text = "Останні звільнені в запас";
            this.btnLastFiveDischarged.UseVisualStyleBackColor = true;
            this.btnLastFiveDischarged.Click += new System.EventHandler(this.btnLastFiveDischarged_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Location = new System.Drawing.Point(890, 12);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(23, 23);
            this.btnMinimize.TabIndex = 14;
            this.btnMinimize.Text = "-";
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(919, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(24, 23);
            this.btnExit.TabIndex = 15;
            this.btnExit.Text = "X";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnCreateXmlFile
            // 
            this.btnCreateXmlFile.Location = new System.Drawing.Point(668, 134);
            this.btnCreateXmlFile.Name = "btnCreateXmlFile";
            this.btnCreateXmlFile.Size = new System.Drawing.Size(132, 61);
            this.btnCreateXmlFile.TabIndex = 16;
            this.btnCreateXmlFile.Text = "Створити новий файл";
            this.btnCreateXmlFile.UseVisualStyleBackColor = true;
            this.btnCreateXmlFile.Click += new System.EventHandler(this.btnCreateXmlFile_Click);
            // 
            // txtNewFileName
            // 
            this.txtNewFileName.Location = new System.Drawing.Point(806, 134);
            this.txtNewFileName.Multiline = true;
            this.txtNewFileName.Name = "txtNewFileName";
            this.txtNewFileName.Size = new System.Drawing.Size(137, 61);
            this.txtNewFileName.TabIndex = 17;
            this.txtNewFileName.Text = " Ведіть рік для назви нового файлу xml.";
            this.txtNewFileName.TextChanged += new System.EventHandler(this.txtNewFileName_TextChanged);
            // 
            // DeleteByNameButton
            // 
            this.DeleteByNameButton.Location = new System.Drawing.Point(668, 48);
            this.DeleteByNameButton.Name = "DeleteByNameButton";
            this.DeleteByNameButton.Size = new System.Drawing.Size(132, 61);
            this.DeleteByNameButton.TabIndex = 18;
            this.DeleteByNameButton.Text = "Удалити за ім\'ям";
            this.DeleteByNameButton.UseVisualStyleBackColor = true;
            this.DeleteByNameButton.Click += new System.EventHandler(this.DeleteByNameButton_Click);
            // 
            // txtNameDelete
            // 
            this.txtNameDelete.Location = new System.Drawing.Point(806, 48);
            this.txtNameDelete.Multiline = true;
            this.txtNameDelete.Name = "txtNameDelete";
            this.txtNameDelete.Size = new System.Drawing.Size(137, 61);
            this.txtNameDelete.TabIndex = 19;
            this.txtNameDelete.Text = "Ведіть ім\'я для видалення даних про призивника";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(955, 490);
            this.Controls.Add(this.txtNameDelete);
            this.Controls.Add(this.DeleteByNameButton);
            this.Controls.Add(this.txtNewFileName);
            this.Controls.Add(this.btnCreateXmlFile);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.btnLastFiveDischarged);
            this.Controls.Add(this.btnCountEnlistees);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxColumns);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dateTimePickerEnd);
            this.Controls.Add(this.dateTimePickerStart);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnLoadData);
            this.Controls.Add(this.comboBoxYears);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxYears;
        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.ComboBox comboBoxColumns;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCountEnlistees;
        private System.Windows.Forms.Button btnLastFiveDischarged;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnCreateXmlFile;
        private System.Windows.Forms.TextBox txtNewFileName;
        private System.Windows.Forms.Button DeleteByNameButton;
        private System.Windows.Forms.TextBox txtNameDelete;
    }
}


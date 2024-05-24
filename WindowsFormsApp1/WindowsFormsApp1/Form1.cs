using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dateTimePickerStart.Value = new DateTime(2000, 1, 1);

            LoadYears();
            LoadColumns();

            this.MouseDown += new MouseEventHandler(Form1_MouseDown);
            this.MouseMove += new MouseEventHandler(Form1_MouseMove);
            this.MouseUp += new MouseEventHandler(Form1_MouseUp);
        }

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(diff));
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int indexOfServiceDurationDaysColumn = -1;
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                if (dataGridView1.Columns[i].Name == "ServiceDurationDays")
                {
                    indexOfServiceDurationDaysColumn = i;
                    break;
                }
            }
            if (indexOfServiceDurationDaysColumn != -1)
            {
                dataGridView1.Columns[indexOfServiceDurationDaysColumn].ReadOnly = true;
            }
        }

 
        private void LoadYears()
        {
            for (int year = 2000; year <= 2024; year++)
            {
                comboBoxYears.Items.Add(year.ToString());
            }
            comboBoxYears.SelectedIndex = 0; 
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePickerStart.Value.Date;
            DateTime endDate = dateTimePickerEnd.Value.Date;

            if (startDate > endDate)
            {
                MessageBox.Show("Начальна дата не може бути більша за кінцеву дату");
                return;
            }

            string selectedYear = comboBoxYears.SelectedItem.ToString();
            string filePath = $"{selectedYear}.xml";

            if (File.Exists(filePath))
            {
                XDocument xdoc = XDocument.Load(filePath);

                DataTable dt = new DataTable();
                dt.Columns.Add("Name");
                dt.Columns.Add("Rank");
                dt.Columns.Add("EnlistmentDate", typeof(DateTime));
                dt.Columns.Add("DischargeDate", typeof(DateTime));
                dt.Columns.Add("MilitaryUnit");
                dt.Columns.Add("ServiceDurationDays", typeof(int)); 

                var servicemen = xdoc.Descendants("Serviceman");
                foreach (var serviceman in servicemen)
                {
                    string enlistmentDateString = serviceman.Element("EnlistmentDate")?.Value;
                    string dischargeDateString = serviceman.Element("DischargeDate")?.Value;

                    if (!string.IsNullOrEmpty(enlistmentDateString) && !string.IsNullOrEmpty(dischargeDateString))
                    {
                        DateTime enlistmentDate = DateTime.Parse(enlistmentDateString);
                        DateTime dischargeDate = DateTime.Parse(dischargeDateString);

                        int serviceDurationDays = (dischargeDate - enlistmentDate).Days;

                        if (dischargeDate >= startDate && dischargeDate <= endDate)
                        {
                            dt.Rows.Add(
                                serviceman.Element("Name")?.Value,
                                serviceman.Element("Rank")?.Value,
                                enlistmentDate,
                                dischargeDate,
                                serviceman.Element("MilitaryUnit")?.Value,
                                serviceDurationDays 
                            );
                        }
                    }
                }

                DataView dv = dt.DefaultView;
                dv.Sort = "Name"; 
                dt = dv.ToTable();

                dataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show($"Файл {filePath} не знайден.");
            }
        }

        private void comboBoxYears_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private int BinarySearch(DataTable table, string columnName, string searchValue)
        {
            int left = 0;
            int right = table.Rows.Count - 1;

            while (left <= right)
            {
                int middle = left + (right - left) / 2;
                string value = table.Rows[middle][columnName].ToString();

                int comparison;
                if (DateTime.TryParse(searchValue, out DateTime searchDate) && DateTime.TryParse(value, out DateTime valueDate))
                {
                    comparison = DateTime.Compare(valueDate, searchDate);
                }
                else if (int.TryParse(searchValue, out int searchInt) && int.TryParse(value, out int valueInt))
                {
                    comparison = valueInt.CompareTo(searchInt);
                }
                else
                {
                    comparison = string.Compare(value, searchValue, StringComparison.OrdinalIgnoreCase);
                }

                if (comparison == 0)
                {
                    return middle;
                }
                else if (comparison < 0)
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle - 1;
                }
            }
            return -1; 
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchValue = textBoxSearch.Text.Trim();
            if (string.IsNullOrEmpty(searchValue))
            {
                MessageBox.Show("Будь ласка ведіть пошуковий запит.");
                return;
            }

            string selectedColumn = comboBoxColumns.SelectedItem.ToString();

            DataTable dt = dataGridView1.DataSource as DataTable;
            if (dt != null)
            {
                List<int> matchingRows = new List<int>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string cellValue = dt.Rows[i][selectedColumn].ToString();
                    if (cellValue.ToLower().Contains(searchValue.ToLower()))
                    {
                        matchingRows.Add(i);
                    }
                }

                if (matchingRows.Count > 0)
                {
                    foreach (int rowIndex in matchingRows)
                    {
                        dataGridView1.Rows[rowIndex].Selected = true;
                    }

                    int firstRowIndex = matchingRows[0];
                    dataGridView1.FirstDisplayedScrollingRowIndex = firstRowIndex;
                }
                else
                {
                    MessageBox.Show("Відповідних записів не знайдено.");
                }
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_EnabledChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxColumns_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void LoadColumns()
        {
            comboBoxColumns.Items.AddRange(new object[]     
            {
                "Name",
                "Rank",
                "EnlistmentDate",
                "DischargeDate",
                "MilitaryUnit",
                "ServiceDurationDays"
            });
            comboBoxColumns.SelectedIndex = 0; 
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnCountEnlistees_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePickerStart.Value.Date;
            DateTime endDate = dateTimePickerEnd.Value.Date;

            if (startDate > endDate)
            {
                MessageBox.Show("Дата початку не може бути більшою за дату кінця.");
                return;
            }

            int enlisteeCount = 0;

            DataTable dt = dataGridView1.DataSource as DataTable;
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    DateTime enlistmentDate = DateTime.Parse(row["EnlistmentDate"].ToString());
                    if (enlistmentDate >= startDate && enlistmentDate <= endDate)
                    {
                        enlisteeCount++;
                    }
                }

                MessageBox.Show($"Кількість призовників у період з {startDate.ToShortDateString()} по {endDate.ToShortDateString()}: {enlisteeCount}");
            }
            else
            {
                MessageBox.Show("Немає даних для обробки.");
            }

        }
        private void btnLastFiveDischarged_Click(object sender, EventArgs e)
        {
            DataTable dt = dataGridView1.DataSource as DataTable;
            if (dt != null)
            {
                DataView dv = dt.DefaultView;
                dv.Sort = "DischargeDate DESC"; 
                DataTable sortedDt = dv.ToTable();

                int numberOfRecords = Math.Min(5, sortedDt.Rows.Count);
                DataTable lastFiveDt = sortedDt.Clone(); 

                for (int i = 0; i < numberOfRecords; i++)
                {
                    lastFiveDt.ImportRow(sortedDt.Rows[i]);
                }

                dataGridView1.DataSource = lastFiveDt;
            }
            else
            {
                MessageBox.Show("Немає даних для обробки.");
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnCreateXmlFile_Click(object sender, EventArgs e)
        {
            string fileName = txtNewFileName.Text.Trim();
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{fileName}.xml");

            if (File.Exists(filePath))
            {
                MessageBox.Show($"Файл з іменем {fileName}.xml вже існує.");
                return;
            }

            try
            {
                XDocument xdoc = new XDocument(
                    new XElement("Servicemen")
                );

                for (int i = 0; i < 20; i++)
                {
                    XElement serviceman = new XElement("Serviceman",
                        new XElement("Name", ""),
                        new XElement("Rank", ""),
                        new XElement("EnlistmentDate", ""),
                        new XElement("DischargeDate", ""),
                        new XElement("MilitaryUnit", "")
                    );

                    xdoc.Root.Add(serviceman);
                }

                xdoc.Save(filePath);

                MessageBox.Show($"Створено новий файл: {fileName}.xml .");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при створенні файлу: {ex.Message}");
            }
        }
        private void LoadXmlToDataGridView(string filePath)
        {
            if (File.Exists(filePath))
            {
                XDocument xdoc = XDocument.Load(filePath);

                DataTable dt = new DataTable();
                dt.Columns.Add("Name");
                dt.Columns.Add("Rank");
                dt.Columns.Add("EnlistmentDate", typeof(DateTime));
                dt.Columns.Add("DischargeDate", typeof(DateTime));
                dt.Columns.Add("MilitaryUnit");

                var servicemen = xdoc.Descendants("Serviceman");
                foreach (var serviceman in servicemen)
                {
                    dt.Rows.Add(
                        serviceman.Element("Name")?.Value,
                        serviceman.Element("Rank")?.Value,
                        serviceman.Element("EnlistmentDate")?.Value,
                        serviceman.Element("DischargeDate")?.Value,
                        serviceman.Element("MilitaryUnit")?.Value
                    );
                }

                dataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show($"Файл {filePath} не знайдено.");
            }
        }
        private void txtNewFileName_TextChanged(object sender, EventArgs e)
        {

        }

        private void DeleteByNameButton_Click(object sender, EventArgs e)
        {
            string nameToDelete = txtNameDelete.Text;
            DeleteServicemanByName(nameToDelete);
        }

        private void DeleteServicemanByName(string name)
        {
            string selectedYear = comboBoxYears.SelectedItem.ToString();
            string filePath = $"{selectedYear}.xml";

            if (File.Exists(filePath))
            {
                XDocument xdoc = XDocument.Load(filePath);
                XElement servicemanToDelete = xdoc.Descendants("Serviceman")
                                                  .FirstOrDefault(s => s.Element("Name")?.Value == name);

                if (servicemanToDelete != null)
                {
                    servicemanToDelete.Remove(); 
                    xdoc.Save(filePath); 
                }
                else
                {
                    MessageBox.Show($"Військовослужбовця з іменем '{name}' не знайдено.");
                }
            }
            else
            {
                MessageBox.Show($"Файл {filePath} не знайдено.");
            }
        }

        private void UpdateXmlFileAfterDelete(DataTable dt)
        {
            string selectedYear = comboBoxYears.SelectedItem.ToString();
            string filePath = $"{selectedYear}.xml";

            if (File.Exists(filePath))
            {
                XDocument xdoc = new XDocument(
                    new XElement("Servicemen")
                );

                foreach (DataRow row in dt.Rows)
                {
                    XElement serviceman = new XElement("Serviceman",
                        new XElement("Name", row["Name"]),
                        new XElement("Rank", row["Rank"]),
                        new XElement("EnlistmentDate", row["EnlistmentDate"]),
                        new XElement("DischargeDate", row["DischargeDate"]),
                        new XElement("MilitaryUnit", row["MilitaryUnit"])
                    );

                    xdoc.Root.Add(serviceman);
                }

                xdoc.Save(filePath);
            }
            else
            {
                MessageBox.Show($"Файл {filePath} не знайдено.");
            }
        }
    }
}

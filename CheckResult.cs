using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;
using MySql.Data.MySqlClient;

namespace Diplom
{
    public partial class CheckResult : Form
    {
        private DB db = new DB(); // Ініціалізація змінної db
        private Chart chart = new Chart(); // Ініціалізація графіку

        public CheckResult()
        {
            InitializeComponent();
            InitializeChart();
            LoadDataFromDatabase("centralized");
        }

        private void InitializeChart()
        {
            // Налаштування графіку
            chart.Dock = DockStyle.Fill;
            ChartArea chartArea = chart.ChartAreas.Add("MainChartArea"); // Додано головну область графіка

            // Додавання графіку до panel2
            panel2.Controls.Add(chart);
        }

        private void LoadDataFromDatabase(string tableName)
        {
            DataTable data = db.GetCheckResultData(tableName);
            PlotData(data, tableName);
        }

        private void PlotData(DataTable data, string tableName)
        {
            // Очищення графіку перед оновленням
            chart.Series.Clear();

            // Створення нової серії даних для графіку (для основних даних)
            Series seriesMain = new Series
            {
                ChartType = SeriesChartType.Line,
                BorderWidth = 3,
                Color = tableName == "swarm" ? Color.Blue : Color.Red // Вибіраємо колір в залежності від таблиці
            };

            // Створення нової серії даних для графіку (для додаткових даних, зелені точки)
            Series seriesAdditional = new Series
            {
                ChartType = SeriesChartType.Point,
                Color = Color.Green,
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 8
            };

            // Встановлюємо підписи для осей графіка
            chart.ChartAreas[0].AxisX.Title = "Зібрано плодів";
            chart.ChartAreas[0].AxisY.Title = "Час (секунди)";

            // Додавання даних до серій
            foreach (DataRow row in data.Rows)
            {
                int startNumberOfFruits = Convert.ToInt32(row["startNumberOfFruits"]);
                double executionTimeSeconds = TimeSpan.Parse(row["executionTime"].ToString()).TotalSeconds;

                seriesMain.Points.AddXY(startNumberOfFruits, executionTimeSeconds);

                // Додавання зелених точок для додаткової серії
                seriesAdditional.Points.AddXY(startNumberOfFruits, executionTimeSeconds);
            }

            // Додавання серій до графіку
            chart.Series.Add(seriesMain);
            chart.Series.Add(seriesAdditional);
        }



        private void buttonSwarm_Click(object sender, EventArgs e)
        {
            LoadDataFromDatabase("swarm");
        }

        private void buttonCentralized_Click(object sender, EventArgs e)
        {
            LoadDataFromDatabase("centralized");
        }
    }
}

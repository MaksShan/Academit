using System;
using System.Windows.Forms;

namespace Temperature
{
    public partial class TemperatureConverter : Form
    {
        public TemperatureConverter()
        {
            InitializeComponent();

            string[] listFrom = { "Цельсий", "Фаренгейт", "Кельвин" };
            string[] listTo = { "Цельсий", "Фаренгейт", "Кельвин" };

            comboBoxFrom.DataSource = listFrom;
            comboBoxTo.DataSource = listTo;
        }

        private void ConvertButton_Click(object sender, EventArgs e)
        {
            double sourceTemperature = 0;
            double resultTemperatrure = 0;

            try
            {
                sourceTemperature = double.Parse(textBoxValue.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Неверный формат введенных данных", "Неверный формат", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (comboBoxFrom.Text == "Цельсий" && comboBoxTo.Text == "Цельсий")
            {
                resultTemperatrure = sourceTemperature;
            }
            else if (comboBoxFrom.Text == "Цельсий" && comboBoxTo.Text == "Фаренгейт")
            {
                resultTemperatrure = sourceTemperature * 1.8 + 32;
            }
            else if (comboBoxFrom.Text == "Цельсий" && comboBoxTo.Text == "Кельвин")
            {
                resultTemperatrure = sourceTemperature + 273.15;
            }
            else if (comboBoxFrom.Text == "Фаренгейт" && comboBoxTo.Text == "Фаренгейт")
            {
                resultTemperatrure = sourceTemperature;
            }
            else if (comboBoxFrom.Text == "Фаренгейт" && comboBoxTo.Text == "Цельсий")
            {
                resultTemperatrure = (sourceTemperature - 32) / 1.8;
            }
            else if (comboBoxFrom.Text == "Фаренгейт" && comboBoxTo.Text == "Кельвин")
            {
                resultTemperatrure = sourceTemperature / 1.8 - 32 + 273;
            }
            else if (comboBoxFrom.Text == "Кельвин" && comboBoxTo.Text == "Кельвин")
            {
                resultTemperatrure = sourceTemperature;
            }
            else if (comboBoxFrom.Text == "Кельвин" && comboBoxTo.Text == "Цельсий")
            {
                resultTemperatrure = sourceTemperature - 273.15;
            }
            else if (comboBoxFrom.Text == "Кельвин" && comboBoxTo.Text == "Фаренгейт")
            {
                resultTemperatrure = 32 + (sourceTemperature - 273) * 1.8;
            }
            else
            {
                MessageBox.Show("Шкалы температур заданы неверно", "Неверные шкалы", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            lableConvertResult.Text = resultTemperatrure.ToString("0.00");
        }
    }
}

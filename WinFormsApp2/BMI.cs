using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp2.Properties;
using Newtonsoft.Json;
using Newtonsoft;

namespace WinFormsApp2
{
    public partial class BMI : Form
    {
        public string filePath = "Bmidata.json";
        public List<bmidata> bmi = new List<bmidata>();
        public string remarks;
        public class bmidata
        {
            public string Name { get; set; }
            public string BMI { get; set; }
            public string Remarks { get; set; }
            public string Height { get; set; }
            public string Weight { get; set; }
        }
        private void LoadUserData()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                bmi = JsonConvert.DeserializeObject<List<bmidata>>(json);
            }

        }

        public BMI()
        {
            InitializeComponent();
            LoadUserData();
        }
        double calculateBMI(double height, double weight)
        {
            double bmi = weight / (height * height);
            return bmi;
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                var jsons = File.ReadAllText(filePath);
                bmi = JsonConvert.DeserializeObject<List<bmidata>>(jsons);

                guna2DataGridView1.DataSource = bmi;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid Height or Weight");
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                double height = double.Parse(txthei.Text);
                double weight = double.Parse(txtwei.Text);
                double bmis = calculateBMI(height, weight);

                lblBMI.Text = bmis.ToString("F2");
                var strBMI = bmis.ToString("F2");


                if (bmis < 18.5)
                {
                    lblRemarks.Text = "Underweight";
                    remarks = "Underweight";
                    guna2PictureBox3.Image = Resources.underweight;
                }
                else if (bmis >= 18.5 && bmis <= 24.9)
                {
                    lblRemarks.Text = "Normal";
                    remarks = "Normal";
                    guna2PictureBox3.Image = Resources.normal;
                }
                else if (bmis >= 25 && bmis <= 29.5)
                {
                    lblRemarks.Text = "Overweight";
                    remarks = "Overweight";
                    guna2PictureBox3.Image = Resources.overweight;
                }
                else if (bmis > 30)
                {
                    lblRemarks.Text = "Obese";
                    guna2PictureBox3.Image = Resources.obese;
                }
                var userCred = new bmidata
                {
                    Name = txtName.Text,
                    Height = txthei.Text,
                    Weight = txtwei.Text,
                    BMI = strBMI,
                    Remarks = strBMI
                };
                bmi.Add(userCred);
                var json = JsonConvert.SerializeObject(bmi);
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid Height or Weight");
            }


            


        }

        private void lblBMI_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

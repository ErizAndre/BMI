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

namespace WinFormsApp2
{
    public partial class BMI : Form
    {
        public string filePath = "Cred.json";
        public List<UserCred> userData;
        public class UserCred
        {
            public string User { get; set; }
            public string Pass { get; set; }
        }
        private void LoadUserData()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                userData = JsonConvert.DeserializeObject<List<UserCred>>(json);
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
            var jsons = File.ReadAllText(filePath);
            userData = JsonConvert.DeserializeObject<List<UserCred>>(jsons);

            guna2DataGridView1.DataSource = userData;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                double height = double.Parse(txthei.Text);
                double weight = double.Parse(txtwei.Text);
                double bmi = calculateBMI(height, weight);

                lblBMI.Text = bmi.ToString("F2");

                if (bmi < 18.5)
                {
                    lblRemarks.Text = "Underweight";

                }
                else if (bmi >= 18.5 && bmi <= 24.9)
                {
                    lblRemarks.Text = "Normal";

                }
                else if (bmi >= 25 && bmi <= 29.5)
                {
                    lblRemarks.Text = "Overweight";

                }
                else if (bmi > 30)
                {
                    lblRemarks.Text = "Obese";

                }



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
    }
}

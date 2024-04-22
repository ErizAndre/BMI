using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Newtonsoft;
using Newtonsoft.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static WinFormsApp2.SignUp;

namespace WinFormsApp2
{

    public partial class SignUp : Form
    {
        public string filePath = "Cred.json";
        List<UserCred> userData = new List<UserCred>();
        public class UserCred
        {
            public string User { get; set; }
            public string Pass { get; set; }
        }

        public SignUp()
        {
            InitializeComponent();
            LoadUserData();
        }
        private void LoadUserData()
        {
            
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                userData = JsonConvert.DeserializeObject<List<UserCred>>(json);
            }

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            var result = MessageBox.Show("Press Yes again to Confirm?", "Confirm?", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                var userCred = new UserCred
                {
                    User = txtUser.Text,
                    Pass = txtPass.Text
                };

                bool userExists = false;

                foreach (var credentials in userData)
                {
                    if (txtUser.Text == credentials.User)
                    {
                        userExists = true;
                        break;
                    }
                }

                if (!userExists)
                {
                    userData.Add(userCred);
                    var json = JsonConvert.SerializeObject(userData);
                    File.WriteAllText(filePath, json);
                }
                else
                {
                    MessageBox.Show("User already exists.");
                }
            }




        }
        
       

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.ShowDialog();

        }



        private void label1_Click(object sender, EventArgs e)
        {
            label1.Cursor = Cursors.Hand;
            Form1 form1 = new Form1();
            this.Hide();
            form1.ShowDialog();
        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox1.Checked)
            {
                txtPass.UseSystemPasswordChar = false;
                txtPass.PasswordChar = '\0';
            }
            else
            {
                txtPass.UseSystemPasswordChar = true;
            }
        }
    }
}

using Newtonsoft.Json;
using static WinFormsApp2.SignUp;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public string filePath = "Cred.json";
        public List<UserCred> userData;
        public Form1()
        {
            InitializeComponent();
            LoadUserData();
        }
        private void LoadUserData()
        {
            if(File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                userData = JsonConvert.DeserializeObject<List<UserCred>>(json);
            }

        }

        public class UserCred
        {
            public string User { get; set; }
            public string Pass { get; set; }
        }

        private void guna2Shapes1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUserLog.Text;
            string password = txtPassLog.Text;

            // Iterate through stored credentials to check for a match
            foreach (var credentials in userData)
            {
                if (username == credentials.User && password == credentials.Pass)
                {
                    MessageBox.Show("Login successful!");
                    BMI BMI = new BMI();
                    this.Hide();
                    BMI.ShowDialog();
                    return;
                
                }
            }

            MessageBox.Show("Invalid username or password.");
        }

        

        private void label1_Click(object sender, EventArgs e)
        {
            label1.Cursor = Cursors.Hand;
            SignUp SignUp = new SignUp();
            this.Hide();
            SignUp.ShowDialog();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            SignUp SignUp = new SignUp();
            this.Hide();
            SignUp.ShowDialog();
        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox1.Checked)
            {
                txtPassLog.UseSystemPasswordChar = false;
                txtPassLog.PasswordChar = '\0';
            }
            else
            {
                txtPassLog.UseSystemPasswordChar = true;
            }
        }
    }
}

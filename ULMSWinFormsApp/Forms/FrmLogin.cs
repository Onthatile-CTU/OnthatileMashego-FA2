using ULMSWinFormsApp.Forms;

namespace ULMSWinFormsApp
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // BUG-01 FIX: Validate that fields are not empty before processing
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Username and password cannot be empty.",
                                "Validation Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            // BUG-01 FIX: Changed || to && so BOTH username AND password must match
            if (username == "admin" && password == "admin123")
            {
                MessageBox.Show("Login Successful!");

                FrmDashboard dashboard = new FrmDashboard();
                dashboard.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.",
                                "Login Failed", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        //btnclear
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
        }

    }
}

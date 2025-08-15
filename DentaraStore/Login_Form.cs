using Microsoft.Data.SqlClient;
using System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DentaraStore
{
    public partial class Login_Form : Form
    {
        public string serverName = "ZBOOK15G5-ALDUB";
        public Login_Form()
        {
            InitializeComponent();
        }

        private string EncryptPassword(string rawData)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(rawData);
                byte[] hash = sha256.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "");

            }
        }

        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            RoleLabel.Text = guna2ToggleSwitch1.Checked ? "Admin" : "Customer";
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string email = Email_txt.Text.Trim();
            string password = Passwoerd_txt.Text.Trim();
            string role = guna2ToggleSwitch1.Checked ? "Admin" : "Customer"; // ON = Admin, OFF = Customer

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both email and password.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string hashedPassword = EncryptPassword(password);

            try
            {   
                DBConnection dBConnection = new DBConnection(serverName);
                string dbserver = dBConnection.sqlServerConnection;
                using (SqlConnection conn = new SqlConnection(dbserver))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Users WHERE Email = @Email AND PasswordHash = @PasswordHash AND Role = @Role";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@PasswordHash", hashedPassword);
                        cmd.Parameters.AddWithValue("@Role", role);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            if (role == "Admin")
                            {
                                MessageBox.Show("This is Admin Form ");
                                // Admin_Form adminForm = new Admin_Form();
                                //adminForm.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("This is Customer Form ");
                                //Customer_Form customerForm = new Customer_Form();
                                //customerForm.Show();
                                this.Hide();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid credentials or role mismatch.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

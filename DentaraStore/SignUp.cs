using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DentaraStore
{
    public partial class SignUp : Form
    {
        private string serverName = "DESKTOP-G1QMAOP";

        public SignUp()
        {
            InitializeComponent();
        }

        private bool IsValidEmailAddress(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@(gmail|yahoo)\.com$");
            return regex.IsMatch(email);
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



        private void ClearInputFields()
        {
            Fullname_text.Text = string.Empty;
            Email_txt.Text = string.Empty;
            Passwoerd_txt.Text = string.Empty;


        }

        private void SignUp_btn_Click(object sender, EventArgs e)
        {
        }

        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
          
        }
        private void SignUp_btn_Click_1(object sender, EventArgs e)
        {
            string fullName = Fullname_text.Text.Trim();
            string email = Email_txt.Text.Trim();
            string password = Passwoerd_txt.Text.Trim();
            string gender = Gender_ToggleSwitch2.Checked ? "Male" : "Female"; // ON = Male, OFF = Female
            string role = guna2ToggleSwitch1.Checked ? "Admin" : "Customer";  // ON = Admin, OFF = Customer

            // Basic validation
            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill in all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!IsValidEmailAddress(email))
            {
                MessageBox.Show("Invalid email format. Only gmail.com or yahoo.com addresses are allowed.",
                                "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string hashedPassword = EncryptPassword(password);

            try
            {
                DBConnection dBConnection = new DBConnection(serverName);
                string dbserver = dBConnection.sqlServerConnection;

                using (SqlConnection connection = new SqlConnection(dbserver))
                {
                    connection.Open();

                    // Check for duplicate email
                    string checkQuery = "SELECT COUNT(*) FROM Users WHERE Email = @Email";
                    SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                    checkCommand.Parameters.AddWithValue("@Email", email);

                    int userExists = (int)checkCommand.ExecuteScalar();
                    if (userExists > 0)
                    {
                        MessageBox.Show("This email is already registered. Please log in instead.",
                                        "Duplicate Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Insert new user
                    string query = "INSERT INTO Users (FullName, Email, PasswordHash, Gender, Role) " +
                                   "VALUES (@FullName, @Email, @PasswordHash, @Gender, @Role)";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@FullName", fullName);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@PasswordHash", hashedPassword);
                    command.Parameters.AddWithValue("@Gender", gender);
                    command.Parameters.AddWithValue("@Role", role);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Signup successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Open form by role if needed
                        /* if (role == "Admin")
                        {
                            // new Admin_Form().Show();
                        }
                        else
                        {
                            // new Customer_Form().Show();
                        } */
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Signup failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Send confirmation email
                MailMessage message = new MailMessage
                {
                    From = new MailAddress("aldubai16osama@gmail.com"),
                    Subject = "SignUp Process",
                    Body = $"Dear {fullName},\n\nYou have successfully signed up.\n\nBest regards"
                };
                message.To.Add(new MailAddress(email));

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587)
                {
                    UseDefaultCredentials = false,
                    Credentials = new System.Net.NetworkCredential("aldubai16osama@gmail.com", "tcna czam ktuk yvoc"),
                    EnableSsl = true
                };
                smtp.Send(message);

                MessageBox.Show("We sent a verification email. Please check your inbox!");

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred during signup: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ClearInputFields();

        }

        private void Logout_btn_Click(object sender, EventArgs e)
        {
            Login_Form f3 = new Login_Form();
            f3.Show();
            this.Hide();
        }

        private void Gender_ToggleSwitch2_CheckedChanged(object sender, EventArgs e)
        {
            Gender_label.Text = Gender_ToggleSwitch2.Checked ? "Male" : "Female";
        }

        private void guna2ToggleSwitch1_CheckedChanged_1(object sender, EventArgs e)
        {
            RoleLabel.Text = guna2ToggleSwitch1.Checked ? "Admin" : "Customer";
        }
    }
}

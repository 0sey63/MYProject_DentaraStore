namespace DentaraStore
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Save_btn_Click(object sender, EventArgs e)
        {
            string servername = NameServer.Text;
            DBConnection dBConnection=new DBConnection(servername);
            string dbserver =dBConnection.serverName;
            MessageBox.Show(dbserver);
            Login_Form login_Form = new Login_Form();
            this.Hide();
            login_Form.Show();
        }
    }
}

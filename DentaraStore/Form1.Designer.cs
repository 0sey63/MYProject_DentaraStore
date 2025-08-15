namespace DentaraStore
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            label1 = new Label();
            NameServer = new Guna.UI2.WinForms.Guna2TextBox();
            Save_btn = new Guna.UI2.WinForms.Guna2Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new Point(12, 93);
            label1.Name = "label1";
            label1.Size = new Size(104, 26);
            label1.TabIndex = 0;
            label1.Text = "Server name";
            // 
            // NameServer
            // 
            NameServer.CustomizableEdges = customizableEdges1;
            NameServer.DefaultText = "";
            NameServer.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            NameServer.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            NameServer.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            NameServer.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            NameServer.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            NameServer.Font = new Font("Segoe UI", 9F);
            NameServer.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            NameServer.Location = new Point(143, 93);
            NameServer.Margin = new Padding(3, 4, 3, 4);
            NameServer.Name = "NameServer";
            NameServer.PlaceholderText = "";
            NameServer.SelectedText = "";
            NameServer.ShadowDecoration.CustomizableEdges = customizableEdges2;
            NameServer.Size = new Size(286, 26);
            NameServer.TabIndex = 1;
            // 
            // Save_btn
            // 
            Save_btn.CustomizableEdges = customizableEdges3;
            Save_btn.DisabledState.BorderColor = Color.DarkGray;
            Save_btn.DisabledState.CustomBorderColor = Color.DarkGray;
            Save_btn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            Save_btn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            Save_btn.Font = new Font("Segoe UI", 9F);
            Save_btn.ForeColor = Color.White;
            Save_btn.Location = new Point(215, 138);
            Save_btn.Name = "Save_btn";
            Save_btn.ShadowDecoration.CustomizableEdges = customizableEdges4;
            Save_btn.Size = new Size(142, 38);
            Save_btn.TabIndex = 2;
            Save_btn.Text = "Save Changes";
            Save_btn.Click += Save_btn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(508, 197);
            Controls.Add(Save_btn);
            Controls.Add(NameServer);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Server Name";
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Guna.UI2.WinForms.Guna2TextBox NameServer;
        private Guna.UI2.WinForms.Guna2Button Save_btn;
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KalibrasiKapalDev
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void Masuk_Click_1(object sender, EventArgs e)
        {
            if (this.username.Text == "admin" && this.password.Text == "admin")
            {
                Kalibrasi main = new Kalibrasi();
                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
        }
    }
}

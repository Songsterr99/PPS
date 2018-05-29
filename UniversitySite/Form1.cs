﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversitySite
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            string login = TextLogin.Text;
            string password = TextPassword.Text;

            User user = LoginController.MakeUser(login, password);
            if (user == null)
            {
                MessageBox.Show("Incorrect login or password. Try again!");
            }
            else
            {
                MessageBox.Show("You are welcome:)");
                Hide();
                ChooseAction Action = new ChooseAction(user);
                Action.Show();
            }
        }

        private void TextLogin_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextPassword_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}

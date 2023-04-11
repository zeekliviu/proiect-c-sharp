﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_C_.Forms
{
    public partial class VerificationForm : Form
    {
        private string code;
        private string email;
        public VerificationForm()
        {
            InitializeComponent();
        }
        public VerificationForm(string code, string email) : this()
        {
            this.code = code;
            this.email = email;
            verifyLabel.Text = "Enter the code sent on " + this.email + " in the box below: ";
        }

        private void verifyBtn_Click(object sender, EventArgs e)
        {
            if(this.code == verifyTxtBox.Text)
            {
                MessageBox.Show("E-mail is verified!", "Verified", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Wrong code!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
    }
}
﻿using Oracle.ManagedDataAccess.Client;
using Proiect_C_.Entities;
using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Proiect_C_.Forms
{
    public partial class ChangeName : Form
    {
        string pwd;
        public Client client;
        public ChangeName()
        {
            InitializeComponent();
        }
        public ChangeName(Client client, string pwd) : this()
        {
            this.client = client;
            this.pwd = pwd;
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            if(errorProvider.GetError(newNameTxtBox)=="")
            {
                var new_name = newNameTxtBox.Text.Split(' ');
                client.LastName = new_name[new_name.Length-1];
                client.FirstName = "";
                for(int i = 0; i < new_name.Length-1; i++)
                    client.FirstName += new_name[i] + " ";
                client.FirstName = client.FirstName.Trim();
                MessageBox.Show("Name changed successfully!");
                DBUtils.DBUtils.UnzipArchive(pwd);
                using (OracleConnection connection = new OracleConnection(Encryption.EncryptionUtils.DecryptString(Properties.Settings.Default.DbConnection, pwd)))
                {
                    connection.Open();
                    string query = "update users set firstname = :firstname, lastname = :lastname where email = :email";
                    OracleCommand command = new OracleCommand(query, connection);
                    command.Parameters.Add(":firstname", client.FirstName);
                    command.Parameters.Add(":lastname", client.LastName);
                    command.Parameters.Add(":email", client.Email);
                    command.ExecuteNonQuery();
                    DBUtils.DBUtils.DeleteFiles();
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void newNameTxtBox_Validating(object sender, CancelEventArgs e)
        {
            if(newNameTxtBox.Text == "")
            {
                errorProvider.SetError(newNameTxtBox, "Please enter a new name!");
                return;
            }
            foreach(char c in newNameTxtBox.Text)
            {
                if (!char.IsLetter(c) && c != ' ' && c != '\'' && c != '-')
                {
                    errorProvider.SetError(newNameTxtBox, "Please enter a valid name!");
                    return;
                }
            }
            string[] names = newNameTxtBox.Text.Split(' ');
            if (names.Length < 2)
            {
                errorProvider.SetError(newNameTxtBox, "Please enter a valid name!");
                return;
            }
            foreach(var name in names)
            if(name.Length < 2)
                {
                errorProvider.SetError(newNameTxtBox, "Please enter a valid name!");
                return;
                }
            string pattern = @"\b([A-Z]{1}[a-z]{1,30}[- ]{0,1}|[A-Z]{1}[- \']{1}[A-Z]{0,1}  
    [a-z]{1,30}[- ]{0,1}|[a-z]{1,2}[ -\']{1}[A-Z]{1}[a-z]{1,30}){2,5}";
            if (!Regex.IsMatch(newNameTxtBox.Text, pattern))
            {
                errorProvider.SetError(newNameTxtBox, "Please enter a valid name!");
                return;
            }
            errorProvider.Clear();
        }

        private void newNameTxtBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                newNameTxtBox_Validating(sender, new CancelEventArgs());
                submitBtn_Click(sender, e); 
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
            Close();
        }
    }
}

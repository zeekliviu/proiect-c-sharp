﻿using Oracle.ManagedDataAccess.Client;
using Proiect_C_.Entities;
using System;
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
    public partial class ChangeName : Form
    {
        string pwd;
        Client client;
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
                client.FirstName = new_name[0];
                client.LastName = "";
                for(int i = 1; i < new_name.Length; i++)
                    client.LastName += new_name[i] + " ";
                client.LastName = client.LastName.Trim();
                MessageBox.Show("Name changed successfully!");
                using (OracleConnection connection = new OracleConnection(Encryption.EncryptionUtils.DecryptString(Properties.Settings.Default.DbConnection, pwd)))
                {
                    connection.Open();
                    string query = "update users set firstname = :firstname, lastname = :lastname where email = :email";
                    OracleCommand command = new OracleCommand(query, connection);
                    command.Parameters.Add(":firstname", client.FirstName);
                    command.Parameters.Add(":lastname", client.LastName);
                    command.Parameters.Add(":email", client.Email);
                    command.ExecuteNonQuery();
                }
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
            string pattern = @"(?:[A-Z][a-z]*\.?\s+){1,2}[A-Z][a-z]*";
            if (!System.Text.RegularExpressions.Regex.IsMatch(newNameTxtBox.Text, pattern))
            {
                errorProvider.SetError(newNameTxtBox, "Please enter a valid name!");
                return;
            }
            errorProvider.Clear();
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RenameMails
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.InitializeComponent();
        }

        private void RenameAllClick(object sender, EventArgs e)
        {
            OrganizeMails.RenameFiles(true);
        }

        private void RenameClick(object sender, EventArgs e)
        {
            OrganizeMails.RenameFiles(false);
        }

        private void MoveClick(object sender, EventArgs e)
        {
            OrganizeMails.MoveFiles();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OrganizeMails.GetAllFiles();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
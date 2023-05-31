﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace _202503071_nüfus_müdürlüğü_otomosyonu
{
    public partial class md5 : Form
    {
        public md5()
        {
            InitializeComponent();
        }

       public static string MD5Sifrele(string sifrelenecekmetin)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] dizi = Encoding.UTF8.GetBytes(sifrelenecekmetin);

            dizi = md5.ComputeHash(dizi);

            StringBuilder sb = new StringBuilder();

            foreach (byte item in dizi)

            sb.Append(item.ToString("x2").ToLower());
            return sb.ToString();


          
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1 .Text != "")
            {
                richTextBox1.Text = MD5Sifrele(textBox1.Text);
            }
        }
    }
}
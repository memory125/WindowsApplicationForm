﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sunflower
{
    public partial class SunflowerForm : Form
    {
        public SunflowerForm()
        {
            InitializeComponent();
        }

        private void widthTxt_TextChanged(object sender, EventArgs e)
        {
            double amountResult = 0.0f;
            double priceUnit = 0.0f;
            var width = widthTxt.Text.ToString();
            var length = lengthTxt.Text.ToString();
            var materialOption = materialComboBox.SelectedIndex;

            if (width.Equals("") || length.Equals(""))
                return;

            switch (Convert.ToInt32(materialOption))
            {
                case 0:
                    priceUnit = 2.2;
                    break;

                case 1:
                    priceUnit = 4.2;
                    break;

                case 2:
                    priceUnit = 6.6;
                    break;

                case 3:
                    priceUnit = 8.6;
                    break;

                default:
                    amountResult = 0.0;
                    break;                
            }

            amountResult = Convert.ToDouble(width) * Convert.ToDouble(length) * priceUnit;

            amountTxt.Text = amountResult.ToString();
        }

        private void widthTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsPunctuation(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = false;//消除不合适字符
            }
            else if (Char.IsPunctuation(e.KeyChar))
            {
                if (e.KeyChar != '.' || this.widthTxt.Text.Length == 0)//小数点
                {
                    e.Handled = true;
                }
                if (widthTxt.Text.LastIndexOf('.') != -1)
                {
                    e.Handled = true;
                }
            }
        }

        private void lengthTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsPunctuation(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;//消除不合适字符
            }
            else if (Char.IsPunctuation(e.KeyChar))
            {
                if (e.KeyChar != '.' || this.lengthTxt.Text.Length == 0)//小数点
                {
                    e.Handled = true;
                }
                if (lengthTxt.Text.LastIndexOf('.') != -1)
                {
                    e.Handled = true;
                }
            }
        }
    }
}

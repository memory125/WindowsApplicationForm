using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sunflower
{
    public partial class SunflowerForm : Form
    {
        private List<double> fabricPrice;       
        private List<double> ropePrice;
        private List<double> shipdistancePrice;
        private List<double> shipwayPrice;

        public SunflowerForm()
        {
            InitializeComponent();
            GetFabricData();
            GetRopeData();
            GetShipDistanceData();
            GetShipWayData();
        }

        private void widthTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {            
            if (!Char.IsNumber(e.KeyChar) && !Char.IsPunctuation(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = false;//消除不合适字符
            }
            else if (Char.IsPunctuation(e.KeyChar))
            {
                if (e.KeyChar != '.' || this.widthTextBox1.Text.Length == 0)//小数点
                {
                    e.Handled = true;
                }
                if (widthTextBox1.Text.LastIndexOf('.') != -1)
                {
                    e.Handled = true;
                }
            }
        }    

        private void bottomComboBox_TextChanged(object sender, EventArgs e)
        {
            var top = bottomComboBox.SelectedIndex;

            switch(Convert.ToInt32(top))
            {
                case 0:
                    widthTextBox2.Enabled = true;
                    lengthTextBox.Enabled = true;
                    heightTextBox3.Enabled = true;
                    diameterTextBox.Enabled = false;
                    heightTextBox2.Enabled = false;
                    widthTextBox1.Enabled = false;
                    heightTextBox1.Enabled = false;
                    break;

                case 1:                    
                    widthTextBox2.Enabled = false;
                    lengthTextBox.Enabled = false;
                    heightTextBox3.Enabled = false;
                    diameterTextBox.Enabled = true;
                    heightTextBox2.Enabled = true;
                    widthTextBox1.Enabled = false;
                    heightTextBox1.Enabled = false;
                    break;

                case 2:
                    widthTextBox2.Enabled = false;
                    lengthTextBox.Enabled = false;
                    heightTextBox3.Enabled = false;
                    diameterTextBox.Enabled = false;
                    heightTextBox2.Enabled = false;
                    widthTextBox1.Enabled = true;
                    heightTextBox1.Enabled = true;
                    break;

                default:
                    break;
            }
        }

        private void GetFabricData()
        {
            string currentPath = AppDomain.CurrentDomain.BaseDirectory;
            currentPath += "fabrics.bin";
          
            string[] lines = File.ReadAllLines(currentPath, Encoding.UTF8);
            if (!lines.Equals(null))
            {
               fabricPrice = new List<double>();
            }
            
            foreach (string line in lines)
            {
                string[] str = line.Split(',');
                fabricComboBox.Items.Add(str[0]);                
                fabricPrice.Add(Convert.ToDouble(str[1]));                
            }
        }

        private void GetRopeData()
        {
            string currentPath = AppDomain.CurrentDomain.BaseDirectory;
            currentPath += "ropes.bin";

            string[] lines = File.ReadAllLines(currentPath, Encoding.UTF8);
            if (!lines.Equals(null))
            {
                ropePrice = new List<double>();
            }

            foreach (string line in lines)
            {
                string[] str = line.Split(',');
                ropeComboBox.Items.Add(str[0]);
                ropePrice.Add(Convert.ToDouble(str[1]));
            }
        }

        private void GetShipDistanceData()
        {
            string currentPath = AppDomain.CurrentDomain.BaseDirectory;
            currentPath += "shipdistances.bin";

            string[] lines = File.ReadAllLines(currentPath, Encoding.UTF8);
            if (!lines.Equals(null))
            {
                shipdistancePrice = new List<double>();
            }

            foreach (string line in lines)
            {
                string[] str = line.Split(',');
                //Encoding utf8 = Encoding.UTF8;
                //Encoding defaultCode = Encoding.Unicode;

                //// Convert the string into a byte[].
                //byte[] utf8Bytes = utf8.GetBytes(str[0].ToString());
                //// Perform the conversion from one encoding to the other.
                //byte[] defaultBytes = Encoding.Convert(utf8, defaultCode, utf8Bytes);
                //char[] defaultChars = new char[defaultCode.GetCharCount(defaultBytes, 0, defaultBytes.Length)];
                //defaultCode.GetChars(defaultBytes, 0, defaultBytes.Length, defaultChars, 0);
                //string defaultString = new string(defaultChars);

                distanceComboBox.Items.Add(str[0]);
                shipdistancePrice.Add(Convert.ToDouble(str[1]));
            }
        }

        private void GetShipWayData()
        {
            string currentPath = AppDomain.CurrentDomain.BaseDirectory;
            currentPath += "shipways.bin";

            string[] lines = File.ReadAllLines(currentPath, Encoding.UTF8);
            if (!lines.Equals(null))
            {
                shipwayPrice = new List<double>();
            }

            foreach (string line in lines)
            {
                string[] str = line.Split(',');
                shipwayComboBox.Items.Add(str[0]);
                shipwayPrice.Add(Convert.ToDouble(str[1]));
            }
        }

        private void numberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;//消除不合适字符         
            }         
        }

        private void heightTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsPunctuation(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;//消除不合适字符
            }
            else if (Char.IsPunctuation(e.KeyChar))
            {
                if (e.KeyChar != '.' || this.heightTextBox1.Text.Length == 0)//小数点
                {
                    e.Handled = true;
                }
                if (heightTextBox1.Text.LastIndexOf('.') != -1)
                {
                    e.Handled = true;
                }
            }
        }

        private void diameterTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsPunctuation(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;//消除不合适字符
            }
            else if (Char.IsPunctuation(e.KeyChar))
            {
                if (e.KeyChar != '.' || this.diameterTextBox.Text.Length == 0)//小数点
                {
                    e.Handled = true;
                }
                if (diameterTextBox.Text.LastIndexOf('.') != -1)
                {
                    e.Handled = true;
                }
            }
        }

        private void heightTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsPunctuation(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;//消除不合适字符
            }
            else if (Char.IsPunctuation(e.KeyChar))
            {
                if (e.KeyChar != '.' || this.heightTextBox2.Text.Length == 0)//小数点
                {
                    e.Handled = true;
                }
                if (heightTextBox2.Text.LastIndexOf('.') != -1)
                {
                    e.Handled = true;
                }
            }
        }

        private void widthTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsPunctuation(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;//消除不合适字符
            }
            else if (Char.IsPunctuation(e.KeyChar))
            {
                if (e.KeyChar != '.' || this.widthTextBox2.Text.Length == 0)//小数点
                {
                    e.Handled = true;
                }
                if (widthTextBox2.Text.LastIndexOf('.') != -1)
                {
                    e.Handled = true;
                }
            }
        }

        private void lengthTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsPunctuation(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;//消除不合适字符
            }
            else if (Char.IsPunctuation(e.KeyChar))
            {
                if (e.KeyChar != '.' || this.lengthTextBox.Text.Length == 0)//小数点
                {
                    e.Handled = true;
                }
                if (lengthTextBox.Text.LastIndexOf('.') != -1)
                {
                    e.Handled = true;
                }
            }
        }

        private void heightTextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsPunctuation(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;//消除不合适字符
            }
            else if (Char.IsPunctuation(e.KeyChar))
            {
                if (e.KeyChar != '.' || this.heightTextBox3.Text.Length == 0)//小数点
                {
                    e.Handled = true;
                }
                if (heightTextBox3.Text.LastIndexOf('.') != -1)
                {
                    e.Handled = true;
                }
            }
        }
    }
}

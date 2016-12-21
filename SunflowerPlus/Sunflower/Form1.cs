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
        private List<double> configsData;
        private List<double> fabircWeight;
        private List<double> fabircWidth;
        private List<double> fabricPrice;
        private List<double> ropeWeight;
        private List<double> ropePrice;
        private List<double> shipSFPrice;
        private List<double> shipYDPrice;
        private List<double> currentShipPrice;
        private List<double> shipwayPrice;

        private Int16 currentBottomSelectIndex = 0;

        private double Width_Space = 0.0f;
        private double Height_Space = 0.0f;

        private Int16 ropeTypeIndex = -1;
        private Int16 fabricTypeIndex = -1;
        private Int16 ropeMaterialIndex = -1;
        private Int16 shipDistanceIndex = -1;
        private Int16 shipWayIndex = -1;

        private enum ConfigsData
        {
            Rope_Double_Space_Index,
            Rope_Single_Space_Index,
            Width_Space_Generic_Index,
            Height_Space_Generic_top_Index,
            Height_Space_Muer_top_Index,
            Height_Space_Tie_top_Index,
            Height_Space_Round_bottom_Index,
            Height_Space_Single_bottom_Index,
            Profit_ratio_Index,
            Invoice_ratio_Index,
            ConfigsData_Max
        };

        public SunflowerForm()
        {
            InitializeComponent();
            GetConfigData();
            GetFabricData();
            GetRopeData();
            GetShipDistanceData();
            GetShipWayData();
            SetDefaultConfigurationData();
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
            var bottomOption = bottomComboBox.SelectedIndex;
            currentBottomSelectIndex = Convert.ToInt16(bottomOption);

            switch (bottomOption)
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

        private void GetConfigData()
        {
            string currentPath = AppDomain.CurrentDomain.BaseDirectory;
            currentPath += "configs.bin";

            if (!File.Exists(currentPath))
            {
                MessageBox.Show(string.Format("文件\"{0}\"不存在！", currentPath, Encoding.UTF8));
                return;
            }

            string[] lines = File.ReadAllLines(currentPath, Encoding.UTF8);
            if (lines.Length == 0)
            {
                MessageBox.Show(string.Format("\"{0}\"内容为空，请参考\"name = value\"格式！", currentPath, Encoding.UTF8));
                return;
            }
            else
            {
                configsData = new List<double>();
            }
         
            foreach (string line in lines)
            {
                string[] str = line.Split('=');
                if (str.Length != 2)
                {
                    MessageBox.Show(string.Format("\"{0}\"文件格式错误，请参考\"name/weight/width/price\"格式！", currentPath, Encoding.UTF8));
                    return;
                }

                configsData.Add(Convert.ToDouble(str[1]));                
            }
        }
        private void GetFabricData()
        {
            string currentPath = AppDomain.CurrentDomain.BaseDirectory;
            currentPath += "fabrics.bin";

            if (!File.Exists(currentPath))
            {
                MessageBox.Show(string.Format("文件\"{0}\"不存在！", currentPath, Encoding.UTF8));
                return;
            }

            string[] lines = File.ReadAllLines(currentPath, Encoding.UTF8);
            if (lines.Length == 0)
            {
                MessageBox.Show(string.Format("\"{0}\"内容为空，请参考\"name/price\"格式！", currentPath, Encoding.UTF8));
                return;
            }
            else
            {
               fabircWeight = new List<double>();
               fabircWidth = new List<double>();
               fabricPrice = new List<double>();
            }
            
            foreach (string line in lines)
            {
                string[] str = line.Split('/');
                if (str.Length != 4)
                {
                    MessageBox.Show(string.Format("\"{0}\"文件格式错误，请参考\"name/weight/width/price\"格式！", currentPath, Encoding.UTF8));
                    return;
                }
            
                fabricComboBox.Items.Add(str[0]);
                fabircWeight.Add(Convert.ToDouble(str[1]));
                fabircWidth.Add(Convert.ToDouble(str[2]));
                fabricPrice.Add(Convert.ToDouble(str[3]));
            }
        }

        private void GetRopeData()
        {
            string currentPath = AppDomain.CurrentDomain.BaseDirectory;
            currentPath += "ropes.bin";

            if (!File.Exists(currentPath))
            {
                MessageBox.Show(string.Format("文件\"{0}\"不存在！", currentPath, Encoding.UTF8));
                return;
            }

            string[] lines = File.ReadAllLines(currentPath, Encoding.UTF8);
            if (lines.Length == 0)
            {
                MessageBox.Show(string.Format("\"{0}\"内容为空，请参考\"name/price\"格式！", currentPath, Encoding.UTF8));
                return;
            }
            else
            {
                ropeWeight = new List<double>();
                ropePrice = new List<double>();
            }

            foreach (string line in lines)
            {
                string[] str = line.Split('/');
                if (str.Length != 3)
                {
                    MessageBox.Show(string.Format("\"{0}\"文件格式错误，请参考\"name/weight/price\"格式！", currentPath, Encoding.UTF8));
                    return;
                }
                ropeComboBox.Items.Add(str[0]);
                ropeWeight.Add(Convert.ToDouble(str[1]));
                ropePrice.Add(Convert.ToDouble(str[2]));
            }
        }

        private void GetShipDistanceData()
        {
            string currentPath = AppDomain.CurrentDomain.BaseDirectory;
            currentPath += "shipto.bin";

            if (!File.Exists(currentPath))
            {
                MessageBox.Show(string.Format("文件\"{0}\"不存在！", currentPath, Encoding.UTF8));
                return;
            }

            string[] lines = File.ReadAllLines(currentPath, Encoding.UTF8);
            if (lines.Length == 0)
            {
                MessageBox.Show(string.Format("\"{0}\"内容为空，请参考\"name/SF price/YD price\"格式！", currentPath, Encoding.UTF8));
                return;
            }
            else
            {
                shipSFPrice = new List<double>();
                shipYDPrice = new List<double>();
            }

            foreach (string line in lines)
            {
                string[] str = line.Split('/');
                if (str.Length != 3)
                {
                    MessageBox.Show(string.Format("\"{0}\"文件格式错误，请参考\"name/SF price/YD price\"格式！", currentPath, Encoding.UTF8));
                    return;
                }
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
                shipSFPrice.Add(Convert.ToDouble(str[1]));
                shipYDPrice.Add(Convert.ToDouble(str[2]));
            }
        }

        private void GetShipWayData()
        {
            string currentPath = AppDomain.CurrentDomain.BaseDirectory;
            currentPath += "shipways.bin";

            if (!File.Exists(currentPath))
            {
                MessageBox.Show(string.Format("文件\"{0}\"不存在！", currentPath, Encoding.UTF8));
                return;
            }

            string[] lines = File.ReadAllLines(currentPath, Encoding.UTF8);
            if (lines.Length == 0)
            {
                MessageBox.Show(string.Format("\"{0}\"内容为空，请参考\"name/price\"格式！", currentPath, Encoding.UTF8));
                return;
            }
            else
            {
                shipwayPrice = new List<double>();
            }

            foreach (string line in lines)
            {
                string[] str = line.Split('/');
                if (str.Length != 2)
                {
                    MessageBox.Show(string.Format("\"{0}\"文件格式错误，请参考\"name/price\"格式！", currentPath, Encoding.UTF8));
                    return;
                }
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

        private void tpriceTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsPunctuation(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;//消除不合适字符
            }
            else if (Char.IsPunctuation(e.KeyChar))
            {
                if (e.KeyChar != '.' || this.tpriceTextBox.Text.Length == 0)//小数点
                {
                    e.Handled = true;
                }
                if (tpriceTextBox.Text.LastIndexOf('.') != -1)
                {
                    e.Handled = true;
                }
            }
        }

        private void spriceTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsPunctuation(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;//消除不合适字符
            }
            else if (Char.IsPunctuation(e.KeyChar))
            {
                if (e.KeyChar != '.' || this.spriceTextBox.Text.Length == 0)//小数点
                {
                    e.Handled = true;
                }
                if (spriceTextBox.Text.LastIndexOf('.') != -1)
                {
                    e.Handled = true;
                }
            }
        }

        private void UpdateOutputResult()
        {
            switch (currentBottomSelectIndex)
            {
                case 0:                   // square
                    CalculateSqureOutput();
                    break;

                case 1:                   // round
                    CalculateRoundOutput();
                    break;

                case 2:                   // generic
                    CalculateGenericOutput();
                    break;

                default:
                    break;
            }
        }

        private void CalculateSqureOutput()
        {   
            var widthValue = widthTextBox2.Text;
            var lengthValue = lengthTextBox.Text;
            var heightValue = heightTextBox3.Text;
            
            if (widthValue.Equals("") || lengthValue.Equals("") || heightValue.Equals(""))
            {
                return;
            }

            double piece_width = Convert.ToDouble(lengthValue) + Convert.ToDouble(widthValue) + Width_Space * 2;
            double piece_height = Convert.ToDouble(heightValue) * 2 + Height_Space * 2 + Convert.ToDouble(lengthValue);

            CalculatePriceAndUpdateOutputContent(piece_width, piece_height);
        }

        private void CalculateRoundOutput()
        {     
            var diameterValue = diameterTextBox.Text;
            var heightValue = heightTextBox2.Text;

            if (diameterValue.Equals("") || heightValue.Equals(""))
            {
                return;
            }
          
            double piece_width = 3.141 * Convert.ToDouble(diameterValue) + Width_Space;
            double piece_height = Convert.ToDouble(heightValue) + Height_Space * 2 + configsData[(Int16)ConfigsData.Height_Space_Round_bottom_Index];

            CalculatePriceAndUpdateOutputContent(piece_width, piece_height);
        }

        private void CalculateGenericOutput()
        {
            var widthValue = widthTextBox1.Text;
            var heightValue = heightTextBox1.Text;

            if (widthValue.Equals("") || heightValue.Equals(""))
            {
                return;
            }

            double piece_width = Convert.ToDouble(widthValue) + Width_Space * 2;
            double piece_height = (Convert.ToDouble(heightValue) + Height_Space) * 2;

            CalculatePriceAndUpdateOutputContent(piece_width, piece_height);
        }

        private void ropetypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ropetypeIndex = ropetypeComboBox.SelectedIndex;
            ropeTypeIndex = Convert.ToInt16(ropetypeIndex);

            switch (ropetypeIndex)
            {
                case 0:                  //single
                    Width_Space = configsData[(Int16)ConfigsData.Width_Space_Generic_Index] / 2;
                    break;

                case 1:                  //double
                    Width_Space = configsData[(Int16)ConfigsData.Width_Space_Generic_Index];
                    break;

                default:
                    break;
            }
        }
        
        private void CalculatePriceAndUpdateOutputContent(double piece_width, double piece_height)
        {
            var totalNumber = numberTextBox.Text;        
            var ropeType = ropetypeComboBox.SelectedIndex;
            var logotPriceValue = tpriceTextBox.Text;
            var logosPriceValue = spriceTextBox.Text;        

            if (totalNumber.Equals("") || logotPriceValue.Equals("") || logosPriceValue.Equals(""))
            {
                return;
            }

            if (ropeTypeIndex.Equals(-1) || fabricTypeIndex.Equals(-1) || ropeMaterialIndex.Equals(-1)
                || shipDistanceIndex.Equals(-1) || shipWayIndex.Equals(-1))
            {
                return;
            }

            if (piece_width.CompareTo(piece_height) > 0)
            {
                double temp = piece_width;
                piece_width = piece_height;
                piece_height = temp;
            }

            // calculate the fabric output

            var TotalNumber = Convert.ToInt32(totalNumber);
            var FabricNumberUnit = fabircWidth[fabricTypeIndex] / piece_width;
            if (FabricNumberUnit.CompareTo(1) < 0)
            {
                MessageBox.Show(string.Format("袋子尺寸超过一张布料尺寸！", Encoding.UTF8));
                ClearEntryContent();
                return;
            }

            // (int)(Number /(int)(fabric_width/piece_width))*piece_height/100

            Int32 fabricNeed = Convert.ToInt32(Convert.ToInt32(TotalNumber / Convert.ToInt32(FabricNumberUnit) * piece_height) / 100);
            double fabricNeed_Weight = (TotalNumber * piece_width * piece_height / 10000) * fabircWeight[fabricTypeIndex] / 1000;
            fabricNeed_Weight = Math.Round(fabricNeed_Weight, 2, MidpointRounding.AwayFromZero);

            double fabricNeed_Price = fabricNeed * fabricPrice[fabricTypeIndex];
            fabricNeed_Price = Math.Round(fabricNeed_Price, 2, MidpointRounding.AwayFromZero);

            // update the fabric output
            fcountTextBox.Text = fabricNeed.ToString();
            fpriceTextBox.Text = fabricNeed_Price.ToString();
            fweightTextBox.Text = fabricNeed_Weight.ToString();

            double ropeNeed = 0.0;

            // rope
            switch (ropeType)
            {
                case 0:
                    ropeNeed = (piece_width + configsData[(Int16)ConfigsData.Rope_Double_Space_Index]) * 4 / 100;
                    break;

                case 1:
                    ropeNeed = (piece_width + configsData[(Int16)ConfigsData.Rope_Single_Space_Index]) * 2 / 100;
                    break;
            }

            ropeNeed = Math.Round(ropeNeed, 2, MidpointRounding.AwayFromZero);

            // calculate the rope output            
            double ropeNeed_Price = ropeNeed * ropePrice[ropeMaterialIndex];
            ropeNeed_Price = Math.Round(ropeNeed_Price, 2, MidpointRounding.AwayFromZero);

            double ropeNeed_Weight = ropeNeed * ropeWeight[ropeMaterialIndex];
            ropeNeed_Weight = Math.Round(ropeNeed_Weight, 2, MidpointRounding.AwayFromZero);

            // update the rope output
            rcountTextBox.Text = ropeNeed.ToString();
            rpriceTextBox.Text = ropeNeed_Price.ToString();
            rweightTextBox.Text = ropeNeed_Weight.ToString();

            // calculate the logo price
            double Logo_Price = (Convert.ToDouble(logotPriceValue) + Convert.ToDouble(logosPriceValue)) * Convert.ToInt32(totalNumber);
            Logo_Price = Math.Round(Logo_Price, 2, MidpointRounding.AwayFromZero);

            // calculate the total weight
            double totalWeight = fabricNeed_Weight + ropeNeed_Weight;
            totalWeight = Math.Round(totalWeight, 2, MidpointRounding.AwayFromZero);

            // calculate the ship price        
            double Ship_Price =  shipwayPrice[shipWayIndex] + currentShipPrice[shipDistanceIndex] * (totalWeight - 0.9);
            Ship_Price = Math.Round(Ship_Price, 2, MidpointRounding.AwayFromZero);

            // calculate the total price
            double Total_Price = fabricNeed_Price + ropeNeed_Price + Logo_Price + Ship_Price;
            Total_Price = Math.Round(Total_Price, 2, MidpointRounding.AwayFromZero);     

            // calculate the sale price (according to the profit, which is read from config file)
            double Sale_Price = Total_Price * (1 + configsData[(Int16)ConfigsData.Profit_ratio_Index]);
            Sale_Price = Math.Round(Sale_Price, 2, MidpointRounding.AwayFromZero);

            // calculate the invoice price (read from config file)
            double Receipt_Price = Sale_Price * (1 + configsData[(Int16)ConfigsData.Invoice_ratio_Index]);
            Receipt_Price = Math.Round(Receipt_Price, 2, MidpointRounding.AwayFromZero);

            // update the finally output
            // logo
            logopriceTextBox.Text = Logo_Price.ToString();

            // ship
            shippriceTextBox.Text = Ship_Price.ToString();

            // receipt
            receiptTextBox.Text = Receipt_Price.ToString();

            // sale
            salepriceTextBox.Text = Sale_Price.ToString();

            // total
            totalpriceTextBox.Text = Total_Price.ToString();
        }

        private void topComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var topIndex = topComboBox.SelectedIndex;

            switch (topIndex)
            {
                case 0:               //Generic
                    Height_Space = configsData[(Int16)ConfigsData.Height_Space_Generic_top_Index];
                    break;

                case 1:               //Muer
                    Height_Space = configsData[(Int16)ConfigsData.Height_Space_Muer_top_Index];
                    break;

                case 2:               //Tie
                    Height_Space = configsData[(Int16)ConfigsData.Height_Space_Tie_top_Index];
                    break;

                default:
                    break;
            }
        }

        private void fabricComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var fabricIndex = fabricComboBox.SelectedIndex;
            fabricTypeIndex = Convert.ToInt16(fabricIndex);            
        }

        private void ropeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ropeIndex = ropeComboBox.SelectedIndex;
            ropeMaterialIndex = Convert.ToInt16(ropeIndex);            
        }

        private void distanceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var distanceIndex = distanceComboBox.SelectedIndex;
            shipDistanceIndex = Convert.ToInt16(distanceIndex);            
        }

        private void shipwayComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var shipwayIndex = shipwayComboBox.SelectedIndex;
            shipWayIndex = Convert.ToInt16(shipwayIndex);

            switch (shipwayIndex)
            {
                case 0:                         //Shun Feng
                    currentShipPrice = shipSFPrice;
                    break;

                case 1:                        //Yun Da
                    currentShipPrice = shipYDPrice;
                    break;

                default:
                    break;
            }          
        }

        private void ClearEntryContent()
        {
            widthTextBox2.Text = "";
            lengthTextBox.Text = "";
            heightTextBox3.Text = "";
            diameterTextBox.Text = "";
            heightTextBox2.Text = "";
            widthTextBox1.Text = "";
            heightTextBox1.Text = "";
            rcountTextBox.Text = "";
            rpriceTextBox.Text = "";
            rweightTextBox.Text = "";
            logopriceTextBox.Text = "";                     
            shippriceTextBox.Text = "";
            receiptTextBox.Text = "";         
            salepriceTextBox.Text = "";         
            totalpriceTextBox.Text = "";
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            UpdateOutputResult();
        }

        private void SetDefaultConfigurationData()
        {
            topComboBox.SelectedIndex = 2;
            bottomComboBox.SelectedIndex = 2;
            tpriceTextBox.Text = "0";
            spriceTextBox.Text = "0";
            shipwayComboBox.SelectedIndex = 1;
        }
    }
}

using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConferenceScheduleTest
{
    public partial class Conference : Form
    {
        private List<string> origDatas;
        private List<string> moringDatas;
        private List<Int16> timeSpanDatas;
        private List<Int16> origDataIndex;

        private Int32 timeRecords = 0;
       
        public Conference()
        {
            InitializeComponent();
        }

        private void fileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                //InitialDirectory = @"C:\",
                RestoreDirectory = true,
                Filter = "Text Files(*.txt)|*.txt|All Files(*.*)|*.*",       //设置打开文件类型
                FilterIndex = 1,                
            };
            
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileTextBox.Text = openFileDialog.FileName;
            }

            FileContentParse(fileTextBox.Text);

            DataAnalysisWithoutSort();
        }

        private void FileContentParse(string fileName)
        {
            if (fileName.Equals("") || fileName.Equals(null))
            {
                MessageBox.Show(string.Format("File {0} is not exist!", fileName), "ERROR");
                return;
            }

            string [] strContent = File.ReadAllLines(fileName);
            if (strContent.Length == 0)
            {
                MessageBox.Show(string.Format("File {0} is empty!", fileName), "ERROR");
                return;
            }
            else
            {
                origDatas = new List<string>();
                timeSpanDatas = new List<Int16>();
                origDataIndex = new List<Int16>();
            }

            foreach (string str in strContent)
            {
                origDatas.Add(str);
            }

            var i = 0;
            foreach (string strline in strContent)
            {                              
                string[] strSplit = strline.Split('/');
                if (strSplit.Length != 2)
                {
                    MessageBox.Show(string.Format("File {0} format is wrong! Please follow \"Conferece Topic - Time Span", fileName), "ERROR");
                    return;
                }

                var index = strSplit[1].IndexOf("min");
                origDataIndex.Add(Convert.ToInt16(i));
                timeSpanDatas.Add(Convert.ToInt16(strSplit[1].Substring(0, index)));
                i++;
            }            
        }

        private void DataAnalysisWithoutSort()
        {
            Int16 index = 0;
            Int16 timeMinutes = 0;
            Int16 countOfTimeSpanDatas = 0;
            Int16 timeSpanMinutes = 0;
            Int16 totalTimeMinutes = 0;
            TimeSpan startTime = new TimeSpan(9, 0, 0);
            TimeSpan midTime = new TimeSpan(12, 0, 0);
            TimeSpan endTime = new TimeSpan(17, 0, 0);
            List<string> tempDatas = origDatas;

            var str = string.Format("The first data without sorting:");

            resultListBox.Items.Add(str.ToString());
                       
            //morning schedule
            //str = string.Format("{0} AM: {1}", startTime.ToString(), tempDatas[index]);
            //resultListBox.Items.Add(str.ToString());

            // based on the first item
            countOfTimeSpanDatas = (Int16)timeSpanDatas.Count;
            //timeRecords += timeSpanDatas[index];
            //timeSpanDatas.RemoveAt(index);
            //countOfTimeSpanDatas--;
            //tempDatas.RemoveAt(index);
            totalTimeMinutes = (Int16)midTime.Subtract(startTime).TotalMinutes;
            while (index < countOfTimeSpanDatas)
            {
                Int16 tempTimeSpan = timeSpanDatas[index];
                if (timeRecords >= totalTimeMinutes)
                {
                    if (timeRecords == totalTimeMinutes)
                    {
                        break;
                    }

                    timeMinutes = (Int16)midTime.Subtract(startTime).Minutes;
                    if (timeMinutes != 0)
                    {
                        if (timeSpanDatas[index] != timeMinutes)
                        {
                            index++;
                            continue;
                        }
                        else
                        {                            
                            startTime = startTime.Add(new TimeSpan(0, timeSpanMinutes, 0));                        
                            str = string.Format("{0} AM: {1}", startTime.ToString(), tempDatas[index]);
                            resultListBox.Items.Add(str.ToString());
                            timeSpanDatas.RemoveAt(index);
                            countOfTimeSpanDatas--;
                            tempDatas.RemoveAt(index);
                            timeSpanMinutes = tempTimeSpan;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    startTime = startTime.Add(new TimeSpan(0, timeSpanMinutes, 0));
                    str = string.Format("{0} AM: {1}", startTime.ToString(), tempDatas[index]);
                    resultListBox.Items.Add(str.ToString());
                    timeSpanDatas.RemoveAt(index);
                    countOfTimeSpanDatas--;
                    tempDatas.RemoveAt(index);
                    timeSpanMinutes = tempTimeSpan;
                    timeRecords += tempTimeSpan;
                }

            }
            str = string.Format("{0} PM: Lunch", midTime.ToString());
            resultListBox.Items.Add(str.ToString());

            // afternoon schedule
            index = 0;
            timeRecords = 0;
            timeSpanMinutes = 0;
            midTime = midTime.Add(new TimeSpan(1, 0, 0));           
            countOfTimeSpanDatas = (Int16)timeSpanDatas.Count;
            totalTimeMinutes = (Int16)endTime.Subtract(midTime).TotalMinutes;
            while (index < countOfTimeSpanDatas)
            {               
                if (timeRecords >= totalTimeMinutes)
                {
                    if (timeRecords == totalTimeMinutes)
                    {
                        break;
                    }

                    timeMinutes = (Int16)endTime.Subtract(midTime).Minutes;
                    if (timeMinutes != 0)
                    {
                        if (timeSpanDatas[index] != timeMinutes)
                        {
                            index++;
                            continue;
                        }
                        else
                        {
                            Int16 tempTimeSpan = timeSpanDatas[index];
                            midTime = midTime.Add(new TimeSpan(0, timeSpanMinutes, 0));                          
                            str = string.Format("{0} PM: {1}", midTime.ToString(), tempDatas[index]);
                            resultListBox.Items.Add(str.ToString());
                            timeSpanDatas.RemoveAt(index);
                            countOfTimeSpanDatas--;
                            tempDatas.RemoveAt(index);
                            timeSpanMinutes = tempTimeSpan;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    Int16 tempTimeSpan = timeSpanDatas[index];
                    midTime = midTime.Add(new TimeSpan(0, timeSpanMinutes, 0));                 
                    str = string.Format("{0} PM: {1}", midTime.ToString(), tempDatas[index]);
                    resultListBox.Items.Add(str.ToString());                  
                    timeSpanDatas.RemoveAt(index);
                    countOfTimeSpanDatas--;
                    tempDatas.RemoveAt(index);
                    timeRecords += tempTimeSpan;
                    timeSpanMinutes = tempTimeSpan;
                }
            }
           
            // End
            str = string.Format("{0} PM: Networking Event", endTime.ToString());
            resultListBox.Items.Add(str.ToString());
        }
    }
}

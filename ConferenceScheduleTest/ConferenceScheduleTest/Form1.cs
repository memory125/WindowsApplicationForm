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
        private List<Int16> timeSpanDatas;
        private List<Int16> origDataIndex;       
       
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

            // Without sorting
            DataAnalysisWithoutSort();

            // With sorting
            DataAnalysisWithSort();
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
                    MessageBox.Show(string.Format("File {0} format is wrong! Please follow \"Conferece Topic / Time Span", fileName), "ERROR");
                    return;
                }

                var index = strSplit[1].IndexOf("min");
                timeSpanDatas.Add(Convert.ToInt16(strSplit[1].Substring(0, index)));
                i++;
            }            
        }

        private void DataAnalysisWithoutSort()
        {     
            TimeSpan startTime = new TimeSpan(9, 0, 0);
            TimeSpan midTime = new TimeSpan(12, 0, 0);
            TimeSpan endTime = new TimeSpan(17, 0, 0);
            //List<string> tempDatas = origDatas;

            // Start information
            var str = string.Format("The first data without sorting:");
            resultListBox.Items.Add(str.ToString());

            // Morning schedule
            CoreDataAnalysis(startTime, midTime, origDatas);           

            // Midnoon for Lunch
            str = string.Format("{0} PM: Lunch", midTime.ToString());
            resultListBox.Items.Add(str.ToString());

            // After lunch, begin with 13 : 00
            midTime = midTime.Add(new TimeSpan(1, 0, 0));

            // Afternoon schedule
            CoreDataAnalysis(midTime, endTime, origDatas);
      
            // End information
            str = string.Format("{0} PM: Networking Event", endTime.ToString());
            resultListBox.Items.Add(str.ToString());
        }

        private void CoreDataAnalysis(TimeSpan startTime, TimeSpan endTime, List<string> dataSource)
        {
            var countOfTimeSpanDatas = 0;
            var totalTimeMinutes = 0;
            var timeSpanMinutes = 0;
            var timeMinutes = 0;
            var timeRecords = 0;
            var index = 0;
            var str = "";

            if (dataSource.Count == 0)
            {
                return;
            }
           
            countOfTimeSpanDatas = (Int16)timeSpanDatas.Count;
            totalTimeMinutes = (Int16)endTime.Subtract(startTime).TotalMinutes;
            while (index < countOfTimeSpanDatas)
            {
                Int16 tempTimeSpan = timeSpanDatas[index];
                if (timeRecords >= totalTimeMinutes)
                {
                    if (timeRecords == totalTimeMinutes)
                    {
                        break;
                    }

                    timeMinutes = (Int16)endTime.Subtract(startTime).Minutes;
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
                            if (startTime.CompareTo(new TimeSpan(12, 0, 0)) > 0)
                            {
                                str = string.Format("{0} PM: {1}", startTime.ToString(), dataSource[index]);
                            }
                            else
                            {
                                str = string.Format("{0} AM: {1}", startTime.ToString(), dataSource[index]);
                            }
                            resultListBox.Items.Add(str.ToString());
                            timeSpanDatas.RemoveAt(index);
                            if (timeSpanDatas.Count == 0)
                            {
                                break;
                            }
                            countOfTimeSpanDatas--;
                            dataSource.RemoveAt(index);
                            if (dataSource.Count == 0)
                            {
                                break;
                            }
                            timeSpanMinutes = tempTimeSpan;
                            //RecordInformation(startTime, (Int16)timeSpanMinutes, (Int16)index, dataSource);
                            //countOfTimeSpanDatas--;                       
                            //timeSpanMinutes = tempTimeSpan;
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
                    if (startTime.CompareTo(new TimeSpan(12, 0, 0)) > 0)
                    {
                        str = string.Format("{0} PM: {1}", startTime.ToString(), dataSource[index]);
                    }
                    else
                    {
                        str = string.Format("{0} AM: {1}", startTime.ToString(), dataSource[index]);
                    }
                    resultListBox.Items.Add(str.ToString());
                    timeSpanDatas.RemoveAt(index);
                    if(timeSpanDatas.Count == 0)
                    {
                        break;
                    }
                    countOfTimeSpanDatas--;
                    dataSource.RemoveAt(index);
                    if (dataSource.Count == 0)
                    {
                        break;
                    }
                    timeSpanMinutes = tempTimeSpan;
                    //RecordInformation(startTime, (Int16)timeSpanMinutes, (Int16)index, dataSource);
                    //countOfTimeSpanDatas--;
                    //timeSpanMinutes = tempTimeSpan;
                    timeRecords += tempTimeSpan;
                }
            }
        }

        //private void RecordInformation(TimeSpan startTime, Int16 timeSpan, Int16 currentIndex, List<string> dataSource)
        //{
        //    var str = "";
        //    startTime = startTime.Add(new TimeSpan(0, timeSpan, 0));
        //    if (startTime.CompareTo(new TimeSpan(12, 0, 0)) > 0)
        //    {
        //        str = string.Format("{0} PM: {1}", startTime.ToString(), dataSource[currentIndex]);
        //    }
        //    else
        //    {
        //        str = string.Format("{0} AM: {1}", startTime.ToString(), dataSource[currentIndex]);
        //    }
        //    resultListBox.Items.Add(str.ToString());
        //    timeSpanDatas.RemoveAt(currentIndex);
        //    //countOfTimeSpanDatas--;
        //    dataSource.RemoveAt(currentIndex);
        //    //timeSpanMinutes = tempTimeSpan;
        //}

        private void DataAnalysisWithSort()
        {
            origDatas.Sort();

            var i = 0;

            //clear the timeSpanDatas List
            //for (; i < timeSpanDatas.Count; i++)
            //{
            //    timeSpanDatas.RemoveAt(i);
            //}
            timeSpanDatas.Clear();

            for (; i< origDatas.Count; i++)
            {
                string[] strSplit = origDatas[i].Split('/');
                if (strSplit.Length != 2)
                {
                    MessageBox.Show(string.Format("Content format is wrong! Please follow \"Conferece Topic / Time Span"), "ERROR");
                    return;
                }



                var index = strSplit[1].IndexOf("min");
                timeSpanDatas.Add(Convert.ToInt16(strSplit[1].Substring(0, index)));
                i++;
            }

            TimeSpan startTime = new TimeSpan(9, 0, 0);
            TimeSpan midTime = new TimeSpan(12, 0, 0);
            TimeSpan endTime = new TimeSpan(17, 0, 0);
            //List<string> tempDatas = origDatas;

            // Start information
            var str = string.Format("The second data with sorting:");
            resultListBox.Items.Add(str.ToString());

            // Morning schedule
            CoreDataAnalysis(startTime, midTime, origDatas);

            // Midnoon for Lunch
            str = string.Format("{0} PM: Lunch", midTime.ToString());
            resultListBox.Items.Add(str.ToString());

            // After lunch, begin with 13 : 00
            midTime = midTime.Add(new TimeSpan(1, 0, 0));

            // Afternoon schedule
            CoreDataAnalysis(midTime, endTime, origDatas);

            // End information
            str = string.Format("{0} PM: Networking Event", endTime.ToString());
            resultListBox.Items.Add(str.ToString());
        }
    }
}
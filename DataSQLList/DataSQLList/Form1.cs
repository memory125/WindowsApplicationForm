using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataSQLList
{
    public partial class DataSQLList : Form
    {
        public DataSQLList()
        {
            InitializeComponent();
            this._listView.Columns.Add("ID");
            this._listView.Columns.Add("Name");
            this._listView.Columns.Add("Age");
            this._listView.Columns.Add("Salary");
            this._listView.Columns.Add("Address");
            this._listView.View = System.Windows.Forms.View.Details;
        }

        private void _queryButton_Click(object sender, EventArgs e)
        {
            MySqlConnection myconn = null;
            MySqlCommand mycom = null;
            myconn = new MySqlConnection("Host =localhost;Database=mysqltest;Username=root;Password=123456");
            myconn.Open();
            mycom = myconn.CreateCommand();
            mycom.CommandText = "SELECT * FROM employee";
            MySqlDataAdapter adap = new MySqlDataAdapter(mycom);
            DataSet ds = new DataSet();
            adap.Fill(ds);
            _dataGridView.DataSource = ds.Tables[0].DefaultView;
            string sql = string.Format("SELECT * FROM employee");
            mycom.CommandText = sql;
            mycom.CommandType = CommandType.Text;
            MySqlDataReader sdr = mycom.ExecuteReader();
            int i = 0;
            var fieldCount = sdr.FieldCount;
            while (sdr.Read())
            {
                _listView.Items.Add(sdr[0].ToString());
                _listView.Items[i].SubItems.Add(sdr[1].ToString());
                _listView.Items[i].SubItems.Add(sdr[2].ToString());
                _listView.Items[i].SubItems.Add(sdr[3].ToString());
                _listView.Items[i].SubItems.Add(sdr[4].ToString());
                i++;
            }
            myconn.Close();
        }      
    }
}

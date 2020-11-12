using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.OleDb;

namespace cheque_system
{
    public partial class add_item : Form
    {
        OleDbConnection sc = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\db\cheque_system.mdb");
        DataSet ds = new DataSet();
        public add_item()
        {
            InitializeComponent();
        }
        string itemid()
        {
            sc.Open();
            string qry = "SELECT COUNT (*) FROM item";
            //  SqlCommand cmd = new SqlCommand(qry, sc);
            OleDbCommand cmd = new OleDbCommand(qry, sc);
            int a = 00001 + (Int32)cmd.ExecuteScalar();
            string reg = "" + a.ToString();
            sc.Close();
            return (reg);

        }
        private void button1_Click(object sender, EventArgs e)
        {
            sc.Open();
            OleDbCommand cmd = new OleDbCommand("insert into item (item_id,item_name) values(@item_id,@item_name)", sc);
            cmd.Parameters.AddWithValue("@item_id", label3.Text);
            cmd.Parameters.AddWithValue("@item_name", textBox1.Text);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Saved!");
            sc.Close();

        }

        private void add_item_Load(object sender, EventArgs e)
        {
            label3.Text = itemid();
        }
    }
}

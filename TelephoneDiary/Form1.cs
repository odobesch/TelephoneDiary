using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TelephoneDiary
{
    public partial class Form1 : Form
    {
        //SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Projects\\TelephoneDiary\\TelephoneDiary\\Phone.mdf;Integrated Security=True;Connect Timeout=30");
        List<Person> people = new List<Person>();

        public Form1()
        {
            InitializeComponent();
            //dataGridView1.DataSource = people;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        internal void ClearTextBoxes()
        {
            tbFirstName.Text = "";
            tbLastName.Text = "";            
            tbEmail.Text = "";
            tbMobile.Text = "";
            cbCategory.SelectedIndex = -1;
            tbFirstName.Focus();
            
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            //conn.Open();
            //SqlCommand cmd = new SqlCommand(
            //    @"INSERT INTO Mobiles
            //    (First, Last, Mobile, Email, Category) 
            //    VALUES ('"+ tbFirstName.Text + "','"+ tbLastName.Text + "','"+ tbMobile.Text + "','"+ tbEmail.Text + "','"+ cbCategory.Text + "')", 
            //    conn           
            //    );
            //cmd.ExecuteNonQuery();
            //conn.Close();
            //MessageBox.Show("Contact SAVED successfully");

            DataAccess data = new DataAccess();
            data.InsertPeople(tbFirstName.Text, tbLastName.Text, tbMobile.Text, tbEmail.Text, cbCategory.Text);

            DisplayData();
            ClearTextBoxes();
        }

        void DisplayData() 
        {
            DataAccess data = new DataAccess();
            people = data.GetPeople();
            
            //SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Mobiles", conn);
            //DataTable dt = new DataTable();
            //sda.Fill(dt);
            
            dataGridView1.Rows.Clear();

            foreach (Person item in people)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item.First;
                dataGridView1.Rows[n].Cells[1].Value = item.Last;
                dataGridView1.Rows[n].Cells[2].Value = item.Mobile;
                dataGridView1.Rows[n].Cells[3].Value = item.Email;
                dataGridView1.Rows[n].Cells[4].Value = item.Category;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            tbFirstName.Text =  dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            tbLastName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            tbMobile.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            tbEmail.Text =  dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            cbCategory.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //conn.Open();
            //SqlCommand cmd = new SqlCommand(
            //    @"DELETE FROM Mobiles
            //    WHERE (Mobile = '" + tbMobile + "')",
            //    conn
            //    );
            //cmd.ExecuteNonQuery();
            //conn.Close();
            //MessageBox.Show("Contact DELETED successfully");

            DataAccess data = new DataAccess();
            data.DeletePeople(tbMobile.Text);

            DisplayData();
            ClearTextBoxes();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //conn.Open();
            //SqlCommand cmd = new SqlCommand(
            //    @"UPDATE Mobiles
            //    SET First='"+ tbFirstName.Text +"', Last='" + tbLastName.Text +"', Mobile ='"+ tbMobile.Text +"' , " +
            //    "Email= '" + tbEmail.Text+ "', Category ='" +cbCategory.Text+ "' WHERE (Mobile = '" + tbMobile.Text + "')",
            //    conn);
            //cmd.ExecuteNonQuery();
            //conn.Close();

            //MessageBox.Show("Contact UPDATED successfully");
            DataAccess data = new DataAccess();
            data.UpdatePeople(tbFirstName.Text, tbLastName.Text, tbMobile.Text, tbEmail.Text, cbCategory.Text);

            DisplayData();
            ClearTextBoxes();
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            //SqlDataAdapter sda = new SqlDataAdapter("Select * From Mobiles Where (Mobile like '%"+ tbMobile.Text +"%') or (Last like '%"+tbLastName.Text+"%')", conn);            
            //DataTable dt = new DataTable();
            //sda.Fill(dt);

            dataGridView1.Rows.Clear();

            DataAccess data = new DataAccess();
            people = data.SearchPeople(tbMobile.Text, tbLastName.Text);

            foreach (Person item in people)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item.First;
                dataGridView1.Rows[n].Cells[1].Value = item.Last;
                dataGridView1.Rows[n].Cells[2].Value = item.Mobile;
                dataGridView1.Rows[n].Cells[3].Value = item.Email;
                dataGridView1.Rows[n].Cells[4].Value = item.Category;
            }
        }
    }
}

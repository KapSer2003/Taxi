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

namespace Taxi.Areas.Admin
{
    public partial class AddEmpl : Form
    {
        int row;
        int idPost;
        int idAdrReg;
        public AddEmpl()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            row = dataGridView1.CurrentCell.RowIndex;
            idPost = (int)dataGridView1[0, row].Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addEmpl();
        }

        private void AddEmpl_Load(object sender, EventArgs e)
        {
            string CommandText = "select * from Post";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(CommandText, Data.ConnectionString);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds, "[Post]");
            dataGridView1.DataSource = ds.Tables["[Post]"].DefaultView;

            dataGridView1.Columns[0].Visible = false;
        }

        private void addEmpl()
        {
            GenKey();
            SqlConnection con = new SqlConnection(Data.ConnectionString);
            SqlCommand addPas = new SqlCommand("insert into Pasport (Seriya, Number, Surname, Name, MiddleName, BirthDay) " +
                $"values ('{maskedTextBox1.Text}', '{maskedTextBox2.Text}', '{textBox1.Text}', '{textBox2.Text}', '{textBox3.Text}', '{maskedTextBox3.Text}')", con);
            SqlCommand addAdr = new SqlCommand("insert into AddressRegistration (ID, PostalIndex, Country, Region, District, Locality, Street, House, Corpuse, Flat)" +
                $"values ({idAdrReg}, '{maskedTextBox4.Text}', '{textBox4.Text}', '{textBox5.Text}', '{textBox6.Text}', " +
                $"'{textBox7.Text}', '{textBox8.Text}', {(int)numericUpDown1.Value}, {(int)numericUpDown2.Value}, {(int)numericUpDown3.Value})", con);
            SqlCommand addEm = new SqlCommand("insert into Employee (Seriya, Number, Address, PhoneNumber, IDPost) " +
                $"Values ('{maskedTextBox1.Text}', '{maskedTextBox2.Text}', {idAdrReg}, '{maskedTextBox5.Text}', {idPost})", con);

            try
            {
                con.Open();
                addPas.ExecuteNonQuery();
                addAdr.ExecuteNonQuery();
                addEm.ExecuteNonQuery();
                MessageBox.Show("Данные добавлены!");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Дабавление:\n" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void GenKey()
        {
            SqlConnection con = new SqlConnection(Data.ConnectionString);
            SqlCommand com = new SqlCommand("select max(ID) from AddressRegistration", con);

            try
            {
                con.Open();
                SqlDataReader reader = com.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        idAdrReg = (int)reader.GetValue(0);
                    }

                    idAdrReg += 1;
                }
                else
                {
                    idAdrReg = 1;
                }
            }
            catch
            {

            }
            finally
            {
                con.Close();
            }
        }
    }
}

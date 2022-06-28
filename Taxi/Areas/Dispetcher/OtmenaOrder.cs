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

namespace Taxi.Areas.Dispetcher
{
    public partial class OtmenaOrder : Form
    {
        int row;
        public OtmenaOrder()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelOrder();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы действительно хотите отменить данную заявку?", "Отмена заявки", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                UpdateOrders();
                SelOrder();
            }
        }

        private void UpdateOrders()
        {
            SqlConnection con = new SqlConnection(Data.ConnectionString);
            SqlCommand com = new SqlCommand($"update Orders set Status = 'Отменена' where ID = {(int)dataGridView1[0, row].Value}", con);

            try
            {
                con.Open();
                com.ExecuteNonQuery();
                MessageBox.Show("Заявка успешно отменена!");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Отмена:\n" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SelOrder();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            row = dataGridView1.CurrentCell.RowIndex;
        }

        private void SelOrder()
        {
            string CommandText = "select " +
                "ID as 'Номер заявки', " +
                "PhoneNumberClient as 'Номер клиента', " +
                "IDRate as 'Тариф', " +
                "Status as 'Статус заявки' " +
                "from " +
                "Orders " +
                "where " +
                "(Status = 'На выполнении') ";

            if (numericUpDown1.Value != 0)
            {
                CommandText += $"and (ID = {numericUpDown1.Value})";
            }
            SqlDataAdapter dataAdapter = new SqlDataAdapter(CommandText, Data.ConnectionString);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds, "[Orders]");
            dataGridView1.DataSource = ds.Tables["[Orders]"].DefaultView;
        }

        private void OtmenaOrder_Load(object sender, EventArgs e)
        {
            SelOrder();
        }
    }
}

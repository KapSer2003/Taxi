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
    public partial class MainMenu : Form
    {
        int row;
        public MainMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new AddOrder().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new OtmenaOrder().ShowDialog();
        }

        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Data.autarization.Show();
        }

        private void MainMenu_Load(object sender, EventArgs e)
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
                "Orders";

            
            SqlDataAdapter dataAdapter = new SqlDataAdapter(CommandText, Data.ConnectionString);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds, "[Orders]");
            dataGridView1.DataSource = ds.Tables["[Orders]"].DefaultView;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SelOrder();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы действительно хотите удалить отменённые заявки?", "Удаление", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection(Data.ConnectionString);
                SqlCommand command = new SqlCommand("delete from Orders where Status = 'Отменена'", con);
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
                SelOrder();
            }
        }
    }
}

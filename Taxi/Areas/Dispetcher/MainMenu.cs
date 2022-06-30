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
                "Orders.ID as 'Номер заявки', " +
                "Orders.PhoneNumberClient as 'Номер клиента', " +
                "Orders.IDRate as 'Тариф', " +
                "Orders.Status as 'Статус заявки', " +
                "Orders.Price as 'Цена поездки', " +
                "Car.ID, " +
                "Car.Number as 'Номер авто', " +
                "Car.Region as 'Регион', " +
                "Car.Brand as 'Марка', " +
                "Car.Model as 'Модель', " +
                "Car.Status as 'Статус авто' " +
                "from " +
                "Orders inner join Car on Orders.IDDriver = Car.ID";

            if (radioButton1.Checked == true)
            {
                CommandText += $" where Orders.Status = '{radioButton1.Text}'";
            }
            if (radioButton2.Checked == true)
            {
                CommandText += $" where Orders.Status = '{radioButton2.Text}'";
            }
            if (radioButton3.Checked == true)
            {
                CommandText += $" where Orders.Status = '{radioButton3.Text}'";
            }
            SqlDataAdapter dataAdapter = new SqlDataAdapter(CommandText, Data.ConnectionString);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds, "[Orders]");
            dataGridView1.DataSource = ds.Tables["[Orders]"].DefaultView;
            dataGridView1.Columns[5].Visible = false;
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

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы действительно хотите завершить заявку?", "Завершение заявки", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                UpdateOrderAndCar();
            }
        }

        private void UpdateOrderAndCar()
        {
            dataGridView1.Columns[5].Visible = true;
            SqlConnection con = new SqlConnection(Data.ConnectionString);
            SqlCommand upOrder = new SqlCommand($"update Orders set Status = 'Завершена' where ID = {dataGridView1[0, row].Value}", con);
            SqlCommand upCar = new SqlCommand($"update Car set Status = 'Свободен' where ID = {dataGridView1[5, row].Value}", con);

            try
            {
                con.Open();
                upOrder.ExecuteNonQuery();
                upCar.ExecuteNonQuery();
                dataGridView1.Columns[5].Visible = false;
                MessageBox.Show("Заявка успешно закрыта!");
                SelOrder();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Update status`s order and car:\n" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            SelOrder();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            SelOrder();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            SelOrder();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Data.idOrder = (int)dataGridView1[0, row].Value;
            new Otchet().ShowDialog();
        }
    }
}

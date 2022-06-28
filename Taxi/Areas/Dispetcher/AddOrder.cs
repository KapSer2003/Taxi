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
    public partial class AddOrder : Form
    {
        int row;
        int idDriver;
        int price = 0;
        int bagazh;
        int zhivotnoe;
        string idRate;
        int? orderID;
        public AddOrder()
        {
            InitializeComponent();
            price_lb.Text = "Цена: " + price.ToString();
        }

        private void AddOrder_Load(object sender, EventArgs e)
        {
            SelCar();
        }

        private void car_dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            row = car_dgv.CurrentCell.RowIndex;
            idDriver = (int)car_dgv[4, row].Value;
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            AddOrders(Data.ConnectionString);
        }

        private void refresh_btn_Click(object sender, EventArgs e)
        {
            SelCar();
        }

        private void econom_rb_CheckedChanged(object sender, EventArgs e)
        {
            SelCar();
            SqlConnection con = new SqlConnection(Data.ConnectionString);
            SqlCommand com = new SqlCommand($"select PriceCity, Bagezh, Zhivotnoe from Rate where Name = '{econom_rb.Text}'", con);
            SqlDataReader reader;

            try
            {
                con.Open();
                reader = com.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        price = (int)reader.GetValue(0);
                        bagazh = (int)reader.GetValue(1);
                        zhivotnoe = (int)reader.GetValue(2);
                        idRate = econom_rb.Text;
                    }
                    price_lb.Text = "Цена: " + price.ToString();

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Считывание цен:\n" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void comfort_rb_CheckedChanged(object sender, EventArgs e)
        {
            SelCar();
            SqlConnection con = new SqlConnection(Data.ConnectionString);
            SqlCommand com = new SqlCommand($"select PriceCity, Bagezh, Zhivotnoe from Rate where Name = '{comfort_rb.Text}'", con);
            SqlDataReader reader;

            try
            {
                con.Open();
                reader = com.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        price = (int)reader.GetValue(0);
                        bagazh = (int)reader.GetValue(1);
                        zhivotnoe = (int)reader.GetValue(2);
                        idRate = comfort_rb.Text;
                    }
                    price_lb.Text = "Цена: " + price.ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Считывание цен:\n" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void bagazh_cb_CheckedChanged(object sender, EventArgs e)
        {
            
            if (bagazh_cb.Checked == true)
            {
                price += bagazh;
                price_lb.Text = "Цена: " + price.ToString();
                
            }
            else
            {
                    price -= bagazh;
                    price_lb.Text = "Цена: " + price.ToString();
            }
        }

        private void zivotnoe_cb_CheckedChanged(object sender, EventArgs e)
        {
            
            if (zivotnoe_cb.Checked == true)
            {
                price += zhivotnoe;
                price_lb.Text = "Цена: " + price.ToString();
               
            }
            else
            {
                    price -= zhivotnoe;
                    price_lb.Text = "Цена: " + price.ToString();      
            }
        }

        private void SelCar()
        {
            string CommandText = "select " +
                "[Car].[Number] as 'Номер', " +
                "[Car].[Region] as 'Регион', " +
                "[Car].[Brand] as 'Марка', " +
                "[Car].[Model] as 'Модель', " +
                "[Car].[IDdriver], " +
                "[Car].[ComfortClass] as 'Класс комфорта', " +
                "[Car].[Status] as 'Статус' " +
                "from " +
                "[Car] " +
                "where " +
                "([Car].[Status] = 'Свободен') ";
            
            if (econom_rb.Checked == true)
            {
                CommandText += $"and ([Car].[ComfortClass] = '{econom_rb.Text}')";
            }
            if (comfort_rb.Checked == true)
            {
                CommandText += $"and ([Car].[ComfortClass] = '{comfort_rb.Text}')";
            }

            SqlDataAdapter dataAdapter = new SqlDataAdapter(CommandText, Data.ConnectionString);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds, "[Car]");
            car_dgv.DataSource = ds.Tables["[Car]"].DefaultView;

            car_dgv.Columns[4].Visible = false;
        }

        private void AddOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void AddOrders(string ConnectionString)
        {
            GenerKey();
            SqlConnection con = new SqlConnection(ConnectionString);
            
            SqlCommand addOrd = new SqlCommand("insert into Orders (ID, IDDriver, PhoneNumberClient, IDRate, Status, Price) " +
                $"Values ({orderID}, {idDriver}, '{maskedTextBox1.Text}', '{idRate}', 'На выполнении', {price})", con);

            SqlCommand addAdr = new SqlCommand("insert into DestinationAddress (IDOrders, Status, Locality, Street, House, Corpuse, Entrance) " +
                "Values " +
                $"({orderID}, 'Откуда', '{localityN_tb.Text}', '{streetN_tb.Text}', {(int)houseN_nud.Value}, {(int)corpusN_nud.Value}, {(int)podezdN_nud.Value})", con);

            SqlCommand addAdrk = new SqlCommand("insert into DestinationAddress (IDOrders, Status, Locality, Street, House, Corpuse, Entrance) " +
                "Values " +
                $"({orderID}, 'Куда', '{localityK_tb.Text}', '{streetK_tb.Text}', {(int)houseK_nud.Value}, {(int)corpusK_nud.Value}, {(int)podezdK_nud.Value})", con);

            try
            {
                con.Open();
                addOrd.ExecuteNonQuery();
                addAdr.ExecuteNonQuery();
                addAdrk.ExecuteNonQuery();
                MessageBox.Show("Данные успешно добавлены");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Добавление:\n" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void GenerKey()
        {
            string ds;
            SqlConnection con = new SqlConnection(Data.ConnectionString);
            SqlCommand com = new SqlCommand("select max(ID) from Orders", con);

            try
            {
                con.Open();
                SqlDataReader reader = com.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        orderID = (int?)reader.GetValue(0);
                    }
                    
                    orderID += 1;
                }
                else
                {
                    orderID = 1;
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

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

namespace Taxi
{
    public partial class Autarization : Form
    {
        bool IsAutoriz = false;
        int? idPost;

        public Autarization()
        {
            InitializeComponent();
            Data.autarization = this;
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            Auteriz(Data.ConnectionString);
            if(IsAutoriz == true)
            {
                DifinitionPost(Data.ConnectionString);
                if(idPost == 1)
                {
                    new Areas.Admin.MainMenu().Show();
                    ClearTB();
                    this.Hide();
                }
                if (idPost == 2)
                {
                    new Areas.Dispetcher.MainMenu().Show();
                    ClearTB();
                    this.Hide();
                }
            }
        }

        private void Auteriz(string ConnectionString)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand com = new SqlCommand($"Select IDEmployee from Autorization where Login = '{login_tb.Text}' and Password = '{pass_tb.Text}'", con);
            SqlDataReader reader;
            try
            {
                con.Open();
                reader = com.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Data.AutorizEmp = (int?)reader.GetValue(0);
                        IsAutoriz = true;
                    }
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль!\nПроверьте ввёдёные данные и повторите попытку!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Авторизация:\n" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void DifinitionPost(string ConnectionString)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand com = new SqlCommand($"Select IDPost from Employee where ID = '{Data.AutorizEmp}'", con);
            SqlDataReader reader;
            try
            {
                con.Open();
                reader = com.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        idPost = (int?)reader.GetValue(0);
                    }
                }
                else
                {
                    MessageBox.Show("ненайден данные сотрудник");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Авторизация:\n" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    
        private void ClearTB()
        {
            login_tb.Text = "";
            pass_tb.Text = "";
        }
    }
}

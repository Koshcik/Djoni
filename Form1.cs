
using Microsoft.VisualBasic.ApplicationServices;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using Timer = System.Windows.Forms.Timer;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Numerics;

namespace Djoni
{
    public partial class Form1 : Form
    {
        int i = 0;
        BigInteger rol = 0;
        Timer timer = new Timer();
        DataBase dataBase = new DataBase();

        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }
        public bool CheckNumslnName(string str)
        {
            throw new NotImplementedException();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataBase.GetConnection().Open();
            var roles = label2.Text;
            var loginUser = textBox1.Text;
            var passUser = textBox2.Text;
            label1.Text = string.Format("", i++);
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string querystring = $"select id,id_roles,login_user, pass from users where login_user = '{loginUser}' and pass = '{passUser}'";
            SqlCommand command = new SqlCommand(querystring, dataBase.GetConnection());
            
            adapter.SelectCommand = command;
            adapter.Fill(table);
            SqlDataReader reader = command.ExecuteReader();
            
            if (table.Rows.Count == 1)
            {
                while (reader.Read())
                {
                    rol = reader.GetInt64(1);
                }
                reader.Close();
                dataBase.GetConnection().Close();
                if (rol == 1)
                {
                    MessageBox.Show("Авторизация завершена успешно", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form2 fr = new Form2();
                    this.Hide();
                    fr.ShowDialog();
                    this.Show();
                    timer.Stop();
                    button1.Enabled = true;
                    return;
                    //dataBase.GetConnection().Close();
                    //reader.Close();
                }
                else
                {
                    MessageBox.Show("Авторизация завершена успешно", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form3 fr = new Form3();
                    this.Hide();
                    fr.ShowDialog();
                    this.Show();
                    timer.Stop();
                    button1.Enabled = true;
                    return;
                }
                //dataBase.GetConnection().Close();
                //reader.Close();
            }


             if (i == 2)
             {
                    MessageBox.Show("Такого аккаунта не существует еще 2 попытки", "Аккаунта не существует", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
             }
            //reader.Close();
            //dataBase.GetConnection().Close();
            if (i == 3)
                {
                    MessageBox.Show("Такого аккаунта не существует еще 1 попытки", "Аккаунта не существует", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                }
                else if (i >= 4)
                {

                    MessageBox.Show("Такого аккаунта не существует 10c блокировки", "Аккаунта не существует", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    timer.Interval = 10000; // here time in milliseconds
                    timer.Tick += timer_Tick;
                    timer.Start();
                    button1.Enabled = false;
                    Form2 frm1 = new Form2();
                    this.Hide();
                    frm1.ShowDialog();
                    this.Show();

                }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
            textBox2.MaxLength = 50;
            textBox1.MaxLength = 50;
        }
        void timer_Tick(object sender, EventArgs e)
        {
            button1.Enabled = true;
            timer.Stop();
        }
       

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Djoni
{
    public partial class Form2 : Form
    {
        private string resut = "";
        string res;
        DataBase dataBase = new DataBase();
        Image result;
        DataTable tovar;
        int counter;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dataBase.openConnection();

            var reader = new SqlCommand("select * from tovar", dataBase.GetConnection()).ExecuteReader();

            tovar = new DataTable();
            tovar.Load(reader);

            counter = 0;

            GetData(counter);
        }
        public void GetData(int counter)
        {
           
                label1.Text = tovar.Rows[counter][1].ToString();
            

    }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // задаем текст для печати
            resut = label1.Text;

            

            // объект для печати
            PrintDocument printDocument = new PrintDocument();

            // обработчик события печати
            printDocument.PrintPage += PrintPageHandler;

            // диалог настройки печати
            PrintDialog printDialog = new PrintDialog();

            // установка объекта печати для его настройки
            printDialog.Document = printDocument;

            // если в диалоге было нажато ОК
            if (printDialog.ShowDialog() == DialogResult.OK)
                printDialog.Document.Print(); // печатаем
        }
        void PrintPageHandler(object sender, PrintPageEventArgs e)
        {
            // печать строки result
            e.Graphics.DrawString(resut, new Font("Arial", 14), Brushes.Black, 0, 0);
        }
    }
}

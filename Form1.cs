using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


// "==" - не равен

namespace Справочник
{
    public struct люди   //создание структуры
    {
        public string name;
        public string number;
    }

    public partial class Form1 : Form
    {
        List<люди> l = new List<люди>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //кнопка добавить
        {
            Form2 s = new Form2(); //создание переменной
            s.Show();
        }

        private void button2_Click(object sender, EventArgs e) //кнопка открыть
        {
            StreamReader sr = new StreamReader("D:\\Справочник.txt");
            string b;
            while ((b= sr.ReadLine()) != null)
            {
                люди A;
                A.name = b;
                A.number = sr.ReadLine();
                l.Add(A);
            }
            sr.Close();
        }

        private void button5_Click(object sender, EventArgs e) //кнопка очистить
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button6_Click(object sender, EventArgs e) //кнопка закрыть
        {
            Close();
        }

        int find(string s)
        {
            for (int i = 0; i < l.Count; i++)
                if (l[i].name.Equals(s))
                    return i;

            return -1;
        }

        private void button4_Click(object sender, EventArgs e) //кнопка изменить
        {
            if((textBox1.Text == "")||(textBox2.Text == ""))    // Text - сво-во
            {
                MessageBox.Show("Данные некорректны. \n" + "Необходимо заполнить оба поля" , "Справочник", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                люди A;
                A.name = textBox1.Text;
                A.number = textBox2.Text;
                int x = find(A.name);
                if (x == -1)
                {
                    l.Add(A);
                    textBox1.Text = "";
                    textBox2.Text = "";
                    MessageBox.Show("Внесения зафиксированы");
                }
                else
                {
                    MessageBox.Show("Контакт не может быть продублирован");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e) //кнопка поиск
        {
            string s = textBox1.Text;
            int x = find(s);
            if (x != -1)
                textBox2.Text = l[x].number;
            else
                MessageBox.Show("Контакт не найдет");
        }

        private void button7_Click(object sender, EventArgs e) //кнопка удалить
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e) //поле имени абонента
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e) //поле номера телефонного абонента 
        {

        }
    }
}

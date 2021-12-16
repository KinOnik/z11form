using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        class myStr
        {
            //a	Поля
            private StringBuilder Line;
            private int n;

            //b	Конструктор, позволяющий создать строку из n символов.
            public myStr(string bufstr, int bufN)
            {
                Line = new StringBuilder(bufstr);
                if (Line.Length < bufN)
                {
                    n = Line.Length;
                }
                else
                {
                    n = bufN;
                }
                Line.Remove(n, Line.Length - n);
            }
            public myStr(string bufstr)
            {
                Line = new StringBuilder(bufstr);
                n = Line.Length;

                Line.Remove(n, Line.Length - n);
            }

            //c Методы, позволяющие:
            //	1 подсчитать количество пробелов в строке;
            public int countSpace()
            {
                int buf = 0;
                for (int i = 0; i < n; i++)
                {
                    if (Line[i] == ' ')
                    {
                        buf++;
                    }
                }
                return buf;
            }


            //	2 заменить в строке все прописные символы на строчные;
            public void goToUpper()
            {
                Line.Replace(Line.ToString(), Line.ToString().ToUpper());
            }


            //	3 удалить из строки все знаки препинания.
            public void deleteSymbol()
            {
                char[] buf = { '.', ',', '!', '?', ':', ';', '\\', '\'', '\"', '(', ')', '&', '*', '`', '[', ']', '{', '}', '|', '`' };
                for (int i = 0; i < buf.Length; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (Line[j] == buf[i])
                        {
                            Line.Remove(j, 1);
                            n--;
                        }
                    }
                }
            }


            //d свойства
            public int N
            {
                get
                {
                    return Line.Length;
                }
            }

            public string Lines
            {
                get
                {
                    return Line.ToString();
                }
                set
                {
                    Line = new StringBuilder(value);
                    n = Line.Length;
                }
            }

            //вывод, для проверки строки
            public string printMyStr()
            {
                return ($"\n\t{Line.ToString()}\n");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            myStr str = new myStr("Это игра, она старая. О ней не говорят уже очень долгое время! Да?", 20);

            richTextBox1.Text = ($"\n\tИзначальная строка ({str.N} символов): {str.printMyStr()}");
            int cSpace = str.countSpace();
            richTextBox1.Text += ($"\n\tКоличество пробелов в строке: {cSpace}\n");

            str.goToUpper();
            richTextBox1.Text += ($"\n\tИзмененная строка(все буквы строчные): {str.printMyStr()}");

            str.deleteSymbol();
            richTextBox1.Text += ($"\n\tИзмененная строка(удалить все знаки препинания):{str.printMyStr()}");

            richTextBox1.Text += ($"\n\t Количество элементов в строке: {str.N}\n\n");

            str.Lines = "Та самая строка из свойств";

            richTextBox1.Text += ($"\n\tСтрока записанная через свойства: \n\t\t{str.Lines}\n\tКоличество элементов в новой строке: {str.N}\n\n");

        }
    }
}

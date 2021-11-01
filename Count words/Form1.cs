using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Count_words
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                String path = openFileDialog.FileName;
                filetxttxt.Text = File.ReadAllText(path);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            filetxttxt.Clear();
        }

        private void createwordlistbtn_Click(object sender, EventArgs e)
        {
            string[] allwords = filetxttxt.Text.Split(' ',',','-','.');
            foreach (string word in allwords)
            {
                if (!listBox1.Items.Contains(word.Trim()))
                {
                    if(word.Trim() =="" || word.Trim() ==" ")
                    {
                        continue;

                    }
                    else { 
                        listBox1.Items.Add(word.Trim());
                    }
                    
                }
            }
        }

        private void sortwordlistbtn_Click(object sender, EventArgs e)
        {
            listBox1.Sorted = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string allwords = filetxttxt.Text;
            string[] words = allwords.Split(' ', ',', '-', '.');
            List<WordCounter> wordcounter = new List<WordCounter>();
            foreach (string w in words)
            {
               WordCounter theword =  wordcounter.Find(x => x.word == w);

                if(theword != null)
                {
                    theword.count ++;
                }
                else
                {
                    wordcounter.Add(new WordCounter(w,1));
                }

            }
            listView1.Columns.Add("word", 100);
            listView1.Columns.Add("Ferquant", 70);
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;

            foreach (WordCounter item in wordcounter)
            {
                string[] word = new string[] { item.word, item.count.ToString() };
                listView1.Items.Add(new ListViewItem(word));
            }

        }
    }
}

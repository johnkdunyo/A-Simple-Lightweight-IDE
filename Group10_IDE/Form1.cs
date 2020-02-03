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

namespace Group10_IDE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox5.Clear();
            richTextBox3.Clear();
            richTextBox4.Clear();
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Title = "Open a new file";
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Clear();
                using (StreamReader sr = new StreamReader(openfile.FileName))
                {
                    richTextBox1.Text = sr.ReadToEnd();
                    sr.Close();
                }
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Title = "Save file as..";
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                StreamWriter txtoutput = new StreamWriter(savefile.FileName);
                txtoutput.Write(richTextBox1.Text);
                txtoutput.Close();
            }
        }

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void redoButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void selectAllButton_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newToolStripButton.PerformClick();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openToolStripButton.PerformClick();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveToolStripButton.PerformClick();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            undoButton.PerformClick();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            redoButton.PerformClick();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cutToolStripButton.PerformClick();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            copyToolStripButton.PerformClick();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pasteToolStripButton.PerformClick();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectAllButton.PerformClick();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
            richTextBox1.SelectionBackColor = Color.White;
            richTextBox1.SelectionColor = Color.Black;
            richTextBox5.Clear(); 
            richTextBox3.Clear();
            richTextBox4.Clear();
            int noLines = richTextBox1.Lines.Count();
            string lines = noLines.ToString();
            richTextBox5.AppendText(" " + lines);
            //MessageBox.Show(noLines.ToString());

            string count = richTextBox1.Text;
            int noChar = richTextBox1.Text.Length;
            // (count.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length).ToString();
            richTextBox3.AppendText(" " + noChar.ToString());

            string InputCode = richTextBox1.Text;

            if (Class4.IsBalanced(InputCode))             //function checkParenthesis(input)
            {
                richTextBox4.AppendText("  Parenthesis Balanced");
            }
            else
            {
                richTextBox4.AppendText("  Parenthesis Not Balanced");
            }
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            Stack<int> stk = new Stack<int>();
            string nextLn = "\r\n";
            int len = InputCode.Length;
            int li;

            for (int i = 0; i < len; i++)
            {
                char ch = InputCode[i];
                if (ch == '(')
                { stk.Push(i); }
                else if (ch == ')')
                {
                    try
                    {
                        int p = stk.Pop() + 1;
                        //   richTextBox4.AppendText( nextLn + "'(' at index " + p + " is matched with ')' at index " + (i+1)); 
                    }
                    catch (Exception)
                    {
                        li = richTextBox1.GetLineFromCharIndex(i + 1) + 1;
                        richTextBox4.AppendText(nextLn + "[Error]: Missing openning'(' for ')' at position " + (i + 1) + " on line " + li);
                        richTextBox1.Select(richTextBox1.GetFirstCharIndexFromLine(li - 1), richTextBox1.Lines[li - 1].Length);
                        richTextBox1.SelectionBackColor = Color.OrangeRed;
                        richTextBox1.Select((i), 1);
                        richTextBox1.SelectionColor =  Color.Blue;           
                    }
                    
                }
            }
            while (stk.Count > 0)
            {
                int w = stk.Pop() + 1;
                int q = richTextBox1.GetLineFromCharIndex(w) + 1;
                richTextBox4.AppendText(nextLn + "[Error]: Missing  closing')' for '(' at position " + w + " on line " + (q));
                richTextBox1.Select(richTextBox1.GetFirstCharIndexFromLine(q - 1), richTextBox1.Lines[q - 1].Length);
                richTextBox1.SelectionBackColor = Color.OrangeRed;
                richTextBox1.SelectionBackColor = Color.OrangeRed;
                richTextBox1.Select((w-1), 1);
                richTextBox1.SelectionColor = Color.Blue;
            }

            for (int i = 0; i < len; i++)
            {
                char ch = InputCode[i];
                if (ch == '{')
                { stk.Push(i); }
                else if (ch == '}')
                {
                    try
                    {
                        int p = stk.Pop() + 1;
                        // richTextBox4.AppendText(nextLn + "'{' at index " + p + " is matched with '}' at index " + (i + 1));
                    }
                    catch (Exception)
                    {
                        li = richTextBox1.GetLineFromCharIndex(i + 1) + 1;
                        richTextBox4.AppendText(nextLn + "[Error]: Missing openning'{' for '}' at position " + (i + 1) + " on line " + li);
                        richTextBox1.Select(richTextBox1.GetFirstCharIndexFromLine(li - 1), richTextBox1.Lines[li - 1].Length);
                        richTextBox1.SelectionBackColor = Color.OrangeRed;
                        richTextBox1.SelectionBackColor = Color.OrangeRed;
                        richTextBox1.Select((i), 1);
                        richTextBox1.SelectionColor = Color.Blue;
                    }
                }
            }
            while (stk.Count > 0)
            {
                int w = stk.Pop() + 1;
                int q = richTextBox1.GetLineFromCharIndex(w) + 1;
                richTextBox4.AppendText(nextLn + "[Error]: Missing  closing'}' for '{' at position " + w + " on line " + q);
                richTextBox1.Select(richTextBox1.GetFirstCharIndexFromLine(q - 1), richTextBox1.Lines[q - 1].Length);
                richTextBox1.SelectionBackColor = Color.OrangeRed;
                richTextBox1.SelectionBackColor = Color.OrangeRed;
                richTextBox1.Select((w-1), 1);
                richTextBox1.SelectionColor = Color.Blue;
            }

            for (int i = 0; i < len; i++)
            {
                char ch = InputCode[i];
                if (ch == '[')
                { stk.Push(i); }
                else if (ch == ']')
                {
                    try
                    {
                        int p = stk.Pop() + 1;
                        //  richTextBox4.AppendText(nextLn + "'[' at index " + p + " is matched with ']' at index " + (i + 1));
                    }
                    catch (Exception)
                    {
                        li = richTextBox1.GetLineFromCharIndex(i + 1) + 1;
                        richTextBox4.AppendText(nextLn + "[Error]: Missing openning'[' for ']' at position " + (i + 1) + " on line " + li);
                        richTextBox1.Select(richTextBox1.GetFirstCharIndexFromLine(li - 1), richTextBox1.Lines[li - 1].Length);
                        richTextBox1.SelectionBackColor = Color.OrangeRed;
                        richTextBox1.SelectionBackColor = Color.OrangeRed;
                        richTextBox1.Select((i), 1);
                        richTextBox1.SelectionColor = Color.Blue;

                    }
                }
            }
            while (stk.Count > 0)
            {
                int w = stk.Pop() + 1;
                int q = richTextBox1.GetLineFromCharIndex(w) + 1;
                richTextBox4.AppendText(nextLn + "[Error]: Missing  closing']' for '[' at position " + w + " on line " + q);
                richTextBox1.Select(richTextBox1.GetFirstCharIndexFromLine(q - 1), richTextBox1.Lines[q - 1].Length);
                richTextBox1.SelectionBackColor = Color.OrangeRed;
                richTextBox1.SelectionBackColor = Color.OrangeRed;
                richTextBox1.Select((w-1), 1);
                richTextBox1.SelectionColor = Color.Blue;
            }
            //
            /*   System.Collections.ArrayList lineList = new System.Collections.ArrayList();
               System.Collections.IEnumerator myEnumerator = lineList.GetEnumerator();*/
            int index = 0;
            string temp = richTextBox4.Text;
            richTextBox4.Text = "";
            richTextBox4.Text = temp;
        while(index < richTextBox4.Text.LastIndexOf("[Error]"))
            {
                richTextBox4.Find("[Error]", index, richTextBox4.TextLength, RichTextBoxFinds.None);
                richTextBox4.SelectionColor = Color.Red;
                index = richTextBox4.Text.IndexOf("[Error]", index) + 1;
            }
            ///////////////   
         /*   int firstcharindex = richTextBox1.GetFirstCharIndexOfCurrentLine();

            int currentline = richTextBox1.GetLineFromCharIndex(firstcharindex);

            string currentlinetext = richTextBox1.Lines[currentline];

            richTextBox1.Select(firstcharindex, currentlinetext.Length);*/
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        }

            private void group10IDEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is an IDE " + "\r\n" + " that checks whether the parenthesis in a code are balanced or not");
        }

        private void group10DevelopersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string Developers = "Group 10 Developers... " + "\r\n" + "Computer Enginnering 2               Year 2019" + "\r\n";
            string firstfive = "\r\n"+"1. Agyemang Yaw" + "\r\n" + "2. John Kwame Dunyo" + "\r\n" + "3. Doe Godfred" + "\r\n" + "4. Gyesie Andrew" + "\r\n" + "5. Oppong Kwame" + "\r\n";
            string lastfive = "6. Bash" + "\r\n" + "7. Afreh Christian" + "\r\n" + "8. Akubidila Daniel" + "\r\n" + "9. Chentiwuni Rafiq" + "\r\n" + "  and the rest ";
            MessageBox.Show(Developers + firstfive + lastfive);
        }

        private void richTextBox4_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}

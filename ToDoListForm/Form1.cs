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

namespace ToDoListForm
{
    public partial class Form1 : Form
    {
        List<CheckBox> rList = new List<CheckBox>();
        int num = 0;
        int high = 30;
        string path = @"C:\Users\default.bigamus\Documents\Visual Studio 2017\Projects\Challenges\ToDoListForm";

        public Form1()
        {
            InitializeComponent();
            File.Create(path);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (high == 510)
            {
                MessageBox.Show("Too many items on the list.", "Warning: ", MessageBoxButtons.OK);
            }
            else
            {

                rList.Add(new CheckBox());
                rList[num].Location = new Point(30, high);
                this.Controls.Add(rList[num]);

                string totalText = titleBox.Text + ": ";
                totalText += descBox.Text;

                rList[num].AutoSize = true;
                rList[num].Text = totalText;

                titleBox.Text = "Title";
                descBox.Text = "Description";

                high += 20;
                num++;
            }
        }

        private void deleteTask_Click(object sender, EventArgs e)
        {
            int times = 0;
            for (int i = 0; i < rList.Count; i++)
            {
                if (rList[i].Checked == true)
                {
                    this.Controls.Remove(rList[i]);
                    rList.Remove(rList[i]);
                    times++;
                    i--;
                }
            }

            high = 30;

            foreach(CheckBox x in rList)
            {
                x.Location = new Point(30, high);
                high += 20;
            }

            num -= times;
        }
    }
}

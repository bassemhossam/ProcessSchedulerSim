using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OS_Assignment_try_1
{

    public partial class Schedulers : Form
    {
        public static string nprocess;
        public static bool fcfs;
        public static bool sjf;
        public static bool sjfp;
        public static bool priority;
        public static bool priorityp;
        public static bool rr;
        public static int rrq;
        

         public Schedulers()
        {
            InitializeComponent();
        }

        private void Schedulers_Load(object sender, EventArgs e)
        {
            
        }

       
        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void proTxtbox_TextChanged_1(object sender, EventArgs e)
        {
            int num;

            bool isNum = Int32.TryParse(proTxtbox.Text, out num);
            if (isNum)
                nprocess = Convert.ToString(num);
           
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void PriorityChk_CheckedChanged(object sender, EventArgs e)
        {

            if (PriorityChk.Checked)
            {
                priority = true;
                PriorityCombo.Visible = true;
            }
            else
            {
                PriorityCombo.Visible = false;
                priority = false;
            }
        }
        private void FCFSChk_CheckedChanged(object sender, EventArgs e)
        {
            if(FCFSChk.Checked)
            fcfs = true;
            else
            fcfs = false;
        }

        

        private void nxtBtn_Click(object sender, EventArgs e)
        {
            Processform k = new Processform();
            k.ShowDialog(); 
            
        }

        private void SJFChk_CheckedChanged(object sender, EventArgs e)
        {

            if (SJFChk.Checked)
            {
                sjf = true;
                SJFCombo.Visible = true;
            }
            else
            {
                sjf = false;
                SJFCombo.Visible = false;
            }
        }

        private void SJFCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(SJFCombo.SelectedIndex==0)
            {
                sjfp = true;
            }
            else
            {
                sjfp = false;
            }
        }

        private void PriorityCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PriorityCombo.SelectedIndex == 0)
            {
                priorityp = true;
            }
            else
            {
                priorityp = false;
            }
        }

        private void qntTxtbox_TextChanged(object sender, EventArgs e)
        {

            
        }

        private void RRChk_CheckedChanged(object sender, EventArgs e)
        {

            if (RRChk.Checked)
            {
                rr = true;
                qntTxtbox.Visible = true;
            }
            else
            {
                rr = false;
                qntTxtbox.Visible = false;
            }
        }

        private void qntTxtbox_TextChanged_1(object sender, EventArgs e)
        {

            int num;

            bool isNum = Int32.TryParse(qntTxtbox.Text, out num);
            if (isNum)
                rrq = num;
            //Int32.TryParse(qntTxtbox.Text, out rrq);



        }
    }
}

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
    public partial class Processform : Form
    {
        public static List<Process> pro = new List<Process>(COUNT);

        TableLayoutPanel pnlContent = new TableLayoutPanel();

        public static int COUNT ;
        public Processform()
        {
            InitializeComponent();
        }

        public  void Processform_Load(object sender, EventArgs e)
        {
            pnlContent.Controls.Clear();
            pnlContent.RowStyles.Clear();
            pnlContent.ColumnStyles.Clear();

            Button next = new Button();
            Button back = new Button();
            
            COUNT = Convert.ToInt32(Schedulers.nprocess);
            //Schedulers protext = new Schedulers(); 
            
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.AutoScroll = true;
            pnlContent.AutoScrollMargin = new Size(1, 1);
            pnlContent.AutoScrollMinSize = new Size(1, 1);
            pnlContent.RowCount = COUNT+2;
            pnlContent.ColumnCount = 3;
            if (Schedulers.priority)
                pnlContent.ColumnCount++;
            
            for (int i = 0; i < pnlContent.ColumnCount; i++)
            {
                pnlContent.ColumnStyles.Add(new ColumnStyle());
            }

           for(int i=0;i<pnlContent.ColumnCount;i++)
                pnlContent.ColumnStyles[i].Width = 20;

            this.Controls.Add(pnlContent);

            for (int i = 0; i < COUNT + 1; i++)
            {
                pnlContent.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));

                if (i == 0)
                {
                    Label lblprocess = new Label();
                    lblprocess.Text = string.Format("Process");
                    lblprocess.TabIndex = (i);
                    lblprocess.Margin = new Padding(5, 25, 0, 0);
                    // lblprocess.Dock = DockStyle.Fill;
                    pnlContent.Controls.Add(lblprocess, 0, i);

                    Label lblarrival = new Label();
                    lblarrival.Text = string.Format("Arrival Time");
                    lblarrival.Left = 0;
                   lblarrival.TabIndex = (i) + 1;
                    lblarrival.Margin = new Padding(25, 25, 0, 0);
                    lblarrival.Dock = DockStyle.Fill;
                    pnlContent.Controls.Add(lblarrival, 1, i);

                    Label lblburst = new Label();
                    lblburst.Text = string.Format("Burst Time");
                    lblburst.Left = 0;
                    lblburst.TabIndex = (i) + 2;
                    lblburst.Margin = new Padding(25, 25, 0, 0);
                    //  lblburst.Dock = DockStyle.Fill;
                    pnlContent.Controls.Add(lblburst, 2, i);
                    if (Schedulers.priority)
                    {
                        Label lblpriority = new Label();
                        lblpriority.Text = string.Format("Priority");
                        lblpriority.Left = 0;
                        lblpriority.TabIndex = (i) + 3;
                        lblpriority.Margin = new Padding(25, 25, 0, 0);
                        // lblpriority.Dock = DockStyle.Fill;
                        pnlContent.Controls.Add(lblpriority, 3, i);
                    }
                }
                else
                {
                    Label Pname = new Label();
                    Pname.Text = string.Format(" {0}", i);
                    Pname.TabIndex = (i*pnlContent.ColumnCount);
                    Pname.Margin = new Padding(5, 25, 0, 0);
                    Pname.Dock = DockStyle.Fill;
                    pnlContent.Controls.Add(Pname, 0, i);

                    TextBox Parrival = new TextBox();
                    Parrival.TabIndex = (i * pnlContent.ColumnCount) + 1;
                    Parrival.Left = 0;
                    Parrival.Margin = new Padding(25);
                    Parrival.Dock = DockStyle.Fill;
                    Parrival.KeyDown += new KeyEventHandler(Parrival_KeyDown);
                    pnlContent.Controls.Add(Parrival, 1, i);

                    TextBox Pburst = new TextBox();
                    Pburst.TabIndex = (i*pnlContent.ColumnCount) + 2;
                    Pburst.Left = 0;
                    Pburst.Margin = new Padding(25);
                    //Pburst.Dock = DockStyle.Fill;
                    Pburst.KeyDown += new KeyEventHandler(Pburst_KeyDown);
                    pnlContent.Controls.Add(Pburst, 2, i);
                    if (Schedulers.priority)
                    {
                        TextBox Ppriority = new TextBox();
                       Ppriority.TabIndex = (i * pnlContent.ColumnCount) + 3;
                        Ppriority.Margin = new Padding(25);
                        Ppriority.Left = 0;
                        // Ppriority.Dock = DockStyle.Fill;
                        Ppriority.KeyDown += new KeyEventHandler(Ppriority_KeyDown);
                        pnlContent.Controls.Add(Ppriority, 3, i);
                    }
                }
            }
            pnlContent.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));

            pnlContent.ColumnCount++;
            pnlContent.ColumnStyles.Add(new ColumnStyle());
            pnlContent.ColumnStyles[pnlContent.ColumnCount - 1].Width = 20;
            
            next.Name =" next";
            next.Text = string.Format("Next>");
            next.TabIndex = COUNT*pnlContent.ColumnCount ;
            next.Margin = new Padding(25);
            next.Click += new EventHandler(next_Click);


            // lblprocess.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(back, 1, COUNT + 1);
            back.Name = "back";
            back.Text = string.Format("<Back");
            back.TabIndex = COUNT* pnlContent.ColumnCount+3;
            back.Margin = new Padding(25);
            back.Click += new EventHandler(back_Click);


            pnlContent.Controls.Add(next, pnlContent.ColumnCount-1, COUNT + 2);
            // lblprocess.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(back, 0, COUNT + 2);
        }
         void next_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < COUNT+1; i++)
            {

                Gantt.chart.Controls.Clear();
                Gantt.chart.RowStyles.Clear();
                Gantt.chart.ColumnStyles.Clear();
                Process nextpro = new Process();
                nextpro.name = string.Format("p{0}", i);
              nextpro.arrival=(Convert.ToInt32(pnlContent.GetControlFromPosition(1,i).Text));
                nextpro.burst=(Convert.ToInt32(pnlContent.GetControlFromPosition(2, i).Text));
                if(Schedulers.priority)
                    nextpro.priority=(Convert.ToInt32(pnlContent.GetControlFromPosition(3, i).Text));
                pro.Add(nextpro);
            }
            Gantt f = new Gantt();
            f.ShowDialog();
        }
        void back_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }
        void Parrival_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        void Pburst_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        void Ppriority_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
    }

}
 

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
    public struct Process
    {

        public string name;
        public int burst;
        public int arrival;
        public int priority;
        public Process(string n, int arr = 0, int b = 0, int p = 0)
        {
            name = n;
            arrival = arr;
            burst = b;
            priority = p;
        }
    };
    public partial class Gantt : Form
    {
        static public TableLayoutPanel chart = new TableLayoutPanel();
        Button finish = new Button();

        public Gantt()
        {
            InitializeComponent();
        }

        public void Gantt_Load(object sender, EventArgs e)
        {
            Gantt.chart.Controls.Clear();
            Gantt.chart.RowStyles.Clear();
            Gantt.chart.ColumnStyles.Clear();
            int nsched = 0;
            if (Schedulers.fcfs)
            {
                nsched++;
                SchedulerFunction.FCFS_Sched(Processform.pro, Processform.COUNT);

            }
            if (Schedulers.priority)
            {
                nsched++;
                SchedulerFunction.Priority_Sched(Processform.pro, Processform.COUNT, Schedulers.priorityp);

            }
            if (Schedulers.sjf)
            {
                nsched++;
                SchedulerFunction.SJF_Sched(Processform.pro, Processform.COUNT, Schedulers.sjfp);

            }
            if (Schedulers.rr)
            {
                nsched++;
                SchedulerFunction.RR_sched(Processform.pro, Processform.COUNT, Schedulers.rrq);

            }
            chart.Dock = DockStyle.Fill;
            chart.AutoScroll = true;
            chart.AutoScrollMargin = new Size(1, 1);
            chart.AutoScrollMinSize = new Size(1, 1);
            chart.RowCount = 5 * nsched;
            chart.ColumnCount = Math.Max(Math.Max(SchedulerFunction.Prioritytime.Count(), SchedulerFunction.SJFtime.Count()), Math.Max(SchedulerFunction.FCFStime.Count(), SchedulerFunction.RRtime.Count()));
            /*  for (int i = 0; i < chart.ColumnCount; i++)
              {
                  chart.ColumnStyles.Add(new ColumnStyle());
                  chart.ColumnStyles[i].Width = 20;
              }*/
            for (int j = 0; j < nsched; j++)
            {
                chart.RowStyles.Add(new RowStyle(SizeType.AutoSize, 250));
                chart.RowStyles.Add(new RowStyle(SizeType.AutoSize, 250));
                chart.RowStyles.Add(new RowStyle(SizeType.AutoSize, 250));
                chart.RowStyles.Add(new RowStyle(SizeType.AutoSize, 250));
                chart.RowStyles.Add(new RowStyle(SizeType.AutoSize, 250));

            }

            chart.RowStyles.Add(new RowStyle(SizeType.AutoSize, 250));
            Button back = new Button();
            chart.Controls.Add(back, 0, nsched*5 + 1);
            back.Name = "back";
            back.Text = string.Format("<Back");
            back.TabIndex = nsched ;
            back.Margin = new Padding(25);
            back.Click += new EventHandler(back_Click);
            int x = 0;
            if (Schedulers.fcfs)
            {
                printgantt(SchedulerFunction.FCFSnames, SchedulerFunction.FCFStime, SchedulerFunction.FCFSavgwait, x, "FCFS");

                x++;
            }
            if (Schedulers.priority)
            {
                string s;
                if (Schedulers.sjfp)
                    s = "Priority Preemtive";
                else
                    s = "Priority Non-Preemtive";
                printgantt(SchedulerFunction.Prioritynames, SchedulerFunction.Prioritytime, SchedulerFunction.Priorityavgwait, x, s);

                x++;
            }
            if (Schedulers.sjf)
            {
                string s;
                if (Schedulers.sjfp)
                    s = "SJF Preemtive";
                else
                    s = "SJF Non-Preemtive";
                printgantt(SchedulerFunction.SJFnames, SchedulerFunction.SJFtime, SchedulerFunction.SJFavgwait, x, s);

                x++;
            }
            if (Schedulers.rr)
            {
                printgantt(SchedulerFunction.RRnames, SchedulerFunction.RRtime, SchedulerFunction.RRavgwait, x, "Round Robin");

                x++;
            }


            this.Controls.Add(chart);


        }
        void printgantt(List<string> namespro, List<int> timepro, double avgwait, int schedrow, string name)
        {

            for (int i = 0; i < timepro.Count() - 1; i++)
            {
                chart.ColumnStyles.Add(new ColumnStyle());
                if (timepro[i] != 0 && timepro[i + 1] != 0)
                    chart.ColumnStyles[i].Width = 100;
                else
                    chart.ColumnStyles[i].Width = 100;
            }
            chart.ColumnStyles.Add(new ColumnStyle());
            Label namelbl = new Label();

            namelbl.Text = name+":";
            namelbl.TabIndex = (schedrow * 5);
            namelbl.Margin = new Padding(40, 25, 0, 25);

            chart.Controls.Add(namelbl, 0, (schedrow * 5));
            for (int z = 0; z < timepro.Count(); z++)
            {
                if (z < namespro.Count())
                {
                    Label lblprocess = new Label();
                    lblprocess.Text = namespro[z];
                    lblprocess.TabIndex = (schedrow * 5 + 1);
                    if (z == 0)
                        lblprocess.Margin = new Padding(50, 0, 0, 0);
                    else
                        lblprocess.Margin = new Padding(0);

                    lblprocess.Height = 50;
                    lblprocess.TextAlign = ContentAlignment.MiddleCenter;
                    lblprocess.Dock = DockStyle.Fill;
                    lblprocess.BorderStyle = BorderStyle.FixedSingle;
                    chart.Controls.Add(lblprocess, z, schedrow * 5 + 1);
                }
                Label lbltime = new Label();
                lbltime.Text = Convert.ToString(timepro[z]);
                lbltime.TabIndex = ((schedrow * 5) + 2);
                lbltime.Dock = DockStyle.Fill;
                if (z == 0)
                    lbltime.Margin = new Padding(50, 0, 0, 0);
                else

                    lbltime.Margin = new Padding(0);
                chart.Controls.Add(lbltime, z, (schedrow * 5) + 2);
            }
            Label avgtime = new Label();
            avgtime.Text = string.Format("Avg Wait={0:0.00}s", avgwait);
            avgtime.TabIndex = (schedrow * 5) + 3;
            avgtime.Dock = DockStyle.Fill;
            //avgtime.Margin = new Padding(25);

            chart.Controls.Add(avgtime, chart.ColumnCount / 2, (schedrow * 5) + 3);
            Label emptyspace = new Label();

            emptyspace.Name = "";
            emptyspace.Text = string.Format("");
            emptyspace.TabIndex = schedrow * 5 + 4;
            // emptyspace.Margin = new Padding(25);
            chart.Controls.Add(emptyspace, 0, schedrow * 5 + 4);

        }
        void back_Click(object sender, EventArgs e)
        {
            
            Processform.pro.Clear();

            this.Close();
        }
        public class SJFCompare : IComparer<Process>
        {
            public int Compare(Process x, Process y)
            {
                if (x.burst > y.burst)
                    return 1;
                else if (x.burst < y.burst)
                    return -1;
                else
                {
                    if (x.arrival > y.arrival)
                        return 1;
                    else if (x.arrival < y.arrival)
                        return -1;
                    else
                        return x.name.CompareTo(y.name);
                }
            }

        }
        public class PriorityCompare : IComparer<Process>
        {
            public int Compare(Process x, Process y)
            {
                if (x.priority > y.priority)
                {
                    return 1;
                }
                else if (x.priority < y.priority)
                {
                    return -1;
                }
                else
                {
                    if (x.arrival > y.arrival)
                        return 1;
                    else if (x.arrival < y.arrival)
                        return -1;
                    else
                        return x.name.CompareTo(y.name);
                }
            }

        }
        public class ArrivalCompare : IComparer<Process>
        {
            public int Compare(Process x, Process y)
            {
                if (x.arrival > y.arrival)
                {
                    return 1;
                }
                else if (x.arrival < y.arrival)
                {
                    return -1;
                }
                else
                {
                    return x.name.CompareTo(y.name);
                }
            }

        }
        public class SchedulerFunction
        {
            public static List<string> RRnames = new List<string>();
            public static List<int> RRtime = new List<int>();

            public static List<string> SJFnames = new List<string>();
            public static List<int> SJFtime = new List<int>();

            public static List<string> FCFSnames = new List<string>();
            public static List<int> FCFStime = new List<int>();

            public static List<string> Prioritynames = new List<string>();
            public static List<int> Prioritytime = new List<int>();
            public static double RRavgwait;
            public static double FCFSavgwait;
            public static double SJFavgwait;
            public static double Priorityavgwait;

            public static void RR_sched(List<Process> pro, int nprocess, int quantum)//add arrival time check
            {
                RRnames.Clear();
                RRtime.Clear();
                RRtime.Add(0);
                double wait = 0;
                List<Process> RR = new List<Process>();
                List<Process> p = new List<Process>();
                foreach (Process x in pro)
                {
                    p.Add(x);
                    wait -= x.arrival;
                    wait -= x.burst;
                }
                ArrivalCompare a = new ArrivalCompare();
                p.Sort(a);
                int burstTime, proTime = 0 /*mish 3ayzeen n5aleeha b 0 3ashan mmkn yeb2a awel arrival mish b 0*/;
                
                int j = 0;
                while (p.Count() != 0 && j < p.Count() && p[j].arrival == proTime)
                {
                    RR.Insert(0, (p[j]));
                    p.RemoveAt(j);
                    j++;
                }

                while (RR.Count() != 0 || p.Count() != 0)
                {
                    int k = 0;
                    while (p.Count() != 0 && k < p.Count() && p[k].arrival <= proTime)
                    {
                        RR.Insert(0, (p[k]));
                        p.RemoveAt(k);
                        k++;
                    }
                    if (RR.Count() == 0 && p[k].arrival > proTime)
                    {
                        proTime++;
                        RRtime.Add(proTime);
                        RRnames.Add("No Process");

                    }
                    if (RR.Count() != 0 && RR[0].burst > quantum)
                    {
                        burstTime = RR[0].burst;
                        burstTime -= quantum;
                        //wait += quantum * (RR.Count() - 1);
                        proTime += quantum;
                        int x = 0;
                        while (p.Count() != 0 && x < p.Count() && p[x].arrival <= proTime)
                        {
                            RR.Add(p[x]);
                            p.RemoveAt(x);
                            x++;
                        }
                        Process processnext = new Process();
                        processnext.name = RR[0].name;
                        processnext.burst = burstTime;
                        RRnames.Add(RR[0].name);
                        RRtime.Add(proTime);
                        RR.RemoveAt(0);
                        RR.Add(processnext);
                    }
                    else if (RR.Count() != 0 && RR[0].burst == quantum)
                    {
                        
                        proTime += quantum;
                        RRnames.Add(RR[0].name);
                        wait += proTime;
                        RRtime.Add(proTime);
                        RR.RemoveAt(0);
                    }
                    else if (RR.Count() != 0 && RR[0].burst < quantum)
                    {
                        burstTime= RR[0].burst;
                        proTime += burstTime;
                        RRnames.Add(RR[0].name);
                        RRtime.Add(proTime);
                        RR.RemoveAt(0);
                        wait += proTime;
                    }
                }
                RRavgwait = wait / nprocess;
            }
            public static void FCFS_Sched(List<Process> p, int nprocess)
            {

                FCFSnames.Clear();
                FCFStime.Clear();
                FCFStime.Add(0);
                List<Process> FCFS = new List<Process>();
                for (int i = 0; i < nprocess; i++)
                {
                    FCFS.Add(p[i]);
                }
                ArrivalCompare a = new ArrivalCompare();
                FCFS.Sort(a);
                int time = 0;
                double wait = 0;

                while (FCFS.Count() != 0)
                {
                    if (FCFS[0].arrival > time)
                    {
                        time++;
                        FCFStime.Add(time);
                        FCFSnames.Add("No Process");

                    }
                    else
                    {
                        wait += time - FCFS[0].arrival;
                        time += FCFS[0].burst;
                        FCFSnames.Add(FCFS[0].name);
                        FCFStime.Add(time);
                        FCFS.RemoveAt(0);
                    }
                }
                FCFSavgwait = wait / nprocess;
            }
            public static void SJF_Sched(List<Process> pro, int nprocess, bool Preemtive = false)
            {
                SJFnames.Clear();
                SJFtime.Clear();
                SJFtime.Add(0);
                List<Process> p = new List<Process>();
            
                foreach (Process x in pro)
                    p.Add(x);
                SJFCompare d = new SJFCompare();
                p.Sort(d);
                int time = 0;
                double wait = 0;
                if (Preemtive)
                {
                    foreach (Process z in p)
                        wait -= z.arrival;

                    int i = 0;
                    while (p.Count() != 0 && p[i].arrival != time && i < p.Count()) i++;
                    Process currentp = new Process();
                    currentp = p[i];
                    p.RemoveAt(i);
                    bool done = false;
                    while (p.Count() != 0 || !done)
                    {
                        currentp.burst--;
                        wait += p.Count();
                        time++;
                        int j = 0;
                        while (p.Count() != 0 && j < p.Count() - 1 && p[j].arrival > time)
                        {
                            j++;
                        }
                        if (p.Count() != 0)

                            if (p.Count != 0 && currentp.burst != 0 && currentp.burst > p[j].burst && p[j].arrival <= time)
                            {
                                SJFnames.Add(currentp.name);
                                SJFtime.Add(time);
                                p.Add(currentp);
                                currentp = p[j];
                                p.RemoveAt(j);
                                SJFCompare c = new SJFCompare();
                                p.Sort(c);
                            }
                        if (currentp.burst == 0)
                        {
                            SJFnames.Add(currentp.name);
                            SJFtime.Add(time);
                            if (p.Count != 0)
                            {
                                currentp = p[j];
                                p.RemoveAt(j);
                            }
                            else done = true;
                        }

                    }

                    SJFavgwait = wait / nprocess;
                }

                else
                {
                    while (p.Count() != 0)
                    {
                        int i = 0;
                        while (p.Count() != 0 && i < p.Count() - 1 && p[i].arrival > time) i++;
                        if (p[i].arrival <= time)
                        {
                            wait += time - p[i].arrival;
                            time += p[i].burst;
                            SJFnames.Add(p[i].name);
                            SJFtime.Add(time);
                            p.RemoveAt(i);
                        }
                        else
                        {
                            time++;
                            SJFtime.Add(time);
                            SJFnames.Add("No Process");


                        }
                    }
                    SJFavgwait = wait / nprocess;
                }
            }
            public static void Priority_Sched(List<Process> p, int nprocess, bool Preemtive = false)
            {

                Prioritynames.Clear();
                Prioritytime.Clear();
                Prioritytime.Add(0);
                List<Process> priority = new List<Process>();
                for (int i = 0; i < nprocess; i++)
                {
                    priority.Add(p[i]);
                }
                PriorityCompare d = new PriorityCompare();
                priority.Sort(d);
                int time = 0;
                double wait = 0;
                bool done = false;
                if (Preemtive)
                {
                    foreach (Process z in priority)
                        wait -= z.arrival;

                    int i = 0;
                    while (priority.Count() != 0 && i < priority.Count() && priority[i].arrival != time) i++;
                    Process currentp = new Process();
                    currentp = priority[i];
                    priority.RemoveAt(i);

                    while (priority.Count() != 0 || !done)
                    {

                        currentp.burst--;
                        wait += priority.Count();

                        time++;
                        int j = 0;
                        while (priority.Count() != 0 && j < priority.Count() - 1 && priority[j].arrival > time)
                        {
                            j++;
                        }
                        if (priority.Count() != 0)

                            if (priority.Count != 0 && currentp.burst != 0 && currentp.priority > priority[j].priority && priority[j].arrival <= time)
                            {
                                Prioritynames.Add(currentp.name);
                                Prioritytime.Add(time);
                                priority.Add(currentp);
                                currentp = priority[j];
                                priority.RemoveAt(j);
                                PriorityCompare c = new PriorityCompare();
                                priority.Sort(c);
                            }
                        if (currentp.burst == 0)
                        {
                            Prioritynames.Add(currentp.name);
                            Prioritytime.Add(time);
                            if (priority.Count != 0)
                            {
                                currentp = priority[j];
                                priority.RemoveAt(j);
                            }
                            else done = true;
                        }

                    }

                    Priorityavgwait = wait / nprocess;
                }
                else
                {
                    while (priority.Count() != 0)
                    {
                        int i = 0;
                        while (priority.Count() != 0 && i < priority.Count() - 1 && priority[i].arrival > time) i++;
                        if (priority[i].arrival <= time)
                        {
                            wait += time - priority[i].arrival;
                            time += priority[i].burst;
                            Prioritynames.Add(priority[i].name);
                            Prioritytime.Add(time);
                            priority.RemoveAt(i);
                        }
                        else
                        {
                            time++;
                            Prioritytime.Add(time);
                            Prioritynames.Add("No Process");
                        }
                    }
                    Priorityavgwait = wait / nprocess;
                }
            }
        }
    }
}
        
    



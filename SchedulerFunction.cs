using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    class SchedulerFunction
    {
        static List<string> RRnames = new List<string>();
        static List<int> RRtime = new List<int>();

        static List<string> SJFnames = new List<string>();
        static List<int> SJFtime = new List<int>();

        static List<string> FCFSnames = new List<string>();
        static List<int> FCFStime = new List<int>();

        static List<string> Prioritynames = new List<string>();
        static List<int> Prioritytime = new List<int>();
        static double RRavgwait;
        static double FCFSavgwait;
        static double SJFavgwait;
        static double Priorityavgwait;

        static void RR_sched(List<Process> pro, int nprocess, int quantum)//add arrival time check
        {
            RRtime.Add(0);
            Queue<Process> RR = new Queue<Process>();
            List<Process> p = new List<Process>();
            foreach (Process x in pro)
                p.Add(x);
            ArrivalCompare a = new ArrivalCompare();
            p.Sort(a);
            int burstTime, proTime = 0;
            double wait = 0;
            foreach (Process z in p)
                wait -= z.arrival;
            int j = 0;
            while (p.Count() != 0 && p[j].arrival == proTime && j < p.Count())
            {
                RR.Enqueue(p[j]);
                p.RemoveAt(j);
                j++;
            }

            while (RR.Count() != 0)
            {
                int k = 0;
                while (p.Count() != 0 && k < p.Count() && p[k].arrival <= proTime)
                {
                    RR.Enqueue(p[k]);
                    p.RemoveAt(k);
                    k++;
                }
                if (RR.Peek().burst > quantum)
                {
                    burstTime = RR.Peek().burst;
                    burstTime -= quantum;
                    wait += quantum * ((RR.Count() - 1) + p.Count());
                    proTime += quantum;
                    int x = 0;
                    while (p.Count() != 0 && x < p.Count() && p[x].arrival <= proTime)
                    {
                        RR.Enqueue(p[x]);
                        p.RemoveAt(x);
                        x++;
                    }
                    Process processnext = new Process();
                    processnext.name = RR.Peek().name;
                    processnext.burst = burstTime;
                    RRnames.Add(RR.Peek().name);
                     RRtime.Add(proTime);
                    RR.Dequeue();
                    RR.Enqueue(processnext);
                }
                else if (RR.Peek().burst == quantum)
                {
                    wait += quantum * ((RR.Count() - 1) + p.Count());
                    proTime += quantum;
                    RRnames.Add(RR.Peek().name);
                    RRtime.Add(proTime);
                    RR.Dequeue();
                }
                else if (RR.Peek().burst < quantum)
                {
                    proTime += RR.Peek().burst;
                    wait += RR.Peek().burst * ((RR.Count() - 1) + p.Count());
                    RRnames.Add(RR.Peek().name);
                    RRtime.Add(proTime);
                    RR.Dequeue();
                }


            }
            RRavgwait= wait / nprocess;
        }
        static void FCFS_Sched(List<Process> p, int nprocess)
        {
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
                wait += time - FCFS[0].arrival;
                time += FCFS[0].burst;
                FCFSnames.Add(FCFS[0].name);
                FCFStime.Add(time);
                FCFS.RemoveAt(0);
            }
            FCFSavgwait = wait / nprocess;
        }
        static void SJF_Sched(List<Process> p, int nprocess, bool Preemtive = false)
        {
            SJFtime.Add(0);
            List<Process> SJF = new List<Process>();
            for (int i = 0; i < nprocess; i++)
            {
                SJF.Add(p[i]);
            }
            SJFCompare d = new SJFCompare();
            SJF.Sort(d);
            int time = 0;
            double wait = 0;
            bool done = false;
            if (Preemtive)
            {
                foreach (Process z in SJF)
                    wait -= z.arrival;

                int i = 0;
                while (SJF.Count() != 0 && SJF[i].arrival != time && i < SJF.Count()) i++;
                Process currentp = new Process();
                currentp = SJF[i];
                SJF.RemoveAt(i);
                SJFtime.Add(0);

                while (SJF.Count() != 0 || !done)
                {
                    currentp.burst--;
                    wait += SJF.Count();
                    time++;
                    int j = 0;
                    while (SJF.Count() != 0 && j < SJF.Count() - 1 && SJF[j].arrival > time)
                    {
                        j++;
                    }
                    if (SJF.Count() != 0)

                        if (SJF.Count != 0 && currentp.burst != 0 && currentp.burst > SJF[j].burst && SJF[j].arrival <= time)
                        {
                            SJFnames.Add(currentp.name);
                            SJFtime.Add(time);
                            SJF.Add(currentp);
                            currentp = SJF[j];
                            SJF.RemoveAt(j);
                            SJFCompare c = new SJFCompare();
                            SJF.Sort(c);
                        }
                    if (currentp.burst == 0)
                    {
                        SJFnames.Add(currentp.name);
                        SJFtime.Add(time);
                        if (SJF.Count != 0)
                        {
                            currentp = SJF[j];
                            SJF.RemoveAt(j);
                        }
                        else done = true;
                    }

                }

               SJFavgwait = wait / nprocess;
            }
            else
            {
                while (SJF.Count() != 0)
                {
                    int i = 0;
                    while (SJF.Count() != 0 && SJF[i].arrival > time && i < SJF.Count()) i++;
                    if (SJF[i].arrival <= time)
                    {
                        wait += time - SJF[i].arrival;
                        time += SJF[i].burst;
                        SJFnames.Add(SJF[i].name);
                        SJFtime.Add(time);
                        SJF.RemoveAt(i);
                    }
                    else
                    {
                        wait += SJF.Count();
                        time++;
                    }
                }
                SJFavgwait = wait / nprocess;
            }
        }
        static void Priority_Sched(List<Process> p, int nprocess, bool Preemtive = false)
        {

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
                while (priority.Count() != 0 && priority[i].arrival != time && i < priority.Count()) i++;
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
                    Prioritytime.Add(0);
                    int i = 0;
                    while (priority.Count() != 0 && priority[i].arrival > time && i < priority.Count()) i++;
                    if (priority[i].arrival <= time)
                    {
                        wait += time - priority[i].arrival;
                        time += priority[i].burst;
                        Prioritynames.Add(priority[i].name);
                        Prioritytime.Add(time);
                        Console.WriteLine();
                        priority.RemoveAt(i);
                    }
                    else
                    {
                        wait += priority.Count();
                        time++;
                    }
                }
                Priorityavgwait = wait / nprocess;
            }
        }

    }
}
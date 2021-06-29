using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Potok_2
{
    class Mythread
    {
        Thread thread;
        public delegate void Changing();
        public event Changing OnChanging;
        Form1 form1;
        public bool b = false;
        public Mythread(Changing Ch)
        {
            OnChanging = Ch; 
            thread = new Thread(new ThreadStart(Execute)) { IsBackground = true };
            thread.Start();
        }
        public Mythread(Form1 form)
        {
            form1 = form;
            thread = new Thread(new ThreadStart(Time)) { IsBackground = true };
            thread.Start();
        }
        public void Execute()
        {
            while (true)
            {
                if (!b)
                    OnChanging();
                Thread.Sleep(20);
            }
        }
        public void Time() { while (true) form1.Invoke(new Action(form1.time)); }
        public void Stop() { thread.Abort();}
        public void Res() { b = false;}
        public void Sus() { b = true; }
        public ThreadPriority Priority
        {
            get { return thread.Priority; }
            set { thread.Priority = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Clock
{
    public delegate void ClockHandler(object sender, Clock e);
    
    public class Clock
    {
        int time = 0;
        public event ClockHandler tick;
        public event ClockHandler alarm;
        public void addOneSec(object sender,Clock e)
        {
            time+= 1;
        }
        public void Tick(object sender,Clock e)
        {
            Console.WriteLine("tick");
        }
        public void Alarm(object sender,Clock e)
        {
            Console.WriteLine("alarm");
        }
        public void Start()
        {
            Clock clock1= new Clock();
            clock1.tick += new ClockHandler(addOneSec);
            clock1.tick += new ClockHandler(Tick) ;
            clock1.alarm += new ClockHandler(Alarm);
            while(true)
            {
                clock1.tick(this,clock1);
                if(time%5 == 0)
                {
                    clock1.alarm(this,clock1);
                }
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
        public class Program
    {
        static void Main(string[] args)
        {
            Clock text= new Clock();
            text.Start();
        }
    }
}

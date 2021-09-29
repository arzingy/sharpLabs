using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace events
{
   
    public class DemonstrateEventArgs : EventArgs
    {
        public DemonstrateEventArgs(string Text)
        {
            this.Text = Text;
        }
        public string Text
        { get; }

    }
    class Demonstrator
    {
        public delegate void DemonstrateEventHandler(object sender, DemonstrateEventArgs e);
        public event DemonstrateEventHandler DemonstrateEvent;
        public delegate void StopCalculatingEventHandler(object sender, EventArgs e);
        public event StopCalculatingEventHandler StopCalculatingEvent;
        public delegate void StartCalculatingEventHandler(object sender, EventArgs e);
        public event StartCalculatingEventHandler StartCalculatingEvent;
        public Demonstrator() { }
        public void to_Demonstrate()
        {
            
            if (StartCalculatingEvent != null)
                StartCalculatingEvent(this, new EventArgs());
        }
        public void CalculatingIsFinished(object sender, CalculateEventArgs e)
        {
            if (DemonstrateEvent != null)
            {
                string str = "На промежутке [" + e.x.ToString() + "," + e.y.ToString() + "] автоморфных чисел: "+ e.number.ToString();
                DemonstrateEvent(this, new DemonstrateEventArgs(str));
            }
        }
        public void Stop_Demontrating()
        {
            if (StopCalculatingEvent != null)
                StopCalculatingEvent(this, new EventArgs());
        }

    }
}

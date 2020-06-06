using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrafficLights
{
    public partial class TrafficLights : Form
    {
        private Timer timerSwitch = null;
        private Timer timerBlink = null;
        private int timeCounter = 0;

        public TrafficLights()
        {
            InitializeComponent();
            InitializeTrafficLights();
            InitializeTimerSwitch();
            InitializeTimerBlink();
        }

        private void InitializeTimerSwitch() 
        {
            timerSwitch = new Timer();
            timerSwitch.Interval = 1000;
            timerSwitch.Tick += new EventHandler(TimerSwitch_Tick);
            timerSwitch.Start();
        }

        private void InitializeTimerBlink() 
        {
            timerBlink = new Timer();
            timerBlink.Interval = 200;
            timerBlink.Tick += new EventHandler(TimerBlink_Tick);
        }

        private void TimerBlink_Tick(object sender, EventArgs e) 
        {
            if (GreenLight.BackColor == Color.Gray) 
            {
                GreenLight.BackColor = Color.Green;
            }
            else 
            {
                GreenLight.BackColor = Color.Gray;
            }
        }

        private void TimerSwitch_Tick(object sender, EventArgs e) 
        {
            SwitchLights();
        }

        private void SwitchLights() 
        {
            switch (timeCounter)
            {
                case 0:
                    RedLight.BackColor = Color.Red;
                    break;
                case 3:
                    YellowLight.BackColor = Color.Yellow;
                    //RedLight.BackColor = Color.Gray;
                    break;
                case 5:
                    RedLight.BackColor = Color.Gray;
                    YellowLight.BackColor = Color.Gray;
                    GreenLight.BackColor = Color.Green;
                    break;
                case 6:
                    timerBlink.Start();
                    break;
                case 8:
                    timerBlink.Stop();
                    YellowLight.BackColor = Color.Yellow;
                    GreenLight.BackColor = Color.Gray;
                    break;
                case 10:
                    YellowLight.BackColor = Color.Gray;
                    RedLight.BackColor = Color.Red;
                    timeCounter = -1;
                    break;
            }
            timeCounter++;
        }

        private void InitializeTrafficLights() 
        {
            RedLight.BackColor = Color.Gray;
            YellowLight.BackColor = Color.Gray;
            GreenLight.BackColor = Color.Gray;
        }
    }
}

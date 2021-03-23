using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlarmClock
{
    public partial class Form1 : Form
    {
        private System.Timers.Timer t;
        public Form1()
        {
            InitializeComponent();
            t = new System.Timers.Timer(1000);
            t.Start();
            t.Elapsed += new System.Timers.ElapsedEventHandler(vrijeme);
            t.Elapsed += Timer_Elapsed;
        }

        private void btnPostavi_Click(object sender, EventArgs e)
        {
            

        }

        private void vrijeme(object s, EventArgs e)
        {
            //Metoda Invoke izvršava delegata na niti koja je vlasnik
            //rukovatelja kontrola (uobičajeno, glavna nit)
            //MethodInvoker je delegat koji može izvršiti bilo koju
            //metodu koja ne vraća ništa i nema parametre
            Invoke((MethodInvoker)delegate //Anonimna metoda
            {
                lblTime.Text = DateTime.Now.ToLongTimeString();
            });
        }
        

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            DateTime currentTime = DateTime.Now;
            DateTime userTime = dateTimePicker.Value;
            if (currentTime.Hour == userTime.Hour && currentTime.Minute == userTime.Minute && currentTime.Second == userTime.Second)
            {
                t.Stop();
                System.Media.SoundPlayer player = new System.Media.SoundPlayer("C:/Users/Bljeona/Documents/beepOne.wav");
                player.Play();
                btnPostavi.Text = "Zaustavi";
               
            }
        }
    }
}

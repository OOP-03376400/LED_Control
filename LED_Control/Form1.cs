using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LED_Control
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (sender == button1)
            {
                pictureBox1.Load("REDOn.jpg");
                serialportWrite("LED 1,1");

            }
            if (sender == button2)
            {
                pictureBox1.Load("REDOff.jpg");
                serialportWrite("LED 1,0");
            }
            if (sender == button3)
            {
                pictureBox2.Load("REDOn.jpg");
                serialportWrite("LED 2,1");
            }
            if (sender == button4)
            {
                pictureBox2.Load("REDOff.jpg");
                serialportWrite("LED 2,0");
            }
            if (sender == button5)
            {
                pictureBox3.Load("REDOn.jpg");
                serialportWrite("LED 3,1");
            }
            if (sender == button6)
            {
                pictureBox3.Load("REDOff.jpg");
                serialportWrite("LED 3,0");
            }
            if (sender == button7)
            {
                pictureBox4.Load("REDOn.jpg");
                serialportWrite("LED 4,1");
            }
            if (sender == button8)
            {
                pictureBox4.Load("REDOff.jpg");
                serialportWrite("LED 4,0");
            }

        }

        private void serialportWrite(string v)
        {
            if (serialPort1.IsOpen)
                serialPort1.WriteLine(v);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                MessageBox.Show("Please enter serial port name.");
            serialPort1.PortName = textBox1.Text;
            if (serialPort1.IsOpen) serialPort1.Close();
            serialPort1.Open();
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string ss = serialPort1.ReadExisting();
            this.Invoke(new MethodInvoker(() => { textBox2.Text += ss; }));
        }

        private void button10_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        int count = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            serialportWrite("LED 1,0");
            serialportWrite("LED 2,0");
            serialportWrite("LED 3,0");
            serialportWrite("LED 4,0");

            switch (count)
            {
                case 0:
                    serialportWrite("LED 1,1");
                    serialportWrite("LED 2,1");
                    break;
                case 1:
                    serialportWrite("LED 2,1");
                    serialportWrite("LED 3,1");
                    break;
                case 2:
                    serialportWrite("LED 3,1");
                    serialportWrite("LED 4,1");
                    break;
                case 3:
                    serialportWrite("LED 4,1");
                    serialportWrite("LED 1,1");
                    break;

            }
            count++;
            count %= 4;


        }




    }
}

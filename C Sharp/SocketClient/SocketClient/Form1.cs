using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace SocketClient
{
    public partial class Form1 : Form
    {
        int port;
        string message;
        int byteCount;
        NetworkStream stream;
        byte[] sendData;
        TcpClient client;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if(!int.TryParse(textBox1.Text, out port))
            {
                MessageBox.Show("Port number not valied");
                listBox1.Items.Add("Port number invalied");
            }
            try
            {
                client = new TcpClient(textBox3.Text, port);
                MessageBox.Show("Connection Made");
                listBox1.Items.Add("Made connection with " + textBox3.Text);
            }
            catch (System.Net.Sockets.SocketException)
            {
                MessageBox.Show("Connection Failed");
                listBox1.Items.Add("Connection failed");
            }
            
           
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                message = textBox2.Text;
                byteCount = Encoding.ASCII.GetByteCount(message);
                sendData = new byte[byteCount];
                sendData = Encoding.ASCII.GetBytes(message);
                stream = client.GetStream();
                stream.Write(sendData, 0, sendData.Length);
                listBox1.Items.Add("Sent Data " + message);
            }
            catch (System.NullReferenceException)
            {
                MessageBox.Show("Connection not installised");
                listBox1.Items.Add("Failed to send data");
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            stream.Close();
            client.Close();
            listBox1.Items.Add("Connection terminated");
        }
    }
}

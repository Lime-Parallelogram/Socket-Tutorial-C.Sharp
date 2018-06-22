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
        byte[] bytes = new byte[256];
        TcpListener server;
        TcpClient clientconnection;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            server = new TcpListener(IPAddress.Any, 8000);
            server.Start();
            listBox1.Items.Add("Server Started");
            clientconnection = server.AcceptTcpClient();
            timer1.Start();
        }

  

        private void timer1_Tick(object sender, EventArgs e)
        {
            NetworkStream streamIn = clientconnection.GetStream();
            byte[] buffer = new byte[clientconnection.ReceiveBufferSize];
            int Data = streamIn.Read(buffer, 0, clientconnection.ReceiveBufferSize);
            string ch = Encoding.ASCII.GetString(buffer, 0, Data);
            listBox1.Items.Add(ch);
        }
    }
}

       

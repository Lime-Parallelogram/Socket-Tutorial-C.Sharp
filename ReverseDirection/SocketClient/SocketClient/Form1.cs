//Required Libs
using System;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace SocketClient //Sorry about the naming issue (This is a server)
{
    public partial class Form1 : Form
    {
        //Vars
        TcpListener server;
        TcpClient clientconnection;

        public Form1()
        {
            //Loads form components
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            server = new TcpListener(IPAddress.Any, 8000); //Opens server port
            server.Start(); //Starts server
            listBox1.Items.Add("Server Started"); //Adds info to list
            clientconnection = server.AcceptTcpClient(); //Accepts connection request
            timer1.Start(); //Starts timer to check stream at regular intervals
        }

  

        private void timer1_Tick(object sender, EventArgs e)
        {
            NetworkStream DataStream = clientconnection.GetStream(); //Gets the data stream
            byte[] buffer = new byte[clientconnection.ReceiveBufferSize]; //Gets required buffer size
            int Data = DataStream.Read(buffer, 0, clientconnection.ReceiveBufferSize); //Gets message (encoded)
            string message = Encoding.ASCII.GetString(buffer, 0, Data); //Decoodes message
            listBox1.Items.Add(message); //Adds message to output window
        }
    }
}

       

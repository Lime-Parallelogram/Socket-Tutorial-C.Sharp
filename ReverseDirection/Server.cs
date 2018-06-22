//Required Libs
using System;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

//Vars
TcpListener server;
TcpClient clientconnection;

server = new TcpListener(IPAddress.Any, 8000); //Opens Server on said port
server.Start(); //Starts listener
clientconnection = server.AcceptTcpClient(); //Accepts Request

NetworkStream DataStream = clientconnection.GetStream(); //Gets data stream
byte[] buffer = new byte[clientconnection.ReceiveBufferSize];
int Data = DataStreamstream.Read(buffer, 0, clientconnection.ReceiveBufferSize); //Recieves data (encoded)
string message = Encoding.ASCII.GetString(buffer, 0, Data); //Decodes data (note: the python .encode() function uses the ASCII code)
//Recieved message as message

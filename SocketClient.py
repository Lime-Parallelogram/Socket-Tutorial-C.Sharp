#Imports library
import socket

#Creates instance of 'Socket'
s = socket.socket()

hostname = 'tutorialspi' #Server IP/Hostname
port = 8000 #Server Port

s.connect((hostname,port)) #Connects to server

while True:
    x = raw_input("Enter message: ") #Gets the message to be sent
    s.send(x.encode()) #Encodes and sends message (x)

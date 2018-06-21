import socket

s = socket.socket()
host = 'rpz5'
port =8000
s.connect((host,port))

Open = True
def ts(str):
   s.send(r.encode()) 
   data = ''
   data = s.recv(1024).decode()
   print (data)
while Open:
   r = raw_input("Enter Command: ")
   if r == 'qut':
      Open = False
   ts(r)

#print s.recv(1024)
s.close()

import socket
import RPi.GPIO as GPIO
import time

listensocket = socket.socket()
Port = 8000
maxConnections = 999
IP = socket.gethostname()

listensocket.bind(('',Port))

listensocket.listen(maxConnections)
print("Server started at " + IP + " on port " + str(Port))

(clientsocket, address) = listensocket.accept()
print("New connection made!")

running = True

GPIO.setmode(GPIO.BOARD)
GPIO.setup(7,GPIO.OUT)

while running:
    message = clientsocket.recv(1024).decode()
    print(message)
    if not message == "":
        GPIO.output(7,True)
        time.sleep(5)
        GPIO.output(7,False)

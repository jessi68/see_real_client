import socket
import SEEREAL
import cv2
import numpy as np
import time

HOST = '192.168.1.6'
PORT = 50001;
BUFFER_SIZE = 100;

serverSocket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
recvAddress = (HOST, PORT)
serverSocket.bind(recvAddress)

serverSocket.listen(1)
 
conn, addr = serverSocket.accept()

# recv and send loop
while 1:
    data = conn.recv(BUFFER_SIZE)
    # 받고 data를 돌려줌.
    if(data != b''):
        data = data.decode('UTF-8');
        file = open('./pattern_txt/test.txt', 'w');
        dataArray = data.split('\n');
        for i in range(4):
            line = dataArray[i]
            file.write(line + '\n');
        file.close();
        SEEREAL.SEEREAL();
        time.sleep(5);
        with open("./test.png", "rb") as image:
            file = image.read()
            b_file = bytearray(file)
        print(len(b_file));
        print(b_file[0:10]);
        # file = open('./test.png', 'rb');
        # b_file = file.read();
        # file.close();
        conn.sendall(b_file);

conn.close()

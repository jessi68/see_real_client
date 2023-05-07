import socket

HOST = '127.0.0.1'
PORT = 50001;

# socket create and connection
sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
sock.connect((HOST, PORT))

# send msg
test_msg = "안녕하세요 상대방님"
sock.send(test_msg)

# recv data
data_size = 512
data = sock.recv(data_size)

# connection close
sock.close()
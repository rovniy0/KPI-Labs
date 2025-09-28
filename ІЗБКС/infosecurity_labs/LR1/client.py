import socket
HOST = '127.0.0.1'  # IP
PORT = 65432        # port
with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
    s.connect((HOST, PORT))
    message = input("Введіть повідомлення: ")
    s.sendall(message.encode())
    data = s.recv(1024)
    print("Від сервера:", data.decode())


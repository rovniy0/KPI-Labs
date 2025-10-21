import socket
import time

HOST = "127.0.0.1"
PORT = 5001

with socket.socket(socket.AF_INET, socket.SOCK_DGRAM) as client:
    for i in range(1, 101):
        message = f"Message №{i}"
        start_time = time.time()

        client.sendto(message.encode(), (HOST, PORT))

        client.settimeout(2)
        try:
            data, addr = client.recvfrom(1024)
            status = data.decode()
        except socket.timeout:
            status = "No response. Packets lost."

        end_time = time.time()
        print(f"[{i}] Response: {status} | Time={end_time - start_time:.6f} sec")


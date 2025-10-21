import socket
import time
import random

HOST = "127.0.0.1"
PORT = 5001
LOG_FILE = "udp_log.txt"

with socket.socket(socket.AF_INET, socket.SOCK_DGRAM) as server:
    server.bind((HOST, PORT))
    server.settimeout(10)
    print(f"UDP-сервер запущено на {HOST}:{PORT}")

    while True:
        try:
            data, addr = server.recvfrom(1024)
        except socket.timeout:
            print("Немає сигналів більше 10 секунд. Сервер завершує роботу.")
            break

        start_time = time.time()
        message = data.decode()
        print(f"Отримано від {addr}: {message}")

        if random.random() < 0.1:
            print("Імітація випадкової втрати пакету, відповіді не буде")
            status = "Випадкова втрата пакету"
        else:
            reply = "UDP: Дані отримано"
            server.sendto(reply.encode(), addr)
            status = "Відповідь відправлена"

        end_time = time.time()
        delay = end_time - start_time
        print(f"Час обробки: {delay:.6f} сек")

        with open(LOG_FILE, "a", encoding="utf-8") as log:
            log.write(f"{time.strftime('%Y-%m-%d %H:%M:%S')} | UDP | {status} | Час={delay:.6f} сек\n")

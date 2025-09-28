import socket
HOST = '127.0.0.1'  # localhost
PORT = 65432        # port
with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
    s.bind((HOST, PORT))      # звязуємо порт і хост
    s.listen()                # waiting for connect
    print(f"Сервер запущено на {HOST}:{PORT}")

    while True:
        conn, addr = s.accept()  # прийняти конект
        with conn:
            print(f"Підключено: {addr}")
            while True:
                data = conn.recv(1024)  # прийом даних
                if not data:
                    break
                response = data.upper()  # .upper -- верхній регістр
                conn.sendall(response)   # повернення даних клієнту


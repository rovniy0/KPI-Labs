from flask import Flask, request, render_template
from flask_mail import Mail, Message

app = Flask(__name__)
app.config['MAIL_SERVER'] = 'smtp.ukr.net'
app.config['MAIL_PORT'] = 465
app.config['MAIL_USE_TLS'] = False
app.config['MAIL_USE_SSL'] = True
app.config['MAIL_USERNAME'] = 'grisharovniy@ukr.net'
app.config['MAIL_PASSWORD'] = 'egtODVstJ41wLKQB'


mail = Mail(app)


@app.route('/', methods=['GET', 'POST'])
def index():
    return render_template('ТР-23 Ровний ЛР6.html')

@app.route('/send_email', methods=['POST'])
def send_email():
  if request.method == 'POST':
    data = request.get_json()
    #webkpi21@gmail.com

    msg = Message('Новий вхід', sender='grisharovniy@ukr.net', recipients=['rovniy.grisha@lll.kpi.ua'])
    msg.body = f"Користувач авторизований:\nEmail: {data['email']}\nПароль: {data['password']}"
    mail.send(msg)
    return "Message sent"

@app.route('/submit_registration_form', methods=['POST'])
def submit_registration_form():
    if request.method == 'POST':
        data = request.get_json()

        body =  f"Ім'я: {data.get('name')}\n"
        body += f"Прізвище: {data.get('surname')}\n"
        body += f"Стать: {data.get('gender')}\n"
        body += f"Вік: {data.get('age')}\n"
        body += f"Дата народження: {data.get('birthday')}\n"
        body += f"Країна проживання: {data.get('country')}\n"
        body += f"Номер телефону: {data.get('phoneNumber')}\n"
        body += f"Соцмережа: {data.get('socialMedia')}\n"
        body += f"Електронна пошта: {data.get('email')}\n"
        body += f"Пароль: {data.get('password')}\n"

        msg = Message('Дані з форми реєстрації', sender='grisharovniy@ukr.net', recipients=['rovniy.grisha@lll.kpi.ua'])
        msg.body = body
        mail.send(msg)
        return "Registration data received"

@app.route('/submit_feedback_form', methods=['POST'])
def submit_feedback_form():
    if request.method == 'POST':
        data = request.get_json()
        # Опрацьовуйте дані зворотного зв'язку тут
        # Наприклад, відправка на електронну пошту або збереження в базу даних
        return "Feedback data received"

if __name__ == '__main__':
    app.run(debug=True)

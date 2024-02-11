// Форма входу
function sendLoginForm() {
  const email = document.getElementById("loginEmail").value;
  const password = document.getElementById("loginPassword").value;
  // Перетворюємо дані в JSON об'єкт
  const data = {
    email: email,
    password: password,
  };
  // Формуємо запит
  const request = new XMLHttpRequest();
  request.open("POST", "/send_email");
  request.setRequestHeader("Content-Type", "application/json");

  // Відправляємо запит
  request.send(JSON.stringify(data));

  // Обробляємо відповідь
  request.onload = function () {
    if (request.status === 200) {
      alert("Дані успішно відправлено на пошту.");
    } else {
      alert("Помилка при відправці даних.");
    }
  };
}

//Форма реєстрації
function sendRegistrationForm() {
  const name = document.getElementById("name").value;
  const surname = document.getElementById("surname").value;
  const gender = document.querySelector('input[name="gender"]:checked').value;
  const age = document.getElementById("age").value;
  const birthday = document.getElementById("birthday").value;
  const country = document.getElementById("country").value;
  const phoneNumber = document.getElementById("phoneNumber").value;
  const socialMedia = document.getElementById("socialMedia").value;
  const email = document.getElementById("email").value;
  const password = document.getElementById("password").value;

  const data = {
    name: name,
    surname: surname,
    gender: gender,
    age: age,
    birthday: birthday,
    country: country,
    phoneNumber: phoneNumber,
    socialMedia: socialMedia,
    email: email,
    password: password,
  };

  const request = new XMLHttpRequest();
  request.open("POST", "/submit_registration_form");
  request.setRequestHeader("Content-Type", "application/json");

  request.send(JSON.stringify(data));

  request.onload = function () {
    if (request.status === 200) {
      alert("Дані реєстрації успішно відправлено.");
    } else {
      alert("Помилка при відправці даних реєстрації.");
    }
  };
}

// Форма зворотнього зв'язку
function sendFeedbackForm() {
  const feedbackName = document.getElementById("feedbackName").value;
  const feedbackEmail = document.getElementById("feedbackEmail").value;
  const feedbackTopic = document.getElementById("feedbackTopic").value;
  const feedbackMessage = document.getElementById("feedbackMessage").value;

  const data = {
    feedbackName: feedbackName,
    feedbackEmail: feedbackEmail,
    feedbackTopic: feedbackTopic,
    feedbackMessage: feedbackMessage,
  };

  const request = new XMLHttpRequest();
  request.open("POST", "/submit_feedback_form");
  request.setRequestHeader("Content-Type", "application/json");

  request.send(JSON.stringify(data));

  request.onload = function () {
    if (request.status === 200) {
      alert("Дані зворотного зв'язку успішно відправлено.");
    } else {
      alert("Помилка при відправці даних зворотного зв'язку.");
    }
  };
}

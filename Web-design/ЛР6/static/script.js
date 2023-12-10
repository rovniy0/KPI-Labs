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

//Завдання №1
function createUser() {
  let userID = document.getElementById("userID").value;
  let userLogin = document.getElementById("userLogin").value;
  let userPassword = document.getElementById("userPassword").value;
  let user = {
    ID: userID,
    login: userLogin,
    password: userPassword,
  };
  console.log(
    "ID:",
    user.ID,
    "Користувач:",
    user.login,
    "Пароль:",
    user.password
  );
}

//Завдання №2
function createAdmin() {
  let admin = {
    type: "admin",
    add: function (user) {
      if (this.type === "admin") {
        console.log("Користувач доданий:", user);
      } else {
        console.log("Неможливо додати користувача. Об'єкт не є типу 'admin'.");
      }
    },
    remove: function (user) {
      if (this.type === "admin") {
        let index = this.users.indexOf(user);
        if (index !== -1) {
          this.users.splice(index, 1);
          console.log("Користувач видалений:", user);
        } else {
          console.log("Користувач не знайдений:", user);
        }
      } else {
        console.log(
          "Неможливо видалити користувача. Об'єкт не є типу 'admin'."
        );
      }
    },
    change: function (oldUser, newUser) {
      if (this.type === "admin") {
        let index = this.users.indexOf(oldUser);
        if (index !== -1) {
          this.users[index] = newUser;
          console.log("Користувач змінений:", oldUser, "=>", newUser);
        } else {
          console.log("Користувач не знайдений:", oldUser);
        }
      } else {
        console.log("Неможливо змінити користувача. Об'єкт не є типу 'admin'.");
      }
    },
  };
  console.log(admin);
}

function combineProperties() {}

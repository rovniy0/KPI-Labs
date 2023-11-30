//Завдання №1
let user = {
  ID: "",
  login: "",
  password: "",
};

function createUser() {
  let userID = document.getElementById("userID").value;
  let userLogin = document.getElementById("userLogin").value;
  let userPassword = document.getElementById("userPassword").value;

  user.ID = userID;
  user.login = userLogin;
  user.password = userPassword;
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
let admin = {
  type: "admin",
  users: [],
  add: function (user) {
    if (this.type === "admin") {
      console.log("Користувач доданий:", user);
      this.users.push(user);
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
      console.log("Неможливо видалити користувача. Об'єкт не є типу 'admin'.");
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
//------------------------------------

function doTask2() {
  let potniyStudent = {
    ID: "344363",
    login: "potniyPlayer",
    password: "potniyPassword",
  };
  let newUser = {
    ID: "456",
    login: "newLogin",
    password: "newPassword",
  };
  admin.add(potniyStudent);
  console.log(admin);
  admin.change(potniyStudent, newUser);
  console.log(admin);
  admin.remove(newUser);
  console.log(admin);
}
//----------------------------
// Завдання 3
function combineUserAndAdmin() {
  let combinedObject = Object.assign({}, user, admin);
  console.log("Об'єднаний об'єкт:", combinedObject);
}

// Завдання 4
Object.prototype.showData = function () {
  console.log(
    "ID:",
    this.ID,
    "Користувач:",
    this.login,
    "Пароль:",
    this.password
  );
};
// Виклик ShowDate
function ShowData() {
  user.showData();
}

// Завдання №5
let user2 = Object.create(user);
user2.isAdmin = true;
user2.ID = "222";
user2.login = "pes_patron";
user2.password = "gav";
// Перевизначення методу ShowDate
user2.showData = function () {
  console.log(
    "ID:",
    user2.ID,
    "Користувач:",
    user2.login,
    "Пароль:",
    user2.password,
    "Адмін:",
    user2.isAdmin
  );
};
function ShowDataUser2() {
  user2.showData();
}

//Завдання 6

// Клас "КористувачКлас"
class UserClass {
  constructor(ID, login, password) {
    this._ID = ID;
    this._login = login;
    this._password = password;
  }

  get ID() {
    return this._ID;
  }

  set ID(newID) {
    this._ID = newID;
  }

  get login() {
    return this._login;
  }

  set login(newLogin) {
    this._login = newLogin;
  }

  get password() {
    return this._password;
  }

  set password(newPassword) {
    this._password = newPassword;
  }

  showData() {
    console.log(
      "ID:",
      this.ID,
      "Користувач:",
      this.login,
      "Пароль:",
      this.password
    );
  }
}

class AdminClass extends UserClass {
  constructor(ID, login, password, isAdmin) {
    super(ID, login, password);
    this._isAdmin = isAdmin;
  }

  get isAdmin() {
    return this._isAdmin;
  }

  set isAdmin(newIsAdmin) {
    this._isAdmin = newIsAdmin;
  }
  showData() {
    console.log(
      "ID:",
      this.ID,
      "Користувач:",
      this.login,
      "Пароль:",
      this.password,
      "Адмін:",
      this.isAdmin
    );
  }
}
let userClassInstance = new UserClass("343", "Shaurma", "so-svininoy");
let adminClassInstance = new AdminClass(
  "767",
  "Kievsky_Tortik",
  "VKUSNO",
  true
);
function ShowClass() {
  userClassInstance.showData();
  adminClassInstance.showData();
}

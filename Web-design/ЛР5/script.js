var quizData = [
  {
    // Одна відповідь
    type: "base",
    question: "Що таке блочна модель у веб-розробці?",
    answers: [
      "Спосіб розміщення елементів на веб-сторінці",
      "Модель, яка використовується для шифрування даних",
      "Архітектурний підхід до створення серверів",
      "Математична модель роботи алгоритмів",
    ],
    correct: "Спосіб розміщення елементів на веб-сторінці",
  },

  {
    // багато відповідей
    type: "multiple choice",
    question:
      "Які властивості визначають позицію елемента в блочній моделі CSS?",
    answers: [
      "position",
      "display",
      "float",
      "margin",
      "padding",
      "top",
      "left",
      "right",
      "bottom",
    ],
    correct: ["position", "top", "left", "right", "bottom"],
  },

  {
    // Ввести код / текст
    type: "enter text",
    question:
      "Напишіть css властивість для вирівнювання для вирівнювання елемента всередині конейнера ",
    correct: "margin: 0 auto;",
  },

  {
    // Ввести код / текст
    type: "enter text",
    question: "Що таке позиціонування 'relative' у CSS?",
    correct: "елемент зсувається відносно свого звичайного положення",
  },

  {
    // Ввести код / текст
    type: "enter text",
    question: "Назвіть основні значення властивості 'position' у CSS.",
    correct: "static, relative, absolute, fixed",
  },

  {
    // Одна відповідь
    type: "base",
    question: "Яка основна різниця між блочним та строчковим елементами в CSS?",
    answers: [
      "Блочні елементи займають весь доступний простір по ширині, строчкові - лише необхідний",
      "Строчкові елементи завжди розташовані горизонтально, блочні - вертикально",
      "Блочні елементи можуть містити строчкові, але не навпаки",
      "Строчкові елементи мають margin і padding, блочні - ні",
    ],
    correct: "Блочні елементи можуть містити строчкові, але не навпаки",
  },

  {
    // багато відповідей
    type: "multiple choice",
    question: "Які значення може мати властивість 'display' в CSS?",
    answers: ["block", "inline", "inline-block", "flex", "grid", "table"],
    correct: ["block", "inline", "inline-block", "flex", "grid", "table"],
  },

  {
    // випадаючий список
    type: "select",
    question: "Які основні категорії позиціонування елементів у CSS?",
    text: "Елемент %answer% <br><br> Блок %answer% <br><br> Лінія %answer%",
    answers: ["static", "relative", "absolute", "fixed", "sticky"],
    correct: ["Елемент static", "Блок relative", "Лінія absolute"],
  },

  {
    // багато відповідей
    type: "multiple choice",
    question: "Як можна центрувати елемент по горизонталі в CSS?",
    answers: [
      "margin: auto",
      "text-align: center",
      "position: absolute; left: 50%",
      "transform: translateX(-50%)",
    ],
    correct: [
      "margin: auto",
      "text-align: center",
      "transform: translateX(-50%)",
    ],
  },

  {
    // випадаючий список
    type: "select",
    question: "Як в CSS визначити порядок накладання елементів один на одного?",
    text: "Елемент з %answer% <br><br> має %answer% пріоритету <br><br> перед елементом з %answer%",
    answers: [
      "position: relative",
      "position: absolute",
      "position: fixed",
      "z-index",
      "position: static",
    ],
    correct: [
      "Елемент з position: relative",
      "має z-index пріоритету",
      "перед елементом з position: static",
    ],
  },
];

const modal = document.querySelector(".modal");
const openModalBtn = document.querySelector(".start_test");
const overlay = document.querySelector(".overlay");
const submitBtn = document.querySelector(".start_test");
const quizInner = document.querySelector(".start-page");
const header = document.querySelector(".header");
var headerContainer;
var taskContainer;
var loginInfo = {};
let score = 0;
let questionIndex = 0;

openModalBtn.addEventListener("click", openModal);
overlay.addEventListener("click", closeModal);

submitBtn.addEventListener(
  "click",
  () => {
    submitBtn.onclick = checkAnswer;
    saveInfo();
    changeModal();
    shuffle(quizData);
    showQuestion();
  },
  { once: true }
);

function openModal() {
  modal.classList.remove("hidden");
  overlay.classList.remove("hidden");
}

function closeModal() {
  modal.classList.add("hidden");
  overlay.classList.add("hidden");
}

function saveInfo() {
  loginInputs = document.querySelectorAll(".login");
  for (i = 0; i < loginInputs.length; i++) {
    var element = loginInputs[i];
    var name = element.name;
    var value = element.value;
    if (name) {
      loginInfo[name] = value;
    }
  }
}
function changeModal() {
  quizInner.innerHTML = `<div class="header_container"></div>
    <div class="task_container">
      <ul class="quiz_list">
      </ul>
    </div>`;
  headerContainer = document.querySelector(".header_container");
  taskContainer = document.querySelector(".task_container");
  listContainer = document.querySelector(".quiz_list");
  submitBtn.innerHTML = "Next";
  quizInner.style.display = "block";
}

function clearPage() {
  headerContainer.innerHTML = "";
  listContainer.innerHTML = "";
}

function shuffle(array) {
  let j, temp;
  for (let i = array.length - 1; i > 0; i--) {
    j = Math.floor(Math.random() * (i + 1));
    temp = array[j];
    array[j] = array[i];
    array[i] = temp;
  }
  return array;
}

function showQuestion() {
  const headerTemplate = `<h2 class="title">%title%</h2>`;
  const title = headerTemplate.replace(
    "%title%",
    quizData[questionIndex]["question"]
  );
  headerContainer.innerHTML = title;

  if (quizData[questionIndex]["type"] === "base") {
    shuffle(quizData[questionIndex]["answers"]);
    for (answerText of quizData[questionIndex]["answers"]) {
      const questionTemplate = `<li>
            <label>
                <input value="%answer%" type="radio" class="answer" name="answer" />
                <span>%answer%</span>
            </label>
        </li>`;
      const answerHtml = questionTemplate
        .replace("%answer%", answerText)
        .replace("%answer%", answerText);
      listContainer.innerHTML += answerHtml;
    }
  } else if (quizData[questionIndex]["type"] === "multiple choice") {
    shuffle(quizData[questionIndex]["answers"]);
    for (answerText of quizData[questionIndex]["answers"]) {
      const questionTemplate = `<li>
            <label>
                <input value="%answer%" type="checkbox" class="answer" name="answer" />
                <span>%answer%</span>
            </label>
        </li>`;
      const answerHtml = questionTemplate
        .replace("%answer%", answerText)
        .replace("%answer%", answerText);
      listContainer.innerHTML += answerHtml;
    }
  } else if (quizData[questionIndex]["type"] === "enter text") {
    const answerHtml = `<li>
            <label>
                <input type="text" class="answer" name="answer" placeholder="Answer" />
            </label>
      </li>`;
    listContainer.innerHTML = answerHtml;
  } else if (quizData[questionIndex]["type"] === "select") {
    shuffle(quizData[questionIndex]["answers"]);

    const selectTemplate = `<select class="quiz_select"></select>`;
    let textTemplate = quizData[questionIndex]["text"];
    for (i = 0; i < quizData[questionIndex]["answers"].length; i++) {
      textTemplate = textTemplate.replace("%answer%", selectTemplate);
    }
    const text = `<p class="select_text"> ${textTemplate}</p>`;
    listContainer.innerHTML = text;

    const selectContainer = taskContainer.querySelectorAll(".quiz_select");
    for (j = 0; j < selectContainer.length; j++) {
      selectContainer[
        j
      ].innerHTML += `<option selected="selected" disabled="disabled">Select</option>`;
      for (i = 0; i < quizData[questionIndex]["answers"].length; i++) {
        selectContainer[
          j
        ].innerHTML += `<option>${quizData[questionIndex]["answers"][i]}</option>`;
      }
    }
  }
}

function checkAnswer() {
  if (quizData[questionIndex]["type"] === "normal") {
    const checkedRadio = taskContainer.querySelector(
      'input[type="radio"]:checked'
    );

    const userAnswer = checkedRadio.value;

    if (userAnswer === quizData[questionIndex]["correct"]) {
      score++;
    }
  } else if (quizData[questionIndex]["type"] === "multiple choice") {
    const checkedCheckBox = Array.from(
      taskContainer.querySelectorAll('input[type="checkbox"]:checked')
    );
    let userAnswer = [];
    for (i = 0; i < checkedCheckBox.length; i++) {
      userAnswer[i] = checkedCheckBox[i].value;
    }

    if (
      JSON.stringify(quizData[questionIndex]["correct"].sort()) ===
      JSON.stringify(userAnswer.sort())
    ) {
      score++;
    }
  } else if (quizData[questionIndex]["type"] === "enter text") {
    let userAnswer = taskContainer.querySelector('input[type="text"]');

    if (quizData[questionIndex]["correct"] === userAnswer.value) {
      score++;
    }
  } else if (quizData[questionIndex]["type"] === "select") {
    const userAnswerTemplate = Array.from(
      taskContainer.querySelectorAll(".quiz_select")
    );
    let userAnswer = [];
    for (i = 0; i < userAnswerTemplate.length; i++) {
      userAnswer[i] = userAnswerTemplate[i].value;
    }

    if (
      JSON.stringify(quizData[questionIndex]["correct"]) ===
      JSON.stringify(userAnswer)
    ) {
      score++;
    }
  }

  if (questionIndex !== 9) {
    questionIndex++;
    clearPage();
    showQuestion();
    return;
  } else {
    clearPage();
    showResults();
  }
}

function showResults() {
  const headerTemplate = `<h2 class="title">Quiz completed!</h2>`;
  headerContainer.innerHTML = headerTemplate;

  const resultTemplate = `<h3 class="result_msg">%result%</h3>`;
  let result = `${loginInfo.name}, your result - ${score} / 10`;
  const finalResult = resultTemplate.replace("%result%", result);
  taskContainer.innerHTML = finalResult;
  loginInfo.score = `${score}/10`;

  submitBtn.innerHTML = "Finish!";
}

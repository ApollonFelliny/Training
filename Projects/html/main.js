let name = document.getElementById("name");
let age = document.getElementById("age");
let email = document.getElementById("email");
let message = document.getElementById("message");
let inputs = document.querySelectorAll("input, textarea");

let form = document.querySelector("form");
let button = document.getElementById("button");

let sideBar = document.getElementById("side-bar");

const BOT_TOKEN = "8584804127:AAHurc_bV0NrHU5s9CSF7epUSgwlbws7j8M";
const CHAT_ID = "1512047981";

function sendForm() {
  let allowForm = true;

  for (let i = 0; i < inputs.length; i++) {
    if (inputs[i].value === "") {
      allowForm = false;
      break;
    }
  }

  if (!allowForm) {
    alert("Пожалуйста, введите все данные");
  } else {
    const tgMessage =
      "Новое сообщение от пользователя: \n\nИмя: " +
      name.value +
      "\nВозраст: " +
      age.value +
      "\nEmail: " +
      email.value +
      "\nСообщение: " +
      message.value;

    const data = {
      chat_id: CHAT_ID,
      text: tgMessage,
    };

    fetch(`https://api.telegram.org/bot${BOT_TOKEN}/sendMessage`, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(data),
    })
      .then((res) => res.json())
      .then((data) => {
        form.innerHTML = `<h1 style="text-align: center; color: #00ff88;">Сообщение отправлено!</h1>`;
        button.style.display = "none";
      })
      .catch((err) => alert("Что-то пошло не так. Попробуйте позже."));

    for (let k = 0; k < inputs.length; k++) {
      inputs[k].value = "";
    }
  }
}

function openSideBar() {
  sideBar.classList.add('open');
  document.body.style.overflow = 'hidden';
}

function closeSideBar() {
  sideBar.classList.remove('open');
  document.body.style.overflow = 'auto';
}

// Закрытие шторки при клике вне ее области
document.addEventListener('click', function(e) {
  if (sideBar.classList.contains('open') && 
      !sideBar.contains(e.target) && 
      !e.target.classList.contains('menu-icon')) {
    closeSideBar();
  }
});

// Закрытие шторки по ESC
document.addEventListener('keydown', function(e) {
  if (e.key === 'Escape' && sideBar.classList.contains('open')) {
    closeSideBar();
  }
});

// Плавная прокрутка для якорных ссылок
document.querySelectorAll('a[href^="#"]').forEach(anchor => {
  anchor.addEventListener('click', function (e) {
    e.preventDefault();
    const target = document.querySelector(this.getAttribute('href'));
    if (target) {
      target.scrollIntoView({
        behavior: 'smooth',
        block: 'start'
      });
      closeSideBar();
    }
  });
});
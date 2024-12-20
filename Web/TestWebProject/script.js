const button = document.querySelector("button");
button.addEventListener("click", updateName);

function updateName() {
  const name = prompt("Введите новое имя");
  const paragraph = document.querySelector("p");
  paragraph.textContent = `Привет! Меня зовут ${name}. Я учусь на программиста и хочу в будущем создавать кучу интересных проектов`;

  const width = prompt("Введите новую ширину картинки");
  const img = document.querySelector("img");
  img.width = width;
}

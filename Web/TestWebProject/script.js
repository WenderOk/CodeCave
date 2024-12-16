const button = document.querySelector("button");
button.addEventListener("click", updateName);

function updateName() {
  const name = prompt("Enter ur name");
  const paragraph = document.querySelector("p");
  paragraph.textContent = `Hello, ${name}!`;
}

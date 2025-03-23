import * as readline from "node:readline";

const rl = readline.createInterface({
  input: process.stdin,
  output: process.stdout,
});

let item = {
  name: "Яблоки",
  price: 150,
  quantity: 5,
};

// console.log(item);

item.check = function () {
  console.log(`Товар ${this.name}, находится на складе: ${this.quantity}`);
};

item.sell = function (qty) {
  if (this.quantity >= qty) {
    this.quantity -= qty;
    console.log(`Продан товар: ${this.name}\nКоличество: ${qty}`);
  } else {
    console.log(`Недостаточно товара на складе`);
  }
};

item.add = function (qty) {
  this.quantity += qty;
  console.log(`Добавлено товар: ${this.name}\nКоличество: ${qty}`);
};

let qty;

qty = await rl.question("What do you think of Node.js? ");
rl.close();

// item.sell(readline.question("Сколько продать?")); // продали 2 яблока
item.check(); // проверяем количество. Должно остаться 3
item.add(qty); // добовляем 12 яблок. Теперь должно быть 15
item.check();

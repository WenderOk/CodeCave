let str = "Я ЛюБлЮ JavaScript"; // исходная строка​
let regexp = /люблю/i; // регулярное выражение​

console.log(regexp.test(str)); // выведет true

// В данном коде сначала мы создаем переменую str со строкой "Я ЛюБлЮ JavaScript" внутри.
// Затем мы создаем переменную regexp со значением /люблю/i.
// И в конце выводим через, console.log результат вызванного у regexp метода .test
// он выведет true, потому что строка str создержит в себе подстроку "люблю", которое указано в регулярном выражении.

// Флаг i судя по всему нужен для игнорирования регистра при проверке. Если его убрать в кончоль выведется false,
// потому что регистр будет учитываться и выйдет так что ЛюБлЮ не равно люблю.
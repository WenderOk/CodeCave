let uint8Array1 = new Uint8Array([72, 101, 108, 108, 111]);
console.log( new TextDecoder().decode(uint8Array1) ); // Hello

let uint8Array2 = new Uint8Array([228, 189, 160, 229, 165, 189]);
console.log( new TextDecoder().decode(uint8Array2) ); // 你好

let uint8Array3 = new Uint8Array([240, 159, 152, 177]);
console.log( new TextDecoder().decode(uint8Array3) ); // 😱

// В этом коде мы создаем 3 бинарных массива в которые записываем последовательность байтов,
// кодирующих определенные символы. Затем мы с помощью метода объекта TextDecoder .decode декадируем байты в символы строки
// и выводим их в колнсоль
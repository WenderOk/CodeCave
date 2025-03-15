// 1.а Поиск максимального значения

let arr = [654, 684, 32, -15, 4625, 12, -14];

function MaxElement(arr) {
  let maxIndex = 0;
  for (let i = 0; i < arr.length; i++) {
    if (arr[i] > arr[maxIndex]) {
      maxIndex = i;
    }
  }
  return maxIndex;
}

console.log("Идекс максималього значения:", MaxElement(arr));

// 1.б Поиск максимального и минимального значения

function MinMaxElements(arr) {
  let minIndex = 0;
  let maxIndex = 0;
  for (let i = 1; i < arr.length; i++) {
    if (arr[i] < arr[minIndex]) {
      minIndex = i;
    }
    if (arr[i] > arr[maxIndex]) {
      maxIndex = i;
    }
  }
  return [minIndex, maxIndex];
}
let result = MinMaxElements(arr);
console.log("Идекс максималього значения:", result[1]);
console.log("Идекс минимального значения:", result[0]);

// 2.а, 2.б Пересечения и разница множеств

let s1 = new Set([1, 2, 3, 4, 5, 6]);
let s2 = new Set([5, 1, 10, 2]);

let insect = s1.intersection(s2);
let diff = s1.difference(s2)
console.log("Пересечение множеств: ", [...insect]);
console.log("Разность множеств: ",[...diff]);

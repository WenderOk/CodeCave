let arr = [654, 684, 32, -15, 4625, 12, -14];

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

console.log(MinMaxElements(arr))
// let [indMin, indMax] = MinMaxElements(arr);
// console.log(indMin);
// console.log(arr[indMin]);
// console.log(indMax);
// console.log(arr[indMax]);

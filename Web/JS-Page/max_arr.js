let arr = [654, 684, 32, -15, 4625, 12, -14];

function MinMaxElements(arr) {
  let maxIndex = 0;
  for (let i = 0; i < arr.length; i++) {
    if (arr[i] > arr[maxIndex]) {
      maxIndex = i;
    }
  }
  return maxIndex;
}

console.log(MinMaxElements(arr));
console.log(arr[MinMaxElements(arr)]);

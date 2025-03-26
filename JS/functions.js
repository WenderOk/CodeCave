function arithmetic(arr) {
  let sum = 0;
  for (let i = 0; i < arr.length; i++) {
    sum += arr[i];
  }
  return sum / arr.length;
}

console.log(arithmetic([1, 2, 3, 4, 5, 6, 6, 7, 7, 8]));

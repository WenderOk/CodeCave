let str = "Привет \nмир!";

function repl(str, i, chr) {
  let beg = str.slice(0, i);
  let end = str.slice(i + 1);
  return beg + chr + end;
}

console.log(str);
console.log(repl(str, 3, "v"));

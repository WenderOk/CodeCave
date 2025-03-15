let s1 = new Set([1, 2, 3, 4, 5, 6]);
let s2 = new Set([5, 1, 10, 2]);

let insect = s1.intersection(s2);
let diff = s1.difference(s2)
console.log([...insect]);
console.log([...diff])

function ucFirst(str){
    let result = str[0].toUpperCase() + str.slice(1,str.length);
    return result;
}

console.log(ucFirst("георгий"));

function ucLast(str){
    let result = str.slice(0,str.length-1) + str[str.length-1].toUpperCase();
    return result;
}

console.log(ucLast("георгий"));
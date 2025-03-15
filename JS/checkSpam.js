function checkSpam(str) {
    let result = false;
    str = str.toLowerCase();
    let triggers = ["xxx", "viagra", "casino", "credit"];
    for (let i = 0; i < triggers.length; i++) {
        if (str.includes(triggers[i])) result = true;
    }
    return result
}

console.log(checkSpam("interestingVideos.xxx"));
console.log(checkSpam("random ViagrA"));
console.log(checkSpam("get free Credit now!"));
console.log(checkSpam("Самое честное casino в городе!"));
console.log(checkSpam("какой-то текст..."));
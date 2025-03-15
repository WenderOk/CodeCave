let student = {
  name: "Владислав",
  age: 16,
  group: "РПО",
};

function writeAllFields(obj) {
  for (let key in obj) {
    console.log(key + ": " + obj[key]);
  }
}

writeAllFields(student);
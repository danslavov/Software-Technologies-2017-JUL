function x(input) {
    let list = [];
    for (let el of input) {
        let student = el.split(" -> ");
        let name = student[0];
        let age = student[1];
        let grade = student[2];
        list.push({Name:name, Age:age, Grade:grade});
    }
    list.forEach(s => console.log(`Name: ${s.Name}\nAge: ${s.Age}\nGrade: ${s.Grade}`));
}

// x([ 'Pesho -> 13 -> 6.00', 'Ivan -> 12 -> 5.57', 'Toni -> 13 -> 4.90' ]);
function x(input) {
    let student = {};
    for (let el of input) {
        let pair = el.split(" -> ");
        let key = pair[0];
        let value = pair[1];
        if (!isNaN(parseInt(value)) && key !== "date") {
            value = parseInt(value);
        }
        student[key] = value;
    }
    console.log(JSON.stringify(student));
}

// x(['name -> Angel', 'surname -> Georgiev', 'age -> 20', 'grade -> 6.00', 'date -> 23/05/1995', 'town -> Sofia'])
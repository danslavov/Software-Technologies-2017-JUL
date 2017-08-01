function x(input) {
    let arr = [];
    for (let el of input) {
        let pair = el.split(" ");
        let command = pair[0];
        let argument = Number(pair[1]);
        if (command === "add") {
            arr.push(argument);
        } else if (command === "remove" && arr[argument] !== undefined) {
            arr.splice(argument, 1);
        }
    }
    arr.forEach(e => console.log(e));
}

// x([ 'add 3', 'add 5', 'add 7' ]);
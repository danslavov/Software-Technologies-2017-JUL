function x(input) {
    let arrLength = input[0];
    let arr = new Array(Number(arrLength));
    for (let i = 1; i < input.length; i ++) {
        let pair = input[i].split(" - ");
        let key = pair[0];
        let value = pair[1];
        arr[key] = value;
    }
    for (let element of arr) {
        //console.log(element === undefined ? "0" : element);  -- Judge can't understand it  :D
        if (element !== undefined) {
            console.log(element);
        } else {
            console.log("0");
        }
    }
}

// x([ '5', '0 - 3', '3 - -1', '4 - 2' ]);
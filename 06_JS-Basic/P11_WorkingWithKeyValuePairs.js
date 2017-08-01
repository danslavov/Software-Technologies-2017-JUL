function x(input) {
    let arr = [];
    for (let el of input) {
        let pair = el.split(" ");
        let key = pair[0];
        let value = pair[1];
        if (value !== undefined) {
            arr[key] = value;
        } else {
            if (arr[key] !== undefined) {
                console.log(arr[key]);
            } else {
                console.log("None");
            }
        }
    }
}

// x([ '3 test', '3 test1', '4 test2', '4 test3', '4 test5', '4' ]);
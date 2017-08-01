function x(input) {
    let arr = [];
    for (let el of input) {
        let pair = el.split(" ");
        let key = pair[0];
        let value = pair[1];
        if (value !== undefined) {
            if (arr[key] === undefined) {
                arr[key] = [];
            }
            arr[key].push(value);
        } else {
            if (arr[key] !== undefined) {
                for (let el of arr[key]) {
                    console.log(el);
                }
            } else {
                console.log("None");
            }
        }
    }
}

// x([ '3 test', '3 test1', '4 test2', '4 test3', '4 test5', '4' ]);
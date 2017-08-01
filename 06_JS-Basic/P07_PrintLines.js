function x(input) {
    for (let element of input) {
        if (element === "Stop") {
            break;
        }
        console.log(element);
    }
}

// x(["3", "6", "5", "4", "Stop", "10", "12"]);
function x(input) {
    let negative = false;
    for (num of input) {
        if (num < 0) {
            negative = !negative;
        }
    }
    if (negative) {
        console.log("Negative");
    } else {
        console.log("Positive");
    }
}
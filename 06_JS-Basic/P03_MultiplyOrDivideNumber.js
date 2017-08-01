function munction(input) {
    let n = Number(input[0]);
    let x = Number(input[1]);
    if (x >= n) {
        return n * x;
    } else {
        return n / x;
    }
}
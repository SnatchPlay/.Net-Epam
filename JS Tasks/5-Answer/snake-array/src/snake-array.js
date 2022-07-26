const snakeArray = (snakeStart) => {
    let start= [
        [ 0,  1,  2,  3,  4,  5,  6],
        [21, 22, 23, 24, 25, 26,  7],
        [20, 35, 36, 37, 38, 27,  8],
        [19, 34, 41, 40, 39, 28,  9],
        [18, 33, 32, 31, 30, 29, 10],
        [17, 16, 15, 14, 13, 12, 11]
    ];
    for (let i = 0; i < 6; i++) {
        for (let j = 0; j < 7; j++) {
            start[i][j]+=snakeStart;
        }   
    }
    return start;
}

module.exports = snakeArray;

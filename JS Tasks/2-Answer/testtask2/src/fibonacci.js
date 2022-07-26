const fibonacciNumbers = (num) => {
if(Number.isInteger(num)==false){
    return 'Passed argument is not a number';
}
if(num<=2){return 1;}
return fibonacciNumbers(num-1)+fibonacciNumbers(num-2);
};
module.exports = fibonacciNumbers;

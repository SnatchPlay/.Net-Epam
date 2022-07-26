const detectPalindrome = (str) => {
    if (typeof str != 'string') {
        return "Passed argument is not a string";
    }
    else if (str.length==0) {
        return "String is empty";
    }
    else if(str.toLowerCase() == str.toLowerCase().split('').reverse().join('')){
        return 'This string is palindrome!';
    }
    else{
        return 'This string is not a palindrome!';
    } 
};

module.exports = detectPalindrome;

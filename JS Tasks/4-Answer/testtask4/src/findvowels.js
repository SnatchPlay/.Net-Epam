const findVowels = (str) => {
    if (typeof str != 'string') {
        return "Passed argument is not a string";
    }
    else if (str.length==0) {
        return "String is empty";
    }
    const vowels = ["a", "e", "i", "o", "u"];
    let count = 0;
    for (let letter of str.toLowerCase()) {
    if (vowels.includes(letter)) {
    count++;
    }
    }
    if(count!=0){
    return count
    }
    else{
        return 'String does not contain vowels';
    }
};

module.exports = findVowels;

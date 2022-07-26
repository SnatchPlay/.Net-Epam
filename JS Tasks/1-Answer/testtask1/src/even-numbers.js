const evenNumbersInArray = (array) => {
    
    if(Array.isArray(array)==false||array.length==0){
        return 'Passed argument is not an array or empty';
    }
    var arr= [];
    let check=false;
    for (let index = 0; index < array.length; index++) {
        if (array[index]%2==0) {
            arr.push(array[index]);
            check=true;
        }
    }
    if(check==false){
        return 'Passed array does not contain even numbers';
    }
     else {
        return arr;
    }
};

module.exports = evenNumbersInArray;


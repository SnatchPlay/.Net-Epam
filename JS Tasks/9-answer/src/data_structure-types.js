const validateTitle = (value) => {
  
  if(typeof(value)!='string'){
    return 'Incorrect input data';
  }
  let str=String(value);
  if(value.length<2 && value.length>20){
    return 'INVALID';
  }
  if((str[0].toUpperCase()!=str[0])||(!isNaN(str[0]))){
    return 'INVALID';
  }
  return 'VALID';
}

const sum = (value1, value2) => {
  let num1=Number.parseInt(value1);
  let num2=Number.parseInt(value2);
  if(typeof(value1)=='number'){
    if(num1%3==0||num1%5==0||num1%15==0){
        num1*=-1;
    }
  }
  if(typeof(value2)=='number'){
    if(num2%3==0||num2%5==0||num2%15==0){
      num2*=-1;
  }
}
  return num1+num2;
};

module.exports = {
  validateTitle,
  sum,
};

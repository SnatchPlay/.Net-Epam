function isBigger(a, b) {
  return a>b;
}

function isSmaller(a, b) {
  return a<b;
}

function getMin(...numbers) {
  return Math.min(...numbers);
}

function makeNumber(string) {
  let str="";
  for (let iterator of string) {
    if(!isNaN( iterator)){
      str+=iterator;
    }
  }
  return str;
}

function countNumbers(string) {
  let numstr=makeNumber(string);
  let dict={};
  for (let iterator of numstr) {
    if(!dict.hasOwnProperty(iterator)){
      dict[iterator]=1;
    }
    else{
      dict[iterator]+=1;
    }
  }
  return dict;
}

function pipe(number, ...functions) {
  let res=number;
  for (let iterator of functions) {
    res=iterator(res)
  }
  return res;
}

function isLeapYear(date) {
  try {
    Date.parse(date);
  } catch (error) {
    return 'Invalid Date';
  }
  
  let year=new Date(date).getFullYear();
  if(isNaN(year)){return 'Invalid Date';}
  if ((0 == year % 4) && (0 != year % 100) || (0 == year % 400)) {
    return year+' is a leap year';
} else {
    return(year + ' is not a leap year');
}
}


module.exports = {
  isBigger,
  isSmaller,
  makeNumber,
  countNumbers,
  getMin,
  pipe,
  isLeapYear,
};

function convert() {
  let array=Array(arguments.length);
  for (let index = 0; index < array.length; index++) {
    if(typeof(arguments[index])=='number'){
        array[index]=arguments[index].toString();
    }
    else{
      array[index]=Number.parseInt(arguments[index]);
    }
  }
  return array;
}

const executeforEach = (arr,func) => {
  arr.forEach(element => {
    func(element)
  });
  return arr;
};

const mapArray = (arr,func) => {
  let array=Array(arr.length);
  for (let index = 0; index < array.length; index++) {
    array[index]=Number.parseInt(arr[index]);
  }
  for (let index = 0; index < array.length; index++) {
     array[index]=func(array[index]);
  }
  return array;
};

const filterArray = (arr,func) => {
  let array=Array();
  for (let index = 0; index < arr.length; index++) {
    if(func(arr[index])){
      array.push(arr[index])
    }
  }
  
  return array;
};

const flipOver = (str) => {
  let newString = "";
    for (let i = str.length - 1; i >= 0; i--) {
        newString += str[i];
    }
    return newString;
};

const makeListFromRange = (arr) => {
  let res=Array();
  if(arr.length==1){
    return arr;
  }
  else{
    for (let index = arr[0]; index <= arr[1]; index++) {
      res.push(index);
    }
  }
  return res;
};

const getArrayOfKeys = (arr,key) => {
  let array=Array();
  for (let index = 0; index < arr.length; index++) {
    array.push(arr[index][key]);
  }
  return array;
};

const substitute = (array) => {
  let arr=Array();
  for(let i=0;i<array.length;i++){
    if(array[i]<30){
      arr.push('*');
    }
    else{
      arr.push(array[i]);
    }
  }
  return arr;
};

const getPastDay = (date,days) => {
  let d=new Date(date.getTime());
  d.setDate(date.getDate() - days);
  return d.getDate();
};

const formatDate = (date) => {
  let d=new Date(date);
  let day=''+d.getDate();
  let month=''+(d.getMonth()+1);
  let year=d.getFullYear();
  let hour=''+d.getHours();
  let minutes=''+d.getMinutes();
  if (month.length < 2)
  {
      month = '0' + month;
  }
  if (day.length < 2)
  {
    day = '0' + day;
  }
  if (hour.length < 2)
  {
    hour = '0' + hour;
  }
  if (minutes.length < 2)
  {
    minutes = '0' + minutes;
  }

  return [year,month,day].join('/')+" "+[hour,minutes].join(':');
};

module.exports = {
  convert,
  executeforEach,
  mapArray,
  filterArray,
  flipOver,
  makeListFromRange,
  getArrayOfKeys,
  substitute,
  getPastDay,
  formatDate,
};

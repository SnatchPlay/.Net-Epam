//=============================================
// ------------------------------------ TASK №1
//=============================================
const cache = (func) => {
    let cached = {};
    return function(...args){
        if (cached[args]!=undefined){
           return cached[args];
        }
        else{
           cached[args] = func(...args);
            return cached[args];
        }
    }
}

//=============================================
// ------------------------------------ TASK №2
//=============================================
const forwardBackwardSteps = {
     step:0,
     forward:function(){
        this.step+=1;
        return this;
     },
     backward:function(){
        this.step-=1;
        return this;
     },
     revealStep:function(){
        console.log(this.step);
     }
};

//=============================================
// ------------------------------------ TASK №3
//=============================================
const applyAll = (...args) => {
    let f=args[0];
    return f.call(...args);
}
const sum = (...args) => {
    let res=0;
    for (const num of args) {
        res+=Number.parseInt(num);
    }
return res;
}

const mul = (...args) => {
    let res=1;
    for (const num of args) {
        res*=Number.parseInt(num);
    }
return res;
}

//=============================================

module.exports = {cache, forwardBackwardSteps, applyAll, sum, mul}

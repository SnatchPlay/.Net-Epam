const getSum = (str1, str2) => {
  let a,b;
  if(typeof(str1)!='string' || typeof(str2)!='string' ){
    return false;
  }
  else if(str1==''){
    a=0;
    b=Number.parseInt(str2);
    if(str2==''){
      b=0;
    }
    return (a+b).toString();
  }
  else{
    a=Number.parseInt(str1);
    b=Number.parseInt(str2);
    if(isNaN(a)||isNaN(b)){
      return false;
    }
  } 
  return (a+b).toString();
};

const getQuantityPostsByAuthor = (listOfPosts, authorName) => {
  let posts=0,comments=0;
  for (const post of listOfPosts) {
    if(post.author==authorName){
      posts+=1;
    }
    if(post.comments!==undefined){
      for(const comment of post.comments){
        if(comment.author==authorName){
          comments+=1;
        }
      }
    }
  }
  return 'Post:'+posts+',comments:'+comments;
};

const tickets=(people)=> {
  let cash=0;
  for (let iterator of people) {
    if(iterator/25==1){
      cash+=25;
    }
    else if(iterator-25>cash){
      return 'NO';
    }
    else if(iterator-25<=cash){
      cash-=(iterator-25);
      cash+=iterator;
    }
  }
  return 'YES';
};


module.exports = {getSum, getQuantityPostsByAuthor, tickets};

const textForRole = (roles, textLines) => {
    var lines=textLines.split(/\r?\n/);
    for (let index = 0; index < roles.length; index++) {
        roles[index]+=':';
    }
    var script="";
    for (let i = 0; i < roles.length; i++) {
        script+=roles[i]+'\n';
        for(let j=0;j<lines.length;j++){
            let a=lines[j].includes(roles[i]);
            if(a){
                script+=j+1 +')'+lines[j].split(roles[i])[1]+'\n';
            }
        }
        script+='\n';
    }
    return script;
}

module.exports = textForRole;


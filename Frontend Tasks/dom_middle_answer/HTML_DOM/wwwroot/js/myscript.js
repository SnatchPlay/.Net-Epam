const start_color='white';
document.getElementById("run").onclick=run_click;
function run_click(){

    let rows=Number.parseInt( document.getElementById("rows").value);
    let cols=Number.parseInt( document.getElementById("cols").value);
    let table=document.getElementById("table");
    table.innerHTML = "";
    for (let i = 0; i < rows; i++) {
        let row=table.insertRow(i);
        for (let j = 0; j < cols; j++) {
            let cell=row.insertCell(j);
            cell.append(''+(i+1)+''+(j+1));
        }
    }
}

table.onclick=tableclick;
function tableclick(){
var table = document.getElementById("table");
var rows = table.rows;
for (var i = 0; i < rows.length; i++) {
    rows[i].onclick = (function (e) {
        var j = 0;
        var td = e.target;
        while( (td = td.previousElementSibling) != null ) 
            j++;
        if(this.cells[j].style.backgroundColor=='red'){
                this.cells[j].style.backgroundColor=start_color;}
        else{
            this.cells[j].style.backgroundColor='red';
        }
    });
}
}

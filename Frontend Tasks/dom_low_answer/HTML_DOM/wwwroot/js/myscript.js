
document.getElementById("run").onclick=click;
function click(){

    let rows=Number.parseInt( document.getElementById("rows").value);
    let cols=Number.parseInt( document.getElementById("cols").value);
    let table=document.getElementById("table");
    table.innerHTML = "";
    for (let i = 0; i < rows; i++) {
        let row=table.insertRow(i);
        for (let j = 0; j < cols; j++) {
            row.insertCell(j);
        }
    }
}

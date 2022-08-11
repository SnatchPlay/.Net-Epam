const start_color = 'white';
document.getElementById("run").onclick = run_click;
function run_click() {

    let rows = Number.parseInt(document.getElementById("rows").value);
    let cols = Number.parseInt(document.getElementById("cols").value);
    if (rows <= 0 || rows > 10 || cols <= 0 || cols > 10) {
        alert("Wrong number of rows or cols")
        return;
    }
    let table = document.getElementById("table");
    table.innerHTML = "";
    for (let i = 0; i < rows; i++) {
        let row = table.insertRow(i);
        for (let j = 0; j < cols; j++) {
            let cell = row.insertCell(j);
            cell.append('' + (i + 1) + '' + (j + 1));
        }
    }
}

let selectedTd;
table.onclick = function (event) {
    let target = event.target;
    if (target.tagName != 'TD') return;
    else {
        var rect = target.getBoundingClientRect();

        const x = event.clientX;
        const y = event.clientY;

        const borderSize = parseFloat(getComputedStyle(target).borderTopWidth);

        if ((x >= rect.x && x <= rect.x + borderSize) ||
            (x >= rect.x + rect.width - borderSize
                && x <= rect.x + rect.width) ||
            (y >= rect.y && y <= rect.y + borderSize) ||
            (y >= rect.y + rect.height - borderSize &&
                y <= rect.y + rect.height)) {
            return;
        }
        else {
            highlight(target);
        }
    }

};

function highlight(td) {
    if (td.style.backgroundColor == 'red') {
        td.style.backgroundColor = start_color;
    }
    else {
        td.style.backgroundColor = 'red';
    }
}

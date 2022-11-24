var taskCommentType = 1;
var errorBlock;
var filters = {};
var basicUrl = document.location.protocol + "//" + document.location.host;

$(document).ready(function () {
    $('#taskTable').DataTable();
    $('.dataTables_length').addClass('bs-select');
});

document.addEventListener("DOMContentLoaded", function (event) {
    errorBlock = document.getElementById("error");
    searchString = new URLSearchParams(window.location.search);

    filters["project"] = searchString.get('project');
    filters["date"] = searchString.get('date');

    console.log(filters)
});

document.getElementById("flexRadioDefault1").addEventListener("change", function (event) {
    document.getElementById("form-file-type").style.display = "none";
    document.getElementById("form-text-type").style.display = "block";
    taskCommentType = 1;
});

document.getElementById("flexRadioDefault2").addEventListener("change", function (event) {
    document.getElementById("form-text-type").style.display = "none";
    document.getElementById("form-file-type").style.display = "block";
    taskCommentType = 2;
});

document.getElementById("create-task").addEventListener("submit", function (event) {
    event.preventDefault();

    let sendObject = {};
    sendObject["task"] = {};
    sendObject["taskComment"] = {};
    sendObject["task"]["taskName"] = document.getElementById("create-task-name").value;
    var index = document.getElementById("create-project-name").options.selectedIndex;

    if (index == 0) {
        errorBlock.innerHTML = "No project selected";
        return;
    }

    sendObject["task"]["projectId"] = document.getElementById("create-project-name").options[index].value;
    var projectName = document.getElementById("create-project-name").options[index].text;
    sendObject["task"]["startDate"] = document.getElementById("create-startdt").value;
    sendObject["task"]["endDate"] = document.getElementById("create-enddt").value;
    sendObject["taskComment"]["taskCommentType"] = taskCommentType;
    sendObject["taskComment"]["content"] = (taskCommentType == 1) ? document.getElementById("create-task-comment-text").value : document.getElementById("create-task-comment-file").value;
    console.log(sendObject);


    if (!isCorrectData(sendObject)) {
        return;
    }

    console.log("Send to server");

    var result = sendObjectPost(sendObject, projectName, basicUrl + "/task/")
    if (result == 200) {
        errorBlock.innerHTML = "Object created successfully";
    }
});

function isCorrectData(obj) {
    errorBlock.innerHTML = "";
    if (obj["task"]["projectId"] == '') {
        errorBlock.innerHTML = "No project selected";
        return false;
    }
    if (obj["task"]["taskName"] == '') {
        errorBlock.innerHTML = "Task name not specified";
        return false;
    }
    if (obj["task"]["startDate"] == '') {
        errorBlock.innerHTML = "Start time not specified";
        return false;
    }
    if (obj["task"]["endDate"] == '') {
        errorBlock.innerHTML = "End time not specified";
        return false;
    }
    if (obj["task"]["startDate"] > obj["task"]["endDate"]) {
        errorBlock.innerHTML = "Start time cannot be greater than End time";
        return false;
    }
    if (obj["taskComment"]["content"] == '') {
        errorBlock.innerHTML = "Task description not specified";
        return false;
    }
    return true;
}

function sendObjectPost(obj, projectName, url) {
    var xhr = new XMLHttpRequest();
    xhr.open("POST", url, false);

    xhr.setRequestHeader("Accept", "application/json");
    xhr.setRequestHeader("Content-Type", "application/json");

    var json = JSON.stringify(obj)
    console.log(json)
    xhr.send(json);
    console.log(xhr.response);
    console.log(JSON.parse(xhr.response)["id"]);

    if (xhr.status == 200) {
        addRow(obj, projectName, "task/" + JSON.parse(xhr.response)["id"]);
    }
    return xhr.status;
}

function addRow(obj, projectName, link) {
    startDate = new Date(obj["task"]["startDate"]);
    endDate = new Date(obj["task"]["endDate"]);

    table = document.getElementById("taskTable");
    tbody = table.getElementsByTagName("tbody")[0]
    tr = document.createElement("tr");

    tdProjectName = document.createElement("td");
    tdProjectName.setAttribute('scope', 'col');
    tdProjectName.innerHTML = projectName;

    tdSpendTime = document.createElement("td");
    tdSpendTime.setAttribute('scope', 'col');
    tdSpendTime.innerHTML = calculateSpendTime(startDate, endDate);

    tdTaskName = document.createElement("td");
    tdTaskName.setAttribute('scope', 'col');

    taskLink = document.createElement("a");
    taskLink.setAttribute('href', link);
    taskLink.setAttribute('class', 'btn');
    taskLink.innerHTML = obj["task"]["taskName"];

    tdTaskName.appendChild(taskLink);

    tdStartDate = document.createElement("td");
    tdStartDate.setAttribute('scope', 'col');
    tdStartDate.innerHTML = DateAsString(startDate);

    tdEndDate = document.createElement("td");
    tdEndDate.setAttribute('scope', 'col');
    tdEndDate.innerHTML = DateAsString(endDate);

    tr.appendChild(tdProjectName);
    tr.appendChild(tdSpendTime);
    tr.appendChild(tdTaskName);
    tr.appendChild(tdStartDate);
    tr.appendChild(tdEndDate);

    tbody.appendChild(tr);
}

function calculateSpendTime(startTime, endTime) {
    var hourDiff = endTime - startTime;
    var minDiff = hourDiff / 60 / 1000; //in minutes
    var hours = Math.floor(minDiff / 60); //in hours
    var minutes = minDiff % 60;
    if (hours.toString().length == 1) {
        hours = '0' + hours.toString();
    }
    if (minutes.toString().length == 1) {
        minutes = '0' + minutes.toString();
    }
    return hours.toString() + ":" + minutes.toString()
}

function DateAsString(date) {
    var day = date.getDate().toString();
    var month = (date.getMonth() + 1).toString();
    var year = date.getFullYear().toString();
    var hours = date.getHours().toString();
    var minutes = date.getMinutes().toString();

    if (day.length == 1) {
        day = '0' + day;
    }
    if (month.length == 1) {
        month = '0' + month;
    }
    if (hours.length == 1) {
        hours = '0' + hours;
    }
    if (minutes.length == 1) {
        minutes = '0' + minutes;
    }


    return day + '.' + month + '.' + year + ' ' + hours + ':' + minutes;
}

document.getElementById("filter-project").addEventListener("change", function (event) {
    var index = document.getElementById("filter-project").options.selectedIndex;
    filters["project"] = document.getElementById("filter-project").options[index].text;
    acceptFilters();
});

document.getElementById("filter-date").addEventListener("change", function (event) {
    filters["date"] = document.getElementById("filter-date").value;
    acceptFilters();
});


function acceptFilters() {
    let projectFilterStr = null;
    let dateFilterStr = null;
    if (filters["project"] != null) {
        projectFilterStr = "project=" + filters["project"];
    }
    if (filters["date"] != null) {
        dateFilterStr = "date=" + filters["date"];
    }
    window.location = basicUrl + "?" + projectFilterStr + "&" + dateFilterStr;
}

document.getElementById("no-filters").addEventListener("click", function (event) {
    window.location = basicUrl;
});
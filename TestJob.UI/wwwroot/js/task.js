var errorBlock;
var basicUrl = document.location.protocol + "//" + document.location.host;

document.addEventListener("DOMContentLoaded", function (event) {
    errorBlock = document.getElementById("error");
});

document.getElementById("update-task").addEventListener("submit", function (event) {
    event.preventDefault();

    let sendObject = {};
    var taskId = document.getElementById("taskId").innerHTML;
    sendObject["taskName"] = document.getElementById("create-task-name").value;
    var index = document.getElementById("create-project-name").options.selectedIndex;
    sendObject["projectId"] = document.getElementById("create-project-name").options[index].value;
    var projectName = document.getElementById("create-project-name").options[index].text;
    sendObject["startDate"] = document.getElementById("create-startdt").value;
    sendObject["endDate"] = document.getElementById("create-enddt").value;
    sendObject["createDate"] = document.getElementById("create-createdt").value;
    sendObject["updateDate"] = document.getElementById("create-updatedt").value;
    console.log(sendObject);

    if (!isCorrectData(sendObject)) {
        return;
    }

    console.log("Send to server");

    var result = sendObjectPut(sendObject, basicUrl + "/" + taskId)

    if (result == 200) {
        errorBlock.innerHTML = "Task was updated";
    }
});

function isCorrectData(obj) {
    errorBlock.innerHTML = "";
    if (obj["projectId"] == '') {
        errorBlock.innerHTML = "No project selected";
        return false;
    }
    if (obj["taskName"] == '') {
        errorBlock.innerHTML = "Task name not specified";
        return false;
    }
    if (obj["startDate"] == '') {
        errorBlock.innerHTML = "Start time not specified";
        return false;
    }
    if (obj["endDate"] == '') {
        errorBlock.innerHTML = "End time not specified";
        return false;
    }
    if (obj["startDate"] > obj["endDate"]) {
        errorBlock.innerHTML = "Start time cannot be greater than End time";
        return false;
    }
    if (obj["taskComment"] == '') {
        errorBlock.innerHTML = "Task description not specified";
        return false;
    }
    return true;
}

function sendObjectPut(obj, url) {
    var xhr = new XMLHttpRequest();
    xhr.open("PUT", url, false);

    xhr.setRequestHeader("Accept", "application/json");
    xhr.setRequestHeader("Content-Type", "application/json");

    var json = JSON.stringify(obj);
    console.log(json);
    xhr.send(json);
    console.log(xhr.status);
    return xhr.status;
}

document.getElementById("create-comment").addEventListener("submit", function (event) {
    event.preventDefault();

    let comment = {};
    comment["taskId"] = document.getElementById("taskId").innerHTML;
    comment["content"] = document.getElementById("comment-text").value;
    comment["commentType"] = 1;

    if (comment["content"] != '') {
        createCommentRequest(comment, basicUrl + "/api/taskcomment/")
    }

});

function createCommentRequest(obj, url) {
    var xhr = new XMLHttpRequest();
    xhr.open("POST", url, false);

    xhr.setRequestHeader("Accept", "application/json");
    xhr.setRequestHeader("Content-Type", "application/json");

    var json = JSON.stringify(obj)
    console.log(json)
    xhr.send(json);
    console.log(xhr.status)
    if (xhr.status == 200) {
        var data = JSON.parse(xhr.response);
        addComment(data.id, obj["commentType"], obj["content"]);
    }
}

function addComment(id, commentType, content) {
    table = document.getElementById("comment-table");
    tbody = table.getElementsByTagName("tbody")[0];
    tr = document.createElement("tr");
    tr.setAttribute("id", id);
    td = document.createElement("td");
    td.innerHTML = commentType;
    td2 = document.createElement("td");
    td2.innerHTML = content;

    button = document.createElement("button");
    button.setAttribute("class", "btn btn-danger");
    button.setAttribute("onclick", "deleteComment(" + id + ")");
    button.innerHTML = "Delete task comment";
    td3 = document.createElement("td");
    td3.appendChild(button);

    tr.appendChild(td);
    tr.appendChild(td2);
    tr.appendChild(td3);
    tbody.appendChild(tr);
}

function deleteComment(id) {

    var xhr = new XMLHttpRequest();
    xhr.open("DELETE", basicUrl + "/api/taskcomment/" + id, false);

    xhr.setRequestHeader("Accept", "application/json");
    xhr.setRequestHeader("Content-Type", "application/json");

    xhr.send();
    if (xhr.status == 200) {
        removeRowById(id);
    }
}

function removeRowById(id) {
    var tr = document.getElementById(id);
    tr.parentElement.removeChild(tr);
}
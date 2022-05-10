
$(document).ready(function () {
    $.get("Country/GetCountries", function (response) {
        console.log(response);
        $('#countrtList').empty();
        response.map(country => 
            $('countrtList').append($('<option/>', {
                value: country,
                text: country
            })))
    })
});

function findThroughPost(url, firstname, lastname, city) {
    let inputElement = $("#" + firstname + lastname + city);
    var data = {
        [inputElement.attr("name")]: inputElement.val()
    };
    $.post(url, data, function (response) {
        document.getElementById("PersonList").innerHTML = response;
    })
};



function findThroughId(url, inputId) {
    let inputElement = $("#" + inputId);
    var data = {
        [inputElement.attr("name")]: inputElement.val()
    };
    console.log(data);
    $.post(url, data, function (response) {
        document.getElementById("PersonList").innerHTML = response;
    })
};

//jQuery.post(url[, data][, success][, dataType])
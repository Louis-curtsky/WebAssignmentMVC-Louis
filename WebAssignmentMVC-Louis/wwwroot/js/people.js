$(document).ready(function () {
    $.get("/Person/GetCities", function (response) {
        console.log(response);
        $('#cityList').empty();
        response.map(city =>
            $('#cityList').append($('<option/>', {
                value: city,
                text: city
                
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


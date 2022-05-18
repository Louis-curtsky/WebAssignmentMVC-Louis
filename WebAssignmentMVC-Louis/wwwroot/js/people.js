
$(document).ready(function () {
    $.get("Country/GetCountries", function (response) {
        $('#countryList').empty();
        console.log(response);
        response.map(country => 
            $('countryList').append($('<option/>', {
                value: country,
                text: country
            })))
    })
});

function findThroughPost(url, firstname, lastname, countryId, cityId) {
    let inputElement = $("#" + firstname + lastname + countryId + cityId);
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
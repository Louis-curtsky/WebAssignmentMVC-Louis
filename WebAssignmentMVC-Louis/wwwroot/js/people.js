
$(document).ready(function () {
    $.get("Person/GetCountries", function (response) {
        $('#countryList').empty();
        console.log(response);
        response.map(country => 
            $('countryList').append($('<option/>', {
                value: country,
                text: country
            })))
    })
});

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


function findThroughId(url, inputId) {
    let inputElement = $("#" + inputId);
    var data = {
        [inputElement.attr("name")]: inputElement.val()
    };
    console.log(data);
    $.post(url, data, function (response) {
        document.getElementById("DetailList").innerHTML = response;
    })
};

function findThroughPost(url, firstname, lastname, countryId, cityId) {
    let inputElement = $("#" + firstname + lastname + countryId + cityId);
    var data = {
        [inputElement.attr("name")]: inputElement.val()
    };
    $.post(url, data, function (response) {
        document.getElementById("PersonList").innerHTML = response;
    })
};



function findPersonId(url, inputId) {
    let inputElement = $("#" + inputId);
    var data = {
        [inputElement.attr("name")]: inputElement.val()
    };
    console.log(data);
    $.post(url, data, function (response) {
        document.getElementById("partialView").innerHTML = response;
    })
};

function findPersonDetailJSON(actionurl) {
    console.log("Json response:", response);
    document.getElementById("result").innerHTML = response;
};

function findLanguageId(url, inputId) {
    let inputElement = $("#" + inputId);
    var data = {
        [inputElement.attr("name")]: inputElement.val()
    };
    console.log(data);
    $.post(url, data, function (response) {
        document.getElementById("languageView").innerHTML = response;
    })
};
//jQuery.post(url[, data][, success][, dataType])
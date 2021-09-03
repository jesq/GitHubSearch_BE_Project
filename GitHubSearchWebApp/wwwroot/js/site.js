var settings = {
    "url": "/weatherforecast",
    "method": "GET",
    "timeout": 0,
};

$.ajax(settings).done(function (response) {
    //console.log(response);
    //let textArea = document.querySelectorAll('#weatherForecast');
    //let textArea = document.getElementById('weatherForecast');
    $('#weatherForecast').val("The weather for tomorrow should look like this: " + response[0].summary);
    console.log(response.longitude);
    console.log(response.latitude);
});


////var submitt = document.getElementById("mySubmit");
////submitt.addEventListener('submit', function (e) {
////    e.preventDefault;
////    var search = document.getElementById("search_bar").val;
////    var originalRepo = search.split(' ').join(' ');

////    fetch("https://localhost:5001/api/gitrepository/" + originalRepo)
////        .then((result) => result.json())
////        .then((data) => {
////            console.log(data)
////        })
////})

document.querySelector('#submitBtn').addEventListener('click', (e) => {
    e.preventDefault;
    var search = document.getElementById("search_bar").val;
    //var originalRepo = search.split(' ').join(' ');

    fetch("https://localhost:5001/api/gitrepository/" + search)
        .then((result) => result.json())
        .then((data) => {
            console.log(data)
        })
})



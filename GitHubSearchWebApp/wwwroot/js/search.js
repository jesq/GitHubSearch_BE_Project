
class Result {
    constructor(profileImage, userName, repoName) {
        this.profileImage = profileImage;
        this.userName = userName;
        this.repoName = repoName;
    }
}



class UI {
    static displayResults() {
        let result1 = new Result("images/default_avatar.png", "cosmin", "repo");
        let result2 = new Result("images/default_avatar.png", "sofia", "repoTest1");
        let result3 = new Result("images/default_avatar.png", "george", "repoTest2");
        let result4 = new Result("images/default_avatar.png", "stefan", "repoooooo");
        let result5 = new Result("images/default_avatar.png", "TEST", "repository");
        const results = [];
        results.push(result1);
        results.push(result2);
        results.push(result3);
        results.push(result4);
        results.push(result5);
        results.forEach((result) => UI.addSearchResultToList(result));
    }

    static addSearchResultToList(result) {
        const list = document.querySelector('#search-results-list');
        const button = document.createElement('button');
        button.classList.add('list-group-item');
        button.classList.add('list-group-action');
        button.innerHTML = `
            <ul class="list-group list-group-horizontal align-items-center justify-content-center">
                <li class="list-group-item border-0 m-auto">
                    <img src="${result.profileImage}" width="50" height="50" class="rounded-circle" alt="Cinque Terre">
                </li>
                <li class="list-group-item border-0 m-auto">
                    ${result.userName}
                </li>
                <li class="list-group-item border-0 m-auto">
                    ${result.repoName}
                </li>
            </ul>`
        list.appendChild(button);
    }
}

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
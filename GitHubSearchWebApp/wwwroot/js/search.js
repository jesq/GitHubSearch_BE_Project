var results = [];

class UI {
    static async displayResults(data) {
        await Store.getResults(data);
        console.log(results);
        results.forEach((result) => {
            console.log(result);
            UI.addSearchResultToList(result)
        });
    }

    static addSearchResultToList(result) {
        const list = document.querySelector('#search-results-list');
        const button = document.createElement('button');
        button.setAttribute("onclick", `window.open("${ result.htmlUrl }", "_blank")`);
        button.classList.add('list-group-item');
        button.classList.add('list-group-action');
        button.innerHTML = `
            <ul class="list-group list-group-horizontal align-items-center justify-content-center">
                <li class="list-group-item border-0 m-auto">
                    <img src="${result.owner.avatarUrl}" width="50" height="50" class="rounded-circle" alt="Cinque Terre">
                </li>
                <li class="list-group-item border-0 m-auto">
                    ${result.name}
                </li>
                <li class="list-group-item border-0 m-auto">
                    ${result.owner.username}
                </li>
            </ul>`
        list.appendChild(button);
    }

    static resetResults() {
        results.length = 0;
        document.querySelector('#search-results-list').innerHTML = '';
    }
}

class Store {
    static getResults(data) {
        data.forEach((result) => results.push(result));
        return results;
    }

}

document.querySelector('#submitBtn').addEventListener('click', (e) => {
    e.preventDefault;
    UI.resetResults();
    var search = document.getElementById("search_bar").value;
    //var originalRepo = search.split(' ').join(' ');
    console.log(search)
    fetch("https://localhost:5001/api/gitrepository/" + search)
        .then((result) => result.json())
        .then((data) => {
            console.log(data);
            UI.displayResults(data);
        })
})
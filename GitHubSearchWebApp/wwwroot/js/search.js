class UI {
    static addSearchResultToList() {
        const list = document.querySelector('#search-results-list');
        const button = document.createElement('button');
        button.classList.add('list-group-item');
        button.classList.add('list-group-action');
        button.innerHTML = `
            <ul class="list-group list-group-horizontal align-items-center justify-content-center">
                <li class="list-group-item border-0">
                    <img src="images/default_avatar.png" width="50" height="50" class="rounded-circle" alt="Cinque Terre">
                </li>
                <li class="list-group-item border-0">
                    UserName
                </li>
                <li class="list-group-item border-0">
                    RepoName
                </li>
            </ul>`
        list.appendChild(button);
    }
}

document.querySelector('#submitBtn').addEventListener('click', (e) => {
    UI.addSearchResultToList();
})
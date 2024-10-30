fetch("Block/getCoins", {
    method: "GET",
}).then(response => {
        return response.text();
    }
).then(data => {
    document.querySelector(".header__body__balance").innerHTML= (data)
})

function sendTask() {
    localStorage.clear()
    let form = document.querySelector("#sendForm")
    let data = getParamsFromForm(form)

    fetch(form.getAttribute("action"), {
        method: form.getAttribute("method"),
        body: data
    }).then(response => {
            return response.json();
        }
    ).then(response => {
        console.log(response)

    })
}
document.getElementById('typeTask').addEventListener('change', function() {
    let typeTask = this.value;
    let coinsField = document.getElementById('coinsField');
    let messageField = document.getElementById('messageField');

    if (typeTask === '1') {
        coinsField.style.display = 'block';
        messageField.style.display = 'none';
    } else if (typeTask === '2') {
        coinsField.style.display = 'none';
        messageField.style.display = 'block';
    }
});
document.getElementById('typeTask').dispatchEvent(new Event('change'));
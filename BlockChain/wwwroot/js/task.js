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
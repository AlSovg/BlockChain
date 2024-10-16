fetch("Block/getCoins", {
    method: "GET",
}).then(response => {
        return response.text();
    }
).then(data => {
    document.querySelector(".header__body__balance").innerHTML= (data)
})

fetch("Block/getLastBlock", {
    method: "GET",
}).then(response => {
        return response.text();
    }
).then(data => {
    document.querySelector(".task__list").innerHTML= (data)
})

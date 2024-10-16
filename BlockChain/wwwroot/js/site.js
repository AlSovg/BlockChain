// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function auth() {
    localStorage.clear()
    let form = document.querySelector("#authForm")
    let data = getParamsFromForm(form)
    fetch(form.getAttribute("action"), {
        method: form.getAttribute("method"),
        body: data
    }).then(response => {
            return response.json();
        }
    ).then(response => {
        let alertBg = document.querySelector(".alert__bg");
        let alertContent = document.querySelector(".alert__content");
        alertContent.innerHTML = response.message;
        if (response.message.includes("error")){
            alertContent.classList.add("alert-danger")
            addCloseButton(alertContent)
            
        }
        else {
            alertContent.classList.add("alert-success");
            setTimeout(function (){
                window.location.href = "/Block"
            }, 1000);

        }

        alertBg.classList.add("active");

    })
}

function register() {
    localStorage.clear()
    let form = document.querySelector("#registerForm")
    let data = getParamsFromForm(form)
    
    fetch(form.getAttribute("action"), {
        method: form.getAttribute("method"),
        body: data
    }).then(response => {
            return response.json();
        }
    ).then(response => {
        let alertBg = document.querySelector(".alert__bg");
        let alertContent = document.querySelector(".alert__content");
        alertContent.innerHTML = response.message;
        if (response.message.includes("error")){
            alertContent.classList.add("alert-danger")
            addCloseButton(alertContent)
        }
        else {
            alertContent.classList.add("alert-success");
            setTimeout(function (){
                window.location.href = "/Block"
            }, 1000);
            
            
        }
        
        alertBg.classList.add("active");
        
    })


}

function checkLast() {
    $.ajax({
        url: "/Block/getLast",
        method: "GET",
        headers: {
            "Content-Type": "application/json",
        },
    }).done(function (response) {
        document.querySelector(".blocks__zone").innerHTML = response;
    });
}


function changeForm() {
    let authForm = document.getElementById("authForm");
    let registerForm = document.getElementById("registerForm");
    authForm.classList.toggle("active")
    registerForm.classList.toggle("active");
}


function getParamsFromForm(form) {
    let formData = new FormData(form);
    let data = new URLSearchParams();
    for (const pair of formData) {
        data.append(pair[0], pair[1]);
    }
    return data;
}

function clickDocumentToClosePopup(popupName){
    let popup = document.querySelector(popupName);
    document.addEventListener('click', (e) => {
        if (!popup.contains(e.target)) {
            popup.classList.remove("active")
        }
    });
}

function addCloseButton(content){
    let button = document.createElement("button")
    button.classList = "close-btn top-right"
    button.innerHTML = "X"
    button.addEventListener("click", closeParentPopup)
    content.appendChild(button)
}

function closeParentPopup(){
    let popup = this.parentNode.parentNode
    popup.classList.remove("active")
}
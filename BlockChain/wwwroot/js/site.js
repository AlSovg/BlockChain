// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function auth() {
    localStorage.clear()
    let loginInput = document.getElementById("auth_user");
    let passwordInput = document.getElementById("auth_pass");
    let userName = loginInput.value;
    let password = passwordInput.value;

    let raw = JSON.stringify({
        version: localStorage.getItem("session"),
        user_hash: localStorage.getItem("user"),
        data: {},
        username: userName,
        password: password,
    });
    $.ajax({
        url: "/Login/Try",
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        mode: "no-cors",
        data: raw,
    }).done(function (response) {
        console.log(response.user_hash);
        localStorage.setItem("userName", userName)
        localStorage.setItem("password", password)
        localStorage.setItem("user", response.user_hash)
        localStorage.setItem("session", response.session_hash)
        window.location.href = "/main";
    });
}
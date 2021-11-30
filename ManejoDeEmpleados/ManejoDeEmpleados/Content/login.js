document.getElementById("btn_register ").addEventListener("click", Register);
document.getElementById("btn_login").addEventListener("click", Login);

window.addEventListener("resize", widthPage);

var front_login_register = document.querySelector(".front_login_register ");
var form_login = document.querySelector(".form_login ");
var form_register = document.querySelector(".form_register ");
var back_login = document.querySelector(".back_login ");
var back_register = document.querySelector(".back_register ");

function widthPage() {
    if (window.innerWidth > 850) {
        back_login.style.display = "block";
        back_register.style.display = "block";
    } else {
        back_register.style.display = "block";
        back_register.style.opacity = "1";
        back_login.style.display = "none";
        form_login.style.display = "block";
        form_register.style.display = "none";
        front_login_register.style.left = "0px";
    }
}

widthPage();

function Login() {
    if (window.innerWidth > 850) {
        form_register.style.display = "none";
        front_login_register.style.left = "10px";
        form_login.style.display = "block";
        back_register.style.opacity = "1";
        back_login.style.opacity = "0";
    } else {
        form_register.style.display = "none";
        front_login_register.style.left = "0px";
        form_login.style.display = "block";
        back_register.style.display = "block";
        back_login.style.display = "none";
    }


}

function Register() {
    if (window.innerWidth > 850) {
        form_register.style.display = "block";
        front_login_register.style.left = "410px";
        form_login.style.display = "none";
        back_register.style.opacity = "0";
        back_login.style.opacity = "1";
    } else {
        form_register.style.display = "block";
        front_login_register.style.left = "0px";
        form_login.style.display = "none";
        back_register.style.display = "none";
        back_login.style.display = "block";
        back_login.style.opacity = "1";
    }


}

/*Validations Register*/
const nombre = document.querySelector("#name")
const email = document.querySelector("#email")
const user = document.querySelector("#user")
const password = document.querySelector("#password")
const name_wrongr = document.querySelector("#name_wrong")
const email_wrongr = document.querySelector("#email_wrongr");
const password_wrongr = document.querySelector("#password_wrongr");

function ValidateRegister() {

    let em = /^[-\w.%+]{1,64}@(?:[A-Z0-9-]{1,63}\.){1,125}[A-Z]{2,63}$/i
    if (nombre.value.length < 3) {
        name_wrongr.style.display = "block";
    } else {
        name_wrongr.style.display = "none";
    }
    if (!em.test(email.value)) {
        email_wrongr.style.display = "block";

    } else {
        email_wrongr.style.display = "none";
    }
    if (password.value.length < 7) {
        password_wrongr.style.display = "block";
    } else {
        password_wrongr.style.display = "none";
    }
}


// Validations Login
const email_login = document.querySelector("#email_login")
const password_login = document.querySelector("#password_login")

const email_wrong = document.querySelector("#email_wrong");
const password_wrong = document.querySelector("#password_wrong");

function ValidateLogin() {

    let em = /^[-\w.%+]{1,64}@(?:[A-Z0-9-]{1,63}\.){1,125}[A-Z]{2,63}$/i

    if (!em.test(email_login.value)) {
        console.log(email_login.value)
        email_wrong.style.display = "block";

    } else {
        email_wrong.style.display = "none";
    }
    if (password_login.value.length < 7) {
        console.log(password_login.value)
        password_wrong.style.display = "block";
    } else {
        password_wrong.style.display = "none";
    }

}
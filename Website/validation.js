function validateLogin() {

var username = document.getElementsByName("user");
var password = document.getElementsByName("pass");
var message = document.getElementsByName("messages");

if (username.value == "") {
    message.innerHTML = "**Please enter username";
    username.style.border = "1px solid red";
    username.focus();
    return false;
  }

if (password.value == "") {
    message.innerHTML = "**Password is required";
    password.style.border = "1px solid red";
    password.focus();
    return false;
  }
}

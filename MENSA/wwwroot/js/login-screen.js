const hidePassword = document.getElementById("oko");
const showPassword = document.getElementById("zatvoreno-oko");
const password = document.getElementById("password");
hidePassword.addEventListener("click", HidePassword);
function HidePassword()
{
    if(password.type === "password")
    {
        password.type = "text";
        hidePassword.style.display = "none";
        showPassword.style.display = "inline";
    }
    else
    {
        password.type = "password";
            password.type = "password";
            showPassword.style.display = "none";
            hidePassword.style.display = "inline";
    }
};
showPassword.addEventListener("click", ShowPassword);
function ShowPassword()
{
    if(password.type === "password")
    {
        password.type = "text";
        hidePassword.style.display = "none";
        showPassword.style.display = "inline";
    }
    else
    {
        password.type = "password";
        showPassword.style.display = "none";
        hidePassword.style.display = "inline";
    }
};

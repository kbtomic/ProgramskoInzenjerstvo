function myFunction() {
    document.getElementById("myDropdown").classList.toggle("show");
}

const logo = document.querySelector(".header-user");
const logOut = document.querySelector(".dropdown-menu");
function ShowLogOut() {
    if (logOut.style.display === "block") {
        logOut.style.display = "none";
    }
    else {
        logOut.style.display = "block";
    }
}
logo.addEventListener("click", ShowLogOut);
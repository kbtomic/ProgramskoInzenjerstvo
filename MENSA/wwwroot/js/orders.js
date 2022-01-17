
let deleteCardIcons = document.querySelectorAll(".card .delete-button");
for(let i = 0; i < deleteCardIcons.length; i++){
    let deleteCardIcon = deleteCardIcons[i];
    deleteCardIcon.addEventListener("click", handleDeleteCardClick);
}

function handleDeleteCardClick(e){
    let deleteCardIcon = e.currentTarget;
    let card = deleteCardIcon.parentElement;
    let cardTitle = card.querySelector("h3");

    if(confirm("Izbrisati karticu: " + cardTitle.textContent + "?")){
        card.remove();
    }
}

//  var table = document.getElementById("table_id");
// // var totalRowCount = table.rows.length;

//   for (let i in table.rows) {
// const minusButton = document.getElementById('minus');
// const plusButton = document.getElementById('plus');
// const inputField = document.getElementById('input');

// minusButton.addEventListener('click', event => {
//   event.preventDefault();
//   const currentValue = Number(inputField.value) || 0;
//   inputField.value = currentValue - 1;
// });

// plusButton.addEventListener('click', event => {
//   event.preventDefault();
//   const currentValue = Number(inputField.value) || 0;
//   inputField.value = currentValue + 1;
// });



function SomeDeleteRowFunction(o) {
    var p = o.parentNode.parentNode;
    p.parentNode.removeChild(p);
}



// function getTotal(){
//   var arr = document.querySelectorAll('input');
//   var total=0;
//   for(var i =0; i<arr.length;i++){
//     if(parseInt(arr[i].value)){
//       total+= parseInt(arr[i].value);
//     }
//   }

//   document.getElementById('total').value=total;
// }





function smanjivanje() {
    var element = document.getElementById("input").value;
    document.getElementById('input').value = --element;
}

function povecanje() {
    var element = document.getElementById("input").value;
    document.getElementById('input').value = ++element;
}



//   window.onload=function lala(){
//     var minusBtn = document.getElementById("minus"),
//         plusBtn = document.getElementById("plus"),
//         numberPlace = document.getElementById("numberPlace"),
//         submitBtn = document.getElementById("submit"),
//         number = 0, /// number value
//         min = 0, /// min number
//         max = 30; /// max number

//     minusBtn.onclick = function(){
//         if (number>min){
//            number = number-1; /// Minus 1 of the number
//            numberPlace.innerText = number ; /// Display the value in place of the number

//         }
//         if(number == min) {        
//             numberPlace.style.color= "red";
//             setTimeout(function(){numberPlace.style.color= "black"},500)
//         }
//         else {
//           numberPlace.style.color="black";            
//            }

//     }
//     plusBtn.onclick = function(){
//         if(number<max){
//            number = number+1;
//            numberPlace.innerText = number ; /// Display the value in place of the number
//         }     
//         if(number == max){
//                numberPlace.style.color= "red";
//                setTimeout(function(){numberPlace.style.color= "black"},500)
//         }

//         else {
//                numberPlace.style.color= "black";

//         }


//     }
//     submitBtn.onclick = function(){
//         alert("you choice : " + number);
//     }

// }

function addItem() 
{
   let ul = document.getElementById('items');
   let text = document.getElementById('newItemText').value;
   let newLi = document.createElement('li');
   newLi.textContent = text;
   ul.appendChild(newLi)
}
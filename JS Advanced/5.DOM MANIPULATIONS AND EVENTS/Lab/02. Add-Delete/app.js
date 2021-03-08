function addItem() 
{
   let ul = document.getElementById('items');
   let newLi = document.createElement('li');
   newLi.textContent = document.getElementById('newItemText').value;

   let del = document.createElement('a');
   del.textContent = '[Delete]'
   del.href='#'
   
   del.addEventListener('click',onClick)

   newLi.appendChild(del)
   ul.appendChild(newLi)

   document.getElementById('newItemText').value=''

   function onClick(e)
   {
        console.log(e.target.parentNode.remove());
   }
   
}
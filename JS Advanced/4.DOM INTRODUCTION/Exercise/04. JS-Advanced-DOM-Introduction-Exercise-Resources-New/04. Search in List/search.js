function search() 
{
   let listOfTowns = document.querySelectorAll('#towns li');
   let toSearch = document.getElementById('searchText').value;
   let count =0;
  

   for (const town of listOfTowns) 
   {
      if (town.textContent.indexOf(toSearch)>=0) 
      {
         count++;   
         town.style.fontWeight='bold'
         town.style.textDecoration = "underline"
      }
   }
   document.getElementById('result').textContent=`${count} matches found`
}

function create(words) 
{
   let mainDiv = document.getElementById('content')
   words.forEach((w) => 
   {
      let div = document.createElement('div');
      let p = document.createElement('p');
      div.addEventListener('click',(e)=>
      {
         p.style.display=''
      })
      
      p.innerText = w;
      p.style.display = 'none'
      
      div.appendChild(p)
      mainDiv.appendChild(div);
   });
}
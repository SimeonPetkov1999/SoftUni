function lockedProfile() 
{
    let buttons = Array.from(document.querySelectorAll('button'))

    buttons.forEach(e =>
    {
        e.addEventListener('click', (e) =>
        {
            let radioButtonUnlocked = e.target.parentNode.children[4];

            if(radioButtonUnlocked.checked && e.target.parentNode.children[9].style.display === 'inline')
            {            
                e.target.parentNode.children[9].style.display = 'none'
                e.target.textContent = 'Show more'
            }

            else if (radioButtonUnlocked.checked) 
            {
                e.target.parentNode.children[9].style.display = 'inline'
                e.target.textContent = 'Hide it'
            }
            

        })
    });
}
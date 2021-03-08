function validate()
{
    let inputElement = document.getElementById('email');

    inputElement.addEventListener('change', checkEmail);

    function checkEmail(event)
    {
        if (/^[a-z]+@[a-z]+\.[a-z]+$/.test(event.target.value))
        {
            event.target.removeAttribute('class');            
        }
        else    
        {
            event.target.className = 'error';
        }
    }
}
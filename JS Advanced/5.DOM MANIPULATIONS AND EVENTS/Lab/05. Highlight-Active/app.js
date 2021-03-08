function focused()
{
    Array.from(document.querySelectorAll('input')).forEach(i =>
    {
        i.addEventListener('focus', onFocus);
        i.addEventListener('blur', onblur);
    });
    function onFocus(ev)
    {
        ev.target.parentNode.className = 'focus';
    }

    function onblur(ev)
    {
        ev.target.parentNode.className = '';
    }
}
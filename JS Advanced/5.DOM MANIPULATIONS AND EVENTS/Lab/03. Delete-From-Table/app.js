function deleteByEmail() 
{
    let emails = Array.from(document.querySelectorAll('tbody tr td'))
    let emailToSearch = document.querySelector('[name="email"]').value;
    let output = document.getElementById('result');

    emails.forEach((i) =>
    {
        if (i.textContent.includes(emailToSearch))
        {
            i.parentNode.remove();
            output.textContent = 'Deleted.'
            return;
        }
    })

    output.textContent = 'Not found.'
}
function validate()
{
    let pattern = /^([a-z]+)@([a-z]+)+\.([a-z]+)+$/gm;
    let input = document.getElementById('email')
    console.log(input);
    input.addEventListener('change', (e) =>
    {
        if (!pattern.test(e.target.value))
        {
            e.target.classList.add('error')
        }
        else
        {
            e.target.classList.remove('error')
        }
        console.log(e.target.value)
    })
}
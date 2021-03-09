function attachEventsListeners() 
{
    let allDivs = Array.from(document.querySelectorAll('[type="button"]'));
    let allInputs = Array.from(document.querySelectorAll('[type="text"]'));

    allDivs.forEach((d) =>
    {
        d.addEventListener('click', (e) =>
        {           
            if(e.target.id=='daysBtn')
            {
                let days = Number(document.querySelectorAll('[type="text"]')[0].value);
                allInputs[1].value = days*24;
                allInputs[2].value = days*1440;
                allInputs[3].value = days*86400;
            }
            else if(e.target.id=='hoursBtn')
            {
                let hours = Number(document.querySelectorAll('[type="text"]')[1].value);
                let days = hours/24;
                allInputs[0].value = days;
                allInputs[2].value = days*1440;
                allInputs[3].value = days*86400;
            }
            else if(e.target.id=='minutesBtn')
            {
                let minutes = Number(document.querySelectorAll('[type="text"]')[2].value);
                let days = minutes/1440
                allInputs[0].value = days;
                allInputs[1].value = days*24;
                allInputs[3].value = days*86400;
            }
            else if(e.target.id=='secondsBtn')
            {
                let seconds = Number(document.querySelectorAll('[type="text"]')[3].value);
                let days = seconds/86400
                allInputs[0].value = days;
                allInputs[1].value = days*24;
                allInputs[2].value = days*1440;
            }
        })
    })
}
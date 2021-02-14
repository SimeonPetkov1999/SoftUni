function solve(speed, area)
{
    speed = Number(speed);

    let limits =
    {
        'motorway': 130,
        'interstate': 90,
        'city': 50,
        'residential': 20
    }

    let message;
    if (speed <= limits[area])
    {
        message = `Driving ${speed} km/h in a ${limits[area]} zone`;
    }
    else 
    {
        let diff = speed - limits[area];
        let speedingMessage;
        if (diff <= 20) 
        {
            speedingMessage = 'speeding';
        }
        else if (diff <= 40)
        {
            speedingMessage = 'excessive speeding';
        }
        else
        {
            speedingMessage = 'reckless driving';
        }
        message = `The speed is ${diff} km/h faster than the allowed speed of ${limits[area]} - ${speedingMessage}`;
    }
    console.log(message);
}

solve(40, 'city')
solve(21, 'residential')
solve(120, 'interstate')
solve(200, 'motorway')


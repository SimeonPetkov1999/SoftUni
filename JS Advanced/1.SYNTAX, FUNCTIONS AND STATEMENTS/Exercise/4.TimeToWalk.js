function solve(steps,length,speed)
{
    steps = Number(steps);
    length = Number(length);
    speed = Number(speed);

    let distanceMeters = steps * length;
    let speedMetersSec = speed / 3.6;
    let time = distanceMeters / speedMetersSec;
    let rest = Math.floor(distanceMeters / 500);
  
    let mins = Math.floor(time / 60);
    let sec = Math.round(time - (mins * 60));
    let hr = Math.floor(time / 3600);

    console.log((hr < 10 ? "0" : "") + hr + ":" + 
                (mins + rest < 10 ? "0" : "") + (mins + rest) + ":" + 
                (sec < 10 ? "0" : "") + sec);
}
solve(4000, 0.60, 5);
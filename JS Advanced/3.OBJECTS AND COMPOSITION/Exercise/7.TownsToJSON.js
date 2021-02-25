function solve(towns)
{
    let townsArr = [];
    for (let town of towns.slice(1))
    {
        let [_, Town, Latitude, Longitude] =town.split(/\s*\|\s*/);
        Latitude = +(Number(Latitude).toFixed(2));
        Longitude = +(Number(Longitude).toFixed(2));

        townsArr.push({Town,Latitude,Longitude});
    }
    console.log(JSON.stringify(townsArr));
}

solve(['| Town | Latitude | Longitude |',
    '| Sofia | 42.696552 | 23.32601 |',
    '| Beijing | 39.913818 | 116.363625 |'])
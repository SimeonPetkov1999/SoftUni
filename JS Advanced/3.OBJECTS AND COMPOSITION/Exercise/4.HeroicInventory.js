function solve(inputArr)
{
    let heroes = [];
    for (const current of inputArr)     
    {
        let [name, level, items] = current.split(' / ');

        let currentHeroObj =
        {
            name: name,
            level: Number(level),
            items: items ? items.split(', ') : [],
        }
        heroes.push(currentHeroObj);
    }
    return JSON.stringify(heroes);
}

console.log(solve(['Isacc / 25',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara']
))
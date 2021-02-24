function solve(inputArr)
{
    let towns ={};
    for (const input of inputArr) 
    {
        let [name,population] = input.split(' <-> ');
        population = Number(population);

        if (!towns.hasOwnProperty(name)) 
        {
            towns[name]=0;
        }
        towns[name]+=population;
    }

    for (const name in towns) 
    {
        console.log(`${name} : ${towns[name]}`);
    }
}

solve(['Sofia <-> 1200000',
       'Montana <-> 20000',
       'New York <-> 10000000',
       'Washington <-> 2345000',
       'Las Vegas <-> 1000000']);
function solve()
{
    let count ={};
    for (let i = 0; i < arguments.length; i++) 
    {
        let type =typeof arguments[i];
        let value = arguments[i];
        console.log(`${type}: ${value}`); 

        if (!count.hasOwnProperty(type))
        {
            count[type] = 0;
        }
        count[type]++;
    }

    Object.keys(count).sort((a, b) => count[b] - count[a]).forEach(k => console.log(`${k} = ${count[k]}`))
}

solve('cat', 42, function () { console.log('Hello world!'); })
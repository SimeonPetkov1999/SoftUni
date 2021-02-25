function solve(productsArr)
{
    let result = []

    for (const product of productsArr) 
    {
        let [name, price] = product.split(' : ');
        price = Number(price);
    
        result.push({name,price});
    }
    result.sort((a,b)=>a.name.localeCompare(b.name))

    let firstletter = result[0].name.charAt(0);
    console.log(firstletter)
    for (const product of result) 
    {
        if (firstletter !== product.name.charAt(0)) 
        {
            firstletter = product.name.charAt(0);
            console.log(firstletter)
        }
        console.log(`  ${product.name}: ${product.price}`)
    }
}


solve(['Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10']
);
function solve(inputArr)
{
    let result={};

    for (const product of inputArr) 
    {
        let [town,productName,productPrice] = product.split(' | ');   
        productPrice = Number(productPrice);
         
        
        if (productName in result == false) 
        {
            result[productName] = {townName:town,price:productPrice}
        }
        else if(result[productName].price>productPrice)
        {
            result[productName].price = productPrice;
            result[productName].townName = town;
        }        
    }

    for (const key in result) 
    {
        console.log(`${key} -> ${result[key].price} (${result[key].townName})`);
    }
}

solve(['Sample Town | Sample Product | 1000',
'Sample Town | Orange | 2',
'Sample Town | Peach | 1',
'Sofia | Orange | 3',
'Sofia | Peach | 2',
'New York | Sample Product | 1000.1',
'New York | Burger | 10']
)
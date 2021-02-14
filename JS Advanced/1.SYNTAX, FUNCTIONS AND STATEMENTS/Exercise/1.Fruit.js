function solve(type,weight,pricePerKg)
{
   let weigthInGrams = weight /1000;
   let price = weigthInGrams * pricePerKg;
   
   console.log(`I need $${price.toFixed(2)} to buy ${weigthInGrams.toFixed(2)} kilograms ${type}.`);
}

solve('orange',2500,1.80);
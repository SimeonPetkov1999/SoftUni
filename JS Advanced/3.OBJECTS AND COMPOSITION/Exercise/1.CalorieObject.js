function solve(inputArr)
{
    let foods = {};
    for (let i = 0; i < inputArr.length; i+=2) 
    {
         let name = inputArr[i];
         let cal = Number(inputArr[i+1]);
        foods[name] = cal;
    }

    return foods;
}

console.log(solve(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']))
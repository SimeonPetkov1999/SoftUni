function solve(arr)
{
    let newArr = [];
    for (let i = 0;i < arr.length; i+=2) 
    {
       newArr.push(arr[i]);
    }
    return newArr.join(' ');
}

console.log(solve(['20', '30', '40', '50', '60']));
console.log(solve(['5', '10']));

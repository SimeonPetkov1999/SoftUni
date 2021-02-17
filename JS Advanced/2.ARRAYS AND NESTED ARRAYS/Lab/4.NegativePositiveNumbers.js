function solve(arr)
{
    let newArr = [];
    for (const num of arr) 
    {
        num >= 0 ? newArr.push(num) : newArr.unshift(num);
    }
    return newArr.join('\n');
}

console.log(solve([7, -2, 8, 9]));
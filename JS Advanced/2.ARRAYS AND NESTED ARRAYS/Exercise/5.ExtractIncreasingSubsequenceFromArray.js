function solve(arr)
{
    let max = arr[0];
    let newArr = [];

    for (const num of arr) 
    {
        if (num >= max) 
        {
            newArr.push(num);
            max = num;
        }
    }
    return newArr;
}

console.log(solve([1, 3, 8, 4, 10, 12, 3, 2, 24]))
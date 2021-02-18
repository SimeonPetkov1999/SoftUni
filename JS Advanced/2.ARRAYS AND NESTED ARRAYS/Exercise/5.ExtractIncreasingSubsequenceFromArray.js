function solve(arr)
{
    // let max = arr[0];
    // let newArr = [];

    // for (const num of arr) 
    // {
    //     if (num >= max) 
    //     {
    //         newArr.push(num);
    //         max = num;
    //     }
    // }
    // return newArr;

    return arr.reduce((result, currentValue,index,initial) =>
    {
        if (currentValue >= result[result.length - 1] || result.length === 0) 
        {
            result.push(currentValue);
        }
        return result;
    }, [])
}

console.log(solve([20,
    3,
    2,
    15,
    6,
    1]
))
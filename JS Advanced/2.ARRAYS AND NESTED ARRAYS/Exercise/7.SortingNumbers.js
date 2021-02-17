function solve(arr)
{
    arr = arr.sort((a, b) => a - b);
    let myArr = [];
    while (arr.length != 0)
    {
        myArr.push(arr.shift());
        myArr.push(arr.pop());
    }
    return myArr;
}

console.log(solve([1, 65, 3, 52, 48, 63, 31, -3, 18, 56,]));
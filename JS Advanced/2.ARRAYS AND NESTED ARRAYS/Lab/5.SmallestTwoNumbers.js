function solve(arr)
{
    arr = arr.sort((a, b) => a-b)    
    let smallest = arr.slice(0,2);
    return smallest.join(' ');
}

console.log(solve([30, 15, 50, 5]));
console.log(solve([3, 0, 10, 4, 7, 3]));

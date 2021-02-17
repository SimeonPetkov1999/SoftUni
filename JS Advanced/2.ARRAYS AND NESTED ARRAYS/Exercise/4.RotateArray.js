function solve(arr, shifts)
{
    for (let i = 0; i < shifts; i++) 
    {
        arr.unshift(arr.pop())
    }
    return arr.join(' ');
}

console.log(solve(['Banana', 'Orange', 'Coconut', 'Apple'], 15));
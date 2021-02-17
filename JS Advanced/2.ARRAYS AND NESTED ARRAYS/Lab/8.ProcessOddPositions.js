function solve(arr)
{
    return arr.filter((a, i) => i % 2 != 0)
            .map(e=>e*2)
            .reverse(); 
}
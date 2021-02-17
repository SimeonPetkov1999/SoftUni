function solve(arr)
{
    arr = arr.sort((a, b) =>
    {
        if (a.length - b.length == 0) 
        {   
            return a.localeCompare(b);
        }
        return a.length-b.length;
    })

    return arr.join('\n');
}

console.log(solve(['Isacc', 'Theodor', 'Jack','Harrison', 'George']));

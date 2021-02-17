function solve(matrix)
{
    return matrix.reduce((max, currentRow, index, array) => 
    {
        for (const row of array) 
        {
            for (const num of row) 
            {
                if (num > max) 
                {
                    max = num                 
                }
            }         
        }
        return max;
    }, matrix[0][0]);
}

console.log(solve([[20, 50, 10],
[8, 33, 145]]))

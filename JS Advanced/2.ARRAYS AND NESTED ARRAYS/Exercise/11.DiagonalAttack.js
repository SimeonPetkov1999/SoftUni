function solve(matrix)
{
    matrix = matrix.map(row => row.split(' ').map(Number));

    let primaryDiagonal = 0;
    let secondaryDiagonal = 0;
    for (let row = 0; row < matrix.length; row++) 
    {
        primaryDiagonal += matrix[row][row];
        secondaryDiagonal += matrix[row][matrix.length - row - 1];
    }

    if (primaryDiagonal != secondaryDiagonal) 
    {
        return printMatrix(matrix);
    }
    else
    {
        for (let row = 0; row < matrix.length; row++) 
        {
            for (let col = 0; col < matrix.length; col++) 
            {
                if (row === col || col === matrix.length - 1 - row) 
                {
                    continue;
                }
                matrix[row][col] = primaryDiagonal;
            }
        }
    }
    return printMatrix(matrix);

    function printMatrix(matrix) 
    {
        for (var i = 0; i < matrix.length; i++) 
        {
            matrix[i] = matrix[i].join(' ');
        }
        return matrix.join('\n');
    }
}

console.log(solve(['1 1 1',
'1 1 1',
'1 1 0']))
function solve(matrix)
{
    let isMagic = true;
    let rowSum = 0;
    let colSum = 0;

    for (let row = 0; row < matrix.length; row++) 
    {
        let rowIndex = 0;
        for (let col = 0; col < matrix[row].length; col++) 
        {
            rowSum += matrix[row][col];
            if (rowIndex < matrix.length) 
            {
                colSum += matrix[rowIndex++][row];
            }
        }
        if (rowSum === colSum) 
        {
            isMagic = true;
        }
        else
        {
            isMagic = false;
            break;
        }
        rowSum = 0;
        colSum = 0;
    }
    return isMagic;
}

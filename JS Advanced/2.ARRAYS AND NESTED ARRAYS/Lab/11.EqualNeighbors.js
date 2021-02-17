function solve(matrix)
{
    let equals = 0;
    //console.log(matrix[0][0]);
    for (let row = 0; row < matrix.length; row++) 
    {
        for (let col = 0; col < matrix[row].length; col++) 
        {
            let currentEll = matrix[row][col];
            if (row==matrix.length-1) 
            {
               if (currentEll==matrix[row][col+1]) 
               {
                 equals++;    
               } 
            }          
            else if(currentEll == matrix[row][col+1] ||
                currentEll == matrix[row+1][col]) 
            {
                equals++;
            }
        }
    }
    return equals;
}

console.log(solve([['test', 'yes', 'yo', 'ho'],
['well', 'done', 'yo', '6'],
['not', 'done', 'yet', '5']]));
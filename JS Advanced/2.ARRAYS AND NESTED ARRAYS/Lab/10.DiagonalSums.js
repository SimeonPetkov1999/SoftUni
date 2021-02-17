function solve(matrix)
{
    let firstDiagonal = 0;
    let secondDiagonal = 0;

    for (let i = 0; i < matrix.length; i++) 
    {
       firstDiagonal+=matrix[i][i];
       secondDiagonal+=matrix[i][matrix.length-i-1];       
    }

    console.log(firstDiagonal,secondDiagonal);
}

solve([[20, 40],
    [10, 60]])


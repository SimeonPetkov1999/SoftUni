function solve(arr, step)
{
    // let newArr =[];
    // for (let i = 0; i < arr.length; i+=step) 
    // {
    //     newArr.push(arr[i]); 
    // }
    // return newArr;

    return arr.filter((a, i) => i % step == 0);
}

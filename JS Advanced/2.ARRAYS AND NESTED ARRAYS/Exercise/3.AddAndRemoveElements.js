function solve(arr)
{
    let num = 1;
    let myArr=[];
    for (const command of arr) 
    {
        if (command==='add') 
        {
            myArr.push(num++);
        }    
        else if(command=='remove')
        {
            myArr.pop();
            num++;
        }
    }
    if (myArr.length!=0) 
    {
        return myArr.join('\n');    
    }
    return 'Empty';
}

console.log(solve(['add', 'add', 'add', 'add']));
console.log(solve(['add', 'add', 'remove', 'add', 'add']));
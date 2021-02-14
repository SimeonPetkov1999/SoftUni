function solve(num)
{
    num = String(num);
    let areEqual = true;
    let sum = 0;
    let firstEl = num[0];
    for (let i = 0; i < num.length; i++)
    {
        sum += parseInt(num[i]);
        if (num[i]!== firstEl)
        {
            areEqual = false;
        }
    }
    console.log(areEqual)
    console.log(sum);
}

solve(2222222); 
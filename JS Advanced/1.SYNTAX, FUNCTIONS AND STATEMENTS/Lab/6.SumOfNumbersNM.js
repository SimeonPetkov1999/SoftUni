function solve(n,m)
{
    let from = Number(n);
    let to = Number(m);
    let result = 0;
    for (let i = from; i <= to; i++) 
    {
       result+=i;
    }
    console.log(result);
}

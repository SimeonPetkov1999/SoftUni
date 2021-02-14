function solve(a, b)
{
    let r;
    while (0 !== b) 
    {
        r = a % b;
        a = b;
        b = r;
    }
    return a;
}
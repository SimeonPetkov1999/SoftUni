function add ()
{
    let total = 0;
    return function sum(a)
    {
        total += a;
        sum.toString = () => total;
        return sum;
    }

}
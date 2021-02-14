function solve(input,arg1,arg2,arg3,arg4,arg5)
{
    let num = Number(input);

    for (let i = 1; i < arguments.length; i++) 
    {
        switch (arguments[i]) 
        {
            case 'chop':
                num = num / 2;
                console.log(num);
                break;
            case 'dice':
                num = Math.sqrt(num);
                console.log(num);
                break;
            case 'spice':
                num++;
                console.log(num);
                break;
            case 'bake':
                num *= 3;
                console.log(num);
                break;
            case 'fillet':
                num *= 0.80;
                console.log(num);
                break;
        }
        
    }
}
solve(32, 'chop', 'chop', 'chop', 'chop', 'chop')
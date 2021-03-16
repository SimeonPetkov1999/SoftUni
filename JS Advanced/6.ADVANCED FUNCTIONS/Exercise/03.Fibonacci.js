function getFibonator()
{
    let fibo = [];
    i = 0;
    fillArr();

    return function fib()
    {
        return fibo[i++];
    }

    function fillArr()
    {
        fibo[0] = 1;
        fibo[1] = 1;
        for (let i = 2; i <= 100; i++)
        {
            fibo[i] = fibo[i - 2] + fibo[i - 1];
        }
    }
}

let fib = getFibonator();
console.log(fib()); // 1
console.log(fib()); // 1
console.log(fib()); // 2
console.log(fib()); // 3
console.log(fib()); // 5
console.log(fib()); // 8
console.log(fib()); // 13

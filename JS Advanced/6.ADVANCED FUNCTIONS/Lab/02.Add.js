function solution(n)
{
    return function add(num)
    {
        return n+Number(num)
    }   
}

let add5 = solution(5);
console.log(add5(2));
console.log(add5(3));

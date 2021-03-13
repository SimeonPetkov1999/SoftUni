function solution()
{
    let data = '';

    return { append, removeStart, removeEnd, print }

    function append(text)
    {
        data += text;
    }

    function removeStart(n)
    {
        data = data.slice(n)
    }

    function removeEnd(n)
    {
        data = data.slice(0, -n);
    }

    function print()
    {
        console.log(data);
    }
}

let firstZeroTest = solution();

firstZeroTest.append('hello');
firstZeroTest.append('again');
firstZeroTest.removeStart(3);
firstZeroTest.removeEnd(4);
firstZeroTest.print();

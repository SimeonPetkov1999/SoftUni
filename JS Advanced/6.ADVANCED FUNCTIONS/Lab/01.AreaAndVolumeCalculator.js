function solve(area, vol, input) 
{
    let inputArr = JSON.parse(input);
    let output = []
    inputArr.forEach(element => 
    {
        output.push(
            {
                area:area.call(element),
                volume:vol.call(element)
            })
    });

    return output;
}

console.log(solve(area, vol, `[
    {"x":"1","y":"2","z":"10"},
    {"x":"7","y":"7","z":"10"},
    {"x":"5","y":"2","z":"10"}
    ]`))

function vol()
{
    return Math.abs(this.x * this.y * this.z);
};

function area()
{
    return Math.abs(this.x * this.y);
};

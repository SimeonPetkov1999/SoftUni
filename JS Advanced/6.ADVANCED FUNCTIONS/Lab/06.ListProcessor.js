function solve(data)
{
    let processor = closure();
    for (const cmd of data) 
    {
        let [key, value] = cmd.split(' ');
        
        if (key=='add')
        {
            processor.add(value);
        }
        else if(key=='remove')
        {
            processor.remove(value);
        }
        else if (key=='print')
        {
            processor.print();
        }
    }


    function closure()
    {
        let list = [];

        return { add, remove, print }

        function add(element)
        {
            list.push(element);
        }
        function remove(elements)
        {
            list = list.filter(e => e !== elements);
        }
        function print()
        {
            console.log(list.join(','));
        }
    }
}

solve(['add hello', 'add again', 'remove hello', 'add again', 'print'])
solve(['add pesho', 'add george', 'add peter', 'remove peter','print'])
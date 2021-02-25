function createSortedList()
{
    let data = [];
    return {
        add(el) { data.push(el); data = data.sort((a, b) => a - b) },
        remove(index)
        {
            if (index>=0 && index<data.length) 
            {
                data.splice(index, 1); 
                data = data.sort((a, b) => a - b)   
            }
        },
        get(index)
        {
            if (index>=0 && index<data.length) 
            {
                return data[index];    
            }  
        },
        size:data.length
    }
}

let list = createSortedList();
list.add(5);
list.add(6);
list.add(7);
console.log(list.size)
console.log(list.get(1)); 
list.remove(1);
console.log(list.get(1));

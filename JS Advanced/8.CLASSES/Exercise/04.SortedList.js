class List
{

    constructor()
    {
        this.innerList = [];
        this.size = 0;
    }

    add(el)
    {
        this.innerList.push(el);
        this.innerList.sort((a, b) => a - b);
        this.size++;
    }
    remove(i)
    {
        if (i >= 0 && i < this.innerList.length)
        {
            this.innerList.splice(i,1);
            this.size--;
        }
    }
    get(i)
    {
        if (i >= 0 && i < this.innerList.length)
        {
            return this.innerList[i];
        } 
    }
}

let list = new List();
list.add(5);
list.add(6);
list.add(7);
console.log(list.size)
console.log(list.get(1)); 
list.remove(1);
console.log(list.get(1));

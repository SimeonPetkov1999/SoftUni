function cardFactory(face,suit)
{
    let faces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
    let suits =
    {
        'S': '\u2660',
        'H': '\u2665 ',
        'D': '\u2666 ',
        'C': '\u2663 ',
    }

    if (suits.hasOwnProperty(suit)==false || faces.includes(face)==false) 
    {
        throw new Error("Error");
    }

    return{
        toString:()=>
        {
            suit,
            face,
            toString()
            {
                return `${face}${suits[suit]}`;
            }
        }
    }
}
let obj = cardFactory('A', 'S') 
console.log(obj.toString());
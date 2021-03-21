function solve(arr)
{
    function cardFactory(face,suit)
    {
        let faces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
        let suits =
        {
            'S': '\u2660',
            'H': '\u2665',
            'D': '\u2666',
            'C': '\u2663',
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

    let cards = [];
    for (const card of arr) 
    {
        let face = card.substring(0, card.length - 1);
        let suit = card[card.length -1];
        try 
        {
            let card = cardFactory(face,suit).toString();
            cards.push(card);
        } 
        catch (error) 
        {
            console.log(`Invalid card: ${face}${suit}`);
            return;
        }       
    }
    console.log(cards.join(' '));
}

console.log(solve(['AS', '10D', 'KH', '2C']));
console.log(solve(['5S', '3D', 'QD', '1C']));
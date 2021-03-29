function solve(inputArr, sortingCriteria)
{
    class Ticket
    {
        constructor(destination, price, status)
        {
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }

    let tickets = [];
    for (const currentTicket of inputArr) 
    {
        let ticketInfo = currentTicket.split('|');
        let ticketDestination = ticketInfo[0];
        let ticketPrice = Number(ticketInfo[1]);
        let ticketStatus = ticketInfo[2];

        let ticket = new Ticket(ticketDestination, ticketPrice, ticketStatus)
        tickets.push(ticket);
    }

    if (sortingCriteria=='destination')
    {
        return tickets.sort((a, b) => a.destination.localeCompare(b.destination));
    } 
    else if(sortingCriteria=='price')
    {
        return tickets.sort((a, b) => a.price-b.price);
    }
    else
    {
        return tickets.sort((a, b) => a.status.localeCompare(b.status));
    }
}

console.log(solve(['Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'],
    'destination'))
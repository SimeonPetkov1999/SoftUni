function solve(data, criteria)
{
    let arrData = JSON.parse(data);
    let [key, value] = criteria.split('-');

    if(key==='all')
    {
        print(arrData);
        return;
    }
    
    let output= []
    arrData.forEach(e => 
    {
        if (e[key]===value)
        {
            output.push(e);
        }
    });
    print(output);

    function print(data)
    {
        for (let i = 0; i < data.length; i++)
        {
            console.log(`${i}. ${data[i]['first_name']} ${data[i]['last_name']} - ${data[i]['email']}`);
        }
    }
}

solve(`[{
    "id": "1",
    "first_name": "Ardine",
    "last_name": "Bassam",
    "email": "abassam0@cnn.com",
    "gender": "Female"
  }, {
    "id": "2",
    "first_name": "Kizzee",
    "last_name": "Jost",
    "email": "kjost1@forbes.com",
    "gender": "Female"
  },  
{
    "id": "3",
    "first_name": "Evanne",
    "last_name": "Maldin",
    "email": "emaldin2@hostgator.com",
    "gender": "Male"
  }]`,
    'gender-Female')


solve(`[{
    "id": "1",
    "first_name": "Kaylee",
    "last_name": "Johnson",
    "email": "k0@cnn.com",
    "gender": "Female"
  }, {
    "id": "2",
    "first_name": "Kizzee",
    "last_name": "Johnson",
    "email": "kjost1@forbes.com",
    "gender": "Female"
  }, {
    "id": "3",
    "first_name": "Evanne",
    "last_name": "Maldin",
    "email": "emaldin2@hostgator.com",
    "gender": "Male"
  }, {
    "id": "4",
    "first_name": "Evanne",
    "last_name": "Johnson",
    "email": "ev2@hostgator.com",
    "gender": "Male"
  }]`,
 'all')

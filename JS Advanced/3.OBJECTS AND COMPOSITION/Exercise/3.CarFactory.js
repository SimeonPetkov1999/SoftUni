function solve(requirementsObj)
{
    let smallEngine = { power: 90, volume: 1800 }
    let normalEngine = { power: 120, volume: 2400 }
    let monsterEngine = { power: 200, volume: 3500 }
    
    let hatchBack = { type: 'hatchback', color: requirementsObj.color }
    let coupe = { type: 'coupe', color: requirementsObj.color }
    
    let car = { model: requirementsObj.model }
    
    AddEngine();
    AddCarriage();
    AddWheels()
    
    return car;
    
    function AddEngine()
    {
        if (requirementsObj.power <= 90)
        {
            car['engine'] = smallEngine
        }
        else if (requirementsObj.power <= 120)
        {
            car['engine'] = normalEngine
        }
        
        else
        {
            car['engine'] = monsterEngine
        }
    }
    
    function AddCarriage()
    {
        if (requirementsObj.carriage == 'hatchback')
        {
            car['carriage'] = hatchBack
        }
        else if (requirementsObj.carriage == 'coupe')
        {
            car['carriage'] = coupe
        }
    }
    
    function AddWheels()
    {
        let wheel = Math.round(requirementsObj.wheelsize)
    
        if (wheel % 2 == 0)
        {
            wheel--
        }
    
        car['wheels'] = [wheel, wheel, wheel, wheel]
    }
}

console.log(solve({ model: 'Opel Vectra',
  power: 110,
  color: 'grey',
  carriage: 'coupe',
  wheelsize: 17 }

))
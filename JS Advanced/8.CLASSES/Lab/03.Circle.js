class Circle 
{
    constructor(radius)
    {
        this.r = radius;
    }

    get diameter()
    {
        return this.r * 2;
    }
    set diameter(value)
    {
        this.r = value /2;
    }
    get radius()
    {
        return this.r;
    }

    get area()
    {
        return Math.PI * Math.pow(this.r,2);
    }

}
let c = new Circle(2);
console.log(`Radius: ${c.radius}`);
console.log(`Diameter: ${c.diameter}`);
console.log(`Area: ${c.area}`);
c.diameter = 1.6;
console.log(`Radius: ${c.radius}`);
console.log(`Diameter: ${c.diameter}`);
console.log(`Area: ${c.area}`);



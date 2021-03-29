class Hex
{
    constructor(number)
    {
        this.value = Number(number);
    }
    valueOf()
    {
        return this.value;
    }
    toString()
    {
        return `0x${(this.value.toString(16)).toUpperCase()}`;
    }
    plus(number)
    {
        return new Hex(this.value + Number(number.valueOf()));
    }
    minus(number)
    {
        return new Hex(this.value - Number(number.valueOf()));
    }
    parse(text)
    {
        return parseInt(text, 16);
    }
}
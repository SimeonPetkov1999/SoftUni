const sum = require('./app');
const {expect} = require("chai");

describe('Sums tests',()=>
{
    it('test two num',()=>
    {
        expect(sum([1,1])).to.equal(2);
    })

    it('test one num',()=>
    {
        expect(sum([1])).to.equal(1);
    })
})
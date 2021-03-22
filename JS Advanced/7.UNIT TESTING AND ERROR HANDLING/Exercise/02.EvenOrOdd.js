const {expect,assert} = require('chai');

function isOddOrEven(string)
{
    if (typeof (string) !== 'string')
    {
        return undefined;
    }
    if (string.length % 2 === 0)
    {
        return "even";
    }

    return "odd";
}

describe('Even odd Tests',()=>
{
    it("wrong input",()=>
    {
        expect(isOddOrEven([2,2,2])).to.be.undefined;
        expect(isOddOrEven(123)).to.be.undefined;
        assert.isUndefined(isOddOrEven(1.1));
    })

    it('working fine',()=>
    {
        assert.equal(isOddOrEven('22'),'even')
        assert.equal(isOddOrEven('2'),'odd')
    })
})

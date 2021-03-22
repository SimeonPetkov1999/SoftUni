const { expect, assert } = require('chai');

function lookupChar(string, index)
{
    if (typeof (string) !== 'string' || !Number.isInteger(index))
    {
        return undefined;
    }
    if (string.length <= index || index < 0)
    {
        return "Incorrect index";
    }

    return string.charAt(index);
}


describe('LookupChar Tests', () =>
{
    it("wrong input", () =>
    {
        expect(lookupChar(2, 1)).to.be.undefined;
        assert.isUndefined(lookupChar(2, '2'));
        assert.isUndefined(lookupChar('2', '2'));
        assert.isUndefined(lookupChar('2', 1.5));

        assert.equal(lookupChar('test', 10), 'Incorrect index');
        assert.equal(lookupChar('test', -10), 'Incorrect index');
        assert.equal(lookupChar('test', 4), 'Incorrect index');
    })

    it('Working fine', () =>
    {
        assert.equal(lookupChar('test', 0), 't');
        assert.equal(lookupChar('test', 3), 't');
        assert.equal(lookupChar('test', 2), 's');
    })
})
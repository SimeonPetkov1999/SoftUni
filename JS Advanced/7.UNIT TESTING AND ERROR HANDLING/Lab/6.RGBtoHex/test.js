const { expect } = require('chai');
const rgbToHexColor = require('./app');

describe("RGB to Hex Color", () =>
{
    it('should return #000000 for (0, 0, 0)', function ()
    {
        expect(rgbToHexColor(0, 0, 0)).to.equal('#000000');
    });
    it('should pad zeroes', () =>
    {
        expect(rgbToHexColor(12, 13, 14)).to.equal('#0C0D0E');
    });
    it('return undefined for negative values ', () =>
    {
        expect(rgbToHexColor(-100, -100, -100)).to.be.undefined;
    });
    it('return undefined for greater than 255 (R)', () =>
    {
        expect(rgbToHexColor(1000, 0, 0)).to.be.undefined;
    });
    it('return undefined for greater than 255 (G)', () =>
    {
        expect(rgbToHexColor(0, 1000, 0)).to.be.undefined;
    });
    it('return undefined for greater than 255 (B)', () =>
    {
        expect(rgbToHexColor(0, 0, 1000)).to.be.undefined;
    });
    it('upper limit', () =>
    {
        expect(rgbToHexColor(255, 255, 255)).to.equal('#FFFFFF');
    });
});
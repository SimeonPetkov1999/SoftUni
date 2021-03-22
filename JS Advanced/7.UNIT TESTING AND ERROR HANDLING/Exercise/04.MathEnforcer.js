const { expect, assert } = require('chai');

let mathEnforcer = {
    addFive: function (num)
    {
        if (typeof (num) !== 'number')
        {
            return undefined;
        }
        return num + 5;
    },
    subtractTen: function (num)
    {
        if (typeof (num) !== 'number')
        {
            return undefined;
        }
        return num - 10;
    },
    sum: function (num1, num2)
    {
        if (typeof (num1) !== 'number' || typeof (num2) !== 'number')
        {
            return undefined;
        }
        return num1 + num2;
    }
};


describe("mathEnforcer", () =>
{
    describe('Add Tests', () =>
    {
        it("", () =>
        {
            expect(mathEnforcer.addFive("100")).to.be.equal(undefined);
            expect(mathEnforcer.addFive(5.50)).to.be.closeTo(10.50, 0.1);
            expect(mathEnforcer.addFive(20)).to.be.equal(25);
            expect(mathEnforcer.addFive(-10)).to.be.equal(-5);
        });
    });

    describe('Subtract Tests', () =>
    {
        it("", () =>
        {
            expect(mathEnforcer.subtractTen("100")).to.be.equal(undefined);
            expect(mathEnforcer.subtractTen(20)).to.be.equal(10);
            expect(mathEnforcer.subtractTen(-5)).to.be.equal(-15);
            expect(mathEnforcer.subtractTen(5.50)).to.be.closeTo(-4.50, 0.1);
        });
    });

    describe('Sum Tests', () =>
    {
        it("", () =>
        {
            expect(mathEnforcer.sum("100", 100)).to.be.equal(undefined);
            expect(mathEnforcer.sum(100, "100")).to.be.equal(undefined);
            expect(mathEnforcer.sum(10, -3)).to.be.equal(7);
            expect(mathEnforcer.sum(2.5, 2.5)).to.be.closeTo(5.0, 0.01);
        })
    })
});
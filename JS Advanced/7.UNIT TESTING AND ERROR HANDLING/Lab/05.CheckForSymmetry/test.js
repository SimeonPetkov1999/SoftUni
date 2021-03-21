const {expect} = require("chai");
const isSymmetric = require("./CheckForSymmetry");

describe("Value tests", function () {
    it("should return true for [1, 2, 3, 3, 2, 1]", function () {
        expect(isSymmetric([1,2,3,3,2,1])).to.be.true;
    });
    it("should return false for 1, 2, 3", function () {
        expect(isSymmetric(1, 2, 3)).to.be.false;
    });
    it("should return false for 1, '2', 2", function () {
        expect(isSymmetric(1, '2', 2)).to.be.false;
    });
    it("should return true for [1]", function () {
        expect(isSymmetric([1])).to.be.true;
    });
    it("should return false for [1, 2]", function () {
        expect(isSymmetric([1,2])).to.be.false;
    });
    it("should return true for [1,'test',{a:1},{a:1},'test',1]", function () {
        expect(isSymmetric([1,'test',{a:1},{a:1},'test',1])).to.be.true;
    });
})
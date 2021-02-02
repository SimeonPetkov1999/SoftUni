using NUnit.Framework;

[TestFixture]
public class DummyTests
{
    [Test]
    public void DummyShouldLoseHealthAfterItIsAttacked()
    {
        var dummy = new Dummy(100, 100);
        var axe = new Axe(20, 50);
        axe.Attack(dummy);
        Assert.That(dummy.Health,Is.EqualTo(80));
    }
    [Test]
    public void DeadDummyShouldNotBeAtacked() 
    {
        var dummy = new Dummy(0, 100);
        var axe = new Axe(20, 20);

        Assert.That(() => axe.Attack(dummy),
            Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
    }
    [Test]
    public void DeadDummyShouldGiveExperience()
    {
        var dummy = new Dummy(0, 100);
        var points = dummy.GiveExperience();
        Assert.That(points, Is.EqualTo(100));
    }

    [Test]
    public void AliveDummyShouldNotGiveExperience()
    {
        var dummy = new Dummy(100, 100);
        Assert.That(()=>dummy.GiveExperience(),
            Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
    }


}

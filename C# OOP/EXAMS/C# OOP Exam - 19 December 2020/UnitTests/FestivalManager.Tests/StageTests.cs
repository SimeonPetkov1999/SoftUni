// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using FestivalManager.Entities;

    using NUnit.Framework;
    using System;

    [TestFixture]
    public class StageTests
    {
        private Stage stage;

        [SetUp]
        public void SetUp()
        {
            this.stage = new Stage();
        }

        [Test]
        public void ConstructorTest()
        {
            Assert.That(this.stage.Performers.Count, Is.EqualTo(0));
        }

        [Test]
        public void AddPerformerShouldThrowExeptionIfObjectIsNull()
        {
            Performer performer = null;
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.stage.AddPerformer(performer);
            });

        }

        [Test]
        public void AddPerformerShouldThrowExeptionIfPerformerAgeUnder18()
        {
            Performer performer = new Performer("test", "test", 10);
            Assert.Throws<ArgumentException>(() =>
            {
                this.stage.AddPerformer(performer);
            });
        }

        [Test]
        public void AddPerformerWorkingFine()
        {
            Performer performer = new Performer("test", "test", 20);
            Performer performer1 = new Performer("test1", "test1", 25);
            this.stage.AddPerformer(performer);
            this.stage.AddPerformer(performer1);
            Assert.That(this.stage.Performers.Count, Is.EqualTo(2));
        }

        [Test]
        public void AddSongShouldThrowExeptionIfObjectIsNull()
        {
            Song song = null;
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.stage.AddSong(song);
            });
        }

        [Test]
        public void AddSongShouldThrowExeptionIfSongDurationIsUnder1Minute()
        {
            TimeSpan timeSpan = new TimeSpan(0, 0, 30);

            Song song = new Song("test", timeSpan);
            Assert.Throws<ArgumentException>(() =>
            {
                this.stage.AddSong(song);
            });
        }//? One More Test???//


        [Test]
        public void AddSongToPerformerShouldThrowExeptionIfSongNameIsNull()
        {

            Assert.Throws<ArgumentNullException>(() =>
            {
                this.stage.AddSongToPerformer(null, "test");
            });
        }

        [Test]
        public void AddSongToPerformerShouldThrowExeptionIfPerformerNameIsNull()
        {

            Assert.Throws<ArgumentNullException>(() =>
            {
                this.stage.AddSongToPerformer("test", null);
            });
        }

        [Test]
        public void AddSongToPerformerShouldThrowExeptionIfPerfomerIsMissing()
        {
            this.stage.AddPerformer(new Performer("simo", "petkov", 21));
            this.stage.AddPerformer(new Performer("petko", "simeonov", 22));
            Assert.Throws<ArgumentException>(() =>
            {
                this.stage.AddSongToPerformer("testSong", "notExistingName");
            });
        }

        [Test]
        public void AddSongToPerformerShouldThrowExeptionIfSongIsMissing()
        {
            this.stage.AddSong(new Song("testSong1", new TimeSpan(0, 5, 0)));
            this.stage.AddSong(new Song("testSong2", new TimeSpan(0, 5, 0)));
            this.stage.AddPerformer(new Performer("simo", "petkov", 21));
            Assert.Throws<ArgumentException>(() =>
            {
                this.stage.AddSongToPerformer("notExistingSong", "simo petkov");
            });
        }

        [Test]
        public void AddSongToPerformerWorkingFine()
        {
            var song = new Song("testSong1", new TimeSpan(0, 5, 0));
            var performer = new Performer("simo", "petkov", 21);

            this.stage.AddSong(song); 
            this.stage.AddPerformer(performer);

            var result = this.stage.AddSongToPerformer("testSong1", "simo petkov");

            Assert.That(result, Is.EqualTo($"{song} will be performed by {performer.FullName}"));
        }

        [Test]
        public void PlayTest()
        {
            var song = new Song("testSong1", new TimeSpan(0, 5, 0));
            var performer = new Performer("simo", "petkov", 21);

            this.stage.AddSong(song);
            this.stage.AddPerformer(performer);
            this.stage.AddSongToPerformer("testSong1", "simo petkov");

            var result = this.stage.Play();

            Assert.That(result, Is.EqualTo($"{this.stage.Performers.Count} performers played 1 songs"));
        }

    }
}
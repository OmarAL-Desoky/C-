using static System.Net.Mime.MediaTypeNames;
using Soccer;

namespace MyGenericSet.Test
{
    [TestClass]
    public class SoccerPlayerTest
    {
        [TestMethod]
        public void TestConstructor()
        {
            SoccerPlayer player = new SoccerPlayer(9, "Robert Lewandowski", SoccerPosition.Forward);

            Assert.AreEqual(9, player.JerseyNumber);
            Assert.AreEqual("Robert Lewandowski", player.Name);
            Assert.AreEqual(SoccerPosition.Forward, player.Position);

            player = new SoccerPlayer(20, "Zbigniew Boniek", SoccerPosition.Midfielder);

            Assert.AreEqual(20, player.JerseyNumber);
            Assert.AreEqual("Zbigniew Boniek", player.Name);
            Assert.AreEqual(SoccerPosition.Midfielder, player.Position);

            player = new SoccerPlayer(15, "Kamil Glik", SoccerPosition.Defender);

            Assert.AreEqual(15, player.JerseyNumber);
            Assert.AreEqual("Kamil Glik", player.Name);
            Assert.AreEqual(SoccerPosition.Defender, player.Position);

            player = new SoccerPlayer(1, "Artur Boruc", SoccerPosition.Goalkeeper);

            Assert.AreEqual(1, player.JerseyNumber);
            Assert.AreEqual("Artur Boruc", player.Name);
            Assert.AreEqual(SoccerPosition.Goalkeeper, player.Position);

            player = new SoccerPlayer(99, "Arkadiusz Milik", SoccerPosition.Forward);

            Assert.AreEqual(99, player.JerseyNumber);
            Assert.AreEqual("Arkadiusz Milik", player.Name);
            Assert.AreEqual(SoccerPosition.Forward, player.Position);
        }

        [TestMethod]
        public void TestToString()
        {
            SoccerPlayer player = new SoccerPlayer(9, "Robert Lewandowski", SoccerPosition.Forward);
            Assert.AreEqual("#9 Robert Lewandowski (F)", player.ToString());

            player = new SoccerPlayer(20, "Zbigniew Boniek", SoccerPosition.Midfielder);
            Assert.AreEqual("#20 Zbigniew Boniek (M)", player.ToString());

            player = new SoccerPlayer(15, "Kamil Glik", SoccerPosition.Defender);
            Assert.AreEqual("#15 Kamil Glik (D)", player.ToString());

            player = new SoccerPlayer(1, "Artur Boruc", SoccerPosition.Goalkeeper);
            Assert.AreEqual("#1 Artur Boruc (G)", player.ToString());
        }

        [TestMethod]
        public void TestJerseyNumberTooSmallThrowsException()
        {
            ArgumentException ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                SoccerPlayer player = new SoccerPlayer(-16, "Jakub Błaszczykowski", SoccerPosition.Midfielder);
            });

            Assert.AreEqual("Jersey number must be between 1 and 99!", ex.Message);
        }

        [TestMethod]
        public void TestJerseyNumberZeroThrowsException()
        {
            ArgumentException ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                SoccerPlayer player = new SoccerPlayer(0, "Wojciech Szczęsny", SoccerPosition.Goalkeeper);
            });

            Assert.AreEqual("Jersey number must be between 1 and 99!", ex.Message);
        }

        [TestMethod]
        public void TestJerseyNumberTooLargeThrowsException()
        {
            ArgumentException ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                SoccerPlayer player = new SoccerPlayer(100, "Łukasz Piszczek", SoccerPosition.Defender);
            });

            Assert.AreEqual("Jersey number must be between 1 and 99!", ex.Message);
        }

        [TestMethod]
        public void TestDifferentJerseyNumbersNotEqual()
        {
            SoccerPlayer playerRobert = new SoccerPlayer(9, "Robert Lewandowski", SoccerPosition.Forward);
            //Lewandowski's first number at Dortmund was 7.
            SoccerPlayer playerRobertOldNr = new SoccerPlayer(7, "Robert Lewandowski", SoccerPosition.Forward);
            SoccerPlayer playerKuba = new SoccerPlayer(16, "Jakub Błaszczykowski", SoccerPosition.Midfielder);
            SoccerPlayer playerLukasz = new SoccerPlayer(26, "Łukasz Piszczek", SoccerPosition.Defender);
            SoccerPlayer playerWojciech = new SoccerPlayer(1, "Wojciech Szczęsny", SoccerPosition.Goalkeeper);

            Assert.AreEqual(false, playerRobert.Equals(playerRobertOldNr));
            Assert.AreEqual(false, playerRobert.Equals(playerKuba));
            Assert.AreEqual(false, playerRobert.Equals(playerLukasz));
            Assert.AreEqual(false, playerRobert.Equals(playerWojciech));

            Assert.AreEqual(false, playerRobertOldNr.Equals(playerRobert));
            Assert.AreEqual(false, playerRobertOldNr.Equals(playerKuba));
            Assert.AreEqual(false, playerRobertOldNr.Equals(playerLukasz));
            Assert.AreEqual(false, playerRobertOldNr.Equals(playerWojciech));

            Assert.AreEqual(false, playerKuba.Equals(playerRobert));
            Assert.AreEqual(false, playerKuba.Equals(playerRobertOldNr));
            Assert.AreEqual(false, playerKuba.Equals(playerLukasz));
            Assert.AreEqual(false, playerKuba.Equals(playerWojciech));

            Assert.AreEqual(false, playerLukasz.Equals(playerRobert));
            Assert.AreEqual(false, playerLukasz.Equals(playerRobertOldNr));
            Assert.AreEqual(false, playerLukasz.Equals(playerKuba));
            Assert.AreEqual(false, playerLukasz.Equals(playerWojciech));

            Assert.AreEqual(false, playerWojciech.Equals(playerRobert));
            Assert.AreEqual(false, playerWojciech.Equals(playerRobertOldNr));
            Assert.AreEqual(false, playerWojciech.Equals(playerKuba));
            Assert.AreEqual(false, playerWojciech.Equals(playerLukasz));
        }

        [TestMethod]
        public void TestDifferentClassNotEqual()
        {
            SoccerPlayer playerKuba = new SoccerPlayer(16, "Jakub Błaszczykowski", SoccerPosition.Midfielder);

            Assert.AreEqual(false, playerKuba.Equals("Kubaaaa"));
            Assert.AreEqual(false, playerKuba.Equals(123));
            Assert.AreEqual(false, playerKuba.Equals(new Random()));
        }

        [TestMethod]
        public void TestNullNotEqual()
        {
            SoccerPlayer playerRobert = new SoccerPlayer(9, "Robert Lewandowski", SoccerPosition.Forward);

            Assert.AreEqual(false, playerRobert.Equals(null));
        }

        [TestMethod]
        public void TestEqualJerseyNumbersEqual()
        {
            SoccerPlayer playerZbigniewM = new SoccerPlayer(20, "Zbigniew Boniek", SoccerPosition.Midfielder);
            //Boniek also played as forward.
            SoccerPlayer playerZbigniewF = new SoccerPlayer(20, "Zbyszek Boniek", SoccerPosition.Forward);
            //Zbyszek is actually the short form of Zbigniew. Easy, right?
            SoccerPlayer playerZbyszek = new SoccerPlayer(20, "Zbyszek Boniek", SoccerPosition.Midfielder);

            Assert.AreEqual(true, playerZbigniewM.Equals(playerZbigniewM));
            Assert.AreEqual(true, playerZbigniewM.Equals(playerZbyszek));
            Assert.AreEqual(true, playerZbigniewM.Equals(playerZbigniewF));

            Assert.AreEqual(true, playerZbigniewF.Equals(playerZbigniewM));
            Assert.AreEqual(true, playerZbigniewF.Equals(playerZbyszek));
            Assert.AreEqual(true, playerZbigniewF.Equals(playerZbigniewF));

            Assert.AreEqual(true, playerZbyszek.Equals(playerZbigniewM));
            Assert.AreEqual(true, playerZbyszek.Equals(playerZbyszek));
            Assert.AreEqual(true, playerZbyszek.Equals(playerZbigniewF));
        }
    }
}
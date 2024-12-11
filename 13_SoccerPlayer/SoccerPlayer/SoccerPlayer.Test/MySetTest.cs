using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Soccer;

namespace MyGenericSet.Test
{
    [TestClass]
    public class MySetTest
    {
        [TestMethod]
        public void TestEmptyCorrectCountAndContains()
        {
            MySet<double> set = new MySet<double>();

            Assert.AreEqual(0, set.Count);
            Assert.AreEqual(false, set.Contains(1.23));
            Assert.AreEqual(false, set.Contains(4.5));
        }

        [TestMethod]
        public void TestAddOneElementCorrectCountAndContains()
        {
            MySet<string> set = new MySet<string>();

            set.Add("Lorem ipsum");

            Assert.AreEqual(1, set.Count);
            Assert.AreEqual(true, set.Contains("Lorem ipsum"));
            Assert.AreEqual(false, set.Contains("Dolor sit amet"));
        }

        [TestMethod]
        public void TestAddCorrectCountAndContains()
        {
            MySet<string> set = new MySet<string>();

            Assert.AreEqual(true, set.Add("SEW"));
            Assert.AreEqual(true, set.Add("AM"));
            Assert.AreEqual(true, set.Add("D"));
            Assert.AreEqual(true, set.Add("ITP"));
            Assert.AreEqual(true, set.Add("GGS"));

            Assert.AreEqual(5, set.Count);
            Assert.AreEqual(true, set.Contains("SEW"));
            Assert.AreEqual(true, set.Contains("AM"));
            Assert.AreEqual(true, set.Contains("D"));
            Assert.AreEqual(true, set.Contains("ITP"));
            Assert.AreEqual(true, set.Contains("GGS"));
            Assert.AreEqual(false, set.Contains("NWT"));
            Assert.AreEqual(false, set.Contains("SYT"));
            Assert.AreEqual(false, set.Contains("E"));
        }

        [TestMethod]
        public void TestAddDuplicatesCorrectCountAndContains()
        {
            MySet<SoccerPlayer> set = new MySet<SoccerPlayer>();

            SoccerPlayer playerZbigniewM = new SoccerPlayer(20, "Zbigniew Boniek", SoccerPosition.Midfielder);
            SoccerPlayer playerRobert = new SoccerPlayer(9, "Robert Lewandowski", SoccerPosition.Forward);
            SoccerPlayer playerKuba = new SoccerPlayer(16, "Jakub Błaszczykowski", SoccerPosition.Midfielder);
            SoccerPlayer playerZbigniewF = new SoccerPlayer(20, "Zbyszek Boniek", SoccerPosition.Forward);
            SoccerPlayer playerLukasz = new SoccerPlayer(26, "Łukasz Piszczek", SoccerPosition.Defender);
            SoccerPlayer playerWojciech = new SoccerPlayer(1, "Wojciech Szczęsny", SoccerPosition.Goalkeeper);
            SoccerPlayer playerZbyszek = new SoccerPlayer(20, "Zbyszek Boniek", SoccerPosition.Midfielder);

            Assert.AreEqual(true, set.Add(playerZbigniewM));
            Assert.AreEqual(true, set.Add(playerRobert));
            Assert.AreEqual(true, set.Add(playerKuba));
            Assert.AreEqual(false, set.Add(playerZbigniewF));
            Assert.AreEqual(true, set.Add(playerLukasz));
            Assert.AreEqual(false, set.Add(playerRobert));
            Assert.AreEqual(true, set.Add(playerWojciech));
            Assert.AreEqual(false, set.Add(playerZbyszek));
            Assert.AreEqual(false, set.Add(playerLukasz));

            Assert.AreEqual(5, set.Count);
            Assert.AreEqual(true, set.Contains(playerZbigniewM));
            Assert.AreEqual(true, set.Contains(playerRobert));
            Assert.AreEqual(true, set.Contains(playerKuba));
            Assert.AreEqual(true, set.Contains(playerZbigniewF));
            Assert.AreEqual(true, set.Contains(playerLukasz));
            Assert.AreEqual(true, set.Contains(playerWojciech));
            Assert.AreEqual(true, set.Contains(playerZbyszek));
        }

        [TestMethod]
        public void TestAddRemoveCorrectCountAndContains()
        {
            MySet<int> set = new MySet<int>();

            Assert.AreEqual(true, set.Add(1));
            Assert.AreEqual(true, set.Add(2));
            Assert.AreEqual(false, set.Add(1));
            Assert.AreEqual(true, set.Add(3));
            Assert.AreEqual(true, set.Add(4));
            Assert.AreEqual(true, set.Add(5));

            Assert.AreEqual(5, set.Count);
            Assert.AreEqual(true, set.Contains(1));
            Assert.AreEqual(true, set.Contains(2));
            Assert.AreEqual(true, set.Contains(3));
            Assert.AreEqual(true, set.Contains(4));
            Assert.AreEqual(true, set.Contains(5));
            Assert.AreEqual(false, set.Contains(6));
            Assert.AreEqual(false, set.Contains(7));
            Assert.AreEqual(false, set.Contains(8));
            Assert.AreEqual(false, set.Contains(9));

            Assert.AreEqual(true, set.Remove(2));
            Assert.AreEqual(true, set.Remove(4));
            Assert.AreEqual(false, set.Remove(6));
            Assert.AreEqual(false, set.Remove(8));

            Assert.AreEqual(3, set.Count);
            Assert.AreEqual(true, set.Contains(1));
            Assert.AreEqual(false, set.Contains(2));
            Assert.AreEqual(true, set.Contains(3));
            Assert.AreEqual(false, set.Contains(4));
            Assert.AreEqual(true, set.Contains(5));
            Assert.AreEqual(false, set.Contains(6));
            Assert.AreEqual(false, set.Contains(7));
            Assert.AreEqual(false, set.Contains(8));
            Assert.AreEqual(false, set.Contains(9));

            Assert.AreEqual(true, set.Add(7));
            Assert.AreEqual(false, set.Add(3));
            Assert.AreEqual(true, set.Add(9));
            Assert.AreEqual(false, set.Add(7));
            Assert.AreEqual(true, set.Add(2));

            Assert.AreEqual(6, set.Count);
            Assert.AreEqual(true, set.Contains(1));
            Assert.AreEqual(true, set.Contains(2));
            Assert.AreEqual(true, set.Contains(3));
            Assert.AreEqual(false, set.Contains(4));
            Assert.AreEqual(true, set.Contains(5));
            Assert.AreEqual(false, set.Contains(6));
            Assert.AreEqual(true, set.Contains(7));
            Assert.AreEqual(false, set.Contains(8));
            Assert.AreEqual(true, set.Contains(9));

            Assert.AreEqual(true, set.Remove(9));
            Assert.AreEqual(false, set.Remove(8));
            Assert.AreEqual(true, set.Remove(7));
            Assert.AreEqual(false, set.Remove(6));
            Assert.AreEqual(true, set.Remove(5));
            Assert.AreEqual(false, set.Remove(4));
            Assert.AreEqual(true, set.Remove(3));
            Assert.AreEqual(true, set.Remove(2));
            Assert.AreEqual(true, set.Remove(1));

            Assert.AreEqual(0, set.Count);
            Assert.AreEqual(false, set.Contains(1));
            Assert.AreEqual(false, set.Contains(2));
            Assert.AreEqual(false, set.Contains(3));
            Assert.AreEqual(false, set.Contains(4));
            Assert.AreEqual(false, set.Contains(5));
            Assert.AreEqual(false, set.Contains(6));
            Assert.AreEqual(false, set.Contains(7));
            Assert.AreEqual(false, set.Contains(8));
            Assert.AreEqual(false, set.Contains(9));

            Assert.AreEqual(true, set.Add(7));
            Assert.AreEqual(false, set.Add(7));

            Assert.AreEqual(1, set.Count);
            Assert.AreEqual(false, set.Contains(1));
            Assert.AreEqual(false, set.Contains(2));
            Assert.AreEqual(false, set.Contains(3));
            Assert.AreEqual(false, set.Contains(4));
            Assert.AreEqual(false, set.Contains(5));
            Assert.AreEqual(false, set.Contains(6));
            Assert.AreEqual(true, set.Contains(7));
            Assert.AreEqual(false, set.Contains(8));
            Assert.AreEqual(false, set.Contains(9));

            Assert.AreEqual(true, set.Remove(7));
            Assert.AreEqual(false, set.Remove(7));

            Assert.AreEqual(0, set.Count);
            Assert.AreEqual(false, set.Contains(1));
            Assert.AreEqual(false, set.Contains(2));
            Assert.AreEqual(false, set.Contains(3));
            Assert.AreEqual(false, set.Contains(4));
            Assert.AreEqual(false, set.Contains(5));
            Assert.AreEqual(false, set.Contains(6));
            Assert.AreEqual(false, set.Contains(7));
            Assert.AreEqual(false, set.Contains(8));
            Assert.AreEqual(false, set.Contains(9));

            Assert.AreEqual(false, set.Remove(5));
        }

        [TestMethod]
        public void TestIsSubset()
        {
            MySet<SoccerPlayer> teamEmpty = new MySet<SoccerPlayer>();
            MySet<SoccerPlayer> teamAllStars = new MySet<SoccerPlayer>();
            MySet<SoccerPlayer> teamDortmund = new MySet<SoccerPlayer>();

            SoccerPlayer playerRobert = new SoccerPlayer(9, "Robert Lewandowski", SoccerPosition.Forward);
            SoccerPlayer playerKamil = new SoccerPlayer(15, "Kamil Glik", SoccerPosition.Defender);
            SoccerPlayer playerKuba = new SoccerPlayer(16, "Jakub Błaszczykowski", SoccerPosition.Midfielder);
            SoccerPlayer playerLukasz = new SoccerPlayer(26, "Łukasz Piszczek", SoccerPosition.Defender);
            SoccerPlayer playerWojciech = new SoccerPlayer(1, "Wojciech Szczęsny", SoccerPosition.Goalkeeper);
            SoccerPlayer playerZbyszek = new SoccerPlayer(20, "Zbyszek Boniek", SoccerPosition.Midfielder);

            teamAllStars.Add(playerRobert);
            teamAllStars.Add(playerKamil);
            teamAllStars.Add(playerKuba);
            teamAllStars.Add(playerLukasz);
            teamAllStars.Add(playerWojciech);
            teamAllStars.Add(playerZbyszek);

            teamDortmund.Add(playerKuba);
            teamDortmund.Add(playerRobert);
            teamDortmund.Add(playerLukasz);

            Assert.AreEqual(true, teamEmpty.IsSubsetOf(teamEmpty));
            Assert.AreEqual(true, teamEmpty.IsSubsetOf(teamAllStars));
            Assert.AreEqual(true, teamEmpty.IsSubsetOf(teamDortmund));

            Assert.AreEqual(false, teamDortmund.IsSubsetOf(teamEmpty));
            Assert.AreEqual(true, teamDortmund.IsSubsetOf(teamAllStars));
            Assert.AreEqual(true, teamDortmund.IsSubsetOf(teamDortmund));

            Assert.AreEqual(false, teamAllStars.IsSubsetOf(teamEmpty));
            Assert.AreEqual(true, teamAllStars.IsSubsetOf(teamAllStars));
            Assert.AreEqual(false, teamAllStars.IsSubsetOf(teamDortmund));
        }

        [TestMethod]
        public void TestIsSuperset()
        {
            MySet<char> alphabetEmpty = new MySet<char>();
            MySet<char> alphabetComplete = new MySet<char>();
            MySet<char> alphabetVowels = new MySet<char>();

            char letter = 'a';
            for (int i = 0; i < 26; i++)
            {
                alphabetComplete.Add((char)(letter + i));
            }

            alphabetVowels.Add('a');
            alphabetVowels.Add('e');
            alphabetVowels.Add('i');
            alphabetVowels.Add('o');
            alphabetVowels.Add('u');
            alphabetVowels.Add('y');

            Assert.AreEqual(true, alphabetEmpty.IsSupersetOf(alphabetEmpty));
            Assert.AreEqual(false, alphabetEmpty.IsSupersetOf(alphabetComplete));
            Assert.AreEqual(false, alphabetEmpty.IsSupersetOf(alphabetVowels));

            Assert.AreEqual(true, alphabetVowels.IsSupersetOf(alphabetEmpty));
            Assert.AreEqual(false, alphabetVowels.IsSupersetOf(alphabetComplete));
            Assert.AreEqual(true, alphabetVowels.IsSupersetOf(alphabetVowels));

            Assert.AreEqual(true, alphabetComplete.IsSupersetOf(alphabetEmpty));
            Assert.AreEqual(true, alphabetComplete.IsSupersetOf(alphabetComplete));
            Assert.AreEqual(true, alphabetComplete.IsSupersetOf(alphabetVowels));
        }
    }
}

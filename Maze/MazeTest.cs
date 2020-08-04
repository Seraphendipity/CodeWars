using NUnit.Framework;
namespace Maze {

public class SolutionTest
{
    [Test]
    public void sampleTest_01()
    {

        string a = ".W.\n" +
                   ".W.\n" +
                   "...";
        Assert.AreEqual(true, Finder.PathFinder(a));
    }

    [Test]
    public void sampleTest_02()
    {
        string   b = ".W.\n" +
                ".W.\n" +
                "W..";
        Assert.AreEqual(false, Finder.PathFinder(b));
    }

    [Test]
    public void sampleTest_03()
    {
        string  c = "......\n" +
            "......\n" +
            "......\n" +
            "......\n" +
            "......\n" +
            "......";
        Assert.AreEqual(true, Finder.PathFinder(c));
    }

    [Test]
    public void sampleTest_04()
    {
        string d = "......\n" +
            "......\n" +
            "......\n" +
            "......\n" +
            ".....W\n" +
            "....W.";
        Assert.AreEqual(false, Finder.PathFinder(d));
    }
}

}
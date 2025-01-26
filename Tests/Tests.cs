using NUnit.Framework;
using Solutions;

namespace Tests;

[TestFixture]
public class Tests
{
    [Test]
    [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }, ExpectedResult = "(123) 456-7890")]
    [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, ExpectedResult = "(111) 111-1111")]
    public static string TestCreatePhoneNumber(int[] numbers)
    {
        return Kata.CreatePhoneNumber(numbers);
    }

    private static IEnumerable<TestCaseData> TestCasesForNarcissistic
    {
        get
        {
            yield return new TestCaseData(1)
                .Returns(true)
                .SetDescription("1 is narcissitic");
            yield return new TestCaseData(371)
                .Returns(true)
                .SetDescription("371 is narcissitic");
        }
    }

    [Test, TestCaseSource(nameof(TestCasesForNarcissistic))]
    public bool TestNarcissistic(int n) => Kata.Narcissistic(n);

    [Test]
    public void TestGetVowelCount()
    {
        Assert.That(Kata.GetVowelCount("abracadabra"), Is.EqualTo(5), "Incorrect answer for str = \"abracadabra\"");
    }

    [Test]
    public void TestToCamelCase()
    {
        Assert.That(Kata.ToCamelCase("the_stealth_warrior"), Is.EqualTo("theStealthWarrior"),
            "Kata.ToCamelCase('the_stealth_warrior') did not return correct value");
        Assert.That(Kata.ToCamelCase("The-Stealth-Warrior"), Is.EqualTo("TheStealthWarrior"),
            "Kata.ToCamelCase('The-Stealth-Warrior') did not return correct value");
    }

    [Test]
    public void TestSumOfMultiples3Or5()
    {
        AssertionForSumOfMultiples3Or5(expected: 23, input: 10);
        AssertionForSumOfMultiples3Or5(expected: 78, input: 20);
        AssertionForSumOfMultiples3Or5(expected: 9168, input: 200);
        AssertionForSumOfMultiples3Or5(expected: 0, input: 0);
    }

    private static void AssertionForSumOfMultiples3Or5(int expected, int input) =>
        Assert.That(
            Kata.SumOfMultiples3Or5(input),
            Is.EqualTo(expected),
            $"Incorrect answer for input={input}"
        );

    private void TestGetReadableTime(int seconds, String expected)
    {
        String actual = Kata.GetReadableTime(seconds);
        Assert.That(actual, Is.EqualTo(expected), "for " + seconds + " seconds");
    }

    [Test]
    public void Tests4GetReadableTime()
    {
        TestGetReadableTime(0, "00:00:00");
        TestGetReadableTime(59, "00:00:59");
        TestGetReadableTime(60, "00:01:00");
        TestGetReadableTime(90, "00:01:30");
        TestGetReadableTime(3599, "00:59:59");
        TestGetReadableTime(3600, "01:00:00");
        TestGetReadableTime(45296, "12:34:56");
        TestGetReadableTime(86399, "23:59:59");
        TestGetReadableTime(86400, "24:00:00");
        TestGetReadableTime(359999, "99:59:59");
    }

    [Test]
    public void TestDuplicateEncode()
    {
        Assert.That(Kata.DuplicateEncode("din"), Is.EqualTo("((("));
        Assert.That(Kata.DuplicateEncode("recede"), Is.EqualTo("()()()"));
        Assert.That(Kata.DuplicateEncode("Success"), Is.EqualTo(")())())"), "should ignore case");
        Assert.That(Kata.DuplicateEncode("(( @"), Is.EqualTo("))(("));
    }
    
    [Test]
    public void TestfindNb()
    {
        Assert.That(Kata.findNb(36), Is.EqualTo(3));
        Assert.That(Kata.findNb(4183059834009), Is.EqualTo(2022));
        Assert.That(Kata.findNb(24723578342962), Is.EqualTo(-1));
        Assert.That(Kata.findNb(135440716410000), Is.EqualTo(4824));
        Assert.That(Kata.findNb(40539911473216), Is.EqualTo(3568));
    }
    
    [Test]
    public void TestFindMissingLetter()
    {
        Assert.That(Kata.FindMissingLetter(new [] { 'a','b','c','d','f' }), Is.EqualTo('e'));
        Assert.That(Kata.FindMissingLetter(new [] { 'O','Q','R','S' }), Is.EqualTo('P'));
    }
    
    [Test]
    public void TestMoveZeroes()
    {
        int[] expected = new int[] {1, 2, 1, 1, 3, 1, 0, 0, 0, 0};
        Assert.That(Kata.MoveZeroes(new int[] {1, 2, 0, 1, 0, 1, 0, 3, 0, 1}), Is.EqualTo(expected));
    }
    
    [Test]
    public void TestMoveZeroesInPlace()
    {
        int[] expected = new int[] {1, 2, 1, 1, 3, 1, 0, 0, 0, 0};
        Assert.That(Kata.MoveZeroesInPlace(new int[] {1, 2, 0, 1, 0, 1, 0, 3, 0, 1}), Is.EqualTo(expected));
    }
    
    [Test, Description("It should return correct text")]
    public void TestLikes()
    {
        Assert.That(Kata.Likes(new string[0]), Is.EqualTo("no one likes this"));
        Assert.That(Kata.Likes(new string[] {"Peter"}), Is.EqualTo("Peter likes this"));
        Assert.That(Kata.Likes(new string[] {"Jacob", "Alex"}), Is.EqualTo("Jacob and Alex like this"));
        Assert.That(Kata.Likes(new string[] {"Max", "John", "Mark"}), Is.EqualTo("Max, John and Mark like this"));
        Assert.That(Kata.Likes(new string[] {"Alex", "Jacob", "Mark", "Max"}), Is.EqualTo("Alex, Jacob and 2 others like this"));
    }
    
    [Test]
    public void TestRot13()
    {
        var actualOutput = Kata.Rot13("test");
        Assert.That(actualOutput, Is.EqualTo("grfg"), String.Format("Input: test, Expected Output: grfg, Actual Output: {0}", actualOutput));
        
        actualOutput = Kata.Rot13("Test");
        Assert.That(actualOutput, Is.EqualTo("Grfg"), String.Format("Input: Test, Expected Output: Grfg, Actual Output: {0}", actualOutput));
    }
    
    [Test]
    public void MyTest()
    {
        int[,] expected = new int[,]{{1,2,3},{2,4,6},{3,6,9}};
        Assert.That(Kata.MultiplicationTable(3), Is.EqualTo(expected));
    }
    
    
}
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
        Assert.That(Kata.ToCamelCase("the_stealth_warrior"), Is.EqualTo("theStealthWarrior"), "Kata.ToCamelCase('the_stealth_warrior') did not return correct value");
        Assert.That(Kata.ToCamelCase("The-Stealth-Warrior"), Is.EqualTo("TheStealthWarrior"), "Kata.ToCamelCase('The-Stealth-Warrior') did not return correct value");
    }
    
    [Test]
    public void TestSumOfMultiples3Or5()
    {
        AssertionForSumOfMultiples3Or5(expected : 23, input : 10);
        AssertionForSumOfMultiples3Or5(expected : 78, input : 20);
        AssertionForSumOfMultiples3Or5(expected : 9168, input : 200);
        AssertionForSumOfMultiples3Or5(expected : 0, input : 0);
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
        TestGetReadableTime(     0, "00:00:00");
        TestGetReadableTime(    59, "00:00:59");
        TestGetReadableTime(    60, "00:01:00");
        TestGetReadableTime(    90, "00:01:30");
        TestGetReadableTime(  3599, "00:59:59");
        TestGetReadableTime(  3600, "01:00:00");
        TestGetReadableTime( 45296, "12:34:56");
        TestGetReadableTime( 86399, "23:59:59");
        TestGetReadableTime( 86400, "24:00:00");
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
}
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
}
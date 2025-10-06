namespace Code.Katas.Arrays.Spike;

public class Tests
{
    [Test]
    [TestCase(new int[0])]
    [TestCase(new int[] { 1 })]
    public void ReturnsEmpty_WhenGivenShortArray(int[] values)
    {
        // arrange
        var expected = new int[0];

        // act
        var result = Solution.Execute(values);

        // assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void ReturnsSpike_WhenGivenArrayWithSpike()
    {
        // arrange
        var values   = new int[] { 1, 2, 3, 4, 5, 4, 3, 2, 1 };
        var expected = new int[] { 1, 2, 3, 4, 5, 4, 3, 2, 1 };

        // act
        var result = Solution.Execute(values);
        // assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void ReturnsSpike_WhenGivenArrayWithSpikeAndManyDuplicateValues()
    {
        // arrange
        var values = new int[] { 1, 13, 8, 4, 1, 7, 5, 8, 1, 3, 1, 9, 12 };
        var expected = new int[] { 1, 3, 5, 8, 9, 13, 12, 8, 7, 4, 1};

        // act
        var result = Solution.Execute(values);
        // assert
        Assert.That(result, Is.EqualTo(expected));
    }
}

namespace cSharpBird.Test;

public class cSharpBirdTest
{
    [Theory]
    [InlineData("invalid@address")]
    [InlineData("whoopsnoat.com")]
    [InlineData("I'mJustAString")]
    [InlineData("maylookgood@butnotreally.com.")]
    public void ValidEmail_False(string testString)
    {
        bool result = UserController.ValidEmail(testString);

        Assert.False(result);
    }
    [Theory]
    [InlineData("valid@address.com")]
    [InlineData("symbols+go@testme.com")]
    [InlineData("whatabout@sub.domain.com")]
    public void ValidEmail_True(string testString)
    {
        bool result = UserController.ValidEmail(testString);

        Assert.True(result);
    }
}
namespace OldPhonePadTest;

public class UnitTest
{
    [Theory]
    [InlineData("E", "33#")]
    [InlineData("B", "227*#")]
    [InlineData("HELLO", "4433555 555666#")]
    [InlineData("TURING", "8 88777444666*664#")]
    [InlineData("GOODBYE", "4666 66632299933#")]
    [InlineData("", "#")]
    [InlineData("", "4*#")]
    [InlineData("", "*#")]
    [InlineData("'(&('", "11 111 1 111 11#")]
    [InlineData("", "**#")]
    [InlineData("A", "*2*2#")]
    [InlineData("Z", "9999##")]
    [InlineData(" ", "0#")]
    [InlineData("HELLO THERE", "4433555 55566608443377733#")]
    public void TestOldPhonePad(string outputSent, string inputSeq)
    {
        Assert.Equal(outputSent, IronSW.OldPhonePadTranslator.OldPhonePad(inputSeq));
    }
}

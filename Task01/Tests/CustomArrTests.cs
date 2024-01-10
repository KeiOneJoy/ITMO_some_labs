using ITMO_labs_task1;
namespace Tests
{
    public class CustomArrTests
    {
        [Fact]
        public void Constructor_WithPositiveLength_CreatesArray()
        {
            var customArr = new Custom_arr(5);
            Assert.Equal(5, customArr.Array.Length);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Constructor_WithNonPositiveLength_ThrowsException(int length)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Custom_arr(length));
        }

    }
}
using ITMO_labs_task1;
namespace Tests
{
    public class CustomArrTests
    {
        [Fact]
        public void Constructor_InvalidLength_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Custom_arr(-1));
        }

        [Fact]
        public void GetMaxElement_EmptyArray_ThrowsInvalidOperationException()
        {
            var arr = new Custom_arr(0);
            Assert.Throws<InvalidOperationException>(() => arr.GetMaxElement());
        }

    }
}
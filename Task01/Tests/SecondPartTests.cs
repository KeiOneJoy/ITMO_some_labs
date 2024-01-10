using ITMO_labs_task1;

namespace Tests
{
    public class SecondPartTests
    {
        [Fact]
        public void Constructor_NegativeSize_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new SecondPart(-1));
        }


    }
}

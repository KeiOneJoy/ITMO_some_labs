
using ITMO_labs_task1;

namespace Tests
{

    public class SecondPartTests
    {
        [Fact]
        public void Constructor_WithPositiveSize_CreatesMatrix()
        {
            var secondPart = new SecondPart(3);
            Assert.Equal(3, secondPart.Matrix.GetLength(0));
            Assert.Equal(3, secondPart.Matrix.GetLength(1));
        }

        [Theory]
        [InlineData(-1)]
        public void Constructor_WithNegativeSize_ThrowsException(int size)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new SecondPart(size));
        }
    }

using System;
using Xunit;

namespace Booking.Domain.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

        }

        [Theory]
        [InlineData(2)]
        public void Test(int a)
        {
            Assert.Equal(a, 2);
        }
            
            
            
            
    }
}

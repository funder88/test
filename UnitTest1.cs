using Xunit;
using Square;

namespace Square.Tests
{
    public class SquareClassTests
    {
        //1 ����� Init ������ ������������� ���������� ��������.
        [Fact]
        public void Init_ShouldSetCorrectValues()
        {
            var square = new SquareClass();
            square.Init(1.0, 2.0, 3.0);
            Assert.Equal(1.0, square.GetX());
            Assert.Equal(2.0, square.GetY());
            Assert.Equal(3.0, square.GetS());
        }
        //2 ����� Init ������ ��������� �������������� ���������� ��������.
        [Fact]
        public void Init_ShouldOverridePreviousValues()
        {
            var square = new SquareClass();
            square.Init(1.0, 2.0, 3.0);
            square.Init(14.5, 21.4, 17.2);
            Assert.Equal(14.5, square.GetX());
            Assert.Equal(21.4, square.GetY());
            Assert.Equal(17.2, square.GetS());
        }
        //3 ����� GetX ������ ���������� ���������� X.
        [Fact]
        public void GetX_ShouldReturnX()
        {
            var square = new SquareClass();
            square.Init(52.3, 0.0, 1.0);
            Assert.Equal(52.3, square.GetX());
        }

        //4 ����� GetY ������ ���������� ���������� Y.
        [Fact]
        public void GetY_ShouldReturnY()
        {
            var square = new SquareClass();
            square.Init(0.0, -9.8, 1.0);
            Assert.Equal(-9.8, square.GetY());
        }

        //5 ����� GetS ������ ���������� ����� ������� ��������.
        [Fact]
        public void GetS_ShouldReturnSideLength()
        {
            var square = new SquareClass();
            square.Init(0.0, 0.0, 2.78);
            Assert.Equal(2.78, square.GetS());
        }
        //6 ���������� �� ������ ��������� ������ ���� 0, ���� ������� � ������ ���������.
        [Fact]
        public void DistanceFromOrigin_AtOrigin_ReturnsZero()
        {
            var square = new SquareClass();
            square.Init(0.0, 0.0, 1.0);
            Assert.Equal(0.0, square.DistanceFromOrigin());
        }
        //7 ���������� �� ������ ��������� ������ ��������� ���������.
        [Fact]
        public void DistanceFromOrigin_NonZeroCoordinates_ReturnsCorrect()
        {
            var square = new SquareClass();
            square.Init(3.0, 4.0, 1.0);
            Assert.Equal(5.0, square.DistanceFromOrigin());
        }
        //8 ����� Add ������ ������� ����� ������� � ����������� ������������ � ��������.
        [Fact]
        public void Add_TwoSquares_ReturnsAveragedSquare()
        {
            var square1 = new SquareClass();
            var square2 = new SquareClass();
            square1.Init(2.0, 4.0, 6.0);
            square2.Init(4.0, 6.0, 8.0);
            var result = square1.Add(square1, square2);
            Assert.Equal(3.0, result.GetX());
            Assert.Equal(5.0, result.GetY());
            Assert.Equal(7.0, result.GetS());
        }
        //9 ����� Add ������ ���������� ����� ���������, � �� �������� ������������.
        [Fact]
        public void Add_ReturnsNewInstance()
        {
            var square = new SquareClass();
            square.Init(1.0, 2.0, 3.0);
            var result = square.Add(square, square);
            Assert.NotSame(square, result);
        }
        //10 ����� Add �� ������ �������� �������� ��������.
        [Fact]
        public void Add_DoesNotModifyOriginalSquares()
        {
            var square1 = new SquareClass();
            var square2 = new SquareClass();
            square1.Init(1.0, 1.0, 1.0);
            square2.Init(2.0, 2.0, 2.0);
            var result = square1.Add(square1, square2);
            Assert.Equal(1.0, square1.GetX());
            Assert.Equal(1.0, square1.GetY());
            Assert.Equal(1.0, square1.GetS());
            Assert.Equal(2.0, square2.GetX());
            Assert.Equal(2.0, square2.GetY());
            Assert.Equal(2.0, square2.GetS());
        }
    }
}

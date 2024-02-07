using ShapeLibrary;

namespace Tests
{
    [TestClass]
    public class UnitTest
    {
        [TestClass]
        public class ShapeTests
        {
            [TestMethod]
            public void TestCircleArea()
            {
                var radius = 5;
                var circle = new Shape(radius);

                var result = circle.GetArea();

                Assert.AreEqual(Math.PI * radius * radius, result, 0.0001);
            }

            [TestMethod]
            public void TestTriangleArea()
            {
                var a = 3;
                var b = 4;
                var c = 5;
                var triangle = new Shape(a, b, c);

                var s = (a + b + c) / 2;
                var result = Math.Sqrt(s * (s - a) * (s - b) * (s - c));

                Assert.AreEqual(result, triangle.GetArea(), 0.0001);
            }

            [TestMethod]
            public void TestIsRectangular()
            {
                var triangle = new Shape(3, 4, 5);

                bool result = triangle.IsRectangular();

                Assert.IsTrue(result);
            }

            [TestMethod]
            public void TestIsNotRectangular()
            {
                var triangle = new Shape(3, 4, 6);

                bool result = triangle.IsRectangular();

                Assert.IsFalse(result);
            }

            [TestMethod]
            public void Test_IsNotRectangular_InvalidOperationException_ShapeIsNotRectangular()
            {
                int[] dimensions = new int[] { 1 };

                var shape = new Shape(dimensions);

                Assert.ThrowsException<InvalidOperationException>(() => shape.IsRectangular());
            }

            [TestMethod]
            public void Test_ArgumentException_DimensionsIsEmpty()
            {
                int[] dimensions = Array.Empty<int>();

                Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Shape(dimensions));
            }

            [TestMethod]
            public void Test_ArgumentException_DimensionsLengthIsNotSupported()
            {
                int[] dimensions = new int[2];

                Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Shape(dimensions));
            }

            [TestMethod]
            public void Test_ArgumentOutOfRangeException_RadiusIsZero()
            {
                int[] dimensions = new int[] { 0 };


                Assert.ThrowsException<ArgumentException>(() => new Shape(dimensions));
            }

            [TestMethod]
            public void Test_ArgumentOutOfRangeException_RadiusIsNegative()
            {
                int[] dimensions = new int[] { -1 };


                Assert.ThrowsException<ArgumentException>(() => new Shape(dimensions));
            }

            [TestMethod]
            public void Test_ArgumentException_TriangleSidesDoNotFormValidTriangle()
            {
                int[] dimensions = new int[] { 1, 1, 3 };


                Assert.ThrowsException<ArgumentException>(() => new Shape(dimensions));
            }
        }
    }
}
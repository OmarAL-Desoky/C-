using System;

namespace Circle
{
    class Program
    {
        //Set this to true to stop the program on errors:
        private static bool stopOnError = false;

        private static bool containsErrors = false;

        static void Main(string[] args)
        {
            Console.WriteLine("=== Testing constructors with valid values. ===");
            TestConstructorValidValues();
            Console.WriteLine("=== Testing constructors with invalid X. ===");
            TestConstructorInvalidX();
            Console.WriteLine("=== Testing constructors with invalid Y. ===");
            TestConstructorInvalidY();
            Console.WriteLine("=== Testing constructors with invalid radius. ===");
            TestConstructorInvalidRadius();
            Console.WriteLine("=== Testing constructors with invalid color. ===");
            TestConstructorInvalidColor();
            Console.WriteLine("=== Testing constructors with invalid values. ===");
            TestConstructorInvalidValues();
            Console.WriteLine("=== Testing color-setter. ===");
            TestSetterColor();
            Console.WriteLine("=== Testing radius-setter. ===");
            TestSetterRadius();
            Console.WriteLine("=== Testing area. ===");
            TestArea();
            Console.WriteLine("=== Testing circumference. ===");
            TestCircumference();
            Console.WriteLine("=== Testing distance calculation. ===");
            TestCalculateDistanceTo();
            Console.WriteLine("=== Testing is-bigger-than. ===");
            TestIsBiggerThan();
            Console.WriteLine("=== Testing overlap. ===");
            TestIsOverlapping();
            Console.WriteLine("=== Testing moving. ===");
            TestMoving();
            Console.WriteLine("=== Testing distance calculation after move. ===");
            TestCalculateDistanceToAfterMoving();
            Console.WriteLine("=== Testing overlap after resizing and moving. ===");
            TestIsOverlappingAfterResizeAndMove();

            Console.WriteLine();

            if (!containsErrors)
            {
                Console.WriteLine("Good job! :)");
            }
            else
            {
                Console.WriteLine("There are still errors in your solution. :(");
            }
        }

        private static void TestConstructorValidValues()
        {
            Circle circle = new Circle();
            AssertEquals(0, circle.X);
            AssertEquals(0, circle.Y);
            AssertEquals(1.0, circle.Radius, 0.001);
            AssertEquals("blue", circle.Color);

            circle = new Circle(3, 5, 4.5);
            AssertEquals(3, circle.X);
            AssertEquals(5, circle.Y);
            AssertEquals(4.5, circle.Radius, 0.001);
            AssertEquals("blue", circle.Color);

            circle = new Circle(100, 300, 50.0, "white");
            AssertEquals(100, circle.X);
            AssertEquals(300, circle.Y);
            AssertEquals(50.0, circle.Radius, 0.001);
            AssertEquals("white", circle.Color);
        }

        private static void TestConstructorInvalidX()
        {
            Circle circle = new Circle(-1, 5, 4.5);
            AssertEquals(0, circle.X);
            AssertEquals(5, circle.Y);
            AssertEquals(4.5, circle.Radius, 0.001);
            AssertEquals("blue", circle.Color);

            circle = new Circle(-100, 300, 50.0, "white");
            AssertEquals(0, circle.X);
            AssertEquals(300, circle.Y);
            AssertEquals(50.0, circle.Radius, 0.001);
            AssertEquals("white", circle.Color);
        }

        private static void TestConstructorInvalidY()
        {
            Circle circle = new Circle(3, -50, 4.5);
            AssertEquals(3, circle.X);
            AssertEquals(0, circle.Y);
            AssertEquals(4.5, circle.Radius, 0.001);
            AssertEquals("blue", circle.Color);

            circle = new Circle(100, -3, 50.0, "white");
            AssertEquals(100, circle.X);
            AssertEquals(0, circle.Y);
            AssertEquals(50.0, circle.Radius, 0.001);
            AssertEquals("white", circle.Color);
        }

        private static void TestConstructorInvalidRadius()
        {
            Circle circle = new Circle(3, 5, -0.1);
            AssertEquals(3, circle.X);
            AssertEquals(5, circle.Y);
            AssertEquals(1.0, circle.Radius, 0.001);
            AssertEquals("blue", circle.Color);

            circle = new Circle(100, 300, 0.95, "white");
            AssertEquals(100, circle.X);
            AssertEquals(300, circle.Y);
            AssertEquals(1.0, circle.Radius, 0.001);
            AssertEquals("white", circle.Color);
        }

        private static void TestConstructorInvalidColor()
        {
            Circle circle = new Circle(100, 300, 50.0, "");
            AssertEquals(100, circle.X);
            AssertEquals(300, circle.Y);
            AssertEquals(50.0, circle.Radius, 0.001);
            AssertEquals("blue", circle.Color);
        }

        private static void TestConstructorInvalidValues()
        {
            Circle circle = new Circle(-1000, -1, -50.0);
            AssertEquals(0, circle.X);
            AssertEquals(0, circle.Y);
            AssertEquals(1.0, circle.Radius, 0.001);
            AssertEquals("blue", circle.Color);

            circle = new Circle(-2, -99, 0.0, "");
            AssertEquals(0, circle.X);
            AssertEquals(0, circle.Y);
            AssertEquals(1.0, circle.Radius, 0.001);
            AssertEquals("blue", circle.Color);
        }

        private static void TestSetterColor()
        {
            Circle circle = new Circle(100, 300, 50.0, "white");
            AssertEquals(100, circle.X);
            AssertEquals(300, circle.Y);
            AssertEquals(50.0, circle.Radius, 0.001);
            AssertEquals("white", circle.Color);

            circle.Color = "red";

            AssertEquals(100, circle.X);
            AssertEquals(300, circle.Y);
            AssertEquals(50.0, circle.Radius, 0.001);
            AssertEquals("red", circle.Color);

            circle.Color = "";

            AssertEquals(100, circle.X);
            AssertEquals(300, circle.Y);
            AssertEquals(50.0, circle.Radius, 0.001);
            AssertEquals("blue", circle.Color);

            circle.Color = "gold";

            AssertEquals(100, circle.X);
            AssertEquals(300, circle.Y);
            AssertEquals(50.0, circle.Radius, 0.001);
            AssertEquals("gold", circle.Color);

            circle.Color = "blue";

            AssertEquals(100, circle.X);
            AssertEquals(300, circle.Y);
            AssertEquals(50.0, circle.Radius, 0.001);
            AssertEquals("blue", circle.Color);
        }

        private static void TestSetterRadius()
        {
            Circle circle = new Circle(3, 5, 4.5);
            AssertEquals(3, circle.X);
            AssertEquals(5, circle.Y);
            AssertEquals(4.5, circle.Radius, 0.001);
            AssertEquals("blue", circle.Color);

            circle.Radius = 0.9;

            AssertEquals(3, circle.X);
            AssertEquals(5, circle.Y);
            AssertEquals(1.0, circle.Radius, 0.001);
            AssertEquals("blue", circle.Color);

            circle.Radius = 1234.5;

            AssertEquals(3, circle.X);
            AssertEquals(5, circle.Y);
            AssertEquals(1234.5, circle.Radius, 0.001);
            AssertEquals("blue", circle.Color);

            circle.Radius = -100;

            AssertEquals(3, circle.X);
            AssertEquals(5, circle.Y);
            AssertEquals(1.0, circle.Radius, 0.001);
            AssertEquals("blue", circle.Color);
        }

        private static void TestArea()
        {
            Circle circle = new Circle(3, 5, 4.5);

            AssertEquals(63.62, circle.Area, 0.01);

            circle.Radius = 10.0;

            AssertEquals(314.16, circle.Area, 0.01);

            circle.Radius = 123.0;

            AssertEquals(47529.15, circle.Area, 0.01);

            circle.Radius = 0.77;

            AssertEquals(3.14, circle.Area, 0.01);
        }

        private static void TestCircumference()
        {
            Circle circle = new Circle(50, 40, 70, "red");

            AssertEquals(439.82, circle.Circumference, 0.01);

            circle.Radius = 1.5;

            AssertEquals(9.42, circle.Circumference, 0.01);

            circle.Radius = 42.0;

            AssertEquals(263.89, circle.Circumference, 0.01);
        }

        private static void TestCalculateDistanceTo()
        {
            Circle circleA = new Circle(10, 10, 5);
            Circle circleB = new Circle(20, 20, 10);
            Circle circleC = new Circle(20, 40, 7);
            Circle circleD = new Circle(10, 10, 10);

            AssertEquals(14.14, circleA.CalculateDistanceTo(circleB), 0.01);
            AssertEquals(31.62, circleA.CalculateDistanceTo(circleC), 0.01);
            AssertEquals(0.0, circleA.CalculateDistanceTo(circleD), 0.01);

            AssertEquals(14.14, circleB.CalculateDistanceTo(circleA), 0.01);
            AssertEquals(20, circleB.CalculateDistanceTo(circleC), 0.01);
            AssertEquals(14.14, circleB.CalculateDistanceTo(circleD), 0.01);

            AssertEquals(31.62, circleC.CalculateDistanceTo(circleA), 0.01);
            AssertEquals(20, circleC.CalculateDistanceTo(circleB), 0.01);
            AssertEquals(31.62, circleC.CalculateDistanceTo(circleD), 0.01);

            AssertEquals(0, circleD.CalculateDistanceTo(circleA), 0.01);
            AssertEquals(14.14, circleD.CalculateDistanceTo(circleB), 0.01);
            AssertEquals(0.0, circleD.CalculateDistanceTo(circleD), 0.01);
        }

        private static void TestIsBiggerThan()
        {
            Circle circleA = new Circle(10, 10, 5);
            Circle circleB = new Circle(20, 20, 10);
            Circle circleC = new Circle(20, 40, 7);
            Circle circleD = new Circle(10, 10, 11);

            AssertEquals(false, circleA.IsBiggerThan(circleB));
            AssertEquals(false, circleA.IsBiggerThan(circleC));
            AssertEquals(false, circleA.IsBiggerThan(circleD));

            AssertEquals(true, circleB.IsBiggerThan(circleA));
            AssertEquals(true, circleB.IsBiggerThan(circleC));
            AssertEquals(false, circleB.IsBiggerThan(circleD));

            AssertEquals(true, circleC.IsBiggerThan(circleA));
            AssertEquals(false, circleC.IsBiggerThan(circleB));
            AssertEquals(false, circleC.IsBiggerThan(circleD));

            AssertEquals(true, circleD.IsBiggerThan(circleA));
            AssertEquals(true, circleD.IsBiggerThan(circleB));
            AssertEquals(true, circleD.IsBiggerThan(circleC));
        }

        private static void TestIsOverlapping()
        {
            Circle circleA = new Circle(10, 10, 7.5);
            Circle circleB = new Circle(20, 10, 3.5);
            Circle circleC = new Circle(20, 42, 28);
            Circle circleD = new Circle(10, 10, 1.0);
            Circle circleE = new Circle(40, 40, 7.0);
            Circle circleF = new Circle(100, 200, 500);

            AssertEquals(true, circleA.IsOverlapping(circleB));
            AssertEquals(true, circleA.IsOverlapping(circleC));
            AssertEquals(true, circleA.IsOverlapping(circleD));
            AssertEquals(false, circleA.IsOverlapping(circleE));
            AssertEquals(true, circleA.IsOverlapping(circleF));

            AssertEquals(true, circleB.IsOverlapping(circleA));
            AssertEquals(false, circleB.IsOverlapping(circleC));
            AssertEquals(false, circleB.IsOverlapping(circleD));
            AssertEquals(false, circleB.IsOverlapping(circleE));
            AssertEquals(true, circleB.IsOverlapping(circleF));

            AssertEquals(true, circleC.IsOverlapping(circleA));
            AssertEquals(false, circleC.IsOverlapping(circleB));
            AssertEquals(false, circleC.IsOverlapping(circleD));
            AssertEquals(true, circleC.IsOverlapping(circleE));
            AssertEquals(true, circleC.IsOverlapping(circleF));

            AssertEquals(true, circleD.IsOverlapping(circleA));
            AssertEquals(false, circleD.IsOverlapping(circleB));
            AssertEquals(false, circleD.IsOverlapping(circleC));
            AssertEquals(false, circleD.IsOverlapping(circleE));
            AssertEquals(true, circleD.IsOverlapping(circleF));

            AssertEquals(false, circleE.IsOverlapping(circleA));
            AssertEquals(false, circleE.IsOverlapping(circleB));
            AssertEquals(true, circleE.IsOverlapping(circleC));
            AssertEquals(false, circleE.IsOverlapping(circleD));
            AssertEquals(true, circleE.IsOverlapping(circleF));

            AssertEquals(true, circleF.IsOverlapping(circleA));
            AssertEquals(true, circleF.IsOverlapping(circleB));
            AssertEquals(true, circleF.IsOverlapping(circleC));
            AssertEquals(true, circleF.IsOverlapping(circleD));
            AssertEquals(true, circleF.IsOverlapping(circleE));
        }

        private static void TestMoving()
        {
            Circle circle = new Circle(100, 300, 50.0, "white");
            AssertEquals(100, circle.X);
            AssertEquals(300, circle.Y);
            AssertEquals(50.0, circle.Radius, 0.001);
            AssertEquals("white", circle.Color);

            bool isSuccessful = circle.MoveTo(200, 400);
            AssertEquals(true, isSuccessful);

            AssertEquals(200, circle.X);
            AssertEquals(400, circle.Y);
            AssertEquals(50.0, circle.Radius, 0.001);
            AssertEquals("white", circle.Color);

            isSuccessful = circle.MoveTo(-1, 350);
            AssertEquals(false, isSuccessful);

            AssertEquals(200, circle.X);
            AssertEquals(400, circle.Y);
            AssertEquals(50.0, circle.Radius, 0.001);
            AssertEquals("white", circle.Color);

            isSuccessful = circle.MoveTo(5, 0);
            AssertEquals(true, isSuccessful);

            AssertEquals(5, circle.X);
            AssertEquals(0, circle.Y);
            AssertEquals(50.0, circle.Radius, 0.001);
            AssertEquals("white", circle.Color);

            isSuccessful = circle.MoveTo(150, -200);
            AssertEquals(false, isSuccessful);

            AssertEquals(5, circle.X);
            AssertEquals(0, circle.Y);
            AssertEquals(50.0, circle.Radius, 0.001);
            AssertEquals("white", circle.Color);

            isSuccessful = circle.MoveTo(25, 300);
            AssertEquals(true, isSuccessful);

            AssertEquals(25, circle.X);
            AssertEquals(300, circle.Y);
            AssertEquals(50.0, circle.Radius, 0.001);
            AssertEquals("white", circle.Color);

            isSuccessful = circle.MoveTo(-50, -1);
            AssertEquals(false, isSuccessful);

            AssertEquals(25, circle.X);
            AssertEquals(300, circle.Y);
            AssertEquals(50.0, circle.Radius, 0.001);
            AssertEquals("white", circle.Color);
        }

        private static void TestCalculateDistanceToAfterMoving()
        {
            Circle circleA = new Circle(10, 20, 5.0);
            Circle circleB = new Circle(10, 30, 7.5, "white");

            AssertEquals(10.0, circleA.CalculateDistanceTo(circleB), 0.01);
            AssertEquals(10.0, circleB.CalculateDistanceTo(circleA), 0.01);

            circleA.MoveTo(10, 30);

            AssertEquals(0.0, circleA.CalculateDistanceTo(circleB), 0.01);
            AssertEquals(0.0, circleB.CalculateDistanceTo(circleA), 0.01);

            circleB.MoveTo(20, 40);

            AssertEquals(14.14, circleA.CalculateDistanceTo(circleB), 0.01);
            AssertEquals(14.14, circleB.CalculateDistanceTo(circleA), 0.01);

            circleB.MoveTo(1, 1);

            AssertEquals(30.36, circleA.CalculateDistanceTo(circleB), 0.01);
            AssertEquals(30.36, circleB.CalculateDistanceTo(circleA), 0.01);

            circleA.MoveTo(0, 1);

            AssertEquals(1.0, circleA.CalculateDistanceTo(circleB), 0.01);
            AssertEquals(1.0, circleB.CalculateDistanceTo(circleA), 0.01);
        }

        private static void TestIsOverlappingAfterResizeAndMove()
        {
            Circle circleA = new Circle(10, 20, 5.0);
            Circle circleB = new Circle(10, 30, 7.5, "white");

            AssertEquals(true, circleA.IsOverlapping(circleB));
            AssertEquals(true, circleB.IsOverlapping(circleA));

            circleA.Radius = 1.5;

            AssertEquals(false, circleA.IsOverlapping(circleB));
            AssertEquals(false, circleB.IsOverlapping(circleA));

            circleB.MoveTo(10, 28);

            AssertEquals(true, circleA.IsOverlapping(circleB));
            AssertEquals(true, circleB.IsOverlapping(circleA));

            circleB.Radius = 5;

            AssertEquals(false, circleA.IsOverlapping(circleB));
            AssertEquals(false, circleB.IsOverlapping(circleA));

            circleA.MoveTo(12, 26);

            AssertEquals(true, circleA.IsOverlapping(circleB));
            AssertEquals(true, circleB.IsOverlapping(circleA));

            circleA.MoveTo(100, 150);

            AssertEquals(false, circleA.IsOverlapping(circleB));
            AssertEquals(false, circleB.IsOverlapping(circleA));

            circleA.Radius = 99;

            AssertEquals(false, circleA.IsOverlapping(circleB));
            AssertEquals(false, circleB.IsOverlapping(circleA));

            circleB.Radius = 60;

            AssertEquals(true, circleA.IsOverlapping(circleB));
            AssertEquals(true, circleB.IsOverlapping(circleA));
        }

        private static void AssertEquals(Object expected, Object actual)
        {
            if (!expected.Equals(actual))
            {
                RaiseErrorFlag();
                Console.WriteLine($"Expected \"{expected}\" but received \"{actual}\" instead!");
            }
        }

        private static void AssertEquals(double expected, double actual, double delta)
        {
            double difference = Math.Abs(expected - actual);
            if (delta < difference)
            {
                RaiseErrorFlag();
                Console.WriteLine($"Expected \"{expected}\" but received \"{actual}\" instead!");
            }
        }

        private static void RaiseErrorFlag()
        {
            containsErrors = true;

            if(stopOnError)
            {
                throw new Exception();
            }
        }
    }
}

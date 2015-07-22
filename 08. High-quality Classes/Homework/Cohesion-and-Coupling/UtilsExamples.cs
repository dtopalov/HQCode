namespace CohesionAndCoupling
{
    using System;

    internal class UtilsExamples
    {
        private static void Main()
        {
            Console.WriteLine(FileNameUtils.GetFileExtension("example"));
            Console.WriteLine(FileNameUtils.GetFileExtension("example.pdf"));
            Console.WriteLine(FileNameUtils.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileNameUtils.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileNameUtils.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileNameUtils.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("Distance in the 2D space = {0:f2}", CalcDistanceUtils.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}", CalcDistanceUtils.CalcDistance3D(5, 2, -1, 3, -6, 4));

            Figure3D testFigure3D = new Figure3D(3, 4, 5);

            Console.WriteLine("Volume = {0:f2}", testFigure3D.CalcVolume());
            Console.WriteLine("Diagonal XYZ = {0:f2}", testFigure3D.CalcDiagonalXyz());
            Console.WriteLine("Diagonal XY = {0:f2}", testFigure3D.CalcDiagonalXy());
            Console.WriteLine("Diagonal XZ = {0:f2}", testFigure3D.CalcDiagonalXz());
            Console.WriteLine("Diagonal YZ = {0:f2}", testFigure3D.CalcDiagonalYz());
        }
    }
}

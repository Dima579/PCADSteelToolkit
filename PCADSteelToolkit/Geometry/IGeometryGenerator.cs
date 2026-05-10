using PCADSteelToolkit.Models;
using Teigha.DatabaseServices;
using Teigha.Geometry;

namespace PCADSteelToolkit.Geometry
{
    public interface IGeometryGenerator<T>
    {
        void Generate(T section);
    }
}
using PCADSteelToolkit.Models;
using System;
using Teigha.DatabaseServices;
using Teigha.Geometry;

namespace PCADSteelToolkit.Geometry
{
    internal class UBUCGenerator : IGeometryGenerator<UBUC>
    {
        public void Generate(UBUC section)
        {
            Database db = HostApplicationServices.WorkingDatabase;

            using (Transaction tr = db.TransactionManager.StartTransaction())
            {
                BlockTable bt = (BlockTable)tr.GetObject(db.BlockTableId, OpenMode.ForRead);
                BlockTableRecord ms = (BlockTableRecord)tr.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite);

                double depth = section.Depth;
                double width = section.Width;
                double webT = section.WebThickness_mm;
                double flangeT = section.FlangeThickness_mm;

                double hw = webT / 2;
                double cx = width / 2;

                var poly = new Polyline();

                poly.AddVertexAt(0, new Point2d(0, 0), 0, 0, 0);
                poly.AddVertexAt(1, new Point2d(width, 0), 0, 0, 0);
                poly.AddVertexAt(2, new Point2d(width, flangeT), 0, 0, 0);
                poly.AddVertexAt(3, new Point2d(cx + hw, flangeT), 0, 0, 0);
                poly.AddVertexAt(4, new Point2d(cx + hw, depth - flangeT), 0, 0, 0);
                poly.AddVertexAt(5, new Point2d(width, depth - flangeT), 0, 0, 0);
                poly.AddVertexAt(6, new Point2d(width, depth), 0, 0, 0);
                poly.AddVertexAt(7, new Point2d(0, depth), 0, 0, 0);
                poly.AddVertexAt(8, new Point2d(0, depth - flangeT), 0, 0, 0);
                poly.AddVertexAt(9, new Point2d(cx - hw, depth - flangeT), 0, 0, 0);
                poly.AddVertexAt(10, new Point2d(cx - hw, flangeT), 0, 0, 0);
                poly.AddVertexAt(11, new Point2d(0, flangeT), 0, 0, 0);

                poly.Closed = true;

                ms.AppendEntity(poly);
                tr.AddNewlyCreatedDBObject(poly, true);
                tr.Commit();
            }
        }
    }
}

using PCADSteelToolkit.Models;
using System;
using Teigha.DatabaseServices;
using Teigha.Geometry;

namespace PCADSteelToolkit.Geometry
{
    internal class LUNEQGenerator : IGeometryGenerator<LUNEQ>
    {
        public void Generate(LUNEQ section)
        {
            Database db = HostApplicationServices.WorkingDatabase;

            using (Transaction tr = db.TransactionManager.StartTransaction())
            {
                BlockTable bt = (BlockTable)tr.GetObject(db.BlockTableId, OpenMode.ForRead);
                BlockTableRecord ms = (BlockTableRecord)tr.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite);

                //establish variables then use to draw lines
                double verticalL = section.VerticalLegLength;
                double HorizontalL = section.HorizontalLegLength;
                double thickness = section.ThicknessDesignation;

                var poly = new Polyline();

                poly.AddVertexAt(0, new Point2d(0, 0), 0, 0, 0);
                poly.AddVertexAt(1, new Point2d(HorizontalL, 0), 0, 0, 0);
                poly.AddVertexAt(2, new Point2d(HorizontalL, thickness), 0, 0, 0);
                poly.AddVertexAt(3, new Point2d(thickness, thickness), 0, 0, 0);
                poly.AddVertexAt(4, new Point2d(thickness, verticalL), 0, 0, 0);


                poly.AddVertexAt(5, new Point2d(0, verticalL), 0, 0, 0);

                poly.Closed = true;

                ms.AppendEntity(poly);
                tr.AddNewlyCreatedDBObject(poly, true);

                tr.Commit();
            }
        }
    }
}

using PCADSteelToolkit.Models;
using System;
using Teigha.DatabaseServices;
using Teigha.Geometry;

namespace PCADSteelToolkit.Geometry
{
    internal class HFRHGenerator : IGeometryGenerator<HFRH>
    {
        public void Generate(HFRH section)
        {
            Database db = HostApplicationServices.WorkingDatabase;

            using (Transaction tr = db.TransactionManager.StartTransaction())
            {
                BlockTable bt = (BlockTable)tr.GetObject(db.BlockTableId, OpenMode.ForRead);
                BlockTableRecord ms = (BlockTableRecord)tr.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite);

                double width = section.Width;
                double height = section.Height;
                double t = section.ThicknessDesignation;

                double halfW = width / 2;
                double halfH = height / 2;

                // Outer rectangle
                Polyline outer = new Polyline();

                outer.AddVertexAt(0, new Point2d(-halfW, -halfH), 0, 0, 0);
                outer.AddVertexAt(1, new Point2d(halfW, -halfH), 0, 0, 0);
                outer.AddVertexAt(2, new Point2d(halfW, halfH), 0, 0, 0);
                outer.AddVertexAt(3, new Point2d(-halfW, halfH), 0, 0, 0);

                outer.Closed = true;

                ms.AppendEntity(outer);
                tr.AddNewlyCreatedDBObject(outer, true);

                // Inner rectangle
                double innerW = width - 2 * t;
                double innerH = height - 2 * t;

                double halfInnerW = innerW / 2;
                double halfInnerH = innerH / 2;

                Polyline inner = new Polyline();
                inner.AddVertexAt(0, new Point2d(-halfInnerW, -halfInnerH), 0, 0, 0);
                inner.AddVertexAt(1, new Point2d(halfInnerW, -halfInnerH), 0, 0, 0);
                inner.AddVertexAt(2, new Point2d(halfInnerW, halfInnerH), 0, 0, 0);
                inner.AddVertexAt(3, new Point2d(-halfInnerW, halfInnerH), 0, 0, 0);
                inner.Closed = true;

                ms.AppendEntity(inner);
                tr.AddNewlyCreatedDBObject(inner, true);

                tr.Commit();
            }
        }
    }
}

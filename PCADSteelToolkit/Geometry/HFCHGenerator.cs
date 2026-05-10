using PCADSteelToolkit.Models;
using Teigha.DatabaseServices;
using Teigha.Geometry;

namespace PCADSteelToolkit.Geometry
{
    internal class HFCHGenerator : IGeometryGenerator<HFCH>
    {
        public void Generate(HFCH section)
        {
            Database db = HostApplicationServices.WorkingDatabase;

            using (Transaction tr = db.TransactionManager.StartTransaction())
            {
                BlockTable bt = (BlockTable)tr.GetObject(db.BlockTableId, OpenMode.ForRead);
                BlockTableRecord ms = (BlockTableRecord)tr.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite);

                Point3d center = new Point3d(0, 0, 0);
                Vector3d normal = Vector3d.ZAxis;

                // Outer circle
                Circle outer = new Circle(center, normal, section.OuterRadius);
                ms.AppendEntity(outer);
                tr.AddNewlyCreatedDBObject(outer, true);

                // Inner circle
                Circle inner = new Circle(center, normal, section.InnerRadius);
                ms.AppendEntity(inner);
                tr.AddNewlyCreatedDBObject(inner, true);

                tr.Commit();
            }
        }
    }
}

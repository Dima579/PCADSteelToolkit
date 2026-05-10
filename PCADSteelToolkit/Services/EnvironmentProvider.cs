using System;

using IntelliCAD.EditorInput;
using IntelliCAD.ApplicationServices;
using PCADSteelToolkit.DbAccess;

namespace PCADSteelToolkit.Services
{
    internal class EnvironmentProvider
    {
        public Document Document {get;}
        public Editor Editor {get;}
        public SteelPartAccess dbAccess {get;}

        //Manually inserts resources such as DB/DB method access and document editor access
        public EnvironmentProvider()
        {
            Document = Application.DocumentManager.MdiActiveDocument;
            Editor = Document.Editor;

            var db = new DbConnection();
            dbAccess = new SteelPartAccess(db);
        }
    }
}

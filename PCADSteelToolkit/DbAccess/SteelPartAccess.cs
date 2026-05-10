using System;
using Dapper;
using PCADSteelToolkit.Models;

namespace PCADSteelToolkit.DbAccess
{
    public class SteelPartAccess
    {
        private readonly DbConnection _db;

        public SteelPartAccess(DbConnection db)
        {
            _db = db;
        }


        public HFCH GetHFCH(double oD, double tD)
        {
            using (var connection = _db.InitialiseConnection())
            {
                string retrieval = $"SELECT * FROM HFCH WHERE OutsideDiameter_mm = @oD AND ThicknessDesignation = @tD";

                var result = connection.QuerySingle<HFCH>(retrieval, new { oD, tD });

                if (result == null) { throw new Exception("ERROR: Section not found");}
                else { return result; }
            }
        }

        public HFRH GetHFRH(string sB, double tD)
        {
            using (var connection = _db.InitialiseConnection())
            {
                string retrieval = $"SELECT * FROM HFRH WHERE SizeHB_mm = @sB AND ThicknessDesignation = @tD";

                var result = connection.QuerySingle<HFRH>(retrieval, new { sB, tD });

                if (result == null) { throw new Exception("ERROR: Section not found"); }
                else { return result; }
            }
        }

        public LUNEQ GetLUNEQ(string sD, double tD)
        {
            using (var connection = _db.InitialiseConnection())
            {
                string retrieval = $"SELECT * FROM LUNEQ WHERE SectionDesignation = @sD AND ThicknessDesignation = @tD";

                var result = connection.QuerySingle<LUNEQ>(retrieval, new { sD, tD });

                if (result == null) { throw new Exception("ERROR: Section not found"); }
                else { return result; }
            }
        }

        public UBUC GetUBUC(string sT, string sD, string mD)
        {
            using (var connection = _db.InitialiseConnection())
            {
                string table = sT;

                string retrieval = $"SELECT * FROM {table} WHERE SectionDesignation = @sD AND MassDesignation = @mD";

                var result = connection.QuerySingle<UBUC>(retrieval, new { sD, mD });

                if (result == null) { throw new Exception("ERROR: Section not found"); }
                else { return result; }
            }
        }
    }
}
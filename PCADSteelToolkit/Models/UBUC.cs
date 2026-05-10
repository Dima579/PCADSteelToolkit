namespace PCADSteelToolkit.Models
{
    public class UBUC
    {
        public string SectionDesignation {get; set;}
        public string MassDesignation {get; set;}
        public double WebThickness_mm {get; set;}
        public double FlangeThickness_mm {get; set;}

        public double Depth
        {
            get
            {
                var parts = SectionDesignation.ToLower().Split('x');
                return double.Parse(parts[0].Trim());
            }
        }

        public double Width
        {
            get
            {
                var parts = SectionDesignation.ToLower().Split('x');
                return double.Parse(parts[1].Trim());
            }
        }
    }
}
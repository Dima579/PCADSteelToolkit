namespace PCADSteelToolkit.Models
{
    public class LUNEQ
    {
        public string SectionDesignation {get; set;}
        public double ThicknessDesignation {get; set;}
        public double RadiusRoot_mm {get; set;}

        public double VerticalLegLength
        {
            get
            {
                var parts = SectionDesignation.ToLower().Split('x');
                return double.Parse(parts[0]);
            }
        }

        public double HorizontalLegLength
        {
            get
            {
                var parts = SectionDesignation.ToLower().Split('x');
                return double.Parse(parts[1]);
            }
        }
    }
}

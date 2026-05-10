namespace PCADSteelToolkit.Models
{
    public class HFRH
    {
        public string SizeHB_mm { get; set; }
        public double ThicknessDesignation { get; set; }

        public double Width
        {
            get
            {
                var parts = SizeHB_mm.ToLower().Split('x');
                return double.Parse(parts[0].Trim());
            }
        }

        public double Height
        {
            get
            {
                var parts = SizeHB_mm.ToLower().Split('x');
                return double.Parse(parts[1].Trim());
            }
        }

    }
}
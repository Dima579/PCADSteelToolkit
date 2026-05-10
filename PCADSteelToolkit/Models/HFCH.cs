namespace PCADSteelToolkit.Models
{
    public class HFCH
    {
        public double OutsideDiameter_mm {get; set;}
        public double ThicknessDesignation {get; set;}
        public double OuterRadius => OutsideDiameter_mm / 2;
        public double InnerRadius => OuterRadius - ThicknessDesignation;
    }
}

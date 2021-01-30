namespace Playstore.Domain.Abstractions
{
    public class Dimensions
    {
        #region Public Properties

        public decimal Length { get; set; }
        public decimal Width { get; private set; }
        public decimal Height { get; set; }

        #endregion

        #region Constructor

        public Dimensions(decimal length, decimal width, decimal height)
        {
            Validations.ValidateDecimalMinimum(height, 0, "The length must be > 0");
            Validations.ValidateDecimalMinimum(width, 0, "The length must be > 0");
            Validations.ValidateDecimalMinimum(height, 0, "The length must be > 0");

            Length = length;
            Width = width;
            Height = height;
        }

        #endregion

        #region Overriden Methods

        public override string ToString() => FormatedDescription();

        #endregion

        #region Public Methods

        public string FormatedDescription() => $"LxWxH: { Length } x { Width } x { Height }";

        #endregion
    }
}
namespace FastFood.Data.Models.Enumerations
{
    using System.ComponentModel;

    public enum DringSize
    {
        [Description("0.330L")]
        Can = 1,
        [Description("0.500L")]
        HalfLitter = 2,
        [Description("1L")]
        Liter = 3,
    }
}
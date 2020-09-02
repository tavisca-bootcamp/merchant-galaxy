namespace Merchant_Galaxy.Interfaces {
    /// <summary>
    /// This interface should be implemented by all the rules that needs to be satisfied before a conversion 
    /// from one numer system to another can happen.
    /// </summary>
    public interface IConversionRule
        {
                bool Execute(string input);
        }
}

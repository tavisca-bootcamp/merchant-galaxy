namespace Merchant_Galaxy.Interfaces {
    public interface IExpression {
        bool Match(string input);
        void Execute(string input);
    }
}

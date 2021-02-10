package tavisca.workshop;

public class PriceCalculator {
    private RomanCalculator romanCalculator;

    PriceCalculator()  {
        romanCalculator = new RomanCalculator();
    }

    public double calculatePriceForEacMetal(String quantity, String price) {
        romanCalculator.roman = quantity;
        romanCalculator.convertRomanToArabicDecimal();
        return Double.parseDouble(price)/romanCalculator.decimal;
    }
}

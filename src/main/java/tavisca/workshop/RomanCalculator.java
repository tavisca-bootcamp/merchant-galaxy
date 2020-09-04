package tavisca.workshop;

public class RomanCalculator {

    public String roman;
    public int decimal;

    public int convertRomanToArabicDecimal() {
        decimal = 0;
        if(roman.length() == 1)
            return RomanMap.romanMap.get(roman.charAt(0));
        for (int i = 0; i < roman.length(); i++) {
            int value1 = RomanMap.romanMap.get(roman.charAt(i));
            if(i+1 < roman.length())  {
                int value2 = RomanMap.romanMap.get(roman.charAt(i+1));
                if(value1 >= value2)
                    decimal += value1;
                else  {
                    decimal += value2 - value1;
                    i++;
                }
            }
            else {
                decimal += value1;
                i++;
            }
        }
        return decimal;
    }
}

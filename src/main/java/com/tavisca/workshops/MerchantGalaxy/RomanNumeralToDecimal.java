package com.tavisca.workshops.MerchantGalaxy;

public class RomanNumeralToDecimal {
    public int convert(String romanNumeral) {
        int decimal = 0;
        int lastNumber = 0;
        for (int index = romanNumeral.length() - 1; index >= 0; index--) {
            char convertToDecimal = romanNumeral.charAt(index);

            switch (convertToDecimal) {
                case 'M':
                    decimal = processDecimal(1000, lastNumber, decimal);
                    lastNumber = 1000;
                    break;
                case 'D':
                    decimal = processDecimal(500, lastNumber, decimal);
                    lastNumber = 500;
                    break;
                case 'C':
                    decimal = processDecimal(100, lastNumber, decimal);
                    lastNumber = 100;
                    break;
                case 'L':
                    decimal = processDecimal(50, lastNumber, decimal);
                    lastNumber = 50;
                    break;
                case 'X':
                    decimal = processDecimal(10, lastNumber, decimal);
                    lastNumber = 10;
                    break;
                case 'V':
                    decimal = processDecimal(5, lastNumber, decimal);
                    lastNumber = 5;
                    break;
                case 'I':
                    decimal = processDecimal(1, lastNumber, decimal);
                    lastNumber = 1;
                    break;
            }
        }
        return decimal;
    }

    private int processDecimal(int decimal, int lastNumber, int lastDecimal) {
        return (lastNumber > decimal) ? (lastDecimal - decimal) : (lastDecimal + decimal);
    }
}

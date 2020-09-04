package tavisca.workshop;

import java.util.regex.Pattern;

public class ComplexStatements {
    public static String[] Processing(String input) {
        Pattern pattern = Pattern.compile(" is | Credits");
        String[] splits = pattern.split(input);
        return splits;
    }

    public static String[] Parse(GalacticToRomanMapping directory, String input) {
        String[] splits = input.split(" ");
        String metal = splits[splits.length-1];
        String quantity = "";

        int indexOfSpace = input.lastIndexOf(" ");
        quantity = input.substring(0, indexOfSpace);

        return new String[] {quantity, metal};
    }
}

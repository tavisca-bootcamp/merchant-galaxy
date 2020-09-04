package tavisca.workshop;

public class GalacticWordConverter {
    public static String convertGalacticWordsToRoman(GalacticToRomanMapping directory, String input) {
        String romanEquivalent = "";
        String[] splits = input.split(" ");
        for(String s : splits) {
            if (directory.directory.containsKey(s))
                romanEquivalent += directory.directory.get(s);
        }
        return romanEquivalent;
    }
}

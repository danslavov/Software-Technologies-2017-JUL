import java.util.Scanner;

public class P04_VowelOrDigit {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        char sym = scanner.nextLine().toLowerCase().charAt(0);

        if (Character.isDigit(sym)) {
            System.out.println("digit");
        } else if (isVowel(sym)) {
            System.out.print("vowel");
        } else {
            System.out.println("other");
        }
    }

    public static boolean isVowel(char sym) {
        int[] vowels = {97, 101, 105, 111, 117, 119};
        for (int vowel : vowels) {
            if (sym == vowel) {
                return true;
            }
        }
        return false;
    }
}


import java.util.Scanner;

public class P10_IndexOfLetters {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String input = scanner.nextLine();
        for (int i = 0; i < input.length(); i++) {
            System.out.printf("%s -> %d%n", input.charAt(i), input.charAt(i) - 97);
        }
        System.out.println();
    }
}

import java.util.Scanner;

public class P03_ReverseCharacters {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String[] input = new String[3];
        for (int i = 0; i < 3; i++) {
            input[i] = scanner.nextLine();
        }
        for (int i = 2; i >= 0; i--) {
            System.out.print(input[i]);
        }
    }
}

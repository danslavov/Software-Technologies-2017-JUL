import java.util.Scanner;

public class P02_BooleanVariable {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String input = scanner.nextLine();
        System.out.println(Boolean.valueOf(input) ? "Yes" : "No");
    }
}

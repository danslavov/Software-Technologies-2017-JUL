import java.util.Scanner;

public class P01_VariableInHexFormat {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String input = scanner.nextLine();
        System.out.println(Integer.parseInt(input, 16));
    }
}
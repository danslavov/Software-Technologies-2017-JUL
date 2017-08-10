import java.util.Scanner;

public class P05_IntegerToHexAndBinary {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        long num = Long.parseLong(scanner.nextLine());
        System.out.println(Long.toHexString(num).toUpperCase());
        System.out.println(Long.toBinaryString(num));
    }
}

import java.util.Arrays;
import java.util.Scanner;

public class P09_MostFrequentNumber {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int[] input = Arrays
                .stream(scanner.nextLine().split(" "))
                .mapToInt(Integer::parseInt)
                .toArray();
        int maxCount = 1;
        int number = input[0];
        for (int i = 0; i < input.length; i++) {
            int currentCount = 0;
            int left = input[i];
            for (int j = i; j < input.length; j++) {
                int right = input[j];
                if (left == right) {
                    currentCount++;
                }
            }
            if (currentCount > maxCount) {
                maxCount = currentCount;
                number = left;
            }
        }
        System.out.println(number);
    }
}

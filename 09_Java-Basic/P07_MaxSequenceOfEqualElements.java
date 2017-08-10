import java.util.Arrays;
import java.util.Scanner;

public class P07_MaxSequenceOfEqualElements {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int[] input = Arrays
                .stream(scanner.nextLine().split(" "))
                .mapToInt(Integer::parseInt)
                .toArray();
        int maxSequence = 1;
        int maxValue = 1;
        int curSequence = 1;
        int previousValue;

        for (int i = 1; i < input.length; i++) {
            previousValue = input[i - 1];
            int currentValue = input[i];
            if (previousValue == currentValue) {
                curSequence++;
                if (curSequence > maxSequence) {
                    maxSequence = curSequence;
                    maxValue = previousValue;
                }
            } else {
                curSequence = 1;
            }
        }
        for (int i = 0; i < maxSequence; i++) {
            System.out.print(maxValue + " ");
        }
        System.out.println();
    }
}
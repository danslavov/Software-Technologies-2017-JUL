import java.util.Arrays;
import java.util.Scanner;

public class P08_MaxSequenceOfIncreasingElements {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int[] input = Arrays
                .stream(scanner.nextLine().split(" "))
                .mapToInt(Integer::parseInt)
                .toArray();
        int maxLength = 1;
        int maxIndex = 0;
        int curLength = 1;

        for (int i = 1; i < input.length; i++) {
            int previousValue = input[i - 1];
            int currentValue = input[i];
            if (previousValue < currentValue) {
                curLength++;
            } else {
                if (curLength > maxLength) {
                    maxLength = curLength;
                    maxIndex = i - curLength;
                }
                curLength = 1;
            }
            if (i == input.length - 1) {
                if (curLength > maxLength) {
                    maxLength = curLength;
                    maxIndex = i - curLength + 1;
                }
            }
        }
        for (int i = maxIndex; i < maxIndex + maxLength; i++) {
            System.out.print(input[i] + " ");
        }
        System.out.println();
    }
}

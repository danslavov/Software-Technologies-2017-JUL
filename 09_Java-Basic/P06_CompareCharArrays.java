import java.util.Scanner;

public class P06_CompareCharArrays {
    public static void main(String[] args) {
        char[] firstSymbols = readStrAndConvertToChar();
        char[] secondSymbols = readStrAndConvertToChar();
        boolean firstIsBigger;
        if (firstSymbols.length >= secondSymbols.length) {
            firstIsBigger = compareCharArrays(firstSymbols, secondSymbols);
        } else {
            firstIsBigger = !compareCharArrays(secondSymbols, firstSymbols);
        }
        if (firstIsBigger) {
            printArrays(secondSymbols, firstSymbols);
            printArrays(firstSymbols, secondSymbols);
        } else {
            printArrays(firstSymbols, secondSymbols);
            printArrays(secondSymbols, firstSymbols);

        }
    }

    static void printArrays(char[] firstSymbols, char[] secondSymbols) {
        for (char sym : firstSymbols) {
            System.out.print(sym);
        }
        System.out.println();
    }

    static boolean compareCharArrays(char[] firstSymbols, char[] secondSymbols) {
        for (int i = 0; i < secondSymbols.length; i++) {
            if (firstSymbols[i] > secondSymbols[i]) {
                return true;
            } else if (firstSymbols[i] < secondSymbols[i]) {
                return false;
            }
        }
        return true;
    }

    static char[] readStrAndConvertToChar() {
        Scanner scanner = new Scanner(System.in);
        String[] strArr = scanner.nextLine().split("\\s+");
        char[] charArr = new char[strArr.length];
        for (int i = 0; i < charArr.length; i++) {
            charArr[i] = strArr[i].charAt(0);
        }
        return charArr;
    }
}

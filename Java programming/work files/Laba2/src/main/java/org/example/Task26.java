// Сформувати масив b, елементами якого є елементи вихідного
// одновимірного масиву a, розташовані в зворотному порядку.

package org.example;

import java.util.Scanner;
import java.util.Arrays;

public class Task26 {

    public static int[] reverseArray(int[] a) {
        int[] b = new int[a.length];
        for (int i = 0; i < a.length; i++) {
            b[i] = a[a.length - 1 - i];
        }
        return b;
    }

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Введіть розмір масиву: ");
        int size = scanner.nextInt();
        int[] a = new int[size];
        System.out.println("Введіть елементи масиву:");
        for (int i = 0; i < size; i++) {
            a[i] = scanner.nextInt();
        }
        int[] b = reverseArray(a);
        System.out.println("Масив в зворотному порядку: " + Arrays.toString(b));
    }
}

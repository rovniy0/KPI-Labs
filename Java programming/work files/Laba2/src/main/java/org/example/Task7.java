// Визначити абсолютне значення найменшої різниці між двома
// будь-якими значеннями елементів вихідного одновимірного масиву a.
package org.example;

import java.util.Arrays;
import java.util.Scanner;

public class Task7 {

    public static int findMinDifference(int[] a) {
        if (a == null || a.length < 2) {
            throw new IllegalArgumentException("Масив повинен містити принаймні два елементи.");
        }

        Arrays.sort(a);
        int minDifference = Integer.MAX_VALUE;
        for (int i = 1; i < a.length; i++) {
            int difference = Math.abs(a[i] - a[i - 1]);
            if (difference < minDifference) {
                minDifference = difference;
            }
        }

        return minDifference;
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
        int minDifference = findMinDifference(a);
        System.out.println("Найменша різниця між двома елементами: " + minDifference);
    }
}

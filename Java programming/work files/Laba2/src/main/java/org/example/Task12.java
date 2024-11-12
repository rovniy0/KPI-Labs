// Визначити, чи утворюють значення елементів вихідного одновимірного масиву a:
// строго зростаючу послідовність (ai < ai+1), строго спадну послідовність (ai > ai+1)
// або елементи масиву не впорядковані, і вивести для кожного випадку відповідне повідомлення.

package org.example;

import java.util.Scanner;

public class Task12 {

    public static String checkSequence(int[] a) {
        if (a.length < 2) {
            throw new IllegalArgumentException("Масив повинен містити принаймні два елементи");
        }

        boolean isIncreasing = true;
        boolean isDecreasing = true;

        for (int i = 1; i < a.length; i++) {
            if (a[i] > a[i - 1]) {
                isDecreasing = false;
            } else if (a[i] < a[i - 1]) {
                isIncreasing = false;
            }
        }

        if (isIncreasing) {
            return "Строго зростаюча послідовність";
        } else if (isDecreasing) {
            return "Строго спадна послідовність";
        } else {
            return "Елементи масиву не впорядковані";
        }
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
        String result = checkSequence(a);
        System.out.println("Результат: " + result);
    }

}

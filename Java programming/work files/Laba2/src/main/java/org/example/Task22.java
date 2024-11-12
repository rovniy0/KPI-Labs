// Сформувати масив b, елементами якого є значення індексів
// елементів вихідного одновимірного масиву a в порядку убування
// значень елементів.


package org.example;

import java.util.Arrays;
import java.util.Comparator;
import java.util.Scanner;

public class Task22 {

    public static int[] createIndexArray(int[] a) {
        Integer[] indices = new Integer[a.length];
        for (int i = 0; i < a.length; i++) {
            indices[i] = i; // Додаємо індекс ел.
        }
        Arrays.sort(indices, new Comparator<Integer>() {
            @Override
            public int compare(Integer index1, Integer index2) {
                return Integer.compare(a[index2], a[index1]); // Убування значень
            }
        });
        return Arrays.stream(indices).mapToInt(Integer::intValue).toArray();
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
        int[] b = createIndexArray(a);
        System.out.println("Масив індексів в порядку убування значень: " + Arrays.toString(b));
    }
}

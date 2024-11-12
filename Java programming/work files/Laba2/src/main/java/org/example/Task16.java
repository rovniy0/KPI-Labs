// Виведіть на дисплей значення тих елементів масивів a і b,
// які є тільки в одному з масивів, і відсутні в іншому масиві
// (передбачається, що і масив a, і масив b є множинами, тобто
// кожен з них не містить елементів з однаковими значеннями).

package org.example;

import java.util.ArrayList;
import java.util.List;

public class Task16 {

    public static List<Integer> findUniqueElements(int[] a, int[] b) {
        List<Integer> uniqueElements = new ArrayList<>();
        for (int valueA : a) {
            boolean foundInB = false;
            for (int valueB : b) {
                if (valueA == valueB) {
                    foundInB = true;
                    break;
                }
            }
            if (!foundInB) {
                uniqueElements.add(valueA);
            }
        }
        for (int valueB : b) {
            boolean foundInA = false;
            for (int valueA : a) {
                if (valueB == valueA) {
                    foundInA = true;
                    break;
                }
            }
            if (!foundInA) {
                uniqueElements.add(valueB);
            }
        }

        return uniqueElements;
    }

    public static void main(String[] args) {
        int[] a = {1, 2, 3, 4};
        int[] b = {3, 4, 5, 6};

        List<Integer> result = findUniqueElements(a, b);

        System.out.println("Елементи, що є тільки в одному з масивів: " + result);
    }
}


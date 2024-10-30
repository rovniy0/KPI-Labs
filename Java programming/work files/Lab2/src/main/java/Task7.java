package src.main.java;

import java.util.Scanner;
import java.util.Arrays;

public class Task7 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        // Введення розміру масиву
        System.out.print("Введіть розмір масиву: ");
        int size = scanner.nextInt();

        // Створення масиву
        int[] a = new int[size];

        // Введення елементів масиву
        System.out.println("Введіть елементи масиву:");
        for (int i = 0; i < size; i++) {
            a[i] = scanner.nextInt();
        }

        // Сортування масиву
        Arrays.sort(a);

        // Пошук мінімальної різниці між сусідніми елементами
        int minDifference = Integer.MAX_VALUE;
        for (int i = 1; i < size; i++) {
            int difference = Math.abs(a[i] - a[i - 1]);
            if (difference < minDifference) {
                minDifference = difference;
            }
        }

        // Виведення результату
        System.out.println("Найменша різниця між двома елементами: " + minDifference);
    }
}

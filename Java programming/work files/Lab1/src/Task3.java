import java.util.Scanner;

public class Task3 {
    public static void main(String[] args) {
        int number = Integer.parseInt(args[0]);
        if (number < 10 || number > 99) {
            System.out.println("The number isn't two-digit.");
        }
        else {
            task3(Integer.parseInt(args[0]));
        }

    }
    public static void task3 (int number) {
        int first_digit = number / 10;
        int second_digit = number % 10;
        int reversed_number = second_digit * 10 + first_digit;

        double sqrt_value = Math.sqrt(reversed_number);
        int nearest_int = (int) Math.round(sqrt_value);

        System.out.println("Square root: " + sqrt_value);
        System.out.println("Nearest integer: " + nearest_int);
    }
}

// Дана площа квадрата. Знайти сторону даного квадрата і мінімальну цілу
// сторону квадрата, в який вихідний квадрат може бути вписаний.

public class Task7 {
    public static void main(String[] args) {
        if (args.length == 0) {
            System.out.println("Please provide the area of the square.");
            return;
        }
        double area = Double.parseDouble(args[0]);

        if (area <= 0) {
            System.out.println("Area must be a positive integer.");
        }
        else {
            task7(area);
        }
    }

    public static void task7(double area) {
        double side = Math.sqrt(area);
        int minimum_enclosing_side = (int) Math.ceil(side);

        System.out.printf("Side of the square: %.2f\n", side);
        System.out.println("Minimum integer side of square: " + minimum_enclosing_side);
    }
}

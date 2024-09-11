public class Task16 {
    public static void main(String[] args) {
        if(args.length!=2) {
            System.out.println("Number of argument is incorrect ");
        }
        else {
            task16(Double.parseDouble(args[0]), Double.parseDouble(args[1]));
        }
    }

    public static void task16 (double first_side, double second_side) {

        double diagonal = Math.sqrt(Math.pow(first_side, 2) + Math.pow(second_side, 2));
        double perimeter = 2 * (first_side + second_side);

        System.out.println("Diagonal of the rectangle: " + diagonal);
        System.out.println("Perimeter of the rectangle: " + perimeter);
    }
}

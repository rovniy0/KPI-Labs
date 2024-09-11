public class Task12 {
    public static void main(String[] args) {
        int number = Integer.parseInt(args[0]);
        if (number < 100 || number > 999) {
            System.out.println("The number isn't three-digit");
        } else {
            task12(Integer.parseInt(args[0]));
        }
    }

        public static void task12 (int number){
        int first_digit = number / 100;
        int second_digit = (number / 10) % 10;
        int third_digit = number % 10;

        int sum = first_digit + second_digit + third_digit;
        int product = first_digit * second_digit * third_digit;

        System.out.println("Sum of digits: " + sum);
        System.out.println("Product of digits: " + product);
    }
}
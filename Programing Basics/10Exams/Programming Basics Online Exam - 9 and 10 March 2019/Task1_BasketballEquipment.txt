import java.util.Scanner;

public class Task1_BasketballEquipment {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        //такса за тренировка за 1 година
        int moneyForYear =  Integer.parseInt(scanner.nextLine());
        //кецове
        double sneakers = moneyForYear - 0.40 * moneyForYear;
        //екип
        double equipment = sneakers - 0.2 * sneakers;
        //топка
        double ball = 1.0 / 4 * equipment;
        //аксесоари
        double accs = 1.0 / 5 * ball;

        double totalSum = moneyForYear + sneakers + equipment + ball + accs;

        System.out.printf("%.2f", totalSum);


    }
}

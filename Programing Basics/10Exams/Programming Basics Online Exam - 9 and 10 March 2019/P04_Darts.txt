import java.util.Scanner;

public class P04_Darts {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        String name = scan.nextLine();
        int totalPoints = 301;
        int successfulShots = 0;
        int unSuccessfulShots = 0;

        while (totalPoints != 0) {
            String area = scan.nextLine();
            if ("Retire".equals(area)) {
                break;
            }
            int points = Integer.parseInt(scan.nextLine());

            if ("Triple".equals(area)) {
                points *= 3;
            } else if ("Double".equals(area)) {
                points *= 2;
            }

            if (totalPoints - points >= 0) {
                totalPoints -= points;
                successfulShots++;
            } else {
                unSuccessfulShots++;
            }
        }

        if (totalPoints == 0) {
            System.out.println(String.format("%s won the leg with %d shots.", name, successfulShots));
        } else {
            System.out.println(String.format("%s retired after %d unsuccessful shots.", name, unSuccessfulShots));
        }
    }
}

import java.util.Scanner;

public class P06_HighJump {
    public static void main(String[] args) {
Scanner scan = new Scanner(System.in);

        int height = Integer.parseInt(scan.nextLine());
        int staringHeight = height - 30;
        int jumps = 0;
        boolean isFailed = false;

        while (staringHeight <= height) {
            for (int i = 0; i < 3; i++) {
                int currentJum = Integer.parseInt(scan.nextLine());
                jumps++;
                if (currentJum > staringHeight) {
                    staringHeight += 5;
                    break;
                }
                if (i == 2) {
                    System.out.println(String.format("Tihomir failed at %dcm after %d jumps.", staringHeight, jumps));
                    isFailed = true;
                }
            }
            if (isFailed) {
                break;
            }
        }
        if (!isFailed) {
            System.out.println(String.format("Tihomir succeeded, he jumped over %dcm after %d jumps.", height, jumps));
        }
    }
}

import java.util.Scanner;

public class P02_Skeleton {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        int recordMinutes = Integer.parseInt(scan.nextLine());
        int recordSeconds = Integer.parseInt(scan.nextLine());
        double distanceInMeters = Double.parseDouble(scan.nextLine());
        int secondsPerHundredMetres = Integer.parseInt(scan.nextLine());

        int recordInSeconds = recordMinutes * 60 + recordSeconds;
        double additionSeconds = (distanceInMeters / 120) * 2.5;

        double time = (distanceInMeters / 100) * secondsPerHundredMetres - additionSeconds;

        if (time > recordInSeconds) {
            System.out.println(String.format("No, Marin failed! He was %.3f second slower.", time - recordInSeconds));
        } else {
            System.out.println("Marin Bangiev won an Olympic quota!");
            System.out.println(String.format("His time is %.3f.", time));
        }
    }
}
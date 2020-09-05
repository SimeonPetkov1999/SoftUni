import java.util.Scanner;

public class P05_FitnessCenter {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        int visitors = Integer.parseInt(scan.nextLine());
        int back = 0;
        int chest = 0;
        int legs = 0;
        int abs = 0;
        int proteinShake = 0;
        int proteinBar = 0;
        int training = 0;
        int shopping = 0;

        for (int i = 0; i < visitors; i++) {
            String activity = scan.nextLine();
            if ("Back".equals(activity)) {
                back++;
                training++;
            } else if ("Chest".equals(activity)) {
                chest++;
                training++;
            } else if ("Legs".equals(activity)) {
                legs++;
                training++;
            } else if ("Abs".equals(activity)) {
                abs++;
                training++;
            } else if ("Protein shake".equals(activity)) {
                proteinShake++;
                shopping++;
            } else if ("Protein bar".equals(activity)) {
                proteinBar++;
                shopping++;
            }
        }
        System.out.println(String.format("%d - back", back));
        System.out.println(String.format("%d - chest", chest));
        System.out.println(String.format("%d - legs", legs));
        System.out.println(String.format("%d - abs", abs));
        System.out.println(String.format("%d - protein shake", proteinShake));
        System.out.println(String.format("%d - protein bar", proteinBar));
        System.out.println(String.format("%.2f%% - work out", (training * 1.0 / (training + shopping)) * 100));
        System.out.println(String.format("%.2f%% - protein", (shopping * 1.0 / (training + shopping)) * 100));
    }
}

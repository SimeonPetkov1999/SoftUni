import java.util.Scanner;

public class P03_Snooker {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        String stageOfTour = scan.nextLine();
        String ticketType = scan.nextLine();
        int quantity = Integer.parseInt(scan.nextLine());
        boolean pictureWithTrophy = scan.nextLine().equals("Y");

        double price = 0.0;

        switch (stageOfTour) {
            case "Quarter final":
                if ("Standard".equals(ticketType)) {
                    price = 55.50;
                } else if ("Premium".equals(ticketType)) {
                    price = 105.20;
                } else if ("VIP".equals(ticketType)) {
                    price = 118.90;
                }
                break;
            case "Semi final":
                if ("Standard".equals(ticketType)) {
                    price = 75.88;
                } else if ("Premium".equals(ticketType)) {
                    price = 125.22;
                } else if ("VIP".equals(ticketType)) {
                    price = 300.40;
                }
                break;
            case "Final":
                if ("Standard".equals(ticketType)) {
                    price = 110.10;
                } else if ("Premium".equals(ticketType)) {
                    price = 160.66;
                } else if ("VIP".equals(ticketType)) {
                    price = 400.00;
                }
                break;
        }

        price *= quantity;

        if (price > 4000) {
            price *= 0.75;
            pictureWithTrophy = false;
        } else if (price > 2500) {
            price *= 0.9;
        }

        if (pictureWithTrophy) {
            price += (quantity * 40);
        }

        System.out.println(String.format("%.2f", price));
    }
}

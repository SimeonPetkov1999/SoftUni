import java.util.Scanner;

public class P01_TennisEquipment {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        double rocketPrice = Double.parseDouble(scan.nextLine());
        int rocketCount = Integer.parseInt(scan.nextLine());
        int sneakersCount = Integer.parseInt(scan.nextLine());

        double rocketsPrice = rocketPrice * rocketCount;
        double sneakersPrice = sneakersCount * (rocketPrice / 6);
        double otherStuffPrice = (rocketsPrice + sneakersPrice) * 0.2;

        double totalSum = rocketsPrice + sneakersPrice + otherStuffPrice;
        double moneyPaidByDjokovic = Math.floor(totalSum / 8);
        double moneyPaidBySponsors = Math.ceil((totalSum / 8) * 7);
        System.out.println(String.format("Price to be paid by Djokovic %.0f", moneyPaidByDjokovic));
        System.out.println(String.format("Price to be paid by sponsors %.0f", moneyPaidBySponsors));
    }
}

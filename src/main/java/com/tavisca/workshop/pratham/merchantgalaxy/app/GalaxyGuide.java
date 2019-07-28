package com.tavisca.workshop.pratham.merchantgalaxy.app;

import com.tavisca.workshop.pratham.merchantgalaxy.Merchant;

import java.text.ParseException;
import java.util.Arrays;
import java.util.Scanner;

public class GalaxyGuide {

    public static void main(String[] args) {
        Merchant merchant = new Merchant();
        Scanner scanner = new Scanner(System.in);

        System.out.println("Welcome to \"Merchant\'s Guide to the Galaxy\"");
        while(true){
            System.out.print("Query: ");
            String input = scanner.nextLine();
            if(input.equals("exit"))
                return;
            try{
                String response = merchant.query(input);
                System.out.println("Response: " + response);
            }catch (ParseException e){
                System.err.println("Error: " + e.getMessage());
            }
        }
    }
}

using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode2022Day1 {
    class Program {
        static void Main(string[] args) {
            string filePath = @"C:\Users\Nathan Chan\Documents\Programming\Advent of Code\2022\AdventOfCode2022\AdventOfCode2022Day1\Part1Input.txt";
            List<List<int>> elfCaloricInventories = LoadInput(filePath);

            int topX = 3;
            int sumTopXCalorieInventories = SumTopXCalorieInventories(elfCaloricInventories, topX);
            Console.WriteLine("Sum of the top {0} caloric inventories is {1}", topX, sumTopXCalorieInventories);
        }

        public static List<List<int>> LoadInput(string filePath) {
            StreamReader streamReader = new StreamReader(filePath);

            List<List<int>> elfCaloricInventories = new List<List<int>>();
            string nextLine;

            List<int> elfCaloricInventory = new List<int>();
            while ((nextLine = streamReader.ReadLine()) != null) {
                if (nextLine != "") {
                    elfCaloricInventory.Add(Int32.Parse(nextLine));
                }
                else {
                    elfCaloricInventories.Add(elfCaloricInventory);
                    elfCaloricInventory = new List<int>();
                }
            }  

            return elfCaloricInventories;
        }

        public static int SumTopXCalorieInventories(List<List<int>> elfCaloricInventories, int topX) {
            List<KeyValuePair<List<int>, int>> inventoryCalories = CalculateInventoryTotalCalories(elfCaloricInventories);
            inventoryCalories = SortElfInventoriesByCalories(inventoryCalories);

            int sumTopXCalorieInventories = 0;
            for (int i = 0; i < topX; i++) {
                sumTopXCalorieInventories += inventoryCalories[i].Value;
            }
            return sumTopXCalorieInventories;
        }

        public static List<KeyValuePair<List<int>, int>> CalculateInventoryTotalCalories(List<List<int>> elfCaloricInventories) {
            List<KeyValuePair<List<int>, int>> inventoryCalories = new List<KeyValuePair<List<int>, int>>();

            foreach (List<int> elfCaloricInventory in elfCaloricInventories) {
                inventoryCalories.Add(new KeyValuePair<List<int>, int>(elfCaloricInventory, CalculateCaloriesInInventory(elfCaloricInventory)));
            }

            return inventoryCalories;
        }

        public static List<KeyValuePair<List<int>, int>> SortElfInventoriesByCalories(List<KeyValuePair<List<int>, int>> elfCaloricInventories) {
            return elfCaloricInventories.OrderByDescending(elfCaloricInventory => elfCaloricInventory.Value).ToList();
        }

        public static int CalculateCaloriesInInventory(List<int> elfCaloricInventory) {
            return Enumerable.Sum(elfCaloricInventory);
        }
    }
}

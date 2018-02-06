using System;
using System.IO;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length != 1) {
                Console.WriteLine("Please only give the input filename as first paramters");
                return;
            }

            FileStream fileStream;

            try
            {
                fileStream = new FileStream(args[0], FileMode.Open, FileAccess.Read);
            }
            catch (FileNotFoundException e) {
                Console.WriteLine(args[0] + " is not found, please give full path of the input file.");
                return;
            }

            StreamReader reader = new StreamReader(fileStream);
            String line = "";
            TripDB tripDB = new TripDB();
            int lastTripId = 0;
            int lastPayerId = 0;
            try
            {
                while ((line = reader.ReadLine()) != null)
                {
                    int numOfPeople = Int32.Parse(line);
                    if (numOfPeople == 0)
                        break;
                    lastTripId = tripDB.addTrip(numOfPeople);

                    for (int i = 0; i < numOfPeople; i++) {
                        line = reader.ReadLine();
                        int numOfPay = Int32.Parse(line);
                        lastPayerId = tripDB.addPayer(lastTripId, i, numOfPay);

                        for (int j = 0; j < numOfPay; j++) {
                            line = reader.ReadLine();
                            double price = Double.Parse(line);
                            tripDB.addPrice(lastPayerId, j, price);
                        }
                    }
                }

            } catch (Exception e) {
                Console.WriteLine("Input format is wrong.");
                return;
            }
            reader.Close();
            fileStream.Close();

            fileStream = new FileStream(args[0] + ".out", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(fileStream);
            for (int i = 0; i < tripDB.getNoOfTrip(); i++) {
                double[] remains = tripDB.getPayersRemain(i);
                for (int j = 0; j < remains.Length; j++)
                {
                    String price = "$" + Math.Abs(remains[j]);
                    if (remains[j] < 0) {
                        price = "(" + price + ")";
                    }
                    writer.WriteLine(price);
                }
                writer.WriteLine();
            }

            writer.Close();
            fileStream.Close();
        }
    }

    public class TripDB {
        private Dictionary<int, int[]> tripDict;
        private Dictionary<int, double[]> payerDict;
        private int tripId;
        private int payerId;
        public TripDB() {
            tripDict = new Dictionary<int, int[]>();
            payerDict = new Dictionary<int, double[]>();
            tripId = 0;
            payerId = 0;
        }

        public int addTrip(int n) {
            int[] payerArray = new int[n];
            tripDict.Add(tripId, payerArray);
            tripId++;
            return tripId - 1;
        }

        public int addPayer(int trip_id, int index, int noOfPay) {
            //Create price array for this payer.
            double[] priceArray = new double[noOfPay];
            payerDict.Add(payerId, priceArray);

            //Match the trip_id for this payer.
            int[] payerArray = tripDict[trip_id];
            payerArray[index] = payerId;

            payerId++;
            return payerId - 1;
        }

        public void addPrice(int payer_id, int index, double price) {
            double[] priceArray = payerDict[payer_id];
            priceArray[index] = price;
        }

        public int getNoOfTrip() {
            return tripId;
        }

        public int getNoOfPayer() {
            return payerId;
        }

        public double[] getPriceArray(int payer_id) {
            return payerDict[payer_id];
        }

        public int[] getPayerArray(int trip_id) {
            return tripDict[trip_id];
        }

        public double getTripAverage(int trip_id) {
            int[] payerArray = getPayerArray(trip_id);
            double total = 0.0;
            for (int i = 0; i < payerArray.Length; i++) {
                double[] priceArray = payerDict[payerArray[i]];
                for (int j = 0; j < priceArray.Length; j++) {
                    total = total + priceArray[j];
                }
            }
            double noOfPayer = payerArray.Length;
            double average = Math.Round(total / noOfPayer, 2);
            return average;
        }

        public double[] getPayersRemain(int trip_id) {
            int[] payerArray = getPayerArray(trip_id);
            double[] remains = new double[payerArray.Length];
            double average = getTripAverage(trip_id);
            for (int i = 0; i < payerArray.Length; i++)
            {
                double total = 0.0;
                double[] priceArray = payerDict[payerArray[i]];
                for (int j = 0; j < priceArray.Length; j++) {
                    total = total + priceArray[j];
                }
                remains[i] = Math.Round(average - total, 2);
            }
            return remains;
        }
    }
}

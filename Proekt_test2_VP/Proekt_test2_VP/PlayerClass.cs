using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proekt_test2_VP
{
    public class PlayerClass
    {
        public double Credits { get; set; }
        public double Bet { get; set; }
        public double Total { get; set; }
        public double TotalWin { get; set; }
        public int SpinsLeft { get; set; }
        public int BonusPicture { get; set; }
        public PlayerClass()
        {
            Credits = 1000;
            Bet = 5;
            Total = 0;
            TotalWin = 0;
            SpinsLeft = 0;
            BonusPicture = 0;
        }

        public double calculatePayout3(int Picture)
        {
            if (Picture == 1) return Bet * 4;

            if (Picture == 2) return Bet * 3.2;

            if (Picture == 3) return Bet * 2.8;
                              
            if (Picture == 4) return Bet * 2.4;
                              
            if (Picture == 5) return Bet * 2;
                              
            if (Picture == 6) return Bet * 1.6;
                              
            if (Picture == 7) return Bet * 1.6;
            
            return Bet * 2;
        }
        public double calculatePayout4(int Picture)
        {
            if (Picture == 1) return Bet * 20;
                              
            if (Picture == 2) return Bet * 18;
                              
            if (Picture == 3) return Bet * 16;
                              
            if (Picture == 4) return Bet * 15;
                              
            if (Picture == 5) return Bet * 14;
                              
            if (Picture == 6) return Bet * 12;
                              
            if (Picture == 7) return Bet * 12;

            return Bet * 4;
        }
        public double calculateBonusPayout(int occurances,int Picture)
        {
            if (Picture == 9) return 30 * occurances;
                                   
            if (Picture == 10) return 34.5 * occurances;
                                   
            if (Picture == 11) return 37.5 * occurances;
                                   
            if (Picture == 12) return 45 * occurances;
                                   
            if (Picture == 13) return 52.5 * occurances;
                                   
            if (Picture == 14) return 60 * occurances;

            return 0;
        }

        public void getConnected3(int Picture)
        {
            Total = Total + calculatePayout3(Picture);
        }
        public void getConnected4(int Picture)
        {
            Total = Total + calculatePayout4(Picture);
        }
        public void getBonus(int occurances)
        {
            Total = Total + calculateBonusPayout(occurances,BonusPicture);
        }

        public void getCredit()
        {
             Credits = Credits + Total;
        }
        public void getBonusTotal()
        {
             TotalWin = TotalWin + Total;
        }
        public void getBonusCredit()
        {
            Credits = Credits + TotalWin;
        }
        public void Spin()
        {
            Credits = Credits - Bet;
        }

        public void BuyFeature()
        {
            Credits = Credits - Bet * 100;
            SpinsLeft += 10;
        }
        
    }
}

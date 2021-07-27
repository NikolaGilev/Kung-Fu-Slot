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

        public void getConnected3(int Picture)
        {

            if (Picture == 1) Total = Total + Bet * 2;

            if (Picture == 2) Total = Total + Bet * 1.6;

            if (Picture == 3) Total = Total + Bet * 1.4;

            if (Picture == 4) Total = Total + Bet * 1.2;

            if (Picture == 5) Total = Total + Bet * 1;

            if (Picture == 6) Total = Total + Bet * 0.8;

            if (Picture == 7) Total = Total + Bet * 0.8;


        }
        public void getConnected4(int Picture)
        {

            if (Picture == 1) Total = Total + Bet * 10;

            if (Picture == 2) Total = Total + Bet * 9;

            if (Picture == 3) Total = Total + Bet * 8;

            if (Picture == 4) Total = Total + Bet * 7.5;

            if (Picture == 5) Total = Total + Bet * 7;

            if (Picture == 6) Total = Total + Bet * 6;

            if (Picture == 7) Total = Total + Bet * 6;
        }
        //public void getZigZag(int Picture)
        //{
        //    if (Picture == 1) Total = Total + Bet * 6;

        //    if (Picture == 2) Total = Total + Bet * 5;

        //    if (Picture == 3) Total = Total + Bet * 4;

        //    if (Picture == 4) Total = Total + Bet * 3;

        //    if (Picture == 5) Total = Total + Bet * 2;

        //    if (Picture == 6) Total = Total + Bet * 1.5;

        //    if (Picture == 7) Total = Total + Bet * 1.4;
        //}
        public void getBonus(int occurances)
        {
            double multiplier = 0;
            if (occurances == 2) multiplier = 10;
            if (occurances == 3) multiplier = 15;
            if (occurances == 4) multiplier = 20;
            if (BonusPicture == 9) Total = Total + Bet * 2 * multiplier;

            if (BonusPicture == 10) Total = Total + Bet * 2.3 * multiplier;

            if (BonusPicture == 11) Total = Total + Bet * 2.5 * multiplier;

            if (BonusPicture == 12) Total = Total + Bet * 3 *  multiplier;

            if (BonusPicture == 13) Total = Total + Bet * 3.5 * multiplier;

            if (BonusPicture == 14) Total = Total + Bet * 4 * multiplier;
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

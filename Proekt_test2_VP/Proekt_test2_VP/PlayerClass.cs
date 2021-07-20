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
        public long Bet { get; set; }
        public double Total { get; set; }
        public int SpinsLeft { get; set; }
        public PlayerClass()
        {
            Credits = 100;
            Bet = 5;
            Total = 0;
            SpinsLeft = 0;
        }

        public void getConnected3(int Picture)
        {

            if (Picture == 1) Total = Total + Bet * 2.5;

            if (Picture == 2) Total = Total + Bet * 2;

            if (Picture == 3) Total = Total + Bet * 1.5;

            if (Picture == 4) Total = Total + Bet * 1;

            if (Picture == 5) Total = Total + Bet * 0.5;

            if (Picture == 6) Total = Total + Bet * 0.4;

            if (Picture == 7) Total = Total + Bet * 0.3;


        }
        public void getConnected4(int Picture)
        {

            if (Picture == 1) Total = Total + Bet * 6;

            if (Picture == 2) Total = Total + Bet * 4;

            if (Picture == 3) Total = Total + Bet * 3;

            if (Picture == 4) Total = Total + Bet * 2;

            if (Picture == 5) Total = Total + Bet * 1;

            if (Picture == 6) Total = Total + Bet * 0.9;

            if (Picture == 7) Total = Total + Bet * 0.8;
        }
        public void getZigZag(int Picture)
        {
            if (Picture == 1) Total = Total + Bet * 6;

            if (Picture == 2) Total = Total + Bet * 5;

            if (Picture == 3) Total = Total + Bet * 4;

            if (Picture == 4) Total = Total + Bet * 3;

            if (Picture == 5) Total = Total + Bet * 2;

            if (Picture == 6) Total = Total + Bet * 1.5;

            if (Picture == 7) Total = Total + Bet * 1.4;
        }
        public double getCredit()
        {
            return Credits = Credits + Total;
            
        }
        public void Spin()
        {
            Credits = Credits - Bet;
        }

        public void BonusSpin()
        {

        }
    }
}

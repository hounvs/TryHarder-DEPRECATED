using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TryHarder.Models
{
    public class OverviewViewModel
    {
        public Scores UserScores = new Scores();
        
        void setScores(int Category, double EarlyScore, double MidScore, double LateScore)
        {
            switch(Category)
            {
                case 0: // Farming
                    UserScores.Farming[(int)Scores.Times.Early] = EarlyScore;
                    UserScores.Farming[(int)Scores.Times.Mid] = MidScore;
                    UserScores.Farming[(int)Scores.Times.Late] = LateScore;
                    break;
                case 1: // Fighting
                    UserScores.Fighting[(int)Scores.Times.Early] = EarlyScore;
                    UserScores.Fighting[(int)Scores.Times.Mid] = MidScore;
                    UserScores.Fighting[(int)Scores.Times.Late] = LateScore;
                    break;
                case 2: // Objective
                    UserScores.Objective[(int)Scores.Times.Early] = EarlyScore;
                    UserScores.Objective[(int)Scores.Times.Mid] = MidScore;
                    UserScores.Objective[(int)Scores.Times.Late] = LateScore;
                    break;
                case 3: // Efficiency
                    UserScores.Efficiency[(int)Scores.Times.Early] = EarlyScore;
                    UserScores.Efficiency[(int)Scores.Times.Mid] = MidScore;
                    UserScores.Efficiency[(int)Scores.Times.Late] = LateScore;
                    break;
                default:
                    break;
            }
        }
    }

    public class Scores
    {
        public enum Times { Early = 0, Mid, Late };

        public double[] Farming = new double[3];
        public double[] Fighting = new double[3];
        public double[] Objective = new double[3];
        public double[] Efficiency = new double[3];
    }
}
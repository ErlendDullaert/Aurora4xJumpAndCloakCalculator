using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurora4xJumpCloakCalculator.src
{
    class Calculator
    {
        private int calcDrive(int shipWeight, int driveTech)
        {
            int driveWeight = (shipWeight / (driveTech - 1));
            if (driveWeight % 50 != 0) { driveWeight += (50 - driveWeight % 50); }

            return driveWeight;
        }

        public int[] shipCalc(int initShipWeight, int jumpTech, int cloakTech)
        {
            if (cloakTech == 0)
            {
                int driveWeight = calcDrive(initShipWeight, jumpTech);
                //return ("Jump drive Weight:" + driveWeight + " Total Weight:" + (initShipWeight + driveWeight));
                return new[] {driveWeight, 0, initShipWeight + driveWeight};
            }
            else if (jumpTech == 0)
            {
                int driveWeight = calcDrive(initShipWeight, cloakTech);
                //return ("Cloak Weight:" + driveWeight + " Total Weight:" + (initShipWeight + driveWeight));
                return new[] {0, driveWeight, initShipWeight + driveWeight};
            }
            else
            {
                int jumpDrive = calcDrive(initShipWeight, jumpTech);
                int cloakDrive = calcDrive(initShipWeight, cloakTech);
                int totalShipWeight = initShipWeight + jumpDrive + cloakDrive;

                while ((totalShipWeight / jumpTech) >= jumpDrive || (totalShipWeight / cloakTech) >= cloakDrive)
                {
                    while ((totalShipWeight / jumpTech) >= jumpDrive)
                    {
                        jumpDrive += 50;
                        totalShipWeight += 50;
                    }
                    while ((totalShipWeight / cloakTech) >= cloakDrive)
                    {
                        cloakDrive += 50;
                        totalShipWeight += 50;
                    }
                }
                //return ("Jump drive Weight:" + jumpDrive + " Cloak Weight:" + cloakDrive + " Total Weight:" + totalShipWeight);
                return new[] {jumpDrive, cloakDrive, totalShipWeight};
            }
        }
    }
}

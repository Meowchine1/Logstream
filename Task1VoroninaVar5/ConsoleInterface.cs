using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1VoroninaVar5
{
    internal class ConsoleInterface
    {
        private static int action;
    

        public static void StartAction()
        {
         
            while (action != 0)
            {
                ReadAction();
                SwitchAction(action);
            }
        }

         static void ReadAction()
        {
            Console.WriteLine("Enter the number of action. To menu press 1");
            action = int.Parse(Console.ReadLine());
            

        }

        static void ShowMenu()
        {
            Console.WriteLine("1:  2:  3:  4:  5:  6:  7:  8:  9:  10:  11:  12:  13:  14:  15:  16:  ");
        }

        static void SwitchAction( int action)
        {
            while (action != 0)
            {
                switch (action) 
                {

                    case (1): 
                        {

                            ShowMenu();
                        }
                        break;
                    case (2): 
                        {
                            EF.PrintOrderbyHouses();
                        }
                        break;

                    case (3):
                        {
                            EF.PrintOrderbyHousesByRebildNeed();
                        }
                        break;
                    case (4):
                        {

                            EF.PrintOrderbyHousesLessThanMeanRebuilding();

                        }
                        break;
                    case (5):
                        {

                            EF.PrintOrderbyHousesOlderThan5yearsAgoRebuilding();
                        }
                        break;
                    case (6):
                        {

                            EF.MakeRebuildingOldestHome();
                        }
                        break;
                    case (7):
                        {

                            EF.DeleteSmallHouses();

                        }
                        break;
                    case (8):
                        {
                            EF.IncreaseSmallStreet();

                        }
                        break;
                    case (9):
                        {
                            Ado.PrintOrderbyHouses();
                        }
                        break;
                    case (10):
                        {
                            Ado.PrintOrderbyHousesByRebildNeed();
                        }
                        break;
                    case (11):
                        {
                            Ado.PrintOrderbyHousesOlderThan5yearsAgoRebuilding();

                        }
                        break;
                    case (12):
                        {

                            Ado.MakeRebuildingOldestHome();
                        }
                        break;
                    case (13):
                        {
                            Ado.DeleteSmallHouses();

                        }
                        break;
                    case (14):
                        {
                            //NOTHING AAAAAAAA
                        }
                        break;

                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1VoroninaVar5
{
    public class ConsoleInterface
    {
        private static int action = 1;
    

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
            Console.WriteLine("1: menu \n" +
                "2: Вывести список домов (номер, улица), отсортированных по давности последнего ремонта \n" +
                "3:Вывести список домов (номер, улица), отсортированных по степени потребности в ремонте \n " +
                                "(число квартир * давность ремонта). Чем дом населённей, тем выше его приоритет в очереди на капитальный ремонт. \n" +
                                " 4:Вывести список домов, ремонтированных позже среднего по базе. \n" +
                                "5:Вывести пары: {улица, число домов}, ремонтированных позднее 5 лет тому назад \n" +
                                "6:Извлечь самый старый по ремонту дом, поправить, что ремонт состоялся в текущем году.\n  " +
                                "7: Найти самый маленький по числу квартир дом (возможно их несколько), и удалить их из базы. \n" +
                                "8:Найти наименее заселённую улицу (по суммарному числу квартир всех домов), и добавить на неё дом. \n  9:  10:  11:  12:  13:  14:  15:  16:  ");
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
                            Console.WriteLine("");
                            EF.PrintOrderbyHouses();
                        }
                        break;

                    case (3):
                        {
                            Console.WriteLine("");
                            EF.PrintOrderbyHousesByRebildNeed();
                        }
                        break;
                    case (4):
                        {
                            Console.WriteLine("");
                            EF.PrintOrderbyHousesLessThanMeanRebuilding();

                        }
                        break;
                    case (5):
                        {
                            Console.WriteLine("");

                            EF.PrintOrderbyHousesOlderThan5yearsAgoRebuilding();
                        }
                        break;
                    case (6):
                        {
                            Console.WriteLine("");
                            EF.MakeRebuildingOldestHome();
                        }
                        break;
                    case (7):
                        {
                            Console.WriteLine(" ");
                            EF.DeleteSmallHouses();

                        }
                        break;
                    case (8):
                        {
                            Console.WriteLine("");
                            EF.IncreaseSmallStreet();

                        }
                        break;
                    case (9):
                        {
                            Console.WriteLine("");
                            Ado.PrintOrderbyHouses();
                        }
                        break;
                    case (10):
                        {
                            Console.WriteLine("");
                            Ado.PrintOrderbyHousesByRebildNeed();
                        }
                        break;
                    case (11):
                        {
                            Console.WriteLine("");
                            Ado.PrintOrderbyHousesLessThanMeanRebuilding();
                        }
                        break;
                    case (12):
                        {
                            Console.WriteLine("");
                            Ado.PrintOrderbyHousesOlderThan5yearsAgoRebuilding();

                        }
                        break;
                    case (13):
                        {
                            Console.WriteLine("");
                            Ado.MakeRebuildingOldestHome();
                        }
                        break;
                    case (14):
                        {
                            Console.WriteLine("");
                            Ado.DeleteSmallHouses();

                        }
                        break;
                    case (15):
                        {
                            //NOTHING AAAAAAAA
                        }
                        break;
                   

                }
            }
        }
    }
}

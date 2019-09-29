using System;

namespace IPAdresses
{
    class Program
    {
        public static int isCorrectBinary(string address)
        {
            string[] part = new string[10];
            part = address.Split('.');
            if(part.Length != 4)
            {
                Console.WriteLine("IP address has four quads");
                return 1;
            }
            else if((part[0].Length != 8) || (part[1].Length != 8) || (part[2].Length != 8)
                || (part[3].Length != 8))
            {
                Console.WriteLine("Each part of an IP address has 8 binary units");
                return 1;
            }
            else
            {
                int flag = 0;
                for(int i = 0; i < 4; i++)
                {
                    for(int j = 0; j < 8; j++)
                    {
                        if(part[i].ToCharArray()[j] != '0')
                        {
                            if(part[i].ToCharArray()[j] != '1')
                            {
                                //Console.WriteLine(part[i].ToCharArray()[j].
                                //ToString());
                                flag = 1;
                            }
                        }
                    }
                }
                if(flag == 1)
                {
                    Console.WriteLine("A binary IP address should have 0 or 1 at" +
                        " every place");
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        public static int isCorrectDecimal(string address)
        {
            string[] part = new string[10];
            part = address.Split('.');
            try
            {
                if (part.Length != 4)
                {
                    Console.WriteLine("IP address has four quads");
                    return 1;
                }
                else if (((int.Parse(part[0]) >= 0) && (int.Parse(part[0]) <= 255)) && ((int.
                    Parse(part[1])) >= 0) && (int.Parse(part[1]) <= 255) && ((int.Parse(part
                    [2])) >= 0) && (int.Parse(part[2]) <= 255) && (int.Parse(part[3]) >= 0)
                    && (int.Parse(part[3]) <= 255))
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            catch(Exception e1)
            {
                Console.WriteLine("Not an integer");
                return 1;
            }
        }

        static void Main(string[] args)
        {
            char choice = 'O';
            string address, part1;
            try
            {
                while (choice != '3')
                {
                    Console.Clear();
                    Console.WriteLine("\t\t\tIP ADDRESS CASE STUDY");
                    Console.WriteLine("\n1\t:Binary");
                    Console.WriteLine("\n2\t:Decimal");
                    Console.WriteLine("\n3\t:Exit");
                    Console.WriteLine("Enter your choice\t:");
                    choice = char.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case '1':
                            Console.WriteLine("\nEnter Address");
                            address = Console.ReadLine();
                            if(isCorrectBinary(address) == 0)
                            {
                                part1 = (address.Split('.'))[0];
                                if(part1.StartsWith("0"))
                                {
                                    Console.WriteLine("Class A");
                                }
                                else if(part1.StartsWith("10"))
                                {
                                    Console.WriteLine("Class B");
                                }
                                else if(part1.StartsWith("110"))
                                {
                                    Console.WriteLine("Class C");
                                }
                                else if(part1.StartsWith("1110"))
                                {
                                    Console.WriteLine("Class D");
                                }
                                else if (part1.StartsWith("1111"))
                                {
                                    Console.WriteLine("Class E");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Incorrect Address");
                            }
                            break;

                        case '2':
                            Console.WriteLine("\nEnter Address");
                            address = Console.ReadLine();
                            if(isCorrectDecimal(address) == 0)
                            {
                                part1 = (address.Split('.'))[0];
                                if((int.Parse(part1) >= 0) && (int.Parse(part1) <= 127))
                                {
                                    Console.WriteLine("Class A");
                                }
                                else if((int.Parse(part1) >= 128) && (int.Parse(part1) <= 191))
                                {
                                    Console.WriteLine("Class B");
                                }
                                else if((int.Parse(part1) >= 192) && (int.Parse(part1) <= 223))
                                {
                                    Console.WriteLine("Class C");
                                }
                                else if((int.Parse(part1) >= 224) && (int.Parse(part1) <= 239))
                                {
                                    Console.WriteLine("Class D");
                                }
                                else if((int.Parse(part1) >= 240) && (int.Parse(part1) <= 255))
                                {
                                    Console.WriteLine("Class E");
                                }
                                else
                                {
                                    Console.WriteLine("Incorrect Result");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Incorrect Address");
                            }
                            break;

                        case '3':
                            Console.WriteLine("Ending Program");
                            break;

                        default:
                            Console.WriteLine("Incorrect Choice");
                            break;
                    }
                    Console.ReadKey();
                }
            }
            catch(Exception e1)
            {
                Console.WriteLine("Error\n" + e1.ToString());
            }
        }
    }
}

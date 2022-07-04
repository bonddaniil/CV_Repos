using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаб7
{

    internal class Program
    {
        static Entry[] entr;
        static Hashtable hashtable;
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("/findEntry to look for an Entry,");
                Console.WriteLine("/printTable to print the table");
                Console.WriteLine("/getHash to print hashcode of Key");
                Console.WriteLine("/hashCode to count Hash func");
                Console.WriteLine("/end to finish program, /customExample if you want to use created table");
                Console.WriteLine("/getHash to print hashcode of Key, /hashCode to count Hash func");
                Console.WriteLine("/printDisciplines to print disciplines and marks of current student, /insertEntry to add own student to table");
                Console.WriteLine("/newTable to create new own table");
                Console.WriteLine("/update disciplines to update disciplines of chosen student");
                Console.WriteLine("Input command");
                string cmd = Console.ReadLine();
                if ( cmd == "/end")
                {
                    break;
                }
                else if (cmd == "/findEntry")
                {
                    Console.WriteLine("Input surname: ");
                    string surname = Console.ReadLine();
                    Console.WriteLine("Input name");
                    string Name = Console.ReadLine();
                    Key key1 = new Key(Name, surname);
                    Console.WriteLine("Serial number in table / Surname / Name / Id dudent / Birth date / Adress/ Year of entry / Avarage Grade");
                    findEntry(key1);

                }
                else if (cmd == "/removeEntry")
                {
                    Console.WriteLine("Input surname: ");
                    string surname = Console.ReadLine();
                    Console.WriteLine("Input name");
                    string Name = Console.ReadLine();
                    Key key1 = new Key(Name, surname);
                    removeEntry(key1);
                }
                else if (cmd == "/printTable")
                {
                    Console.WriteLine("Serial number in table / Surname / Name / Id dudent / Birth date / Adress/ Year of entry / Avarage Grade");
                    PrintHash();
                }
                else if (cmd == "/getHash")
                {
                    Console.WriteLine("Input surname: ");
                    string surname = Console.ReadLine();
                    Console.WriteLine("Input name");
                    string Name = Console.ReadLine();
                    Key key1 = new Key(Name, surname);
                    int gethash = getHash(key1);
                    Console.WriteLine(gethash);
                }
                else if (cmd == "/hashCode")
                {
                    Console.WriteLine("Input surname: ");
                    string surname = Console.ReadLine();
                    Console.WriteLine("Input name");
                    string Name = Console.ReadLine();
                    Key key1 = new Key(Name, surname);
                    long getHash = hashCode(key1);
                    Console.WriteLine(getHash);
                }
                else if (cmd == "/printDisciplines")
                {
                    Console.WriteLine("Input surname: ");
                    string surname = Console.ReadLine();
                    Console.WriteLine("Input name");
                    string Name = Console.ReadLine();
                    Key key1 = new Key(Name, surname);
                    hashtable.table[getHash(key1)].value.disciplines.Print();
                }
                else if (cmd == "/customExample")
                {
                    CustomExample();
                }
                else if (cmd == "/insertEntry")
                {
                    Console.WriteLine("Input surname: ");
                    string surname = Console.ReadLine();
                    Console.WriteLine("Input name");
                    string Name = Console.ReadLine();
                    Key key1 = new Key(Name, surname);
                    //
                    string id = GenerateId();
                    //
                    Console.WriteLine("Input year of birth");
                    int year = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Input month of birth");
                    int month = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Input date of birth");
                    int day = Convert.ToInt32(Console.ReadLine());
                    Date date = new Date(year, month, day);
                    //
                    LinkedList disciplines = new LinkedList();
                    while (true)
                    {
                        Console.WriteLine("/stop to finish inputing disciplines");
                        Console.WriteLine("/addNew to add new discipline");
                        Console.WriteLine("/update to update diciplines list");
                        Console.WriteLine("/countEvGrade to count evarage grade");
                        Console.WriteLine("/print to print disciplines");
                        string disCom = Console.ReadLine(); 
                        if(disCom == "/stop")
                        {
                            break;
                        }
                        else if (disCom == "/addNew")
                        {
                            Console.WriteLine("Input name of discipline: ");
                            string disName = Console.ReadLine();
                            Console.WriteLine("Input mark: ");
                            string mark = Console.ReadLine();
                            disciplines.AddFirst(disName, Convert.ToInt32(mark));
                        }
                        else if (disCom == "/update")
                        {
                            Console.WriteLine("Input name of discipline: ");
                            string disName = Console.ReadLine();
                            disciplines.updateDisciplinesList(disName);
                        }
                        else if (disCom == "/countEvGrade")
                        {
                            Console.WriteLine(disciplines.CountAverageGrade());
                        }
                        else if (disCom == "/print")
                        {
                            disciplines.Print();
                        }
                        else
                        {
                            Console.WriteLine("Incorrect data, try again");
                        }
                    }
                    //
                    Console.WriteLine("Imput adress");
                    string adress = Console.ReadLine();
                    //
                    Console.WriteLine("Input year of Entry");
                    int yearOfEntr = Convert.ToInt32(Console.ReadLine());
                    //
                    Value val = new Value(id, date, adress, yearOfEntr, disciplines, disciplines.CountAverageGrade());
                    insertEntry(key1, val);
                    Console.WriteLine();
                }
                else if (cmd == "/newTable")
                {
                    Console.WriteLine("Input size of table:");
                    int size = Convert.ToInt32(Console.ReadLine());
                    entr = new Entry[size];
                    hashtable = new Hashtable(entr, 0, size);
                    Console.WriteLine("New table was created");
                }
                else if (cmd == "/update disciplines")
                {
                    Console.WriteLine("Input surname: ");
                    string surname = Console.ReadLine();
                    Console.WriteLine("Input name");
                    string Name = Console.ReadLine();
                    Key key1 = new Key(Name, surname);
                    Console.WriteLine("Input discipline name");
                    string discipline = Console.ReadLine(); 
                    hashtable.table[getHash(key1)].value.disciplines.updateDisciplinesList(discipline);

                }
                else
                {
                    Console.WriteLine("Incorrect command");
                }
            }
            //Console.ReadLine();


        }
        static void CustomExample()
        {
            Console.WriteLine("Serial number in table / Surname / Name / Id dudent / Birth date / Adress/ Year of entry / Avarage Grade");
            entr = new Entry [5];
            Key key;
            Date date;
            LinkedList disciplines;
            disciplines = new LinkedList();
            Value value;
            string[] disNames = { "Programming", "Ads", "Computer Sience", "English" };
            string[] surnames = { "McKinney", "Joseph", "Harvey", "Farmer", "Smith", "Bruce", "Chapman", "Boone" };
            string[] name = { "Douglas", "Paul", "Buck", "Wesley", "Thomas", "Emery", "Brent", "Virgil" };
            string[] adresses = { "496 Red Timber Pike", "6640 Silver Farm", "8862 High Loop", "2463 Cotton Mount", "6671 Lazy Estates", "5733 Heather Autoroute", "6325 Harvest Knoll", "7288 Lazy Hills Via", "6926 Colonial Forest" };
            

            hashtable = new Hashtable(entr, 0, entr.Length);

            string id;
            for (int i = 0; i < surnames.Length; i++)
            {
                id = GenerateId();
                date = new Date(rnd.Next(2000, 2004), rnd.Next(0, 12), rnd.Next(1,31));
                key = new Key(name[i], surnames[i]);
                disciplines = DisMarks(disNames);
                value = new Value(id, date, adresses[i], rnd.Next(2018, 2022), disciplines, disciplines.CountAverageGrade());
                insertEntry(key, value);
                PrintHash();
                Console.WriteLine("-------------------------------------------------------");
            }
            PrintHash();
            /*while (true)
            {
                if(Console.ReadLine() == "/end")
                {
                    break;
                }
                else if(Console.ReadLine() == "/findEntry")
                {
                    Console.WriteLine("Input surname: ");
                    string surname = Console.ReadLine();
                    Console.WriteLine("Input name");
                    string Name = Console.ReadLine();
                    Key key1 = new Key(Name, surname);
                    findEntry(key1);

                }
                else if (Console.ReadLine() == "/removeEntry")
                {
                    Console.WriteLine("Input surname: ");
                    string surname = Console.ReadLine();
                    Console.WriteLine("Input name");
                    string Name = Console.ReadLine();
                    Key key1 = new Key(Name, surname);
                    removeEntry(key1);
                }
                else if(Console.ReadLine()== "/printTable")
                {
                    PrintHash();
                }
                else if (Console.ReadLine() == "/getHash")
                {
                    Console.WriteLine("Input surname: ");
                    string surname = Console.ReadLine();
                    Console.WriteLine("Input name");
                    string Name = Console.ReadLine();
                    Key key1 = new Key(Name, surname);
                    int gethash = getHash(key1);
                    Console.WriteLine(gethash);
                }
                else if (Console.ReadLine() == "/hashCode")
                {
                    Console.WriteLine("Input surname: ");
                    string surname = Console.ReadLine();
                    Console.WriteLine("Input name");
                    string Name = Console.ReadLine();
                    Key key1 = new Key(Name, surname);
                    long getHash = hashCode(key1);
                    Console.WriteLine(getHash);
                }
                else if (Console.ReadLine() == "/printDisciplines")
                {
                    Console.WriteLine("Input surname: ");
                    string surname = Console.ReadLine();
                    Console.WriteLine("Input name");
                    string Name = Console.ReadLine();
                    Key key1 = new Key(Name, surname);
                    hashtable.table[getHash(key1)].value.disciplines.Print();
                }
                else
                {
                    Console.WriteLine("Incorrect command");
                }
            }*/
        }

        static LinkedList DisMarks(string[] disNames)
        {
            
            LinkedList disciplines = new LinkedList();
            for (int i = 0; i < disNames.Length; i++)
            {
                disciplines.AddFirst(disNames[i], rnd.Next(100));
            }
            return disciplines;

        }
        static string GenerateId()
        {
            Encoding ascii = Encoding.ASCII;

            char id1 = (char)(rnd.Next(1, 26) + 96);
            char id2 = (char)(rnd.Next(1, 26) + 96);
            string id = Convert.ToString(id1)+ Convert.ToString(id2)+"-";
            
            int tmp;
            for (int i = 0; i < 6; i++)
            {
                tmp = rnd.Next(0, 9);
                id+=Convert.ToString(tmp);
            }
            return id;
        }

        static void PrintHash()
        {
            for (int i = 0; i < hashtable.size; i++)
            {
               
                if(hashtable.table[i] == null)
                {
                    Console.WriteLine($"{i}-null");
                }
                else
                {
                   if(hashtable.table[i].next == null)
                   {
                        PrintString(hashtable.table[i], i);
                   }
                   else
                   {
                        Entry current = hashtable.table[i];
                        while (current.next != null)
                        {
                            PrintString(current, i);
                            current = current.next;
                        }
                        PrintString(current, i);
                    }
                   
                }
               
            }
        }

        static void PrintString (Entry entr, int i)
        {
            Console.WriteLine($"{i}-{entr.key.lastName} {entr.key.firstName} {entr.value.studentId} {entr.value.birthDate.year}." +
                            $"{entr.value.birthDate.month}.{entr.value.birthDate.day} {entr.value.address} " +
                            $"{entr.value.yearOfEntry} {entr.value.disciplines.CountAverageGrade()}");
        }
        static void insertEntry(Key key, Value value)
        {
            int keyFin = getHash(key);
            if(hashtable.table[keyFin] == null)
            {
                Entry newEntr = new Entry(key, value);
                entr[keyFin] = newEntr;
                hashtable.loadness++;
            }
            else
            {
                Entry entry = new Entry(key, value);
                entr[keyFin].next = entry;
                hashtable.loadness++;
            }
             
            if((double)(hashtable.loadness)/(double)(hashtable.table.Length) > 0.55)//тут должно быть перегеширование
            {
                Console.WriteLine("Hashtable is too big, rehashing...");
                rehashing();
            }
            
        }

        static void rehashing()
        {
            Entry[] prevTable = hashtable.table;
            hashtable.size = hashtable.size * 2;
            Entry[] nextTable = new Entry[hashtable.size];
            for(int i = 0; i < prevTable.Length; i++)
            {
                if(prevTable[i] != null)
                {
                    nextTable[getHash(prevTable[i].key)]= prevTable[i];
                }
            }
            entr = nextTable;
            hashtable.table = entr;

        }
        static void removeEntry(Key key)
        {
            int keyFin = getHash(key);
            hashtable.loadness--;
            hashtable.table[keyFin] = null;
        }
        static void findEntry(Key key)
        {
            bool found = false;
            for (int i = 0; i < hashtable.size; i++)
            {
                if(hashtable.table[i] != null)
                {
                    if ((hashtable.table[i].key.lastName == key.lastName) && (hashtable.table[i].key.firstName == key.firstName))
                    {
                        found = true;
                        if (hashtable.table[i].next == null)
                        {
                            PrintString(hashtable.table[i], i);
                        }
                        else
                        {
                            Entry current = hashtable.table[i];
                            while (current.next != null)
                            {
                                PrintString(current, i);
                                current = current.next;
                            }
                            PrintString(current, i);
                        }
                    }
                }
            }
            if (found == false) Console.WriteLine("Incorrect data"); 
        }
        static int getHash(Key key)
        {
            long hashNum = hashCode(key);
            long keyFin = hashNum % Convert.ToInt64(hashtable.size);
            return Convert.ToInt32(keyFin);
        }
        static long hashCode(Key key)
        {
            Encoding ascii = Encoding.ASCII;

            long keyCount = 0;
            string name = key.firstName;
            string lastName = key.lastName;

            name = name.ToLower();
            byte[] decName = ascii.GetBytes(name);

            lastName = lastName.ToLower();
            byte[] decLastName = ascii.GetBytes(lastName);

            long nameInt = Decoding(decName);
            long lastNameInt = Decoding(decLastName);

            keyCount = nameInt + lastNameInt;
            

            return keyCount;
        }

        static long Decoding(byte[] str)
        {
            int counter = str.Length-1;
            long conv = 0;
            
            for (int i = 0; i < str.Length; i++)
            {
                conv += Convert.ToInt64(Math.Pow(27, counter)) * (str[i] - 96);
                counter--;
            }
            
            return conv;
        }
    }
}

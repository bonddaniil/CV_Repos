using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаб7
{
    internal class LinkedList
    {
        public DLNode head;
        

        public void AddFirst( string disciplineName, int Name)
        {
            if(head == null)
            {
                head = new DLNode(disciplineName, Name);
                head.next = head;
            }
            else
            {
                DLNode node = new DLNode(disciplineName, Name);
                node.next = head;
                DLNode current = head;
                while (current.next != head)
                {
                   current = current.next;
                }
                current.next = node;
                head = node;
            }
        }

        public void Print()
        {
            if (head == null) { Console.WriteLine("Empty"); }
            else
            {
                DLNode current = head;
                int counter = 1;
                while(current.next != head)
                {
                    Console.WriteLine($"{counter}-{current.disciplineName}-{current.grade}");
                    current = current.next;
                    counter++;
                }
                Console.WriteLine($"{counter}-{current.disciplineName}-{current.grade}");
            }
        }

        public void DeleteFirst()
        {
            DLNode current = head;
            while (current.next != head)
            {
                current = current.next;
            }
            current.next = head.next;
            head = head.next;
        }

        public void DeleteLast()
        {
            DLNode current = head;
            while (current.next.next != head) 
            { 
                current = current.next; 
            }
            current.next = head;
            head = current.next;
        }

        public void updateDisciplinesList(string disciplineName)
        {
            DLNode current = head;
            bool disFind = false;
            DLNode check = head;
            while(check != head)
            {
                if(check.disciplineName == disciplineName)
                {
                    Console.WriteLine("Incorrect data, try again");
                    break;
                }
                check = check.next;

            }
            while (true)
            {
                /*if((current.next != head) && (disFind == false))
                {
                    Console.WriteLine("Input mark from "+ disciplineName);
                    AddFirst(disciplineName, int.Parse(Console.ReadLine()));
                    break;
                }*/

                if (current.disciplineName == disciplineName)
                {
                    disFind = true;
                    Console.WriteLine("Do you want to delete this discipline? (Yes or No)");
                    string answer = Console.ReadLine();
                    if (answer == "Yes")
                    {
                        DLNode node = head;
                        while (node.next != current) { node = node.next; }
                        node.next = current.next;
                        current.next = null;
                    }
                    else if (answer == "No")
                    {
                        Console.WriteLine("Input new mark for this discipline");
                        current.grade = int.Parse(Console.ReadLine());
                    }
                    else
                    {
                        Console.WriteLine("Incorrect data");
                    }
                    break;
                }
                else if ((current.next == head) && (disFind == false))
                {
                    
                    Console.WriteLine("Input mark from " + disciplineName);
                    AddFirst(disciplineName, int.Parse(Console.ReadLine()));
                    break;
                }
                current = current.next;
            }
        }

        public double CountAverageGrade()
        {
            DLNode current = head;
            double avarage = 0;
            int counter = 1;
            while(current.next != head)
            {
                avarage+= current.grade;
                counter++;
                current = current.next; 
            }
            
            avarage += current.grade;
            avarage = avarage / counter;
            return avarage;
        }
    }
}

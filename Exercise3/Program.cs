using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3
{
    class Node
    {
        /*creates Nodes for the circular nexted list*/
        public int rollNumber;
        public string name;
        public Node next;
        public Node prev;
    }
    class Circularlist
    {
        Node LAST;

        public Circularlist()
        {
            LAST = null;
        }

        public bool Search(int rollNo, ref Node previous, ref Node current)
        {
            for (previous = current = LAST; current != null &&
                rollNo != current.rollNumber; previous = current,
                current = current.next)
            { }
            /*The above for loop traverses the list. If the specified node
             * is found then the function returns true, otherwise false.*/
            return (current != null);
        }
        public bool listEmpty()
        {
            if (LAST == null)
                return true;
            else
                return false;
        }


        public void traverse()/*Traverse the list*/
        {

            if (listEmpty())
                Console.WriteLine("\nList is empty");
            else
            {
                Console.WriteLine("\nRecords in the ascending order of " +
                    "roll numbers are:\n");
                Node currentNode;
                for (currentNode = LAST; currentNode != null;
                    currentNode = currentNode.next)
                    Console.Write(currentNode.rollNumber + "   "
                        + currentNode.name + "\n");
            }
        }
        public void firstNode()
        {
            if (!listEmpty())
                Console.WriteLine("\nList is empty");
            else
                Console.WriteLine("\nThe first record in the list is:\n\n " + LAST.next.rollNumber + "    " + LAST.next.name);
        }
        public void addNode()/*Adds a new node*/
        {
            int rollNo;
            string nm;
            Console.Write("\nEnter the roll number of the student: ");
            rollNo = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nEnter the name of the student: ");
            nm = Console.ReadLine();
            Node newnode = new Node();
            newnode.rollNumber = rollNo;
            newnode.name = nm;
            /*Checks if the list is empty*/
            if (LAST == null || rollNo <= LAST.rollNumber)
            {
                if ((LAST != null) && (rollNo == LAST.rollNumber))
                {
                    Console.WriteLine("\nDuplicate roll numbers not allowed");
                    return;
                }
                newnode.next = LAST;
                if (LAST != null)
                    LAST.prev = newnode;
                newnode.prev = null;
                LAST = newnode;
                return;
            }
            Node previous, current;
            for (current = previous = LAST; current != null &&
                rollNo >= current.rollNumber; previous = current, current =
                current.next)
            {
                if (rollNo == current.rollNumber)
                {
                    Console.WriteLine("\nDuplicate roll numbers not allowed");
                    return;
                }
            }
            /*On the execution of the above for loop, prev and
             * current will point to those nodes
             * between which the new node is to be inserted.*/
            newnode.next = current;
            newnode.prev = previous;
            /*If the node is to be inserted at the end of the list.*/
            if (current == null)
            {
                newnode.next = null;
                previous.next = newnode;
                return;
            }
            current.prev = newnode;
            previous.next = newnode;
        }
        public bool delNode(int rollNo)/*Deletes the specified node*/
        {
            Node previous, current;
            previous = current = null;
            if (Search(rollNo, ref previous, ref current) == false)
                return false;
            if (current == LAST)/*If the first node is to be deleted*/
            {
                LAST = LAST.next;
                if (LAST != null)
                    LAST.prev = null;
                return true;
            }
            if (current.next == null)/*If the last node is to be deleted*/
            {
                previous.next = null;
                return false;
            }
            /*If the node to be deleted is in between the list then the
             * following lines of code is execute.*/
            previous.next = current.next;
            current.next.prev = previous;
            return true;
        }
        static void Main(string[] args )
        {
            Circularlist obj = new Circularlist();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. View all the records in the list");
                    Console.WriteLine("2. Search for a record in the list");
                    Console.WriteLine("3. Display the first record in the list");
                    Console.WriteLine("4. Add a record to the list");
                    Console.WriteLine("5. Delete a record from the list");
                    Console.WriteLine("6. Exit");
                    Console.WriteLine("\nEnter your choice (1-4): ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.traverse();
                            }
                            break;
                        case '2':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                Node prev, curr;
                                prev = curr = null;
                                Console.Write("\nEnter the roll number of the student whose record is to be searched: ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.Search(num,ref prev, ref curr) == false)
                                Console.WriteLine("\nRecord not found");
                                else
                                {
                                    Console.WriteLine("\nRecord found");
                                    Console.WriteLine("\nRoll number: " + curr.rollNumber);
                                    Console.WriteLine("\nName: " + curr.name);
                                }
                            }
                            break;
                        case '3':
                            {
                                obj.firstNode();
                            }
                            break;
                        case '4':
                            {
                                obj.addNode();
                            }
                            break;
                        case '5':
                            {
                                if (obj.listEmpty())
                                {
                                    Console.WriteLine("\nList is Empty");
                                    break;
                                }
                                Console.Write("\nEnter the roll number of the student" +
                                    " whose record is to be deleted: ");
                                int rollNo = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (obj.delNode(rollNo) == false)
                                    Console.WriteLine("Record not found");
                                else
                                    Console.WriteLine("Record with roll number " + rollNo + " deleted \n");
                            }
                            break;
                        case '6':
                            return;
                        default:
                            {
                                Console.WriteLine("Invalid option");
                                break;
                            }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }
}


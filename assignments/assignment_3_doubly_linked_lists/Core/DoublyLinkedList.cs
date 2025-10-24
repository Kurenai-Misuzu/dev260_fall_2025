using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Reflection.Metadata.Ecma335;

namespace Week4DoublyLinkedLists.Core
{
    /*
     * ========================================
     * ASSIGNMENT 3: DOUBLY LINKED LIST IMPLEMENTATION
     * ========================================
     * 
     * 🎯 IMPLEMENTATION GUIDE:
     * Step 1: Node<T> class (already provided below)
     * Step 2: Basic DoublyLinkedList<T> structure (already provided below)
     * Step 3: Add Methods (AddFirst, AddLast, Insert) - START HERE
     * Step 4: Traversal Methods (DisplayForward, DisplayBackward, ToArray)
     * Step 5: Search Methods (Contains, Find, IndexOf)
     * Step 6: Remove Methods (RemoveFirst, RemoveLast, Remove, RemoveAt)
     * Step 7: Advanced Operations (Clear, Reverse)
     * 
     * 💡 TESTING STRATEGY:
     * - Implement each step completely before moving to the next
     * - Use the CoreListDemo to test each step as you complete it
     * - Focus on pointer manipulation - draw diagrams if helpful
     * - Handle edge cases: empty list, single element, etc.
     * 
     * 📚 KEY RESOURCES:
     * - GeeksforGeeks Doubly Linked List: https://www.geeksforgeeks.org/dsa/doubly-linked-list/
     * - Each TODO comment includes specific reference links
     * 
     * 🚀 START WITH: Step 3 (Add Methods) - look for "STEP 3A" below
     */
    /// <summary>
    /// STEP 1: Node class for doubly linked list (✅ COMPLETED)
    /// Contains data and pointers to next and previous nodes
    /// 📚 Reference: https://www.geeksforgeeks.org/dsa/doubly-linked-list/#node-structure
    /// </summary>
    /// <typeparam name="T">Type of data stored in the node</typeparam>
    public class Node<T>
    {
        /// <summary>
        /// Data stored in this node
        /// </summary>
        public T Data { get; set; }
        
        /// <summary>
        /// Reference to the next node in the list
        /// </summary>
        public Node<T>? Next { get; set; }
        
        /// <summary>
        /// Reference to the previous node in the list
        /// </summary>
        public Node<T>? Previous { get; set; }
        
        /// <summary>
        /// Constructor to create a new node with data
        /// </summary>
        /// <param name="data">Data to store in the node</param>
        public Node(T data)
        {
            Data = data;
            Next = null;
            Previous = null;
        }
        
        /// <summary>
        /// String representation of the node for debugging
        /// </summary>
        /// <returns>String representation of the node's data</returns>
        public override string ToString()
        {
            return Data?.ToString() ?? "null";
        }
    }
    
    /// <summary>
    /// STEP 2: Generic doubly linked list implementation (✅ STRUCTURE COMPLETED)
    /// Supports forward and backward traversal with efficient insertion/deletion
    /// 📚 Reference: https://www.geeksforgeeks.org/dsa/doubly-linked-list/
    /// 
    /// 🎯 YOUR TASK: Implement the methods marked with TODO in Steps 3-7
    /// </summary>
    /// <typeparam name="T">Type of elements stored in the list</typeparam>
    public class DoublyLinkedList<T> : IEnumerable<T>
    {
        #region Private Fields
        
        private Node<T>? head;     // First node in the list
        private Node<T>? tail;     // Last node in the list
        private int count;         // Number of elements in the list
        
        #endregion
        
        #region Public Properties
        
        /// <summary>
        /// Gets the number of elements in the list
        /// </summary>
        public int Count => count;
        
        /// <summary>
        /// Gets whether the list is empty
        /// </summary>
        public bool IsEmpty => count == 0;
        
        /// <summary>
        /// Gets the first node in the list (readonly)
        /// </summary>
        public Node<T>? First => head;
        
        /// <summary>
        /// Gets the last node in the list (readonly)
        /// </summary>
        public Node<T>? Last => tail;
        
        #endregion
        
        #region Constructor
        
        /// <summary>
        /// Initialize an empty doubly linked list
        /// </summary>
        public DoublyLinkedList()
        {
            head = null;
            tail = null;
            count = 0;
        }
        
        #endregion
        
        #region Step 3: Add Methods - TODO: Students implement these step by step
        
        /// <summary>
        /// STEP 3A: Add an item to the beginning of the list
        /// Time Complexity: O(1)
        /// 📚 Reference: https://www.geeksforgeeks.org/dsa/introduction-and-insertion-in-a-doubly-linked-list/#insertion-at-the-beginning-in-doubly-linked-list
        /// </summary>
        /// <param name="item">Item to add</param>
        public void AddFirst(T item)
        {
            // TODO: Step 3a - Implement adding to the beginning of the list
            // 1. Create a new node with the item
            // 2. If list is empty: set both head and tail to new node
            // 3. If list is not empty:
            //    - Set new node's Next to current head
            //    - Set current head's Previous to new node
            //    - Update head to new node
            // 4. Increment count
            // 📖 See: https://www.geeksforgeeks.org/dsa/introduction-and-insertion-in-a-doubly-linked-list/#insertion-at-the-beginning-in-doubly-linked-list

            // create new node
            Node<T> newNode = new Node<T>(item);
            // if head isn't null move node to node next. otherwise make newnode the tail aswell
            if (head != null)
            {
                newNode.Previous = null;
                newNode.Next = head;
                head.Previous = newNode;

            }
            else
            {
                // make newnode tail
                tail = newNode;
            }
            // make newnode head
            head = newNode;
            // increment count
            count++;
            //throw new NotImplementedException("TODO: Step 3a - Implement AddFirst method");
        }
        
        /// <summary>
        /// STEP 3B: Add an item to the end of the list
        /// Time Complexity: O(1)
        /// 📚 Reference: https://www.geeksforgeeks.org/dsa/introduction-and-insertion-in-a-doubly-linked-list/#insertion-at-the-end-in-doubly-linked-list
        /// </summary>
        /// <param name="item">Item to add</param>
        public void AddLast(T item)
        {
            // TODO: Step 3b - Implement adding to the end of the list
            // 1. Create a new node with the item
            // 2. If list is empty: set both head and tail to new node
            // 3. If list is not empty:
            //    - Set current tail's Next to new node
            //    - Set new node's Previous to current tail
            //    - Update tail to new node
            // 4. Increment count
            // 📖 See: https://www.geeksforgeeks.org/dsa/introduction-and-insertion-in-a-doubly-linked-list/#insertion-at-the-end-in-doubly-linked-list
            
            // create newnode
            Node<T> newNode = new Node<T>(item);
            // check if list is empty, if not empty, put at the end
            if (!IsEmpty)
            {
                newNode.Next = null;
                tail.Next = newNode;
                newNode.Previous = tail;
            }
            // if list is empty make the newnode the head
            else
            {
                head = newNode;
            }
            // make new node tail
            tail = newNode;
            // incrememt count
            count++;

            //throw new NotImplementedException("TODO: Step 3b - Implement AddLast method");
        }
        
        /// <summary>
        /// Convenience method - calls AddLast
        /// </summary>
        /// <param name="item">Item to add</param>
        public void Add(T item) => AddLast(item);
        
        /// <summary>
        /// STEP 3C: Insert an item at a specific index
        /// Time Complexity: O(n)
        /// 📚 Reference: https://www.geeksforgeeks.org/dsa/introduction-and-insertion-in-a-doubly-linked-list/#insertion-after-a-given-node-in-doubly-linked-list
        /// </summary>
        /// <param name="index">Index to insert at (0-based)</param>
        /// <param name="item">Item to insert</param>
        public void Insert(int index, T item)
        {
            // TODO: Step 3c - Implement inserting at a specific position
            // 1. Validate index range (0 to count inclusive)
            // 2. Handle special cases:
            //    - If index == 0: call AddFirst
            //    - If index == count: call AddLast
            // 3. For middle insertion:
            //    - Traverse to the position (use GetNodeAt helper)
            //    - Create new node
            //    - Update pointers: new node's Next/Previous and surrounding nodes
            // 4. Increment count
            // 📖 See: https://www.geeksforgeeks.org/dsa/introduction-and-insertion-in-a-doubly-linked-list/#insertion-after-a-given-node-in-doubly-linked-list
            
            // if first call addfirst
            // if last call addlast
            if (index == 0)
            {
                AddFirst(item);
            }
            else if (index == count)
            {
                AddLast(item);
            }
            else
            {
                // getnode at the index and add the new node right before it
                Node<T> indexNode = GetNodeAt(index);
                Node<T> newNode = new Node<T>(item);
                newNode.Next = indexNode;
                newNode.Previous = indexNode.Previous;
                if (indexNode.Previous != null)
                {
                    indexNode.Previous.Next = newNode;    
                }
                indexNode.Previous = newNode;
                // increment count
                count++;
            }

            //throw new NotImplementedException("TODO: Step 3c - Implement Insert method");
        }
        
        #endregion
        
        #region Step 4: Traversal and Display Methods - TODO: Students implement these
        
        /// <summary>
        /// STEP 4A: Display the list in forward direction  
        /// 📚 Reference: https://www.geeksforgeeks.org/dsa/traversal-in-doubly-linked-list/#forward-traversal
        /// </summary>
        public void DisplayForward()
        {
            // TODO: Step 4a - Implement forward traversal and display
            // 1. Start from head node
            // 2. Traverse using Next pointers until null
            // 3. Print each node's data with proper formatting
            // 4. Show empty list message if list is empty
            // 📖 See: https://www.geeksforgeeks.org/dsa/traversal-in-doubly-linked-list/#forward-traversal

            // if list is empty display []
            if (IsEmpty)
            {
                Console.WriteLine("[] ");
            }

            // create a tempnode and keep traversing through the whole list
            Node<T>? indexNode = head;
            for( int i = 0; i < count; i++)
            {
                Console.WriteLine($"[{indexNode.ToString()}] ");
                indexNode = indexNode.Next;
            }

            //throw new NotImplementedException("TODO: Step 4a - Implement DisplayForward method");
        }
        
        /// <summary>
        /// STEP 4B: Display the list in backward direction
        /// 📚 Reference: https://www.geeksforgeeks.org/dsa/traversal-in-doubly-linked-list/#backward-traversal
        /// </summary>
        public void DisplayBackward()
        {
            // TODO: Step 4b - Implement backward traversal and display
            // 1. Start from tail node
            // 2. Traverse using Previous pointers until null
            // 3. Print each node's data with proper formatting
            // 4. Show empty list message if list is empty
            // This demonstrates the power of doubly linked lists!
            // 📖 See: https://www.geeksforgeeks.org/dsa/traversal-in-doubly-linked-list/#backward-traversal

            // display [] if empty
            if (IsEmpty)
            {
                Console.WriteLine("[] ");
            }
            // create a tempnode and keep traversing through the whole list through the back
            Node<T>? indexNode = tail;
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"[{indexNode.ToString()}]");
                indexNode = indexNode.Previous;
            }
            
            //throw new NotImplementedException("TODO: Step 4b - Implement DisplayBackward method");
        }
        
        /// <summary>
        /// STEP 4C: Convert the list to an array
        /// Time Complexity: O(n)
        /// 📚 Reference: https://www.geeksforgeeks.org/dsa/traversal-in-doubly-linked-list/
        /// </summary>
        /// <returns>Array containing all list elements</returns>
        public T[] ToArray()
        {
            // TODO: Step 4c - Implement array conversion
            // 1. Create array of size count
            // 2. Traverse the list and copy elements to array
            // 3. Return the populated array
            // 📖 See: https://www.geeksforgeeks.org/dsa/traversal-in-doubly-linked-list/

            // create new array
            T[] newArray = new T[count];
            // if empty return empty array
            if (IsEmpty)
            {
                return newArray;
            }
            // create tempnode to go through list
            Node<T>? indexNode = head;
            for (int i = 0; i < count; i++)
            {
                // put the data of indexnode into array
                newArray[i] = indexNode.Data;
                // go to next
                indexNode = indexNode.Next;
            }

            // return array
            return newArray;
            

            //throw new NotImplementedException("TODO: Step 4c - Implement ToArray method");
        }
        
        #endregion
        
        #region Step 5: Search Methods - TODO: Students implement these
        
        /// <summary>
        /// STEP 5A: Check if the list contains a specific item
        /// Time Complexity: O(n)
        /// 📚 Reference: https://www.geeksforgeeks.org/dsa/search-an-element-in-a-doubly-linked-list/
        /// </summary>
        /// <param name="item">Item to check for</param>
        /// <returns>True if item is in the list</returns>
        public bool Contains(T item)
        {
            // TODO: Step 5a - Implement contains check
            // 1. Traverse the list from head to tail
            // 2. Compare each node's data with the item
            // 3. Return true if found, false if not found
            // 📖 See: https://www.geeksforgeeks.org/dsa/search-an-element-in-a-doubly-linked-list/

            // return false if array is empty
            if (IsEmpty)
            {
                return false;
            }
            // create temp indexnode set to head
            Node<T>? indexNode = head;
            // traverse the list
            for (int i = 0; i < count; i++)
            {
                // check if item equals data
                if (Equals(indexNode.Data, item))
                {
                    // return true if found
                    return true;
                }
                indexNode = indexNode.Next;
            }
            // will only be calledif item could not be found
            return false;

            //throw new NotImplementedException("TODO: Step 5a - Implement Contains method");
        }
        
        /// <summary>
        /// STEP 5B: Find the first node containing the specified item
        /// Time Complexity: O(n)
        /// 📚 Reference: https://www.geeksforgeeks.org/dsa/search-an-element-in-a-doubly-linked-list/
        /// </summary>
        /// <param name="item">Item to find</param>
        /// <returns>Node containing the item, or null if not found</returns>
        public Node<T>? Find(T item)
        {
            // TODO: Step 5b - Implement find method
            // 1. Traverse the list from head to tail
            // 2. Compare each node's data with the item
            // 3. Return the node if found, null if not found
            // 📖 See: https://www.geeksforgeeks.org/dsa/search-an-element-in-a-doubly-linked-list/

            // code very similar to Contains function, but returns Node instead of bool
            if (IsEmpty)
            {
                return null;
            }
            Node<T>? indexNode = head;
            for (int i = 0; i < count; i++)
            {
                if (Equals(indexNode.Data, item))
                {
                    return indexNode;
                }
                indexNode = indexNode.Next;
            }
            return null;
            
            //throw new NotImplementedException("TODO: Step 5b - Implement Find method");
        }
        
        /// <summary>
        /// STEP 5C: Find the index of an item
        /// Time Complexity: O(n)
        /// 📚 Reference: https://www.geeksforgeeks.org/dsa/search-an-element-in-a-doubly-linked-list/
        /// </summary>
        /// <param name="item">Item to find</param>
        /// <returns>Index of the item, or -1 if not found</returns>
        public int IndexOf(T item)
        {
            // TODO: Step 5c - Implement IndexOf method
            // 1. Traverse the list from head to tail
            // 2. Keep track of current index
            // 3. Compare each node's data with the item
            // 4. Return index if found, -1 if not found
            // 📖 See: https://www.geeksforgeeks.org/dsa/search-an-element-in-a-doubly-linked-list/
            
            // very similar to Contains and Find functions
            // returns -1 if item could not be found
            // returns index of node if could be found.
            if (IsEmpty)
            {
                return -1;
            }
            Node<T>? indexNode = head;
            int index = 0;
            for (int i = 0; i < count; i++)
            {
                if (Equals(indexNode.Data, item))
                {
                    return index;
                }
                indexNode = indexNode.Next;
                index++;
            }
            return -1;
            
            //throw new NotImplementedException("TODO: Step 5c - Implement IndexOf method");
        }
        
        #endregion
        
        #region Step 6: Remove Methods - TODO: Students implement these
        
        /// <summary>
        /// STEP 6A: Remove the first item in the list
        /// Time Complexity: O(1)
        /// 📚 Reference: https://www.geeksforgeeks.org/dsa/delete-a-node-in-a-doubly-linked-list/#deletion-at-the-beginning-in-doubly-linked-list
        /// </summary>
        /// <returns>The removed item</returns>
        public T RemoveFirst()
        {
            // TODO: Step 6a - Implement remove first
            // 1. Check if list is empty (throw exception if empty)
            // 2. Store the data to return
            // 3. Update head to head.Next
            // 4. If new head is not null, set its Previous to null
            // 5. If list becomes empty, set tail to null
            // 6. Decrement count
            // 7. Return the stored data
            // 📖 See: https://www.geeksforgeeks.org/dsa/delete-a-node-in-a-doubly-linked-list/#deletion-at-the-beginning-in-doubly-linked-list

            // check if list is empty
            if (head == null || tail == null || count == 0)
            {
                throw new Exception("List is empty!");
            }

            // create T set to head
            T returnData = head.Data;
            // if there is more than 1 item in the list
            if (head.Next != null)
            {
                // set head to headnext and set prev to null. makes headnext the first item in the list
                head = head.Next;
                head.Previous = null;
            }
            // if only item in the list
            else
            {
                // set head and tail to null
                head = null;
                tail = null;
            }
            // decrement count
            count--;
            // return deleted data
            return returnData;

            //throw new NotImplementedException("TODO: Step 6a - Implement RemoveFirst method");
        }
        
        /// <summary>
        /// STEP 6B: Remove the last item in the list
        /// Time Complexity: O(1)
        /// 📚 Reference: https://www.geeksforgeeks.org/dsa/delete-a-node-in-a-doubly-linked-list/#deletion-at-the-end-in-doubly-linked-list
        /// </summary>
        /// <returns>The removed item</returns>
        public T RemoveLast()
        {
            // TODO: Step 6b - Implement remove last
            // 1. Check if list is empty (throw exception if empty)
            // 2. Store the data to return
            // 3. Update tail to tail.Previous
            // 4. If new tail is not null, set its Next to null
            // 5. If list becomes empty, set head to null
            // 6. Decrement count
            // 7. Return the stored data
            // 📖 See: https://www.geeksforgeeks.org/dsa/delete-a-node-in-a-doubly-linked-list/#deletion-at-the-end-in-doubly-linked-list

            // check if list is empty
            if (head == null || tail == null || count == 0)
            {
                throw new Exception("List is empty!");
            }
            // create T set to tail
            T returnData = tail.Data;
            // if more than 1 item in list
            if (tail.Previous != null)
            {
                // set tailprev to the tail making it tailprev the last item in the list
                tail = tail.Previous;
                tail.Next = null;
            }
            // if only item in the list
            else
            {
                // set head and tail to null
                head = null;
                tail = null;
            }
            // decrement count
            count--;
            // return deleted data
            return returnData;

            //throw new NotImplementedException("TODO: Step 6b - Implement RemoveLast method");
        }
        
        /// <summary>
        /// STEP 6C: Remove the first occurrence of an item
        /// Time Complexity: O(n)
        /// 📚 Reference: https://www.geeksforgeeks.org/dsa/delete-a-node-in-a-doubly-linked-list/
        /// </summary>
        /// <param name="item">Item to remove</param>
        /// <returns>True if item was found and removed</returns>
        public bool Remove(T item)
        {
            // TODO: Step 6c - Implement remove by value
            // 1. Find the node containing the item (use Find method or traverse)
            // 2. If not found, return false
            // 3. If found, call RemoveNode helper method
            // 4. Return true
            // 📖 See: https://www.geeksforgeeks.org/dsa/delete-a-node-in-a-doubly-linked-list/

            // find the node of the item
            Node<T>? indexNode = Find(item);
            // if null (either list is empty or item could not be found) return false
            if (indexNode == null)
            {
                return false;
            }
            // delete node if it could be found
            RemoveNode(indexNode);
            return true;
            
            //throw new NotImplementedException("TODO: Step 6c - Implement Remove method");
        }
        
        /// <summary>
        /// STEP 6D: Remove item at a specific index
        /// Time Complexity: O(n)
        /// 📚 Reference: https://www.geeksforgeeks.org/dsa/delete-a-node-in-a-doubly-linked-list/#deletion-at-a-specific-position-in-doubly-linked-list
        /// </summary>
        /// <param name="index">Index to remove (0-based)</param>
        /// <returns>The removed item</returns>
        public T RemoveAt(int index)
        {
            // TODO: Step 6d - Implement remove at index
            // 1. Validate index range (0 to count-1)
            // 2. Handle special cases:
            //    - If index == 0: call RemoveFirst
            //    - If index == count-1: call RemoveLast
            // 3. For middle removal:
            //    - Get the node at index (use GetNodeAt helper)
            //    - Store data to return
            //    - Call RemoveNode helper method
            // 4. Return the stored data
            // 📖 See: https://www.geeksforgeeks.org/dsa/delete-a-node-in-a-doubly-linked-list/#deletion-at-a-specific-position-in-doubly-linked-list

            // get node using getnode (index validation is done in this method)
            Node<T> indexNode = GetNodeAt(index);
            // save the data to a temporary variable
            T returnData = indexNode.Data;
            // remove indexnode
            RemoveNode(indexNode);

            // return the data from the deleted node
            return returnData;

            //throw new NotImplementedException("TODO: Step 6d - Implement RemoveAt method");
        }
        
        #endregion
        
        #region Step 7: Advanced Operations - TODO: Students implement these
        
        /// <summary>
        /// STEP 7A: Remove all items from the list
        /// Time Complexity: O(1)
        /// 📚 Reference: https://docs.microsoft.com/en-us/dotnet/standard/collections/
        /// </summary>
        public void Clear()
        {
            // TODO: Step 7a - Implement clear
            // 1. Set head and tail to null
            // 2. Set count to 0
            // Note: In C#, garbage collection will handle memory cleanup
            // 📖 See: https://docs.microsoft.com/en-us/dotnet/standard/collections/

            // set tail head to null and count to 0
            head = null;
            tail = null;
            count = 0;
            
            //throw new NotImplementedException("TODO: Step 7a - Implement Clear method");
        }
        
        /// <summary>
        /// STEP 7B: Reverse the list in-place
        /// Time Complexity: O(n)
        /// 📚 Reference: https://www.geeksforgeeks.org/dsa/reverse-a-doubly-linked-list/
        /// </summary>
        public void Reverse()
        {
            // TODO: Step 7b - Implement reverse
            // 1. Check if list is empty or has only one element
            // 2. Traverse the list and swap Next and Previous pointers for each node
            // 3. Swap head and tail pointers
            // This is the power of doubly linked lists - easy reversal!
            // 📖 See: https://www.geeksforgeeks.org/dsa/reverse-a-doubly-linked-list/

            // list is has more than 2 elements
            if (count > 2)
            {
                // create indexnode and a tempnode
                Node<T>? indexNode = head;
                Node<T>? tempNode = head; // needed for swap 
                for (int i = 0; i < count; i++)
                {
                    // set tempnode to next
                    tempNode = tempNode.Next;
                    // swap
                    indexNode.Next = indexNode.Previous;
                    indexNode.Previous = tempNode;
                    indexNode = tempNode;
                }
                // swap
                tempNode = head;
                head = tail;
                tail = tempNode;

            }
            // if list has less than 2 elements there is no need to reverse anythign
            
            //throw new NotImplementedException("TODO: Step 7b - Implement Reverse method");
        }

        #endregion

        #region Helper Methods - TODO: Students may need these for advanced operations

        /// <summary>
        /// Get node at specific index (helper for internal use)
        /// Optimizes traversal by starting from head or tail based on index
        /// Used by Insert, RemoveAt, and other positional operations
        /// 📚 Reference: https://www.geeksforgeeks.org/dsa/traversal-in-doubly-linked-list/
        /// </summary>
        /// <param name="index">Index to get node at (0-based)</param>
        /// <returns>Node at the specified index</returns>
        private Node<T> GetNodeAt(int index)
        {
            // TODO: Helper Method - Implement optimized node retrieval
            // 1. Validate index range (0 to count-1)
            // 2. Optimize traversal direction:
            //    - If index < count/2: start from head and go forward
            //    - If index >= count/2: start from tail and go backward
            // 3. Traverse to the specified index
            // 4. Return the node at that position
            // Hint: This optimization makes operations on large lists more efficient
            // 📖 See: https://www.geeksforgeeks.org/dsa/traversal-in-doubly-linked-list/

            // check if index is valid
            if (index < 0 || index > count - 1)
            {
                // invalid
                throw new Exception("Invalid index");
            }

            // if list is empty
            if (head == null || tail == null)
            {
                throw new Exception("List is empty");
            }

            // create temp indexnode
            Node<T>? indexNode = head;
            // if index is less than half count start at head
            // otherwise start at tail
            if (index < count / 2)
            {
                // head start
                indexNode = head;
                // traverse list
                for (int i = 0; i < index; i++)
                {
                    if (indexNode != null)
                    {
                        indexNode = indexNode.Next;
                    }

                }

            }
            else
            {
                // tail start (set indexnode to tail)
                indexNode = tail;
                // traverse list
                for (int i = 0; i < count - index - 1; i++)
                {
                    if (indexNode != null)
                    {
                        indexNode = indexNode.Previous;
                    }

                }

            }
            // if indexnode is null throw error
            if (indexNode == null)
            {
                throw new Exception("Null error");
            }

            // return indexnode
            return indexNode!;

            // /throw new NotImplementedException("TODO: Helper - Implement GetNodeAt helper method");
        }
        
        /// <summary>
        /// Remove a specific node from the list (helper method)
        /// Handles all the pointer manipulation for node removal
        /// Used by Remove, RemoveAt, and other removal operations
        /// 📚 Reference: https://www.geeksforgeeks.org/dsa/delete-a-node-in-a-doubly-linked-list/
        /// </summary>
        /// <param name="node">Node to remove (must not be null)</param>
        private void RemoveNode(Node<T> node)
        {
            // TODO: Helper Method - Implement node removal logic
            // Handle all cases for removing a node:
            // 1. Only node in list (node == head == tail)
            // 2. First node (node == head, but not tail)
            // 3. Last node (node == tail, but not head)
            // 4. Middle node (node has both Previous and Next)
            // 
            // For each case, update the appropriate pointers:
            // - Update Previous node's Next pointer
            // - Update Next node's Previous pointer
            // - Update head/tail if necessary
            // - Decrement count
            // 📖 See: https://www.geeksforgeeks.org/dsa/delete-a-node-in-a-doubly-linked-list/

            // remove first if head
            // remove last if tail
            if (node == head)
            {
                RemoveFirst();
            }
            else if (node == tail)
            {
                RemoveLast();
            }
            else
            {
                // set previousnext to next and nextprevious to previous
                node.Previous.Next = node.Next;
                node.Next.Previous = node.Previous;
                node.Previous = null;
                node.Next = null;
                // decrement count
                count--;
            }

            //throw new NotImplementedException("TODO: Helper - Implement RemoveNode helper method");
        }
        
        #endregion
        
        #region IEnumerable Implementation
        
        /// <summary>
        /// Get enumerator for foreach support
        /// </summary>
        /// <returns>Enumerator for the list</returns>
        public IEnumerator<T> GetEnumerator()
        {
            Node<T>? current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
        
        /// <summary>
        /// Non-generic enumerator implementation
        /// </summary>
        /// <returns>Non-generic enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        
        #endregion
        
        #region Display Methods for Testing and Debugging
        
        /// <summary>
        /// Display detailed information about the list structure
        /// Perfect for testing and understanding the list state
        /// </summary>
        public void DisplayInfo()
        {
            Console.WriteLine("=== DOUBLY LINKED LIST STATE ===");
            Console.WriteLine($"Count: {Count}");
            Console.WriteLine($"IsEmpty: {IsEmpty}");
            Console.WriteLine($"First: {(head?.Data?.ToString() ?? "null")}");
            Console.WriteLine($"Last: {(tail?.Data?.ToString() ?? "null")}");
            Console.WriteLine();
            
            // Show both traversal directions
            try
            {
                DisplayForward();
            }
            catch (NotImplementedException)
            {
                Console.WriteLine("Forward:  [TODO: Implement DisplayForward in Step 4a]");
            }
            
            try
            {
                DisplayBackward();
            }
            catch (NotImplementedException)
            {
                Console.WriteLine("Backward: [TODO: Implement DisplayBackward in Step 4b]");
            }
            
            Console.WriteLine();
        }
        
        #endregion
    }
}
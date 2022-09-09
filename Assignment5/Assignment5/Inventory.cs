using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment5
{
    public class Inventory
    {
        // The dictionary items consist of the item and the quantity
        private Dictionary<Item, int> items;

        public int AvailableSlots
        {
            get
            {
                return availableSlots;
            }
        }

        public int MaxSlots
        {
            get
            {
                return MaxSlots;
            }
        }


        // The available slots to add item, once it's 0, you cannot add any more items.
        private int availableSlots;

        // The max available slots which is set only in the constructor.
        private int maxSlots;
        public Inventory(int slots)
        {
            availableSlots = maxSlots;
            maxSlots = slots;
        }

        /// <summary>
        /// Removes all the items, and restore the original number of slots.
        /// </summary>
        public void Reset()
        {
            items.Clear();
            availableSlots = maxSlots;
        }

        /// <summary>
        /// Removes the item from the items dictionary if the count is 1 otherwise decrease the quantity.
        /// </summary>
        /// <param name="name">The item name</param>
        /// <param name="found">The item if found</param>
        /// <returns>True if you find the item, and false if it does not exist.</returns>
        bool TakeItem(string name, out Item found)
        {
            foreach (var item in items)
            {
                if (item.Key.Name.CompareTo(name) == 0)
                {
                    found = item.Key;
                    return true;
                }
            }
            found = null;
            return false;
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Checks if there is space for a unique item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool AddItem(Item item)
        {
            // Add it in the items dictionary and increment it the number if it already exist
            // Reduce the slot once it's been added.
            // returns false if the inventory is full
            List<Item> itms = ListAllItems();
            foreach (var its in itms)
            {
                if (its == item)
                {
                    items[its] += 1;
                    return true;
                }
            }
            if (availableSlots == 0)
            {
                return false;
            }
            if (items.Count == 0)
            {
                items = new Dictionary<Item, int>();
            }
            items.Add(item, 1);
            availableSlots -= 1;
            return true;
            //throw new NotImplementedException();
        }

        /// <summary>
        /// remove item from items
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool RemoveItem(Item item)
        {
            // Add it in the items dictionary and increment it the number if it already exist
            // Reduce the slot once it's been added.
            // returns false if the inventory is full
            List<Item> itms = ListAllItems();
            foreach (var its in itms)
            {
                if (its == item)
                {
                    items.Remove(its);
                    availableSlots += 1;
                    return true;
                }
            }
            return false;
            //throw new NotImplementedException();
        }

        /// <summary>
        /// remove item from items
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        void ResetItem(Item item)
        {
            // Add it in the items dictionary and increment it the number if it already exist
            // Reduce the slot once it's been added.
            // returns false if the inventory is full
            items.Clear();
            availableSlots = maxSlots;
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Iterates through the dictionary and create a list of all the items.
        /// </summary>
        /// <returns></returns>
        List<Item> ListAllItems()
        {
            // use a foreach loop to iterate through the key value pairs and duplicate the item base on the quantity.
            List<Item> itms = new List<Item>();
            foreach (var its in items)
            {
                itms.Add(its.Key);
            }
            return itms;
            //throw new NotImplementedException();
        }
    }
}
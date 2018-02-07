using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class LinkedList<T>
    {
        class ListItem
        {
            public T Item { get; }
            public ListItem Next { get; set; }

            public ListItem(T o)
            {
                Item = o;
            }

            public override string ToString()
            {
                return Item.ToString();
            }
        }

        // Fields
        private ListItem _firstItem = null;
        private ListItem _lastItem = null;
        private int _itemCount = 0;

        // Properties
        public T First
        {
            get
            {
                if (_firstItem != null)
                {
                    return _firstItem.Item;
                }
                return default(T);
            }
        }

        public object Last
        {
            get
            {
                if (_lastItem != null)
                {
                    return _lastItem.Item;
                }
                return null;
            }
        }

        public int Count => _itemCount;

        // Methods
        public object Items(int index)
        {
            if (index < 0 || index > Count)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                ListItem item = _firstItem;
                while (index > 0)
                {
                    item = item.Next;
                    index--;
                }
                return item.Item;
            }
        }

        public void InsertFirst(T o)
        {
            ListItem listItem = new ListItem(o);

            if (_lastItem == null)
            {
                _lastItem = listItem;
            }
            listItem.Next = _firstItem;
            _firstItem = listItem;
            _itemCount++;
        }

        public void InsertLast(T o)
        {
            ListItem listItem = new ListItem(o);

            if (_firstItem == null)
            {
                _firstItem = listItem;
            }
            else
            {
                _lastItem.Next = listItem;
            }
            _lastItem = listItem;
            _itemCount++;
        }

        public void RemoveAt(int index)
        {
            if (index != 0)
            {
                GetListItemAtIndex(index - 1).Next = GetListItemAtIndex(index).Next;

                if (index == _itemCount - 1)
                {
                    _lastItem = GetListItemAtIndex(index - 1);
                    _lastItem.Next = null;
                }
            }
            else
            {
                _firstItem = GetListItemAtIndex(index).Next;
            }

            _itemCount--;
        }

        private ListItem GetListItemAtIndex(int index)
        {
            if (index < 0 || index > Count)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                ListItem item = _firstItem;

                while (index > 0)
                {
                    item = item.Next;
                    index--;
                }

                return item;
            }
        }

        public override string ToString()
        {
            string output = "";
            ListItem item = _firstItem;

            // output: item1 + " | " + item2...
            while (item != null)
            {
                output += item.Item + "|";
                item = item.Next;
            }

            return output.TrimEnd('|');
        }
    }
}
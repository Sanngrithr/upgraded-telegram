using System;
using System.Collections.Generic;

namespace Aufgabe_10
{
    public class TreeElement<T>
    {
        public dynamic item;
        public TreeElement<T> parent;
        public List<TreeElement<T>> children;
        private int generation = 0;

        public TreeElement(dynamic item)
        {
            this.item = item;
        }

        public void addChild(TreeElement<T> node)
        {
            children.Add(node);
            node.parent = this;
        }

        
        public void removeChild(TreeElement<T> node)
        {
            children.Remove(node);
        }

        public void PrintTree(TreeElement<T> node)
        {
            generation++;

            for(int i = 0; i < generation; i++)
            {
                Console.Write("*");
            }

            Console.WriteLine(item.ToString());

            foreach(var element in children)
            {
                PrintTree(element);
                generation--;
            }
        }
    }
}
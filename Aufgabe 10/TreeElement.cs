using System;
using System.Collections.Generic;

namespace Aufgabe_10
{
    public class TreeElement<T>
    {
        public dynamic item;
        public TreeElement<T> parent;
        public List<TreeElement<T>> children = new List<TreeElement<T>>();
        private int generation = 0;

        public TreeElement(dynamic item)
        {
            this.item = item;
        }

        public void addChild(TreeElement<T> node)
        {
            children.Add(node);
            node.parent = this;
            node.generation = node.parent.generation + 1;
        }

        
        public void removeChild(TreeElement<T> node)
        {
            children.Remove(node);
        }

        public void PrintTree()
        {
            for(int i = 0; i < generation; i++)
            {
                Console.Write("*");
            }

            Console.WriteLine(item.ToString());

            foreach(var element in children)
            {
                element.PrintTree();
            }
        }
        
        public void ForEach(Action<TreeElement<T>> function)
        {
            function(this);
            for(int i = 0; i < this.children.Count; i++)
            {
                this.children[i].ForEach(function);
            }
        }

        public static void WriteNode(TreeElement<T> node)
        {
            Console.Write(node.item.ToString() + " | ");
        }

    }
}
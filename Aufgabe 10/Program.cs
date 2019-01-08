using System;

namespace Aufgabe_10
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeElement<String> root = new TreeElement<String>("root");
            TreeElement<String> child1 = new TreeElement<String>("child1");
            TreeElement<String> child2 = new TreeElement<String>("child2");
            TreeElement<String> child11 = new TreeElement<String>("child11");
            TreeElement<String> child12 = new TreeElement<String>("child12");
            TreeElement<String> child121 = new TreeElement<String>("child121");
            TreeElement<String> child13 = new TreeElement<String>("child13");
            TreeElement<String> child21 = new TreeElement<String>("child21");

            root.addChild(child1);
            root.addChild(child2);
            child1.addChild(child11);
            child1.addChild(child12);
            child12.addChild(child121);
            child1.addChild(child13);
            child2.addChild(child21);

            root.PrintTree();
        }
    }
}

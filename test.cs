using System;
using System.Reflection;
class Program {
    static void Main() {
        try {
            var asm = Assembly.LoadFrom("MetierMemoire\\bin\\MetierMemoire.dll");
            var type = asm.GetType("MetierMemoire.Service1");
            var obj = Activator.CreateInstance(type);
            Console.WriteLine("Service1 instantiated successfully.");
        } catch (Exception ex) {
            Console.WriteLine(ex.ToString());
        }
    }
}

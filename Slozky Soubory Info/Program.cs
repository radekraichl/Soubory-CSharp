using System.IO;
using static System.Console;

namespace Slozky_Soubory_Info
{
    class Program
    {
        static void Main()
        {
            string slozka = @"..\..\..\slozka";
            string soubor = @"..\..\..\slozka\soubor.txt";

            Directory.CreateDirectory(slozka);

            //File.WriteAllText(soubor, "Ahoj");

            FileInfo fi = new FileInfo(soubor);

            WriteLine("*** File ***");
            WriteLine("GetAttributes:               {0}", File.GetAttributes(soubor).ToString());
            WriteLine("GetCreationTime:             {0}", File.GetCreationTime(soubor));
            WriteLine("GetLastWriteTime:            {0}", File.GetLastWriteTime(soubor));
            WriteLine("GetLastAccessTime:           {0}", File.GetLastAccessTime(soubor));

            WriteLine("\n*** FileInfo ***");
            WriteLine("Name:                        {0}", fi.Name);
            WriteLine("FullName:                    {0}", fi.FullName);
            WriteLine("Directory:                   {0}", fi.Directory);
            WriteLine("Length:                      {0}", fi.Length);
            WriteLine("Extension:                   {0}", fi.Extension);
            WriteLine("CreationTime:                {0}", fi.CreationTime);
            WriteLine("LastWriteTime:               {0}", fi.LastWriteTime);
            WriteLine("LastWriteTimeUtc:            {0}", fi.LastWriteTimeUtc);

            WriteLine("\n*** Directory ***");
            WriteLine("Exists:                      {0}", Directory.Exists(slozka));
            WriteLine("GetCreationTime:             {0}", Directory.GetCreationTime(slozka));
            WriteLine("GetLastAccessTime:           {0}", Directory.GetLastAccessTime(slozka));
            WriteLine("GetLastWriteTime:            {0}", Directory.GetLastWriteTime(slozka));
            WriteLine("GetParent:                   {0}", Directory.GetParent(slozka));
            WriteLine("GetDirectoryRoot:            {0}", Directory.GetDirectoryRoot(slozka));

            WriteLine("\n*** Path ***");
            WriteLine("GetRandomFileName:           {0}", Path.GetRandomFileName());
            WriteLine("GetTempPath:                 {0}", Path.GetTempPath());
        }
    }
}

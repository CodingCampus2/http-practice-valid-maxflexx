using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Crud crud = new Crud();
            string method = "";
            if (args.Length >= 1)
            {
                method = args[0];
                method = method.Trim().ToLower();
            }
            switch (method)
            {
                case "get":
                {
                    bool isSorted = false;
                    string id = "";
                    if (args.Length >= 3 && args[1].Contains("sorted"))
                    {
                        isSorted = args[2].Contains("True");
                    }
                    else if (args.Length >= 3 && args[1].Contains("id"))
                    {
                        id = args[2];
                    }
                    if (id.Length == 0)
                    {
                        Console.WriteLine(await crud.GetList(isSorted));
                    }
                    else
                    {
                        Console.WriteLine(await crud.GetSingle(id));
                    }
                    break;
                }
                case "post":
                {
                    SomeData some = new SomeData();
                    if (args.Length >= 2)
                    {
                        some = JsonConvert.DeserializeObject<SomeData>(args[1]);
                    }
                    Console.WriteLine(await crud.Create(some));
                    break;
                }
                case "put":
                    {
                        string id = "";
                        if (args.Length >= 3 && args[1].Contains("id"))
                        {
                            id = args[2];
                        }
                        SomeData some = new SomeData();
                        if (args.Length >= 4)
                        {
                            some = JsonConvert.DeserializeObject<SomeData>(args[3]);
                        }

                        Console.WriteLine(await crud.Update(id, some));
                        break;
                    }
                case "delete":
                    {
                        string id = "";
                        SomeData some = new SomeData();
                        if (args.Length >= 3 && args[1].Contains("id"))
                        {
                            id = args[2];
                        }
                        Console.WriteLine(await crud.Delete(id));
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Invalid http method");
                        break;
                    }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

namespace TestIronPython
{
	class Program
	{
		static void Main(string[] args)
		{
			ScriptEngine engine = Python.CreateEngine();
			engine.Runtime.LoadAssembly(Assembly.LoadFile(@"C:\Users\Edhar_Menhel\Desktop\compile.dll"));
			
			ICollection<string> searchPaths = engine.GetSearchPaths();
			searchPaths.Add(@"C:\Python27\Lib\site-packages\ccxt");
			searchPaths.Add(@"C:\Python27\Lib\site-packages\requests");
			searchPaths.Add(@"C:\Python27\Lib");
			engine.SetSearchPaths(searchPaths);

			ScriptScope scope = engine.Runtime.ImportModule("ccxt");

			IEnumerable<string> list = ((IEnumerable<object>)scope.GetVariable("exchanges")).Cast<string>();
			Console.WriteLine(string.Join(",", list));

			// var marketType = scope.GetVariable("binance");
			// var marketInstance = engine.Operations.CreateInstance(marketType);
			// var result = marketInstance.fetch_order_book("BTC/ETH");
			// Console.WriteLine(result);

			Console.ReadKey();
		}
	}
}

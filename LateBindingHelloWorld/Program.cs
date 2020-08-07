using LateBindingHelloWorld.Contracts;
using LateBindingHelloWorld.Module;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace LateBindingHelloWorld
{
	class Program
	{
		static void Main(string[] args)
		{
			//Find the assembly path
			var assemblyPath = Path.Combine( Path.GetDirectoryName( Assembly.GetExecutingAssembly().Location ), "LateBindingHelloWorld.Module.dll");

			//Load the assembly
			var assembly = Assembly.LoadFile(assemblyPath);

			//Load all types that implement the ILateBoundSample interface
			var types = assembly.GetTypes().Where(p => typeof(ILateBoundSample).IsAssignableFrom(p)).ToList();
			if (types.Any())
			{
				//Create an instance of that class
				var lateBoundSample = (ILateBoundSample)Activator.CreateInstance(types.First());
				
				//Execute the method 
				lateBoundSample.HelloWorld();
			}
		}
	}
}

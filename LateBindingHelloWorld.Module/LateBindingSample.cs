using LateBindingHelloWorld.Contracts;
using System;

namespace LateBindingHelloWorld.Module
{
	public class LateBindingSample : ILateBoundSample
	{
		public void HelloWorld()
		{
			Console.WriteLine("Hello world with late binding");
		}
	}
}

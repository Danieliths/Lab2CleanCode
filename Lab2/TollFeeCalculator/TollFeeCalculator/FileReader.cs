using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollFeeCalculator
{
	public class FileReader
	{
		public string Read(string path)
		{
			string indata;
			try
			{
				indata = System.IO.File.ReadAllText(path);
				return indata;
			}
			catch (Exception)
			{
				return "Could not read file.";
			}
		}
	}
}

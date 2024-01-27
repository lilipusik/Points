using System.Collections.Generic;
using System.IO;
using System.Linq;
using PointLib;

namespace FormsApp
{
	class MyFormat
	{
		public static List<List<string>> Deserialize(FileStream fs)
		{
			List<List<string>> list = new List<List<string>>();
			using (var r = new StreamReader(fs))
			{
				string line;
				while ((line = r.ReadLine()) != null)
				{
					line = line.Replace("(", "").Replace(")", "").Replace(" ", "");
					list.Add(line.Split(',').ToList());
				}
			}
			return list;
		}

		public static void Serialize(FileStream fs, Point[] points)
		{
			using (var sw = new StreamWriter(fs))
				points.ToList().ForEach(x => sw.WriteLine(x.ToString()));
		}
	}
}

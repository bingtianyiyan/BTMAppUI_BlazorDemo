using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
	public class FileInfo
	{
		public string Name { get; set; }
		public long Size { get; set; }
		public string Type { get; set; }
		public byte[] Content { get; set; }
	}
}

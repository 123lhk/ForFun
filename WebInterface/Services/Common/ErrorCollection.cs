using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebInterface.Services.Common
{
	public class ErrorCollection
	{
		public ErrorCollection()
		{
			 Errors = new List<string>();
		}

		public List<string> Errors { get; set; }

		public bool HasError
		{
			get { return Errors.Any(); }
		}
	}
}
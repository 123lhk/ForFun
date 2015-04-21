using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebInterface.Services.Common
{
	public class DetailBase
	{
		public DetailBase()
		{
			ErrorCollection = new ErrorCollection();
		}

		public ErrorCollection ErrorCollection { get; set; }
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace WebInterface.Common.Interface
{
	public interface IViewMapper<TDetail, TModel>
	{
		TDetail MapToDetail(TModel model);

		void MapToModel(TDetail detail, TModel model);
	}
}
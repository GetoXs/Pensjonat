using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PensjonatApp.DS;
using PensjonatApp.Tools;

namespace PensjonatApp.Helpers
{
	class RachunkiHelper
	{
		public static int dodajRachunek(bool zaplacono, decimal? wartosc)
		{
			return TablesManager.Manager.RachunkiTableAdapter.Insert(zaplacono, wartosc);
		}
		public static int edytujRachunek(int Original_id_rachunku, bool zaplacono, decimal? wartosc)
		{
			return TablesManager.Manager.RachunkiTableAdapter.UpdateById(zaplacono, wartosc, Original_id_rachunku);
		}
		public static int kasujRachunek(int id_rachunku)
		{
			return TablesManager.Manager.RachunkiTableAdapter.DeleteById(id_rachunku);
		}
		public static int lastIdRachunek()
		{
			return (int)TablesManager.Manager.RachunkiTableAdapter.ScalarQueryLastId();
		}
	}
}

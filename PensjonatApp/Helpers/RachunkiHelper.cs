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
		public static int dodajRachunek(bool zaplacono)
		{
			return TablesManager.Manager.RachunkiTableAdapter.Insert(zaplacono);
		}
		public static int edytujRachunek(int Original_id_rachunku, bool zaplacono)
		{
			return TablesManager.Manager.RachunkiTableAdapter.UpdateById(zaplacono, Original_id_rachunku);
		}
		public static int kasujRachunek(int id_rachunku)
		{
			return TablesManager.Manager.RachunkiTableAdapter.DeleteById(id_rachunku);
		}
	}
}

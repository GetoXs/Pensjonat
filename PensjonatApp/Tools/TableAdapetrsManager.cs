using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PensjonatApp.DS.KlienciDSTableAdapters;
using PensjonatApp.DS.PobytyDSTableAdapters;
using PensjonatApp.DS.PokojeDSTableAdapters;
using PensjonatApp.DS.PosilkiDSTableAdapters;
using PensjonatApp.DS.PracownicyDSTableAdapters;
using PensjonatApp.DS.RachunkiDSTableAdapters;
using PensjonatApp.DS.RezerwacjeDSTableAdapters;
using PensjonatApp.DS.UslugiDSTableAdapters;
using PensjonatApp.DS.WyposazeniaDSTableAdapters;

namespace PensjonatApp.Tools
{
	/// <summary>
	///TableAdapterManager is used to coordinate TableAdapters in the dataset to enable Hierarchical Update scenarios
	///</summary>
	public class TablesManager
	{
		private static readonly TablesManager _mgr = new TablesManager();

		public static TablesManager Manager
		{
			get
			{
				return _mgr;
			}
		}

		public KlienciTableAdapter KlienciTableAdapter { get; private set;}

		public Miejscowosci_slownikTableAdapter Miejscowosci_slownikTableAdapter { get; private set; }

		public PobytyTableAdapter PobytyTableAdapter { get; private set; }

		public PokojeTableAdapter PokojeTableAdapter { get; private set; }

		public Pokoje_slownikTableAdapter Pokoje_slownikTableAdapter { get; private set; }

		public PosilkiTableAdapter PosilkiTableAdapter { get; private set; }

		public Posilki_slownikTableAdapter Posilki_slownikTableAdapter { get; private set; }

		public PracownicyTableAdapter PracownicyTableAdapter { get; private set; }

		public Pracownicy_slownikTableAdapter Pracownicy_slownikTableAdapter { get; private set; }

        public RabatyTableAdapter RabatyTableAdapter { get; private set; }

		public RachunkiTableAdapter RachunkiTableAdapter { get; private set; }

		public RezerwacjeTableAdapter RezerwacjeTableAdapter { get; private set; }

		public UslugiTableAdapter UslugiTableAdapter { get; private set; }

		public Uslugi_slownikTableAdapter Uslugi_slownikTableAdapter { get; private set; }

		public WyposazeniaTableAdapter WyposazeniaTableAdapter { get; private set; }

		public Wyposazenia_slownikTableAdapter Wyposazenia_slownikTableAdapter { get; private set; }

		private global::System.Data.IDbConnection _connection;

		public global::System.Data.IDbConnection Connection
		{
			get
			{
				if ((this._connection != null))
				{
					return this._connection;
				}
				if (((this.KlienciTableAdapter != null)
							&& (this.KlienciTableAdapter.Connection != null)))
				{
					return this.KlienciTableAdapter.Connection;
				}
				if (((this.Miejscowosci_slownikTableAdapter != null)
							&& (this.Miejscowosci_slownikTableAdapter.Connection != null)))
				{
					return this.Miejscowosci_slownikTableAdapter.Connection;
				}
				if (((this.PobytyTableAdapter != null)
							&& (this.PobytyTableAdapter.Connection != null)))
				{
					return this.PobytyTableAdapter.Connection;
				}
				if (((this.PokojeTableAdapter != null)
							&& (this.PokojeTableAdapter.Connection != null)))
				{
					return this.PokojeTableAdapter.Connection;
				}
				if (((this.Pokoje_slownikTableAdapter != null)
							&& (this.Pokoje_slownikTableAdapter.Connection != null)))
				{
					return this.Pokoje_slownikTableAdapter.Connection;
				}
				if (((this.PosilkiTableAdapter != null)
							&& (this.PosilkiTableAdapter.Connection != null)))
				{
					return this.PosilkiTableAdapter.Connection;
				}
				if (((this.Posilki_slownikTableAdapter != null)
							&& (this.Posilki_slownikTableAdapter.Connection != null)))
				{
					return this.Posilki_slownikTableAdapter.Connection;
				}
				if (((this.PracownicyTableAdapter != null)
							&& (this.PracownicyTableAdapter.Connection != null)))
				{
					return this.PracownicyTableAdapter.Connection;
				}
				if (((this.Pracownicy_slownikTableAdapter != null)
							&& (this.Pracownicy_slownikTableAdapter.Connection != null)))
				{
					return this.Pracownicy_slownikTableAdapter.Connection;
				}
				if (((this.RachunkiTableAdapter != null)
							&& (this.RachunkiTableAdapter.Connection != null)))
				{
					return this.RachunkiTableAdapter.Connection;
				}
				if (((this.RezerwacjeTableAdapter != null)
							&& (this.RezerwacjeTableAdapter.Connection != null)))
				{
					return this.RezerwacjeTableAdapter.Connection;
				}
				if (((this.UslugiTableAdapter != null)
							&& (this.UslugiTableAdapter.Connection != null)))
				{
					return this.UslugiTableAdapter.Connection;
				}
				if (((this.Uslugi_slownikTableAdapter != null)
							&& (this.Uslugi_slownikTableAdapter.Connection != null)))
				{
					return this.Uslugi_slownikTableAdapter.Connection;
				}
				if (((this.WyposazeniaTableAdapter != null)
							&& (this.WyposazeniaTableAdapter.Connection != null)))
				{
					return this.WyposazeniaTableAdapter.Connection;
				}
				if (((this.Wyposazenia_slownikTableAdapter != null)
							&& (this.Wyposazenia_slownikTableAdapter.Connection != null)))
				{
					return this.Wyposazenia_slownikTableAdapter.Connection;
				}
				return null;
			}
			private set
			{
				this._connection = value;
			}
		}

		private TablesManager()
		{
			this.KlienciTableAdapter = new KlienciTableAdapter();
			this.Miejscowosci_slownikTableAdapter = new Miejscowosci_slownikTableAdapter();
			this.PobytyTableAdapter = new PobytyTableAdapter();
			this.Pokoje_slownikTableAdapter = new Pokoje_slownikTableAdapter();
			this.PokojeTableAdapter = new PokojeTableAdapter();
			this.Posilki_slownikTableAdapter = new Posilki_slownikTableAdapter();
			this.PosilkiTableAdapter = new PosilkiTableAdapter();
			this.Pracownicy_slownikTableAdapter = new Pracownicy_slownikTableAdapter();
            this.PracownicyTableAdapter = new PracownicyTableAdapter();
            this.RabatyTableAdapter = new RabatyTableAdapter();
			this.RachunkiTableAdapter = new RachunkiTableAdapter();
			this.RezerwacjeTableAdapter = new RezerwacjeTableAdapter();
			this.Uslugi_slownikTableAdapter = new Uslugi_slownikTableAdapter();
			this.UslugiTableAdapter = new UslugiTableAdapter();
			this.Wyposazenia_slownikTableAdapter = new Wyposazenia_slownikTableAdapter();
			this.WyposazeniaTableAdapter = new WyposazeniaTableAdapter();
		}

		static TablesManager() 
		{}
	}

}

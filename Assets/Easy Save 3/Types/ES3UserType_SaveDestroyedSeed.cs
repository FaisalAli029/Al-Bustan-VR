using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute()]
	public class ES3UserType_SaveDestroyedSeed : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_SaveDestroyedSeed() : base(typeof(SaveDestroyedSeed)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (SaveDestroyedSeed)obj;
			
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (SaveDestroyedSeed)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_SaveDestroyedSeedArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_SaveDestroyedSeedArray() : base(typeof(SaveDestroyedSeed[]), ES3UserType_SaveDestroyedSeed.Instance)
		{
			Instance = this;
		}
	}
}
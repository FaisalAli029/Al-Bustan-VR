using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("guid")]
	public class ES3UserType_SaveDestroyed : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_SaveDestroyed() : base(typeof(SaveDestroyedSeed)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (SaveDestroyedSeed)obj;
			
			writer.WritePrivateField("guid", instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (SaveDestroyedSeed)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "guid":
					instance = (SaveDestroyedSeed)reader.SetPrivateField("guid", reader.Read<System.String>(), instance);
					break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_SaveDestroyedArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_SaveDestroyedArray() : base(typeof(SaveDestroyedSeed[]), ES3UserType_SaveDestroyed.Instance)
		{
			Instance = this;
		}
	}
}
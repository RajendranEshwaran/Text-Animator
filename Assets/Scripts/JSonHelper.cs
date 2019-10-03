using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

	public static class JSonHelper
	{
		public static T[] FromJson<T>(string json)
		{
			Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
		return wrapper.ObjectName;
		}

		public static string ToJson<T>(T[] array)
		{
			Wrapper<T> wrapper = new Wrapper<T>();
		wrapper.ObjectName = array;
			return JsonUtility.ToJson(wrapper);
		}

		public static string ToJson<T>(T[] array, bool prettyPrint)
		{
			Wrapper<T> wrapper = new Wrapper<T>();
		wrapper.ObjectName = array;
			return JsonUtility.ToJson(wrapper, prettyPrint);
		}

	[System.Serializable]
		private class Wrapper<T>
		{
			public T[] ObjectName;
		}
	}

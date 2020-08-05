using System.Runtime.InteropServices;
using UnityEngine;

public class KeyChain
{

#if UNITY_IOS
	[DllImport("__Internal")]
	private static extern void DeleteKeyDeviceId();

	[DllImport("__Internal")]
	private static extern void SetKeyDeviceId(string deviceId);

	[DllImport("__Internal")]
	private static extern string GetKeyDeviceId();

	public static void DeleteKeyId()
	{
		DeleteKeyDeviceId();
	}

	public static void SetKeyId(string deviceId)
	{
		SetKeyDeviceId(deviceId);
	}

	public static string GetKeyId()
	{
		return GetKeyDeviceId();
	}
#endif

}

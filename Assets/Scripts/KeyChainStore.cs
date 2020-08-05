using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyChainStore : MonoBehaviour
{
	private string UUID = "";
	private string keyChainSavedUUID = "";

#if UNITY_IOS
	private void OnGUI()
	{
		GUILayoutOption[] layoutOptions = new GUILayoutOption[] { };

		if (GUILayout.Button("UUID", layoutOptions))
		{
			UUID = SystemInfo.deviceUniqueIdentifier;
		}
		GUILayout.TextArea(UUID, layoutOptions);

		if (GUILayout.Button("Save KeyCahin UUID", layoutOptions))
		{
			KeyChain.SetKeyId(SystemInfo.deviceUniqueIdentifier);
		}

		if (GUILayout.Button("Load KeyChain UUID", layoutOptions))
		{
			keyChainSavedUUID = KeyChain.GetKeyId();
		}
		GUILayout.TextArea(keyChainSavedUUID, layoutOptions);

		if (GUILayout.Button("Remove KeyChain UUID"))
		{
			KeyChain.DeleteKeyId();
		}
	}
#endif

}

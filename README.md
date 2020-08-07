# Unity IOS KeyChain Plugin

This is for unity which developer needs to use ios keychain to store information.

# UICKeyChainStore

We get UICKeyChainStore to make using keychain API easy from https://github.com/kishikawakatsumi/UICKeyChainStore.

We can know the details from UICKeyChainStore documents.

Thanks for kishikawakatsumi.

# Unity KeyChain Plugin - iOS

We need to define the native methods which we want to execute in unity.

For example, we define an extern C method to remove keychain information.

```
#import "UnityKeyChainPlugin.h"
#import "UICKeyChainStore.h"

NSString* _keyforDevice = @"DeviceId";

@implementation UnityKeyChainPlugin
+(void)DeleteKeyDeviceId
{
	[UICKeyChainStore removeItemForKey:_keyforDevice];
}
@end


extern "C" 
{
	void DeleteKeyDeviceId()
	{
		[UnityKeyChainPlugin DeleteKeyDeviceId];
	}
}
```

Then we import objective-c and objective-c++ files in `Plugins/iOS` folder.

# Unity KeyChain Plugin - Unity 

After ios part has been done, we will define extern methods in C# files to call the native methods.

```
using System.Runtime.InteropServices;

public class KeyChain
{
	[DllImport("__Internal")]
	private static extern void DeleteKeyDeviceId();
}
```

In the end, We can use these native methods in Unity.
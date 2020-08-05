#import "UnityKeyChainPlugin.h"
#import "UICKeyChainStore.h"

NSString* _keyforDevice = @"DeviceId";

@implementation UnityKeyChainPlugin

+(char*)GetKeyDeviceId
{
    NSString* deivceId = [UICKeyChainStore stringForKey:_keyforDevice];
 
    if (deivceId == nil || [deivceId isEqualToString:@""]) {
		deivceId = @"";
    }
 
    NSString* json = [NSString stringWithFormat:@"{\"deviceId\":\"%@\"}", deivceId];
 
    return StrCopy([json UTF8String]);
}

+(void)SetKeyDeviceId:(const char*)deviceId
{
	NSString* nsDeviceId = [NSString stringWithUTF8String:deviceId];
	
	[UICKeyChainStore setString:nsDeviceId forKey:_keyforDevice];
}

+(void)DeleteKeyDeviceId
{
	[UICKeyChainStore removeItemForKey:_keyforDevice];
}

char* StrCopy(const char* str)
{
	if (str == NULL)
	{
		return NULL;
	}

	char* source = (char*)malloc(strlen(str) + 1);
	strcpy(source, str);
	return source;
}

@end

extern "C" 
{
	void DeleteKeyDeviceId()
	{
		[UnityKeyChainPlugin DeleteKeyDeviceId];
	}

	void SetKeyDeviceId(const char* deviceId)
	{
		[UnityKeyChainPlugin SetKeyDeviceId:deviceId];
	}

	char* GetKeyDeviceId()
	{
		[UnityKeyChainPlugin GetKeyDeviceId];
	}
}
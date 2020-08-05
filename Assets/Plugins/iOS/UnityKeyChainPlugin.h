#import <Foundation/Foundation.h>

@interface UnityKeyChainPlugin

+(char*)GetKeyDeviceId;
+(void)SetKeyDeviceId:(const char*)deviceId;
+(void)DeleteKeyDeviceId;

@end

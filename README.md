# Logger
A simple log creator for C#

# Under Development - So on release some features could change
- File opened tests
- Permissions tests
- Travis building is failing
- Sync with Nuget Package
- More tests

# How to use

Just:
- Install nuget: Install-Package AndLogger
- Use: 
``` 
 Log.LogDebug(<method>, <message>);
 Log.LogInfo(<method>, <message>);
 Log.LogWarning(<message>);
 Log.LogError(<method>, <message>, <exception>); 
```
- A file .txt will be created inside the application folder

# Example
```
[2016-06-20 09:10:24]|DEBUG|
[2016-06-20 09:10:24]|DEBUG|debug_message
[2016-06-20 09:10:24]|DEBUG|METHOD:|debug_message
[2016-06-20 09:10:24]|DEBUG|METHOD:|debug_message
[2016-06-20 09:10:24]|DEBUG|METHOD:method x|debug_message
```

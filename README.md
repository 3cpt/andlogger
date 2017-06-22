# Logger
A simple log creator for C#

[![Build Status](https://travis-ci.org/iamhandre/andlogger.svg?branch=master)](https://travis-ci.org/iamhandre/Andlogger)

# Under Development

- .Net Core
- Json File implementations
- File opened tests
- Permissions tests
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
- A file .txt will be created inside the application folder that uses this library

# Example
```
[2016-06-20 09:10:24]|DEBUG|
[2016-06-20 09:10:24]|INFO|info_message
[2016-06-20 09:10:24]|WARNING|METHOD:Method2|warning_message
[2016-06-20 09:10:24]|ERROR|METHOD:Method1|error_message|<stacktrace>
[2016-06-20 09:10:24]|DEBUG|METHOD:method x|debug_message
```

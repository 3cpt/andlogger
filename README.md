# AndLogger
A simple log library for C#.

[![Build Status](https://travis-ci.org/iamhandre/andlogger.svg?branch=master)](https://travis-ci.org/iamhandre/Andlogger)

# Under Development

- Json File implementations
- Unit tests

# How to use

- Install nuget: 
``` 
Install-Package AndLogger
``` 

- Instantiate: 
``` 
 ILog log = new Logger(Level.Info, *string.Empty);

 this.log.Debug("debug message");
 this.log.Error("error message", new Exception("exception.Error"));
 
```
* With empty string the path that will be used is where the application is running

# Output Sample
```
[2010-07-01 11:36:55.7776]|DEBUG|debug
[2010-07-02 11:36:55.7906]|DEBUG|debug|>>>TRACE>>>exception.debug>>>
[2010-07-03 11:36:55.7946]|INFO|info
[2010-07-04 11:36:55.7986]|WARNING|Warning
[2010-07-05 11:36:55.8036]|ERROR|Error
[2010-07-06 11:36:55.8076]|ERROR|Error|>>>TRACE>>>exception.Error>>>
[2010-07-07 11:36:55.8136]|DEBUG|debug
```

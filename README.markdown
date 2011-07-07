
Welcome to Cityindex Trading Api Csharp Framework on github
====================


CiApi Framework Quick Start
---------------------

The Binaries folder has the current version with the asscoiated source code in the Source folder.

The TradingApi.Client.Framework.dll has the CiApi singleton. Use this to login and access our trading services and streams.


Logging - example Log4Net
---------------------

The framework uses [common.logging ](http://commons.apache.org/logging/), the binaries folder contains all the required assemblies:
 
1. Add a reference to Common.Logging
2. Add a reference to Common.Logging.Log4Net
3. Add a reference to Log4Net
4. In your config add a config section, common logging adapter and log4net config. See example of this in the Source sample projects


Sample Application
---------------------
The Source has a sample application with example of how to reference and use the CiApi. The TradingApiBaseUri and LightstreamerUrl should point to our preproduction environment.

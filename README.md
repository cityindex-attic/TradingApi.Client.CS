# TradingApi.Client.CS

Cityindex trading API Csharp Framework

## Status

![Incomplete](http://labs.cityindex.com/wp-content/uploads/2012/01/lbl-incomplete.png)![Unsupported](http://labs.cityindex.com/wp-content/uploads/2012/01/lbl-unsupported.png)

This project has been retired and is no longer being supported by City Index Ltd.

* if you should choose to fork it outside of City Index, please let us know so we can link to your project

## Quick Start

The Binaries folder has the current version with the asscoiated source code in the Source folder.

The TradingApi.Client.Framework.dll has the CiApi singleton. Use this to login and access our trading services and streams.

## Logging - example Log4Net

The framework uses [common.logging ](http://commons.apache.org/logging/), the binaries folder contains all the required assemblies:
 
1. Add a reference to Common.Logging
2. Add a reference to Common.Logging.Log4Net
3. Add a reference to Log4Net
4. In your config add a config section, common logging adapter and log4net config. See example of this in the Source sample projects


## Sample Application

The Source has a sample application with example of how to reference and use the CiApi. The TradingApiBaseUri and LightstreamerUrl should point to our preproduction environment.

## License

Copyright 2011 City Index Ltd.

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

  [http://www.apache.org/licenses/LICENSE-2.0](http://www.apache.org/licenses/LICENSE-2.0)

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.

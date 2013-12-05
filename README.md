RazorHtmlMinifier
=================

Easily minifies the html output of a razor c# asp.net mvc 4 application. 

Installation
============

Install-Package MinifierLibrary

Configuration
=============

Find the following configuration section on Views/web.config file,

```xml
<host factoryType="System.Web.Mvc.MvcWebRazorHostFactory, System.Web.Mvc, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" />
```

and replace with the following line,

```xml
<host factoryType="MinifierLibrary.Mvc.MinifierRazorHostFactory, MinifierLibrary"/>
```

see the example in the codebase https://github.com/msusur/RazorHtmlMinifier/blob/master/Sandbox/Views/Web.config#L12

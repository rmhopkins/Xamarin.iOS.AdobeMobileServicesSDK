using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("AdobeMobileLibrary.a", LinkTarget.Simulator | LinkTarget.ArmV7 | LinkTarget.ArmV7s, ForceLoad = true, Frameworks = "ExternalAccessory", LinkerFlags="-lsqlite3.0 -framework SystemConfiguration")]
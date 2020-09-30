# PH.Log4NetExtensions

Extensions for log4net

## Trace 

Enable Trace method in ILog.

```csharp

//simply trace
log.Trace("a message");

//trace with exception
log.Trace("a message with exception", new Exception("some exception"));

```

## NDC Disposable Scope

Push a scope in log4net NDC

```csharp

//write debug message with no NDC property
log.Debug("with no scope");

using (LogScope.Init("testing my scope"))
{
    //write a trace with NDC property set to "testing my scope"
    log.Trace("a message with scope");
}
log.Debug("with no scope2");

```

Push a TRACE scope in log4net NDC

```csharp

//write debug message with no NDC property
log.Debug("with no scope");

using (log.InitTraceLogScope("TRScope"))
{
    //write a trace with NDC property set to "TRScope" and a message set to "----> TRScope"

    //do code...

    //write a trace with NDC property set to "TRScope"
    log.Trace("a message with scope");

    //on disposing write a trace with NDC property set to "TRScope" and a message set to "<---- TRScope"
}

log.Debug("with no scope2");

```



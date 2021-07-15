# RichLogger

## English
It is a WPF control to allow to "log" information for the user. It can copy/paste the text of the log.  
There is a text color system, depending on the type of log, defined by the `StatusLog` enum:
```csharp
public enum StatusLog
{
    Error,   // Red
    Information,  // Black
    Warn,    // Orange
    InfoGreen  // Green
}
```

### Use
In the page/view, add the control:  
```xml
	<customcontrol:LoggerControl AllLogs="{Binding Logs, Mode=OneWay}"
				Margin="10" />
```  
At the code behind, you must have a property :  

```csharp
public ObservableCollection<LogInfo> Logs
{
    get { return _logs; }
    set
    {
        _logs = value;
        OnNotifyPropertyChanged();
    }
}
private ObservableCollection<LogInfo> _logs;
```  
To add a log line, see below.  

## Français
C'est un contrôle WPF pour permettre de "logger" des informations pour l'utilisateur. Il peut copier/coller le texte du log.  
Il y a un système de couleur du texte, en fonction du type de log, définie par l'enum `StatusLog` :

```csharp
public enum StatusLog
{
    Error,   // Rouge
    Information,  // noir
    Warn,    // Orange
    InfoGreen  // Vert
}
```

### Utilisation
Dans la page/vue, ajouter le contrôle : 
```xml
	<customcontrol:LoggerControl AllLogs="{Binding Logs, Mode=OneWay}"
				Margin="10" />
```  
Au niveau du code behind, il faut avoir une propriété :

```csharp
public ObservableCollection<LogInfo> Logs
{
    get { return _logs; }
    set
    {
        _logs = value;
        OnNotifyPropertyChanged();
    }
}
private ObservableCollection<LogInfo> _logs;
```  
Pour ajouter une ligne de log, faire :  
```csharp
public void LogInformation(LogInfo message)
{
    if (App.Current.Dispatcher.CheckAccess())
    {
        Logs.Add(message);
    }
    else
    {
        App.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
        {
            Logs.Add(message);
        }));
    }
}

public void LogInformation(string message)
{
    if (App.Current.Dispatcher.CheckAccess())
    {
        Logs.Add(new LogInfo(StatusLog.Information, message));
    }
    else
    {
        App.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
        {
            Logs.Add(new LogInfo(StatusLog.Information, message));
        }));
    }
}

public void LogError(string message)
{
    if (App.Current.Dispatcher.CheckAccess())
    {
        Logs.Add(new LogInfo(StatusLog.Error, message));
    }
    else
    {
        App.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
        {
            Logs.Add(new LogInfo(StatusLog.Error, message));
        }));
    }
}

public void LogWarning(string message)
{
    if (App.Current.Dispatcher.CheckAccess())
    {
        Logs.Add(new LogInfo(StatusLog.Warn, message));
    }
    else
    {
        App.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
        {
            Logs.Add(new LogInfo(StatusLog.Warn, message));
        }));
    }
}

public void LogSuccess(string message)
{
    if (App.Current.Dispatcher.CheckAccess())
    {
        Logs.Add(new LogInfo(StatusLog.InfoGreen, message));
    }
    else
    {
        App.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
        {
            Logs.Add(new LogInfo(StatusLog.InfoGreen, message));
        }));
    }
}
```
